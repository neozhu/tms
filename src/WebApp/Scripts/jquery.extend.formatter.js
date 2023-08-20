//-------账号类型---------//
var accounttypefiltersource = [{ value: '', text: 'All'}];
var accounttypedatasource = [];
accounttypefiltersource.push({ value: '0',text:'公司'  });
accounttypedatasource.push({ value: '0',text:'公司'  });
accounttypefiltersource.push({ value: '1',text:'供应商'  });
accounttypedatasource.push({ value: '1',text:'供应商'  });
accounttypefiltersource.push({ value: '2',text:'客户'  });
accounttypedatasource.push({ value: '2',text:'客户'  });
accounttypefiltersource.push({ value: '3',text:'外协单位'  });
accounttypedatasource.push({ value: '3',text:'外协单位'  });
//for datagrid AccountType field  formatter
function accounttypeformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = accounttypedatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = accounttypedatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   AccountType  field filter 
$.extend($.fn.datagrid.defaults.filters, {
accounttypefilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: accounttypefiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   AccountType   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
accounttypeeditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: accounttypedatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------报表状态---------//
var bstatusfiltersource = [{ value: '', text: 'All'}];
var bstatusdatasource = [];
bstatusfiltersource.push({ value: '已确认',text:'已确认'  });
bstatusdatasource.push({ value: '已确认',text:'已确认'  });
bstatusfiltersource.push({ value: '待确认',text:'待确认'  });
bstatusdatasource.push({ value: '待确认',text:'待确认'  });
//for datagrid bstatus field  formatter
function bstatusformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = bstatusdatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = bstatusdatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   bstatus  field filter 
$.extend($.fn.datagrid.defaults.filters, {
bstatusfilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: bstatusfiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   bstatus   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
bstatuseditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: bstatusdatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------计费单位---------//
var caltypefiltersource = [{ value: '', text: 'All'}];
var caltypedatasource = [];
caltypefiltersource.push({ value: '1',text:'吨'  });
caltypedatasource.push({ value: '1',text:'吨'  });
caltypefiltersource.push({ value: '2',text:'立方'  });
caltypedatasource.push({ value: '2',text:'立方'  });
caltypefiltersource.push({ value: '3',text:'立方/吨'  });
caltypedatasource.push({ value: '3',text:'立方/吨'  });
//for datagrid caltype field  formatter
function caltypeformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = caltypedatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = caltypedatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   caltype  field filter 
$.extend($.fn.datagrid.defaults.filters, {
caltypefilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: caltypefiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   caltype   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
caltypeeditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: caltypedatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------车辆类型---------//
var cartypefiltersource = [{ value: '', text: 'All'}];
var cartypedatasource = [];
cartypefiltersource.push({ value: '厢式车',text:'厢式车'  });
cartypedatasource.push({ value: '厢式车',text:'厢式车'  });
cartypefiltersource.push({ value: '平板车',text:'平板车'  });
cartypedatasource.push({ value: '平板车',text:'平板车'  });
cartypefiltersource.push({ value: '牵引车',text:'牵引车'  });
cartypedatasource.push({ value: '牵引车',text:'牵引车'  });
cartypefiltersource.push({ value: '轿车',text:'轿车'  });
cartypedatasource.push({ value: '轿车',text:'轿车'  });
cartypefiltersource.push({ value: '面包车',text:'面包车'  });
cartypedatasource.push({ value: '面包车',text:'面包车'  });
cartypefiltersource.push({ value: '飞翼车',text:'飞翼车'  });
cartypedatasource.push({ value: '飞翼车',text:'飞翼车'  });
cartypefiltersource.push({ value: '高栏车',text:'高栏车'  });
cartypedatasource.push({ value: '高栏车',text:'高栏车'  });
//for datagrid cartype field  formatter
function cartypeformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = cartypedatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = cartypedatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   cartype  field filter 
$.extend($.fn.datagrid.defaults.filters, {
cartypefilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: cartypefiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   cartype   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
cartypeeditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: cartypedatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------搬运说明---------//
var costnote3filtersource = [{ value: '', text: 'All'}];
var costnote3datasource = [];
costnote3filtersource.push({ value: '就地卸货',text:'就地卸货'  });
costnote3datasource.push({ value: '就地卸货',text:'就地卸货'  });
costnote3filtersource.push({ value: '平移',text:'平移'  });
costnote3datasource.push({ value: '平移',text:'平移'  });
costnote3filtersource.push({ value: '楼梯上楼',text:'楼梯上楼'  });
costnote3datasource.push({ value: '楼梯上楼',text:'楼梯上楼'  });
costnote3filtersource.push({ value: '电梯上楼',text:'电梯上楼'  });
costnote3datasource.push({ value: '电梯上楼',text:'电梯上楼'  });
costnote3filtersource.push({ value: '电梯上楼+平移',text:'电梯上楼+平移'  });
costnote3datasource.push({ value: '电梯上楼+平移',text:'电梯上楼+平移'  });
//for datagrid costnote3 field  formatter
function costnote3formatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = costnote3datasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = costnote3datasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   costnote3  field filter 
$.extend($.fn.datagrid.defaults.filters, {
costnote3filter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: costnote3filtersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   costnote3   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
costnote3editor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: costnote3datasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------启用状态---------//
var enablefiltersource = [{ value: '', text: 'All'}];
var enabledatasource = [];
enablefiltersource.push({ value: '1',text:'启用'  });
enabledatasource.push({ value: '1',text:'启用'  });
enablefiltersource.push({ value: '2',text:'禁用'  });
enabledatasource.push({ value: '2',text:'禁用'  });
//for datagrid enable field  formatter
function enableformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = enabledatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = enabledatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   enable  field filter 
$.extend($.fn.datagrid.defaults.filters, {
enablefilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: enablefiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   enable   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
enableeditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: enabledatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------文件类型---------//
var filetypefiltersource = [{ value: '', text: 'All'}];
var filetypedatasource = [];
filetypefiltersource.push({ value: '0',text:'txt'  });
filetypedatasource.push({ value: '0',text:'txt'  });
filetypefiltersource.push({ value: '1',text:'xls'  });
filetypedatasource.push({ value: '1',text:'xls'  });
filetypefiltersource.push({ value: '10',text:'docx'  });
filetypedatasource.push({ value: '10',text:'docx'  });
filetypefiltersource.push({ value: '11',text:'py'  });
filetypedatasource.push({ value: '11',text:'py'  });
filetypefiltersource.push({ value: '12',text:'c'  });
filetypedatasource.push({ value: '12',text:'c'  });
filetypefiltersource.push({ value: '13',text:'java'  });
filetypedatasource.push({ value: '13',text:'java'  });
filetypefiltersource.push({ value: '2',text:'pdf'  });
filetypedatasource.push({ value: '2',text:'pdf'  });
filetypefiltersource.push({ value: '3',text:'xlsx'  });
filetypedatasource.push({ value: '3',text:'xlsx'  });
filetypefiltersource.push({ value: '4',text:'json'  });
filetypedatasource.push({ value: '4',text:'json'  });
filetypefiltersource.push({ value: '5',text:'js'  });
filetypedatasource.push({ value: '5',text:'js'  });
filetypefiltersource.push({ value: '6',text:'html'  });
filetypedatasource.push({ value: '6',text:'html'  });
filetypefiltersource.push({ value: '7',text:'xml'  });
filetypedatasource.push({ value: '7',text:'xml'  });
filetypefiltersource.push({ value: '8',text:'cs'  });
filetypedatasource.push({ value: '8',text:'cs'  });
filetypefiltersource.push({ value: '9',text:'doc'  });
filetypedatasource.push({ value: '9',text:'doc'  });
//for datagrid FileType field  formatter
function filetypeformatter(value, row, index) { 
     let multiple = true; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = filetypedatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = filetypedatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   FileType  field filter 
$.extend($.fn.datagrid.defaults.filters, {
filetypefilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: filetypefiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   FileType   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
filetypeeditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: filetypedatasource,
         multiple: true,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------楼层---------//
var floorfiltersource = [{ value: '', text: 'All'}];
var floordatasource = [];
floorfiltersource.push({ value: '0',text:'电梯'  });
floordatasource.push({ value: '0',text:'电梯'  });
floorfiltersource.push({ value: '1',text:'1楼'  });
floordatasource.push({ value: '1',text:'1楼'  });
floorfiltersource.push({ value: '2',text:'2楼'  });
floordatasource.push({ value: '2',text:'2楼'  });
floorfiltersource.push({ value: '3',text:'3楼'  });
floordatasource.push({ value: '3',text:'3楼'  });
floorfiltersource.push({ value: '4',text:'4楼'  });
floordatasource.push({ value: '4',text:'4楼'  });
floorfiltersource.push({ value: '5',text:'5楼'  });
floordatasource.push({ value: '5',text:'5楼'  });
floorfiltersource.push({ value: '6',text:'6楼'  });
floordatasource.push({ value: '6',text:'6楼'  });
//for datagrid floor field  formatter
function floorformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = floordatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = floordatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   floor  field filter 
$.extend($.fn.datagrid.defaults.filters, {
floorfilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: floorfiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   floor   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
flooreditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: floordatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------禁用标志---------//
var isdisabledfiltersource = [{ value: '', text: 'All'}];
var isdisableddatasource = [];
isdisabledfiltersource.push({ value: '0',text:'未禁用'  });
isdisableddatasource.push({ value: '0',text:'未禁用'  });
isdisabledfiltersource.push({ value: '1',text:'已禁用'  });
isdisableddatasource.push({ value: '1',text:'已禁用'  });
//for datagrid IsDisabled field  formatter
function isdisabledformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = isdisableddatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = isdisableddatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   IsDisabled  field filter 
$.extend($.fn.datagrid.defaults.filters, {
isdisabledfilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: isdisabledfiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   IsDisabled   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
isdisablededitor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: isdisableddatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------启用标志---------//
var isenabledfiltersource = [{ value: '', text: 'All'}];
var isenableddatasource = [];
isenabledfiltersource.push({ value: '0',text:'未启用'  });
isenableddatasource.push({ value: '0',text:'未启用'  });
isenabledfiltersource.push({ value: '1',text:'已启用'  });
isenableddatasource.push({ value: '1',text:'已启用'  });
//for datagrid IsEnabled field  formatter
function isenabledformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = isenableddatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = isenableddatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   IsEnabled  field filter 
$.extend($.fn.datagrid.defaults.filters, {
isenabledfilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: isenabledfiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   IsEnabled   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
isenablededitor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: isenableddatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------已读标志---------//
var isnewfiltersource = [{ value: '', text: 'All'}];
var isnewdatasource = [];
isnewfiltersource.push({ value: '0',text:'未读'  });
isnewdatasource.push({ value: '0',text:'未读'  });
isnewfiltersource.push({ value: '1',text:'已读'  });
isnewdatasource.push({ value: '1',text:'已读'  });
//for datagrid IsNew field  formatter
function isnewformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = isnewdatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = isnewdatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   IsNew  field filter 
$.extend($.fn.datagrid.defaults.filters, {
isnewfilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: isnewfiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   IsNew   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
isneweditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: isnewdatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------通知标志---------//
var isnoticefiltersource = [{ value: '', text: 'All'}];
var isnoticedatasource = [];
isnoticefiltersource.push({ value: '0',text:'未发'  });
isnoticedatasource.push({ value: '0',text:'未发'  });
isnoticefiltersource.push({ value: '1',text:'已发'  });
isnoticedatasource.push({ value: '1',text:'已发'  });
//for datagrid IsNotice field  formatter
function isnoticeformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = isnoticedatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = isnoticedatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   IsNotice  field filter 
$.extend($.fn.datagrid.defaults.filters, {
isnoticefilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: isnoticefiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   IsNotice   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
isnoticeeditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: isnoticedatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------NlogLevel---------//
var levelfiltersource = [{ value: '', text: 'All'}];
var leveldatasource = [];
levelfiltersource.push({ value: 'Debug',text:'Debug'  });
leveldatasource.push({ value: 'Debug',text:'Debug'  });
levelfiltersource.push({ value: 'Error',text:'Error'  });
leveldatasource.push({ value: 'Error',text:'Error'  });
levelfiltersource.push({ value: 'Fatal',text:'Fatal'  });
leveldatasource.push({ value: 'Fatal',text:'Fatal'  });
levelfiltersource.push({ value: 'Info',text:'Info'  });
leveldatasource.push({ value: 'Info',text:'Info'  });
levelfiltersource.push({ value: 'Trace',text:'Trace'  });
leveldatasource.push({ value: 'Trace',text:'Trace'  });
levelfiltersource.push({ value: 'Warn',text:'Warn'  });
leveldatasource.push({ value: 'Warn',text:'Warn'  });
//for datagrid Level field  formatter
function levelformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = leveldatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = leveldatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   Level  field filter 
$.extend($.fn.datagrid.defaults.filters, {
levelfilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: levelfiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   Level   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
leveleditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: leveldatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------日志分组---------//
var messagegroupfiltersource = [{ value: '', text: 'All'}];
var messagegroupdatasource = [];
messagegroupfiltersource.push({ value: '0',text:'系统操作'  });
messagegroupdatasource.push({ value: '0',text:'系统操作'  });
messagegroupfiltersource.push({ value: '1',text:'业务操作'  });
messagegroupdatasource.push({ value: '1',text:'业务操作'  });
messagegroupfiltersource.push({ value: '2',text:'接口操作'  });
messagegroupdatasource.push({ value: '2',text:'接口操作'  });
//for datagrid MessageGroup field  formatter
function messagegroupformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = messagegroupdatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = messagegroupdatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   MessageGroup  field filter 
$.extend($.fn.datagrid.defaults.filters, {
messagegroupfilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: messagegroupfiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   MessageGroup   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
messagegroupeditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: messagegroupdatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------日志类型---------//
var messagetypefiltersource = [{ value: '', text: 'All'}];
var messagetypedatasource = [];
messagetypefiltersource.push({ value: '0',text:'Information'  });
messagetypedatasource.push({ value: '0',text:'Information'  });
messagetypefiltersource.push({ value: '1',text:'Error'  });
messagetypedatasource.push({ value: '1',text:'Error'  });
messagetypefiltersource.push({ value: '2',text:'Alert'  });
messagetypedatasource.push({ value: '2',text:'Alert'  });
//for datagrid MessageType field  formatter
function messagetypeformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = messagetypedatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = messagetypedatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   MessageType  field filter 
$.extend($.fn.datagrid.defaults.filters, {
messagetypefilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: messagetypefiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   MessageType   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
messagetypeeditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: messagetypedatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------待派车---------//
var orderstatusfiltersource = [{ value: '', text: 'All'}];
var orderstatusdatasource = [];
orderstatusfiltersource.push({ value: '100',text:'等待派车'  });
orderstatusdatasource.push({ value: '100',text:'等待派车'  });
orderstatusfiltersource.push({ value: '110',text:'已派车'  });
orderstatusdatasource.push({ value: '110',text:'已派车'  });
orderstatusfiltersource.push({ value: '120',text:'在途'  });
orderstatusdatasource.push({ value: '120',text:'在途'  });
orderstatusfiltersource.push({ value: '130',text:'已送达'  });
orderstatusdatasource.push({ value: '130',text:'已送达'  });
orderstatusfiltersource.push({ value: '140',text:'卸货完成'  });
orderstatusdatasource.push({ value: '140',text:'卸货完成'  });
orderstatusfiltersource.push({ value: '170',text:'派送完成'  });
orderstatusdatasource.push({ value: '170',text:'派送完成'  });
orderstatusfiltersource.push({ value: '190',text:'结案'  });
orderstatusdatasource.push({ value: '190',text:'结案'  });
//for datagrid orderstatus field  formatter
function orderstatusformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = orderstatusdatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = orderstatusdatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   orderstatus  field filter 
$.extend($.fn.datagrid.defaults.filters, {
orderstatusfilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: orderstatusfiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   orderstatus   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
orderstatuseditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: orderstatusdatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------订单状态---------//
var orderstatusfiltersource = [{ value: '', text: 'All'}];
var orderstatusdatasource = [];
orderstatusfiltersource.push({ value: '100',text:'等待派车'  });
orderstatusdatasource.push({ value: '100',text:'等待派车'  });
orderstatusfiltersource.push({ value: '110',text:'已派车'  });
orderstatusdatasource.push({ value: '110',text:'已派车'  });
orderstatusfiltersource.push({ value: '120',text:'在途'  });
orderstatusdatasource.push({ value: '120',text:'在途'  });
orderstatusfiltersource.push({ value: '130',text:'已送达'  });
orderstatusdatasource.push({ value: '130',text:'已送达'  });
orderstatusfiltersource.push({ value: '140',text:'卸货完成'  });
orderstatusdatasource.push({ value: '140',text:'卸货完成'  });
orderstatusfiltersource.push({ value: '170',text:'派送完成'  });
orderstatusdatasource.push({ value: '170',text:'派送完成'  });
orderstatusfiltersource.push({ value: '190',text:'结案'  });
orderstatusdatasource.push({ value: '190',text:'结案'  });
//for datagrid orderstatus field  formatter
function orderstatusformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = orderstatusdatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = orderstatusdatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   orderstatus  field filter 
$.extend($.fn.datagrid.defaults.filters, {
orderstatusfilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: orderstatusfiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   orderstatus   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
orderstatuseditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: orderstatusdatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------订单类型---------//
var ordertypefiltersource = [{ value: '', text: 'All'}];
var ordertypedatasource = [];
ordertypefiltersource.push({ value: '1',text:'正常'  });
ordertypedatasource.push({ value: '1',text:'正常'  });
ordertypefiltersource.push({ value: '2',text:'退货'  });
ordertypedatasource.push({ value: '2',text:'退货'  });
ordertypefiltersource.push({ value: '3',text:'回程货'  });
ordertypedatasource.push({ value: '3',text:'回程货'  });
//for datagrid ordertype field  formatter
function ordertypeformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = ordertypedatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = ordertypedatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   ordertype  field filter 
$.extend($.fn.datagrid.defaults.filters, {
ordertypefilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: ordertypefiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   ordertype   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
ordertypeeditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: ordertypedatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------其它附加服务---------//
var otherservicefiltersource = [{ value: '', text: 'All'}];
var otherservicedatasource = [];
otherservicefiltersource.push({ value: '其它服务',text:'其它服务'  });
otherservicedatasource.push({ value: '其它服务',text:'其它服务'  });
otherservicefiltersource.push({ value: '加工服务',text:'加工服务'  });
otherservicedatasource.push({ value: '加工服务',text:'加工服务'  });
//for datagrid otherservice field  formatter
function otherserviceformatter(value, row, index) { 
     let multiple = true; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = otherservicedatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = otherservicedatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   otherservice  field filter 
$.extend($.fn.datagrid.defaults.filters, {
otherservicefilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: otherservicefiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   otherservice   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
otherserviceeditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: otherservicedatasource,
         multiple: true,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------优先级---------//
var priorityfiltersource = [{ value: '', text: 'All'}];
var prioritydatasource = [];
priorityfiltersource.push({ value: '1',text:'高'  });
prioritydatasource.push({ value: '1',text:'高'  });
priorityfiltersource.push({ value: '2',text:'中'  });
prioritydatasource.push({ value: '2',text:'中'  });
priorityfiltersource.push({ value: '3',text:'低'  });
prioritydatasource.push({ value: '3',text:'低'  });
priorityfiltersource.push({ value: '4',text:'低级'  });
prioritydatasource.push({ value: '4',text:'低级'  });
//for datagrid Priority field  formatter
function priorityformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = prioritydatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = prioritydatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   Priority  field filter 
$.extend($.fn.datagrid.defaults.filters, {
priorityfilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: priorityfiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   Priority   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
priorityeditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: prioritydatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------NlogResolved---------//
var resolvedfiltersource = [{ value: '', text: 'All'}];
var resolveddatasource = [];
resolvedfiltersource.push({ value: 'false',text:'未处理'  });
resolveddatasource.push({ value: 'false',text:'未处理'  });
resolvedfiltersource.push({ value: 'true',text:'已处理'  });
resolveddatasource.push({ value: 'true',text:'已处理'  });
//for datagrid Resolved field  formatter
function resolvedformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = resolveddatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = resolveddatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   Resolved  field filter 
$.extend($.fn.datagrid.defaults.filters, {
resolvedfilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: resolvedfiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   Resolved   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
resolvededitor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: resolveddatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------服务名称---------//
var servicenamefiltersource = [{ value: '', text: 'All'}];
var servicenamedatasource = [];
servicenamefiltersource.push({ value: '就地卸货',text:'就地卸货'  });
servicenamedatasource.push({ value: '就地卸货',text:'就地卸货'  });
servicenamefiltersource.push({ value: '平移',text:'平移'  });
servicenamedatasource.push({ value: '平移',text:'平移'  });
servicenamefiltersource.push({ value: '楼梯上楼',text:'楼梯上楼'  });
servicenamedatasource.push({ value: '楼梯上楼',text:'楼梯上楼'  });
servicenamefiltersource.push({ value: '电梯上楼',text:'电梯上楼'  });
servicenamedatasource.push({ value: '电梯上楼',text:'电梯上楼'  });
servicenamefiltersource.push({ value: '电梯上楼+平移',text:'电梯上楼+平移'  });
servicenamedatasource.push({ value: '电梯上楼+平移',text:'电梯上楼+平移'  });
//for datagrid servicename field  formatter
function servicenameformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = servicenamedatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = servicenamedatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   servicename  field filter 
$.extend($.fn.datagrid.defaults.filters, {
servicenamefilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: servicenamefiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   servicename   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
servicenameeditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: servicenamedatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------派车单状态---------//
var shipstatusfiltersource = [{ value: '', text: 'All'}];
var shipstatusdatasource = [];
shipstatusfiltersource.push({ value: '110',text:'待发运'  });
shipstatusdatasource.push({ value: '110',text:'待发运'  });
shipstatusfiltersource.push({ value: '120',text:'在途'  });
shipstatusdatasource.push({ value: '120',text:'在途'  });
shipstatusfiltersource.push({ value: '130',text:'已送达'  });
shipstatusdatasource.push({ value: '130',text:'已送达'  });
shipstatusfiltersource.push({ value: '140',text:'卸货完成'  });
shipstatusdatasource.push({ value: '140',text:'卸货完成'  });
shipstatusfiltersource.push({ value: '150',text:'回程'  });
shipstatusdatasource.push({ value: '150',text:'回程'  });
shipstatusfiltersource.push({ value: '170',text:'完成'  });
shipstatusdatasource.push({ value: '170',text:'完成'  });
shipstatusfiltersource.push({ value: '190',text:'结案'  });
shipstatusdatasource.push({ value: '190',text:'结案'  });
//for datagrid shipstatus field  formatter
function shipstatusformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = shipstatusdatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = shipstatusdatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   shipstatus  field filter 
$.extend($.fn.datagrid.defaults.filters, {
shipstatusfilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: shipstatusfiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   shipstatus   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
shipstatuseditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: shipstatusdatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------运单状态---------//
var shipstatusfiltersource = [{ value: '', text: 'All'}];
var shipstatusdatasource = [];
shipstatusfiltersource.push({ value: '110',text:'待发运'  });
shipstatusdatasource.push({ value: '110',text:'待发运'  });
shipstatusfiltersource.push({ value: '120',text:'在途'  });
shipstatusdatasource.push({ value: '120',text:'在途'  });
shipstatusfiltersource.push({ value: '130',text:'已送达'  });
shipstatusdatasource.push({ value: '130',text:'已送达'  });
shipstatusfiltersource.push({ value: '140',text:'卸货完成'  });
shipstatusdatasource.push({ value: '140',text:'卸货完成'  });
shipstatusfiltersource.push({ value: '150',text:'回程'  });
shipstatusdatasource.push({ value: '150',text:'回程'  });
shipstatusfiltersource.push({ value: '170',text:'完成'  });
shipstatusdatasource.push({ value: '170',text:'完成'  });
shipstatusfiltersource.push({ value: '190',text:'结案'  });
shipstatusdatasource.push({ value: '190',text:'结案'  });
//for datagrid shipstatus field  formatter
function shipstatusformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = shipstatusdatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = shipstatusdatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   shipstatus  field filter 
$.extend($.fn.datagrid.defaults.filters, {
shipstatusfilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: shipstatusfiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   shipstatus   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
shipstatuseditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: shipstatusdatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------派车单类型---------//
var shiptypefiltersource = [{ value: '', text: 'All'}];
var shiptypedatasource = [];
shiptypefiltersource.push({ value: '1',text:'正常'  });
shiptypedatasource.push({ value: '1',text:'正常'  });
shiptypefiltersource.push({ value: '2',text:'加急'  });
shiptypedatasource.push({ value: '2',text:'加急'  });
shiptypefiltersource.push({ value: '3',text:'退货'  });
shiptypedatasource.push({ value: '3',text:'退货'  });
//for datagrid shiptype field  formatter
function shiptypeformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = shiptypedatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = shiptypedatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   shiptype  field filter 
$.extend($.fn.datagrid.defaults.filters, {
shiptypefilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: shiptypefiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   shiptype   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
shiptypeeditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: shiptypedatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------运输类型---------//
var shptypefiltersource = [{ value: '', text: 'All'}];
var shptypedatasource = [];
shptypefiltersource.push({ value: '1',text:'专车直送'  });
shptypedatasource.push({ value: '1',text:'专车直送'  });
shptypefiltersource.push({ value: '2',text:'零担'  });
shptypedatasource.push({ value: '2',text:'零担'  });
//for datagrid shptype field  formatter
function shptypeformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = shptypedatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = shptypedatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   shptype  field filter 
$.extend($.fn.datagrid.defaults.filters, {
shptypefilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: shptypefiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   shptype   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
shptypeeditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: shptypedatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------物料类型---------//
var skutypefiltersource = [{ value: '', text: 'All'}];
var skutypedatasource = [];
skutypefiltersource.push({ value: '洁具',text:'洁具'  });
skutypedatasource.push({ value: '洁具',text:'洁具'  });
skutypefiltersource.push({ value: '瓷砖',text:'瓷砖'  });
skutypedatasource.push({ value: '瓷砖',text:'瓷砖'  });
//for datagrid skutype field  formatter
function skutypeformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = skutypedatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = skutypedatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   skutype  field filter 
$.extend($.fn.datagrid.defaults.filters, {
skutypefilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: skutypefiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   skutype   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
skutypeeditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: skutypedatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------Test---------//
var statusfiltersource = [{ value: '', text: 'All'}];
var statusdatasource = [];
statusfiltersource.push({ value: '0',text:'新增'  });
statusdatasource.push({ value: '0',text:'新增'  });
statusfiltersource.push({ value: '1',text:'修改'  });
statusdatasource.push({ value: '1',text:'修改'  });
statusfiltersource.push({ value: '2',text:'异常'  });
statusdatasource.push({ value: '2',text:'异常'  });
statusfiltersource.push({ value: '3',text:'关闭'  });
statusdatasource.push({ value: '3',text:'关闭'  });
//for datagrid Status field  formatter
function statusformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = statusdatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = statusdatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   Status  field filter 
$.extend($.fn.datagrid.defaults.filters, {
statusfilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: statusfiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   Status   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
statuseditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: statusdatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------单位代码---------//
var unitfiltersource = [{ value: '', text: 'All'}];
var unitdatasource = [];
unitfiltersource.push({ value: '001',text:'台'  });
unitdatasource.push({ value: '001',text:'台'  });
unitfiltersource.push({ value: '002',text:'座'  });
unitdatasource.push({ value: '002',text:'座'  });
unitfiltersource.push({ value: '003',text:'辆'  });
unitdatasource.push({ value: '003',text:'辆'  });
unitfiltersource.push({ value: '004',text:'艘'  });
unitdatasource.push({ value: '004',text:'艘'  });
unitfiltersource.push({ value: '005',text:'架'  });
unitdatasource.push({ value: '005',text:'架'  });
unitfiltersource.push({ value: '006',text:'套'  });
unitdatasource.push({ value: '006',text:'套'  });
unitfiltersource.push({ value: '007',text:'个'  });
unitdatasource.push({ value: '007',text:'个'  });
unitfiltersource.push({ value: '035',text:'千克'  });
unitdatasource.push({ value: '035',text:'千克'  });
//for datagrid unit field  formatter
function unitformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = unitdatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = unitdatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   unit  field filter 
$.extend($.fn.datagrid.defaults.filters, {
unitfilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: unitfiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   unit   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
uniteditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: unitdatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------车辆状态---------//
var vstatusfiltersource = [{ value: '', text: 'All'}];
var vstatusdatasource = [];
vstatusfiltersource.push({ value: '0',text:'禁用'  });
vstatusdatasource.push({ value: '0',text:'禁用'  });
vstatusfiltersource.push({ value: '1',text:'启用'  });
vstatusdatasource.push({ value: '1',text:'启用'  });
vstatusfiltersource.push({ value: '110',text:'预定中'  });
vstatusdatasource.push({ value: '110',text:'预定中'  });
vstatusfiltersource.push({ value: '120',text:'运输中'  });
vstatusdatasource.push({ value: '120',text:'运输中'  });
vstatusfiltersource.push({ value: '170',text:'空车'  });
vstatusdatasource.push({ value: '170',text:'空车'  });
vstatusfiltersource.push({ value: '5',text:'维修中'  });
vstatusdatasource.push({ value: '5',text:'维修中'  });
//for datagrid vstatus field  formatter
function vstatusformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = vstatusdatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = vstatusdatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   vstatus  field filter 
$.extend($.fn.datagrid.defaults.filters, {
vstatusfilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: vstatusfiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   vstatus   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
vstatuseditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: vstatusdatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
//-------仓库号---------//
var whfiltersource = [{ value: '', text: 'All'}];
var whdatasource = [];
whfiltersource.push({ value: '东鹏仓',text:'东鹏仓'  });
whdatasource.push({ value: '东鹏仓',text:'东鹏仓'  });
whfiltersource.push({ value: '丹灶仓',text:'丹灶仓'  });
whdatasource.push({ value: '丹灶仓',text:'丹灶仓'  });
//for datagrid wh field  formatter
function whformatter(value, row, index) { 
     let multiple = false; 
     if (value === null || value === '' || value === undefined) 
     { 
         return "";
     } 
     if (multiple) { 
         let valarray = value.split(','); 
         let result = whdatasource.filter(item => valarray.includes(item.value));
         let textarray = result.map(x => x.text);
         if (textarray.length > 0)
             return textarray.join(",");
         else 
             return value;
      } else { 
         let result = whdatasource.filter(x => x.value == value);
               if (result.length > 0)
                    return result[0].text;
               else
                    return value;
       } 
 } 
//for datagrid   wh  field filter 
$.extend($.fn.datagrid.defaults.filters, {
whfilter: {
     init: function(container, options) {
        var input = $('<select class="easyui-combobox" >').appendTo(container);
        var myoptions = {
             panelHeight: "auto",
             data: whfiltersource ,
             onChange: function () {
                input.trigger('combobox.filter');
             }
         };
         $.extend(options, myoptions);
         input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
         return input;
      },
     destroy: function(target) {
                  
     },
     getValue: function(target) {
         return $(target).combobox('getValue');
     },
     setValue: function(target, value) {
         $(target).combobox('setValue', value);
     },
     resize: function(target, width) {
         $(target).combobox('resize', width);
     }
   }
});
//for datagrid   wh   field  editor 
$.extend($.fn.datagrid.defaults.editors, {
wheditor: {
     init: function(container, options) {
        var input = $('<input type="text">').appendTo(container);
        var myoptions = {
         panelHeight: "auto",
         data: whdatasource,
         multiple: false,
         valueField: 'value',
         textField: 'text'
     };
    $.extend(options, myoptions);
           input.combobox(options);
         input.combobox('textbox').bind('keydown', function (e) {   
            if (e.keyCode === 13) {
              $(e.target).emulateTab();
            }
          });  
           return input;
       },
     destroy: function(target) {
         $(target).combobox('destroy');
        },
     getValue: function(target) {
        let opts = $(target).combobox('options');
        if (opts.multiple) {
           return $(target).combobox('getValues').join(opts.separator);
         } else {
            return $(target).combobox('getValue');
         }
        },
     setValue: function(target, value) {
         let opts = $(target).combobox('options');
         if (opts.multiple) {
             if (value == '' || value == null) { 
                 $(target).combobox('clear'); 
              } else { 
                  $(target).combobox('setValues', value.split(opts.separator));
               }
          }
          else {
             $(target).combobox('setValue', value);
           }
         },
     resize: function(target, width) {
         $(target).combobox('resize', width);
        }
  }  
});
