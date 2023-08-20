﻿(function (factory) {
  if (typeof define === 'function' && define.amd) { // AMD. Register as an anonymous module.
    define(['jquery'], factory);
  } else if (typeof exports === 'object') { // Node/CommonJS
    var jQuery = require('jquery');
    module.exports = factory(jQuery);
  } else { // Browser globals (zepto supported)
    factory(window.jQuery || window.Zepto || window.$); // Zepto supported on browsers as well
  }

}(function ($) {
  "use strict";
  $.fn.serializeFiles = function () {
    var obj = $(this);
    /* ADD FILE TO PARAM AJAX */
    var formData = new FormData();
    $.each($(obj).find("input[type='file']"), function (i, tag) {
      $.each($(tag)[0].files, function (i, file) {
        formData.append(tag.name, file);
      });
    });
    var params = $(obj).serializeArray();
    $.each(params, function (i, val) {
      formData.append(val.name, val.value);
    });
    return formData;
  };


  }));
