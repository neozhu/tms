//dateRange filter
$.extend($.fn.datagrid.defaults.filters, {
  dateRange: {
    init: function (container, options) {
      var cc = $('<span class="textbox combo datebox" style="padding:0px">\
                     <span class="textbox-addon textbox-addon-right" style="right: 0px; top: 0px;">\
                     <a href="javascript:" class="textbox-icon combo-arrow" icon-index="0" tabindex="-1" style="width: 26px; height: 29px;">\
                     </a>\
                     </span>\
                  </span>').appendTo(container);
      var input = $('<input type="text" value="" style="border:0px ;height:29px;padding:2px 8px">').appendTo(cc);
      var myoptions = {
        autoUpdateInput: false,
        applyClass: 'btn-sm btn-success',
        cancelClass: 'btn-sm btn-default',
        locale: {
          applyLabel: '确认',
          cancelLabel: '清空',
          fromLabel: '起始时间',
          toLabel: '结束时间',
          customRangeLabel: '自定义',
          firstDay: 1,
          daysOfWeek: ['日', '一', '二', '三', '四', '五', '六'],
          monthNames: ['一月', '二月', '三月', '四月', '五月', '六月',
            '七月', '八月', '九月', '十月', '十一月', '十二月'],
        },
        ranges: {
          //'最近1小时': [moment().subtract('hours',1), moment()],
          '今日': [moment(), moment()],
          '昨日': [moment().subtract(1, 'days').startOf('day'), moment().subtract(1, 'days').endOf('day')],
          '最近7日': [moment().subtract(6, 'days'), moment()],
          '最近30日': [moment().subtract(29, 'days'), moment()],
          '本月': [moment().startOf("month"), moment().endOf("month")],
          '上个月': [moment().subtract(1, "month").startOf("month"), moment().subtract(1, "month").endOf("month")]
        },
        opens: 'right',    // 日期选择框的弹出位置
        separator: '-',
        showWeekNumbers: false,     // 是否显示第几周
        format: 'MM/DD/YYYY'

      };
      input.on('blur', function () {
        $(this).parent().removeClass('textbox-focused');
      }).on('focus', function () {
        $(this).parent().addClass('textbox-focused');
      });
      input.daterangepicker(myoptions);

      container.find('.textbox-icon').on('click', function () {
        container.find('input').trigger('click.daterangepicker');
      });
      if (options.onChange == undefined) {
        //console.log('Can not find function:onChange for', input[0]);
      }
      else {
        input.on('cancel.daterangepicker', function (ev, picker) {
          $(this).val('');
          options.onChange('');
        });
        input.on('apply.daterangepicker', function (ev, picker) {
          $(this).val(picker.startDate.format('MM/DD/YYYY') + '-' + picker.endDate.format('MM/DD/YYYY'));
          options.onChange(picker.startDate.format('MM/DD/YYYY') + '-' + picker.endDate.format('MM/DD/YYYY'));
        });
      }

      //console.log($(target));
      return input;
    },
    destroy: function (target) {
      $(target).daterangepicker('destroy');
    },
    getValue: function (target) {
      return $(target).data('daterangepicker').getStartDate() + '-' + $(target).data('daterangepicker').getEndDate();
    },
    setValue: function (target, value) {
      //console.log($(target), value);
      var daterange = value.split('-');
      $(target).data('daterangepicker').setStartDate(daterange[0]);
      $(target).data('daterangepicker').setEndDate(daterange[1]);

    },
    resize: function (target, width) {
      $(target)._outerWidth(width - 2)._outerHeight(29);
      // $(target).daterangepicker('resize', width / 2);
    }
  }
});
//booleanfilter
$.extend($.fn.datagrid.defaults.filters, {
    booleanfilter: {
        init: function (container, options) {
            var input = $('<select class="easyui-combobox" >').appendTo(container);
            var myoptions = {
                panelHeight: "auto",
                data: [{ value: '', text: 'All' }, { value: 'true', text: 'True' }, { value: 'false', text: 'False' }],
                onChange: function () {
                    input.trigger('combobox.filter');
                }
            }
            $.extend(options, myoptions);
            input.combobox(options);
            return input;
        },
        destroy: function (target) {
            $(target).combobox('destroy');
        },
        getValue: function (target) {
            return $(target).combobox('getValue');
        },
        setValue: function (target, value) {
            $(target).combobox('setValue', value);
        },
        resize: function (target, width) {
            $(target).combobox('resize', width);
        }
    }
});
//CheckBox Editor
$.extend($.fn.datagrid.defaults.editors, {
    booleaneditor: {


        init: function (container, options) {
            var checked = '<div class="datagrid-cell"><div class="smart-form"><label class="checkbox ">' +
                '<input type="checkbox" name="checkbox"   >' +
                '<i></i>&nbsp; </label></div></div>';
            var input = $(checked).appendTo(container);

            return input;
        },
        destroy: function (target) {

        },
        getValue: function (target) {
            //console.log('getValue', $(target[0]).find(':checkbox').prop('checked'));
            return $(target[0]).find(':checkbox').prop('checked');
        },
        setValue: function (target, value) {

            $(target[0]).find(':checkbox').prop('checked', value);



        },
        resize: function (target, width) {

        }
    }
});


