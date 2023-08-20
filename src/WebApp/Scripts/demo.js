$("#main")
  //.append('<div class="demo"><span id="demo-setting"><i class="fa fa-cog txt-color-blueDark"></i></span> <form><legend class="no-padding margin-bottom-10">Layout Options</legend><section><label><input name="subscription" id="smart-fixed-header" type="checkbox" class="checkbox style-0"><span>Fixed Header</span></label><label><input type="checkbox" name="terms" id="smart-fixed-navigation" class="checkbox style-0"><span>Fixed Navigation</span></label><label><input type="checkbox" name="terms" id="smart-fixed-ribbon" class="checkbox style-0"><span>Fixed Ribbon</span></label><label><input type="checkbox" name="terms" id="smart-fixed-footer" class="checkbox style-0"><span>Fixed Footer</span></label><label><input type="checkbox" name="terms" id="smart-fixed-container" class="checkbox style-0"><span>Inside <b>.container</b> <div class="font-xs text-right">(non-responsive)</div></span></label><label style="display:block;"><input type="checkbox" id="smart-topmenu" class="checkbox style-0"><span>Menu on <b>top</b></span></label><label style="display:block;"><input type="checkbox" id="colorblind-friendly" class="checkbox style-0"><span>For Colorblind <div class="font-xs text-right">(experimental)</div></span></label> <span id="smart-bgimages"></span></section><section><h6 class="margin-top-10 semi-bold margin-bottom-5">Clear Localstorage</h6><a href="javascript:void(0);" class="btn btn-xs btn-block btn-primary" id="reset-smart-widget"><i class="fa fa-refresh"></i> Factory Reset</a></section> <h6 class="margin-top-10 semi-bold margin-bottom-5">SmartAdmin Skins</h6><section id="smart-styles"><a href="javascript:void(0);" id="smart-style-0" data-skinlogo="img/logo.png" class="btn btn-block btn-xs txt-color-white margin-right-5" style="background-color:#4E463F;"><i class="fa fa-check fa-fw" id="skin-checked"></i>Smart Default</a><a href="javascript:void(0);" id="smart-style-1" data-skinlogo="img/logo-white.png" class="btn btn-block btn-xs txt-color-white" style="background:#3A4558;">Dark Elegance</a><a href="javascript:void(0);" id="smart-style-2" data-skinlogo="img/logo-blue.png" class="btn btn-xs btn-block txt-color-darken margin-top-5" style="background:#fff;">Ultra Light</a><a href="javascript:void(0);" id="smart-style-3" data-skinlogo="img/logo-pale.png" class="btn btn-xs btn-block txt-color-white margin-top-5" style="background:#f78c40">Google Skin</a></section></form> </div>')
  .append(
    '<div class="demo"><span id="demo-setting"><i class="fa fa-cogs fa-spin txt-color-blueDark"></i></span> <form><legend class="no-padding margin-bottom-10">Layout Options</legend><section><label><input name="subscription" id="smart-fixed-header" type="checkbox" class="checkbox style-0"><span>Fixed Header</span></label><label><input type="checkbox" name="terms" id="smart-fixed-navigation" class="checkbox style-0"><span>Fixed Navigation</span></label><label><input type="checkbox" name="terms" id="smart-fixed-ribbon" class="checkbox style-0"><span>Fixed Ribbon</span></label><label><input type="checkbox" name="terms" id="smart-fixed-footer" class="checkbox style-0"><span>Fixed Footer</span></label><label><input type="checkbox" name="terms" id="smart-fixed-container" class="checkbox style-0"><span>Inside <b>.container</b></span></label><label style="display:block;"><input type="checkbox" name="terms" id="smart-rtl" class="checkbox style-0"><span>RTL Support</span></label><label style="display:block;"><input type="checkbox" id="smart-topmenu" class="checkbox style-0"><span>Menu on <b>top</b></span></label> <label style="display:block;"><input type="checkbox" id="colorblind-friendly" class="checkbox style-0"><span>For Colorblind <div class="font-xs text-right">(experimental)</div></span></label><span id="smart-bgimages"></span></section><section><h6 class="margin-top-10 semi-bold margin-bottom-5">Clear Localstorage</h6><a href="javascript:void(0);" class="btn btn-xs btn-block btn-primary" id="reset-smart-widget"><i class="fa fa-refresh"></i> Factory Reset</a></section> <h6 class="margin-top-10 semi-bold margin-bottom-5">SmartAdmin Skins</h6><section id="smart-styles"><a href="javascript:void(0);" id="smart-style-0" data-skinlogo="img/logo.png" class="btn btn-block btn-xs txt-color-white margin-right-5" style="background-color:#4E463F;"><i class="fa fa-check fa-fw" id="skin-checked"></i>Smart Default</a><a href="javascript:void(0);" id="smart-style-1" data-skinlogo="img/logo-white.png" class="btn btn-block btn-xs txt-color-white" style="background:#3A4558;">Dark Elegance</a><a href="javascript:void(0);" id="smart-style-2" data-skinlogo="img/logo-blue.png" class="btn btn-xs btn-block txt-color-darken margin-top-5" style="background:#fff;">Ultra Light</a><a href="javascript:void(0);" id="smart-style-3" data-skinlogo="img/logo-pale.png" class="btn btn-xs btn-block txt-color-white margin-top-5" style="background:#f78c40">Google Skin</a><a href="javascript:void(0);" id="smart-style-4" data-skinlogo="img/logo-pale.png" class="btn btn-xs btn-block txt-color-white margin-top-5" style="background: #bbc0cf; border: 1px solid #59779E; color: #17273D !important;">PixelSmash</a> <a href="javascript:void(0);" id="smart-style-5" data-skinlogo="img/logo-pale.png" class="btn btn-xs btn-block txt-color-white margin-top-5" style="background: rgba(153, 179, 204, 0.2); border: 1px solid rgba(121, 161, 221, 0.8); color: #17273D !important;">Glass </a><a href="javascript:void(0);" id="smart-style-6" data-skinlogo="img/logo-pale.png" class="btn btn-xs btn-block txt-color-white margin-top-6" style="background: #2196F3; border: 1px solid rgba(0, 0, 0, 0.3); color: #FFF !important;">MaterialDesign <sup>beta</sup> </a></section></form> </div>');

