NCache Session State Store Provider for NCache Open Source 4.4

	Instructions:
	
		►	The session state store provider is a custom SessionStateStoreProviderBase implementation for an ASP.NET application
			which utilizes NCache as the underlying caching solution. 
			
		►	To use the provider, NCache Open Source 4.4 or later must be installed. To download, install and use NCache Open Source,
			please visit: http://www.alachisoft.com/download.html
			
		►	NC-SesionStateStoreProvider NuGet package adds reference to
				1- NCacheSessionStateStoreProvider.dll
				2- SessionStateManagement.dll
				
		►	The NuGet package modifies the app.config file of the project. Specifically, it add an assembly reference tag for
			the provider, defines a CustomProvider tag named NCacheSessionProvider, and sets the default ASP.Net provider to it.
			For reference on different tags of the provider,
			please visit: http://www.alachisoft.com/resources/docs/ncache/help-4-3/module_1_6_3_1_2.html
			
		►	For basic caching, set up a cache through NCache and change value of the field "cacheName" in the custom provider tag
			in app.config to the name of the newly configured cache. By default, "mycache" is specified.
			
		►	It is required to generate ASP.NET session IDs in the same manner on all nodes. You can use the genmackeys utility
			available with NCache installation to generate the keys. The package adds a default tag for this purpose. 
