using FluentNHibernate;
using NHibernate.Caches.SysCache;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Spring.Data.NHibernate;
using System.Reflection;

namespace Hipica.Repository.Fluent
{
    public class FluentNhibernateLocalSessionFactoryObject : LocalSessionFactoryObject
    {
        /// <summary>
        /// Sets the assemblies to load that contain fluent nhibernate mappings.
        /// </summary>
        /// <value>The mapping assemblies.</value>
        public string[] FluentNhibernateMappingAssemblies
        {
            get;
            set;
        }

        protected override void PostProcessConfiguration(Configuration config)
        {
            base.PostProcessConfiguration(config);
            if (FluentNhibernateMappingAssemblies != null)
            {
                foreach (string assemblyName in FluentNhibernateMappingAssemblies)
                {
                    config.AddMappingsFromAssembly(Assembly.Load(assemblyName));
                }
            }

            SchemaUpdate su = new SchemaUpdate(config);
            su.Execute(true, false);

            // Envers configuration
            //config.Properties.Add("nhibernate.envers.global_with_modified_flag", "true"); //log property data for revisions
            //config.IntegrateWithEnvers(new AttributeConfiguration());
            //config.SetListener(ListenerType.PreUpdate, new ValidatePreUpdateEventListener());
            //config.SetListener(ListenerType.PreInsert, new AutoincrementalListener());
            /*config.SetListener(ListenerType.PreUpdate, new UnneAuditEventListener());
            config.SetListener(ListenerType.PreDelete, new UnneAuditEventListener());
            config.SetListener(ListenerType.PreCollectionRecreate, new UnneAuditEventListener());
            config.SetListener(ListenerType.PreCollectionUpdate, new UnneAuditEventListener());
            config.SetListener(ListenerType.PreCollectionRemove, new UnneAuditEventListener());*/
            config.Cache(c =>
            {
                c.UseMinimalPuts = true;
                c.UseQueryCache = true;
                c.Provider<SysCacheProvider>();
            });
            NHVConfiguration.Initialize(config);
        }
    }
}