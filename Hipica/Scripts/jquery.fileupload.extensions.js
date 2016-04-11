/*
 * jQuery File Upload Plugin 5.32.3
 * https://github.com/blueimp/jQuery-File-Upload
 *
 * Copyright 2010, Sebastian Tschan
 * https://blueimp.net
 *
 * Licensed under the MIT license:
 * http://www.opensource.org/licenses/MIT
 */

/*jslint nomen: true, unparam: true, regexp: true */
/*global define, window, document, location, File, Blob, FormData */

(function ($) {
    $.widget('blueimp.fileupload', $.blueimp.fileupload, {
        options: {
            authenticityTokenName: 'request_authenticity_token',
            destroy: function (e, data) {
                // jQuery Widget Factory uses "namespace-widgetname" since version 1.10.0:
                var fu = $(this).data('blueimp-fileupload') || $(this).data('fileupload');
                data.url = data.url &&
                    fu._addUrlParams(data.url, fu._getAuthenticityToken());
                $.blueimp.fileupload.prototype
                    .options.destroy.call(this, e, data);
            }
        },

        _addUrlParams: function (url, data) {
            return url + (/\?/.test(url) ? '&' : '?') + $.param(data);
        },

        _getAuthenticityToken: function () {
            var name = this.options.authenticityTokenName,
                parts = $.cookie(name).split('|'),
                obj = {};
            obj[name] = parts[0];
            return obj;
        }
    });
}(jQuery));