// hide bg options
var smartbgimage =
  "<h6 class='margin-top-10 semi-bold'>Background</h6><img src='img/pattern/graphy-xs.png' data-htmlbg-url='img/pattern/graphy.png' width='22' height='22' class='margin-right-5 bordered cursor-pointer'><img src='img/pattern/tileable_wood_texture-xs.png' width='22' height='22' data-htmlbg-url='img/pattern/tileable_wood_texture.png' class='margin-right-5 bordered cursor-pointer'><img src='img/pattern/sneaker_mesh_fabric-xs.png' width='22' height='22' data-htmlbg-url='img/pattern/sneaker_mesh_fabric.png' class='margin-right-5 bordered cursor-pointer'><img src='img/pattern/nistri-xs.png' data-htmlbg-url='img/pattern/nistri.png' width='22' height='22' class='margin-right-5 bordered cursor-pointer'><img src='img/pattern/paper-xs.png' data-htmlbg-url='img/pattern/paper.png' width='22' height='22' class='bordered cursor-pointer'>";
$("#smart-bgimages")
  .fadeOut();

$("#demo-setting")
  .click(function () {
    //console.log('setting');
    $(".demo")
      .toggleClass("activate");
  });
/*
 * FIXED HEADER
 */
$('input[type="checkbox"]#smart-fixed-header')
  .click(function () {
    if ($(this)
      .is(":checked")) {
      //checked
      $.root_.addClass("fixed-header");
    } else {
      //unchecked
      $('input[type="checkbox"]#smart-fixed-ribbon')
        .prop("checked", false);
      $('input[type="checkbox"]#smart-fixed-navigation')
        .prop("checked", false);

      $.root_.removeClass("fixed-header");
      $.root_.removeClass("fixed-navigation");
      $.root_.removeClass("fixed-ribbon");

    }
  });

/*
 * FIXED NAV
 */
$('input[type="checkbox"]#smart-fixed-navigation')
  .click(function () {
    if ($(this)
      .is(":checked")) {
      //checked
      $('input[type="checkbox"]#smart-fixed-header')
        .prop("checked", true);

      $.root_.addClass("fixed-header");
      $.root_.addClass("fixed-navigation");

      $('input[type="checkbox"]#smart-fixed-container')
        .prop("checked", false);
      $.root_.removeClass("container");

    } else {
      //unchecked
      $('input[type="checkbox"]#smart-fixed-ribbon')
        .prop("checked", false);
      $.root_.removeClass("fixed-navigation");
      $.root_.removeClass("fixed-ribbon");
    }
  });

