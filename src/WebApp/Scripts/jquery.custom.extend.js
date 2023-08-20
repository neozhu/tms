﻿moment.suppressDeprecationWarnings = true;
jQuery.extend({
  dateNow: function () {
    //console.log(new Date());
    return moment(new Date()).format('YYYY-MM-DD');
  },
  Now: function () {
    //console.log(new Date());
    return moment(new Date()).format('YYYY-MM-DD HH:mm:ss');
  },
  isDateVaild: function (value) {

    var regex = '^\d{4}-\d{2}-\d{2}';
    return value.match(regex);
  },
  isDateTimeVaild: function (value) {

    var regex = new RegExp("/(\d{4})-(\d{2})-(\d{2}) (\d{2}):(\d{2}):(\d{2})/");
    return regex.test(value);
  },
  getUserName: function () {
    return $('#currentuser').val();
  },
  uuid: function () {
    var d = new Date().getTime();
    var guid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
      var r = (d + Math.random() * 16) % 16 | 0;
      d = Math.floor(d / 16);
      return (c === 'x' ? r : (r & 0x7 | 0x8)).toString(16);
    });
    return guid;
  },
  istrue: function (value) {
    if (typeof (value) === 'string') {
      value = value.trim().toLowerCase();
    }
    switch (true) {
      case true === value:
      case "true" === value:
      case value > 0:
      case "ok" === value:
      case "yes" === value:
      case "是" === value:
        return true;
      case "on" === value:
      case false === value:
      case "cancel" === value:
      case "null" === value:
      case "" === value:
      case "否" === value:
      case value <= 0:
        return false;
      default:
        return false;
    }
  },
  postDownload: function (url, formData, onCompleted) {
    return new Promise(function (resolve, reject) {
      var filename = '';
      var xhr = new XMLHttpRequest();
      xhr.open('POST', url, true);
      xhr.responseType = 'blob';
      xhr.overrideMimeType("application/vnd.ms-excel");
      xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200) {
          //console.log(xhr.getResponseHeader('Content-Disposition'));
          var header = xhr.getResponseHeader('Content-Disposition');
          if (header) {
            var regx = /filename[^;=\n]*=((['\"]).*?\2|[^;\n]*)/g;
            filename = decodeURIComponent(regx.exec(header)[1]);
            //console.log(regx.exec(header));
          }
          var blob = xhr.response;
          saveAs(blob, filename);
          if (onCompleted !== undefined)
            onCompleted(filename);

        } else if (xhr.status === 500) {
          reject({
            status: this.status,
            statusText: this.statusText
          });
        }
      };
      xhr.onerror = function () {
        reject({
          status: this.status,
          statusText: this.statusText
        });
      };
      xhr.onload = function (e) {
        resolve({
          filename: filename,
          status: this.status,
          statusText: xhr.statusText
        });
      };
      //var formData = new FormData();
      //formData.append('filterRules', filterRules);
      //formData.append('sort', 'Id');
      //formData.append('order', 'asc');
      xhr.send(formData);
    });
  }
});

