/* global _: false, define: false, ko: false */
define(["jquery","core/util/csrfUtils", "core/exceptionHandler", "core/util/validationUtils"
], function fileUploadBinding($, csrfUtils, exceptionHandler, validationUtils) {
    "use strict";

    var binding = {};

    function init(element, valueAccessor) {
        var broker = valueAccessor().broker,
            url = valueAccessor().url,
            idBrand = valueAccessor().idBrand,
            idJobFile = valueAccessor().idJobFile,
            viewModel = valueAccessor().viewModel,
            $progress,
            success = valueAccessor().success;

        function done(event, data) {
            broker.evictCache();
            if (success)
                success();
            $progress.hide();
        }

        function fail(event, data) {

            if(viewModel)
                viewModel.app.showMessage(data._response.jqXHR.responseJSON.m_StringValue, viewModel.i18n.t('app:ERROR_MESSAGE_BOX_TITLE'), [
                                           viewModel.i18n.t('app:CLOSE_BUTTON_TITLE') ]);
            $progress.hide();
        }

        function processfail() {
           
        }

        function progressall(event, data) {
            if (!$progress) {
                $progress = $(valueAccessor().progress).find(".bar");
            }

            $progress.show();

            if ($progress.length) {
                $progress.css('width', parseInt(data.loaded / data.total * 100, 10) + '%');
            }
        }

        setTimeout(function doAfterBinding() {
            $(element).fileupload({
                url: url,
                acceptFileTypes: validationUtils.ACCEPT_FILE_TYPES,
                //maxFileSize: validationUtils.MAX_FILE_SIZE,
                formData: { idBrand: idBrand, idJobFile: idJobFile },
                processfail: processfail,
                progressall: progressall,
                done: done,
                fail: fail,
                beforeSend: function (event, files, index, xhr, handler, callBack) {
                   // files.data.append("idBrand", valueAccessor().idBrand());
                    csrfUtils.appendXsrfToXhr(event);
                }
            });

            

        }, 0);

        
    }

    binding.init = init;

    return binding;
});