/*
 * FIXED RIBBON
 */
$('input[type="checkbox"]#smart-fixed-ribbon')
  .click(function () {
    if ($(this)
      .is(":checked")) {

      //checked
      $('input[type="checkbox"]#smart-fixed-header')
        .prop("checked", true);
      $('input[type="checkbox"]#smart-fixed-navigation')
        .prop("checked", true);
      $('input[type="checkbox"]#smart-fixed-ribbon')
        .prop("checked", true);

      //apply
      $.root_.addClass("fixed-header");
      $.root_.addClass("fixed-navigation");
      $.root_.addClass("fixed-ribbon");

      $('input[type="checkbox"]#smart-fixed-container')
        .prop("checked", false);
      $.root_.removeClass("container");

    } else {
      //unchecked
      $.root_.removeClass("fixed-ribbon");
    }
  });

/*
 * FIXED FOOTER
 */
$('input[type="checkbox"]#smart-fixed-footer')
  .click(function () {
    if ($(this)
      .is(":checked")) {

      //checked
      $.root_.addClass("fixed-page-footer");

    } else {
      //unchecked
      $.root_.removeClass("fixed-page-footer");
    }
  });


/*
 * RTL SUPPORT
 */
$('input[type="checkbox"]#smart-rtl')
  .click(function () {
    if ($(this)
      .is(":checked")) {

      //checked
      $.root_.addClass("smart-rtl");

    } else {
      //unchecked
      $.root_.removeClass("smart-rtl");
    }
  });

/*
 * MENU ON TOP
 */

$("#smart-topmenu")
  .on("change",
    function (e) {
      if ($(this)
        .prop("checked")) {
        //window.location.href = '?menu=top';
        localStorage.setItem("sm-setmenu", "top");
        location.reload();
      } else {
        //window.location.href = '?';
        localStorage.setItem("sm-setmenu", "left");
        location.reload();
      }
    });

if (localStorage.getItem("sm-setmenu") == "top") {
  $("#smart-topmenu")
    .prop("checked", true);
} else {
  $("#smart-topmenu")
    .prop("checked", false);
}

/*
 * COLORBLIND FRIENDLY
 */

$('input[type="checkbox"]#colorblind-friendly')
  .click(function () {
    if ($(this)
      .is(":checked")) {

      //checked
      $.root_.addClass("colorblind-friendly");

    } else {
      //unchecked
      $.root_.removeClass("colorblind-friendly");
    }
  });


/*
 * INSIDE CONTAINER
 */
$('input[type="checkbox"]#smart-fixed-container')
  .click(function () {
    if ($(this)
      .is(":checked")) {
      //checked
      $.root_.addClass("container");

      $('input[type="checkbox"]#smart-fixed-ribbon')
        .prop("checked", false);
      $.root_.removeClass("fixed-ribbon");

      $('input[type="checkbox"]#smart-fixed-navigation')
        .prop("checked", false);
      $.root_.removeClass("fixed-navigation");

      if (smartbgimage) {
        $("#smart-bgimages")
          .append(smartbgimage)
          .fadeIn(1000);
        $("#smart-bgimages img")
          .bind("click",
            function () {
              var $this = $(this);
              var $html = $("html");
              bgurl = ($this.data("htmlbg-url"));
              $html.css("background-image", "url(" + bgurl + ")");
            });
        smartbgimage = null;
      } else {
        $("#smart-bgimages")
          .fadeIn(1000);
      }

    } else {
      //unchecked
      $.root_.removeClass("container");
      $("#smart-bgimages")
        .fadeOut();
    }
  });

/*
 * REFRESH WIDGET
 */
$("#reset-smart-widget")
  .bind("click",
    function () {
      $("#refresh")
        .click();
      return false;
    });

/*
 * STYLES
 */
$("#smart-styles > a")
  .on("click",
    function () {
      var $this = $(this);

      localStorage.setItem("smart-style", $this.attr("id"));
      localStorage.setItem("smart-logo", "/" + $this.data("skinlogo"));

      initApp.applyTheme();
    });
