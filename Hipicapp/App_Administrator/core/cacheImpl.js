/* global amplify: false, define: false */
/**
 * Evictable amplify cache
 */
define(function cacheImpl() {
    "use strict";

    return function newCache() {
        var cachedKeys = [];

        function evict() {
            var i = 0, imax = cachedKeys.length;

            for (i = 0; i < imax; i = i + 1) {
                amplify.store(cachedKeys[i], null);
            }

            cachedKeys = [];
        }

        function cache(resource, settings, ajaxSettings, ampXHR) {
            /* jshint nomen:false, camelcase: false */
            var cacheKey =
                amplify.request_original.cache._key(settings.resourceId, ajaxSettings.url,
                    ajaxSettings.data), cached = amplify.store(cacheKey), success = ampXHR.success;

            if (cached) {
                ajaxSettings.success(cached);
                return false;
            }

            ampXHR.success = function ampXHRSuccess(data) {
                amplify.store(cacheKey, data, {
                    expires: resource.cache.expires
                });

                cachedKeys.push(cacheKey);

                success.apply(this, arguments);
            };
        }

        cache.evict = evict;

        return cache;
    };
});