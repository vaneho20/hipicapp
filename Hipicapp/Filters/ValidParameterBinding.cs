using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;

namespace Hipicapp.Filters
{
    public class ValidParameterBinding : HttpParameterBinding
    {
        private HttpParameterBinding _defaultFormatterBinding;

        public ValidParameterBinding(HttpParameterDescriptor parameter)
            : base(parameter)
        {
            _defaultFormatterBinding = new FromBodyAttribute().GetBinding(parameter);
        }

        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider,
            HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            Task task = null;
            if (actionContext.Request.Method == HttpMethod.Post || actionContext.Request.Method == HttpMethod.Put || actionContext.Request.Method == HttpMethod.Delete)
            {
                task = _defaultFormatterBinding.ExecuteBindingAsync(metadataProvider, actionContext, cancellationToken);
            }
            return task.ContinueWith((tsk) =>
            {
                object currentBoundValue = this.GetValue(actionContext);

                if (actionContext.Request.Method == HttpMethod.Post || actionContext.Request.Method == HttpMethod.Put || actionContext.Request.Method == HttpMethod.Delete)
                {
                    if (currentBoundValue != null)
                    {
                        NHibernate.Validator.Cfg.Environment.SharedEngineProvider.GetEngine().Validate(currentBoundValue, new object[0]).ToList().ForEach(y =>
                        {
                            actionContext.ModelState.AddModelError(y.PropertyName, y.Message);
                        });
                    }
                }
            });
        }
    }
}