//供应商筛选
$.extend($.fn.datagrid.defaults.filters, {
  supplierfilter: {
    init: function (container, options) {
      var input = $('<select class="easyui-combogrid" >').appendTo(container);
      var myoptions = {
        panelHeight: 'auto',
        url: '/SUPPLIERs/GetComboData',
        method: 'get',
        idField: 'SUPPLIERCODE',
        panelWidth: 360,
        pagination: true,
        pageSize: 10,
        textField: 'SUPPLIERCODE',
        columns: [[
          { field: 'SUPPLIERCODE', title: '供应商代码', width: 110 },
          { field: 'SUPPLIERNAME', title: '供应商名称', width: 230 }
        ]],
        onChange: function () {
          input.trigger('combobox.filter');
        }
      };
      $.extend(options, myoptions);
      input.combogrid(options);
      input.combogrid('textbox').bind('keydown', function (e) {
        if (e.keyCode === 13) {
          $(e.target).emulateTab();
        }
      });
      return input;
    },
    destroy: function (target) {

    },
    getValue: function (target) {
      return $(target).combogrid('getValue');
    },
    setValue: function (target, value) {
      $(target).combogrid('setValue', value);
    },
    resize: function (target, width) {
      $(target).combogrid('resize', width);
    }
  }
});

//车辆筛选
$.extend($.fn.datagrid.defaults.filters, {
  vehfilter: {
    init: function (container, options) {
      var input = $('<select class="easyui-combogrid" >').appendTo(container);
      var myoptions = {
        panelHeight: "auto",
        url: '/Vehicles/GetComboData',
        method: 'get',
        idField: 'PlateNumber',
        panelWidth: 700,
        pagination: true,
        pageSize: 10,
        textField: 'PlateNumber',
        columns: [[
          { field: 'PlateNumber', title: '供应商代码', width: 100 },
          { field: 'CarType', title: '车辆类型', width: 100 },
          { field: 'StdLoadWeight', title: '吨位', width: 100 },
          { field: 'Driver', title: '司机', width: 100 },
          { field: 'DriverPhone', title: '电话', width: 100 },
          { field: 'CarrierName', title: '供方', width: 180 }
        ]],
        onChange: function () {
          input.trigger('combobox.filter');
        }
      };
      $.extend(options, myoptions);
      input.combogrid(options);
      input.combogrid('textbox').bind('keydown', function (e) {
        if (e.keyCode === 13) {
          $(e.target).emulateTab();
        }
      });
      return input;
    },
    destroy: function (target) {

    },
    getValue: function (target) {
      return $(target).combogrid('getValue');
    },
    setValue: function (target, value) {
      $(target).combogrid('setValue', value);
    },
    resize: function (target, width) {
      $(target).combogrid('resize', width);
    }
  }
});



//switchbutton formatter for datagrid
function switchformatter(value, row, index) {
  if (isTrue(value)) {
    return '<input class="easyui-switchbutton"  checked disabled />';
  } else {
    return '<input class="easyui-switchbutton"  disabled />';
  }
}
//switchbutton editor for datagrid
$.extend($.fn.datagrid.defaults.editors, {
  switcheditor: {
    init: function (container, options) {
      var switchbutton = '<input class="easyui-switchbutton" value="true">';
      var input = $(switchbutton).appendTo(container);
      var opts = {};
      input.switchbutton(opts);
      return input;
    },
    destroy: function (target) {

    },
    getValue: function (target) {
      //console.log('getValue', $(target[0]).find(':checkbox').prop('checked'));
      console.log('getvalue', $(target).switchbutton('options').checked);
      return $(target).switchbutton('options').checked;
    },
    setValue: function (target, value) {
      console.log('set value', value);
      if (isTrue(value))
        $(target).switchbutton('check');
      else
        $(target).switchbutton('uncheck');


    },
    resize: function (target, width) {

    }
  }
});
