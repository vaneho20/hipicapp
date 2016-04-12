using NHibernate.Validator.Engine;

namespace Hipicapp.Repository.Fluent
{
    public class CustomSharedEngineProvider : ISharedEngineProvider
    {
        private ValidatorEngine ve;

        public CustomSharedEngineProvider(ValidatorEngine engine)
        {
            this.ve = engine;
        }

        public ValidatorEngine GetEngine()
        {
            return ve;
        }
    }
}