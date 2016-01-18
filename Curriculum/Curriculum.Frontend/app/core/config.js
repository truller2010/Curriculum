define(function configModule() {
    "use strict";

    var config = {};
    
    config.BASE_URL = "http://localhost:1973";
    config.BASE_FRONT_URL = ".";
    config.CLIENT_ID = 'KotikoBlog-web';
    config.CLIENT_SECRET = 'Kotiko@Blog';

    config.PAGE_SIZE_LOWER = 3;
    config.PAGE_SIZES_LOWER = [ 1, 2, 3, 4, 5 ];
    config.PAGE_SIZE = 10;
    config.PAGE_SIZES = [ 1, 5, 10, 20, 50, 100 ];
	config.NUM_MAX_PAGES=5;
	config.DEFAULT_CACHE_TIMEOUT = 300000; // 5 min
	config.SEARCH_FILTER_TIMEOUT = 2000;
	config.INTERVALO_ALERTAS = 300000;// 5 min

    return config;
});