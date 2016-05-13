define(function configModule() {
    "use strict";

    var config = {};

    //>>excludeStart("build", true);
    // configuracion de desarrollo
    config.BASE_URL = "http://localhost:8567";
    config.BASE_FRONT_URL = ".";
    config.CLIENT_ID = "hipicapp-web";
    config.CLIENT_SECRET = "hipicapp@2016~~";
    //>>excludeEnd("build");

    //>>excludeStart("default", pragmas.default);
    /*
    //>>excludeEnd("default");
	// configuracion para desarrollo local
	config.BASE_URL = "http://localhost:8567";
    config.BASE_FRONT_URL = ".";
    config.CLIENT_ID = 'snirh-web';
    config.CLIENT_SECRET = 'abc@123';
	//>>excludeStart("default", pragmas.default);
	*/
    //>>excludeEnd("default");

    //>>excludeStart("pre", pragmas.pre);
    /*
    //>>excludeEnd("pre");
	// configuracion para desarrollo pre
	config.BASE_URL = "http://201.131.221.172:8567";
    config.BASE_FRONT_URL = ".";
    config.CLIENT_ID = 'snirh-web';
    config.CLIENT_SECRET = 'abc@123';
	//>>excludeStart("pre", pragmas.pre);
	*/
    //>>excludeEnd("pre");

    //>>excludeStart("exp", pragmas.exp);
    /*
    //>>excludeEnd("exp");
	// configuracion para desarrollo exp
	config.BASE_URL = "http://201.131.221.173:8567";
    config.BASE_FRONT_URL = ".";
    config.CLIENT_ID = 'snirh-web';
    config.CLIENT_SECRET = 'abc@123';
	//>>excludeStart("exp", pragmas.exp);
	*/
    //>>excludeEnd("exp");

    config.PASSWORD_PATTERN = ".{6,}";
    config.PAGE_SIZE_LOWER = 3;
    config.PAGE_SIZES_LOWER = [
        1, 2, 3, 4, 5
    ];
    config.PAGE_SIZE = 10;
    config.PAGE_SIZES = [
        1, 5, 10, 20, 50, 100
    ];

    config.NUM_MAX_PAGES = 5;

    config.DEFAULT_CACHE_TIMEOUT = 300000; // 5 min

    config.SEARCH_FILTER_TIMEOUT = 2000;

    return config;
});