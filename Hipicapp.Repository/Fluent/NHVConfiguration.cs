using NHibernate.Cfg;
using NHibernate.Validator.Cfg;
using NHibernate.Validator.Engine;
using System;
using System.Collections.Generic;

namespace Hipicapp.Repository.Fluent
{
    public class NHVConfiguration : INHVConfiguration
    {
        private readonly IEnumerable<Type> _entityTypeInspectors = new List<Type>();

        private readonly IList<MappingConfiguration> _mappings = new List<MappingConfiguration>();

        private readonly IDictionary<string, string> _properties =
            new Dictionary<string, string>
            {
                { NHibernate.Validator.Cfg.Environment.ApplyToDDL, "true" },
                { NHibernate.Validator.Cfg.Environment.AutoregisterListeners, "true" },
                { NHibernate.Validator.Cfg.Environment.BaseNameOfMessageResource, "Resources.ValidationMessages, Resources" },
                //{ NHibernate.Validator.Cfg.Environment.MappingLoaderClass, "Hipicapp.Model" },
                { NHibernate.Validator.Cfg.Environment.MessageInterpolatorClass, "Hipicapp.Repository.Fluent.ConventionMessageInterpolator, Hipicapp.Repository" }
            };

        string INHVConfiguration.SharedEngineProviderClass
        {
            get { throw new InvalidOperationException("This is only valid in an app config"); }
        }

        public IDictionary<string, string> Properties
        {
            get { return _properties; }
        }

        IList<MappingConfiguration> INHVConfiguration.Mappings
        {
            get { return _mappings; }
        }

        IEnumerable<Type> INHVConfiguration.EntityTypeInspectors
        {
            get { return _entityTypeInspectors; }
        }

        public static void Initialize(Configuration config)
        {
            var engine = new ValidatorEngine();
            var validationConfig = new NHVConfiguration();
            engine.Configure(validationConfig);

            NHibernate.Validator.Cfg.Environment.SharedEngineProvider = new CustomSharedEngineProvider(engine);

            ValidatorInitializer.Initialize(config, engine);
        }
    }
}