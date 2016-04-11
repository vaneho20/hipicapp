NCache-NHibernate Cache Provider Integration

	Instructions
		
		►	NCache provides a second level or process level cache for NHibernate by implementing NHibernate's 
			ICacheProvider and ICache interfaces. This enables NCache to be used as NHibernate second cache in 
			existing NHibernate application without any code change. All that’s needed is to change NHibernate 
			configuration file to plug-in NCache as cache provider and distributed caching can be used.
		
		►	To use the provider, NCache 4.4 or later must be installed. To try or purchase NCache, 
			please visit: http://www.alachisoft.com/ncache/
			
		►	NC-NHibernateCachingProvider NuGet package adds reference to
				1- Alachisoft.NCache.Integrations.NHibernate.Cache.dll
			Additionally, it adds the NCacheNHibernate configuration files to the project
				1- NCacheNHibernate.xml			
		
		►	The project must contain hibernate.cfg.xml prior to the package installation. The package modifies this
			configuration. Essentially it adds the "cache.provider_class" tag in the configuration. This option lets 
			the user specify NCache as 2nd level cache provider. The user needs to mention two classes which implement
			ICacheProvider and ICache interfaces respectively. This is how NHibernate knows how to call this 2nd level
			cache. It also enables NHibernate 2nd Level Caching and Query Caching by setting the cache.use_second_level_cache
			cache.use_query_cache respectively.
		
		►	The NCacheNHibernate.xml file contains tags for provider specific features. For basic function, the user needs to
			specify a name for a preconfigured cache in the "cache-name" field. By default, "mycache" is specified.
			
		►	NCache provider for NHibernate identifies each application by an application id that is later used to find the 
			appropriate configuration for that application from NCache configuration file for NHibernate "NCacheNHibernate.xml".
			This application id must be specified in application's configuration file (app.config/web.config). The package adds
			a default tag for this purpose, the user needs to modify it according to his/her need.
			
		►	Enabling the use of second level cache does not cache each class object by default. Instead classes needed to be 
			cached are to be marked cacheable in class mapping(.hbm.xml) file.
		
		►	For more information on tags and features, please visit: 
			http://www.alachisoft.com/resources/docs/ncache/help-4-3/module_1_6_4_1_2.html
		
		