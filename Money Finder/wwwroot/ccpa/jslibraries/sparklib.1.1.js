/* SPARK JQUERY CLIENT SIDE VALIDATION */
/* USING PARSLEY 2.6.0 */
/* Author: Samuel Jimenez */
/* 2018-10-03  !!! */

/*------------------------*/

if (typeof jQuery == 'undefined') {
    document.write('<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></' + 'script>');
}


// ---------------------- SCRIPT -----------------------

function SparkDNCWriteOverlayBody() {
    var text = '';
    text = 'You DO have the right to have your DNC (Do Not Call) registration honored and opting in to receive outbound calls is not a requirement to complete this application. If you would not like to receive live telephone calls from our marketing partners, please check the box below:';
    text += '<br/><br/> <input type="checkbox" id="dnc_opt_out_checkbox" value="1" /> No, I do not want to receive live telephone calls <br/><br/> <input type="button" id="inovum_overlay_correct_now"  value="Submit" />';

    body = '<div style="padding:50px 25px 75px 25px;background-color:#fff;font-family: Arial, Helvetica, sans-serif;font-size:12px;float:left;text-align:left;">' + text + '</div>';
    ob = '<div id="invm_overlay_body" class="simple_overlay" style="padding: 0px; margin: 0px;display:none;z-index:10000;background-color:#333;border:1px solid #666;-moz-box-shadow:0 0 40px 5px #666;-webkit-box-shadow: 0 0 40px #666;"> <div id="invm_overlay_wrapper" style="margin: 0px auto 0px auto;"> <a id="invm_overlay_close" style="background-image:url(//docs.corepassage.com/JSLibraries/OptOutOverlay/close.png);position:absolute;right:-15px;top:-15px;cursor:pointer;height:35px;width:35px;"></a> ' + body + ' </div> </div>'; //width: 415px; 
    $('body').prepend(ob);
}

function SparkShowHide(id) {
    $('#invm_overlay_mpartners_body #SparkShowHideID' + id).toggle();

}

function SparkWriteMPartnersOverlayBody(site, buyerlist) {
    var text = '';

    text = "<strong>" + site + "</strong><br/><br/>";
    text += "By registering on our site, you may receive live telephone calls from one or more of the callers listed below at the number you provided. Whether or not you receive any calls may depend on your answers to the offers presented that follow our registration page. You expressly waive all federal and state no-call restrictions with respect to such contact. You may opt out of receiving calls at any time by following the instructions provided by the caller or asking the caller to place you on its do-not-call list."
    text += "<ol style='margin-top:10px;font-family: Arial, Helvetica, sans-serif;font-size:12px;'>";

    if (buyerlist != null) {
        buyers = buyerlist.split('|');
        $.each(buyers, function(k, v) {
            if (v.includes('=')) {
                v2 = v.split('=');
                text += "<li>" + v2[0] + "<a href='#' onclick='SparkShowHide(\"" + k + "\")'> (click for details)</a><div id='SparkShowHideID" + k + "' style='display:none;padding:2px;margin-bottom:3px;border-bottom:1px dashed #ccc;color:#666;'>" + v2[1] + "</div></li>";

            } else {
                text += "<li>" + v + "</li>";
            }
        });
    }


    text += "</ol>";

    body = '<div style="padding:25px 25px 25px 25px;background-color:#fff;font-family: Arial, Helvetica, sans-serif;font-size:12px;float:left;text-align:left;">' + text + '</div>';
    ob = '<div id="invm_overlay_mpartners_body" class="simple_overlay" style="padding: 0px; margin: 0px;display:none;z-index:10000;background-color:#333;border:1px solid #666;-moz-box-shadow:0 0 40px 5px #666;-webkit-box-shadow: 0 0 40px #666;"> <div id="invm_overlay_mpartners_wrapper" style="margin: 0px auto 0px auto;"> <a id="invm_overlay_mpartners_close" style="background-image:url(//docs.corepassage.com/JSLibraries/OptOutOverlay/close.png);position:absolute;right:-15px;top:-15px;cursor:pointer;height:35px;width:35px;"></a> ' + body + ' </div> </div>'; //width 450
    $('body').prepend(ob);
}

function SparkWriteStyles() {
    //var text = '<style>.simple_overlay { width:320px; }</style>';
    //$('body').append(text);
}

function adjustStyle(width) {
    width = parseInt(width);
    if (width < 501) {
        $(".simple_overlay").css('width', '320px');
    } else if (width < 701) {
        $(".simple_overlay").css('width', '400px'); //400

    } else if (width < 900) {
        $(".simple_overlay").css('width', '500px'); //500
    } else {
        $(".simple_overlay").css('width', '650px'); //650
    }
}

//function adjustStyle(width) {
//    width = parseInt(width);
//    if (width < 501) {
//        $(".simple_overlay").css('width', '280px');
//    }
//    else if (width < 701) {
//        $(".simple_overlay").css('width', '300px');

//    } else if (width < 900) {
//        $(".simple_overlay").css('width', '320px');
//    } else {
//        $(".simple_overlay").css('width', '420px'); 
//    }
//}

/*------------------------------------

//var bootstrap_enabled = (typeof $().modal == 'function');
//if (!bootstrap_enabled) {
//if(typeof($.fn.popover) == 'undefined'){
//    document.write('<script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></' + 'script>');
//    document.write('<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">');
//}



/* OVERLAY SCRIPT */
function InitializeOverlayScript() {
    (function(e) {
        var t = e(window);
        var n = {};
        var r = [];
        var i = [];
        var s;
        var o = null;
        var u = "_open";
        var a = "_close";
        var f = [];
        var l = null;
        var c;
        var h = {
            _init: function(t) {
                var n = e(t);
                var s = n.data("popupoptions");
                i[t.id] = false;
                r[t.id] = 0;
                if (!n.data("popup-initialized")) {
                    n.attr("data-popup-initialized", "true");
                    h._initonce(t)
                }
                if (s.autoopen) {
                    setTimeout(function() {
                        h.show(t, 0)
                    }, 0)
                }
            },
            _initonce: function(t) {
                var n = e(t);
                var r = e("body");
                var i;
                var f = n.data("popupoptions");
                var c;
                o = parseInt(r.css("margin-right"), 10);
                l = document.body.style.webkitTransition !== undefined || document.body.style.MozTransition !== undefined || document.body.style.msTransition !== undefined || document.body.style.OTransition !== undefined || document.body.style.transition !== undefined;
                if (f.type == "tooltip") {
                    f.background = false;
                    f.scrolllock = false
                }
                if (f.backgroundactive) {
                    f.background = false;
                    f.blur = false;
                    f.scrolllock = false
                }
                if (f.scrolllock) {
                    var p;
                    var d;
                    if (typeof s === "undefined") {
                        p = e('<div style="width:50px;height:50px;overflow:auto"><div/></div>').appendTo("body");
                        d = p.children();
                        s = d.innerWidth() - d.height(99).innerWidth();
                        p.remove()
                    }
                }
                if (!n.attr("id")) {
                    n.attr("id", "j-popup-" + parseInt(Math.random() * 1e8, 10))
                }
                n.addClass("popup_content");
                r.prepend(t);
                n.wrap('<div id="' + t.id + '_wrapper" class="popup_wrapper" />');
                i = e("#" + t.id + "_wrapper");
                i.css({
                    opacity: 0,
                    visibility: "hidden",
                    position: "absolute"
                });
                if (f.type == "overlay") {
                    i.css({
                        overflow: "auto"
                    })
                }
                n.css({
                    opacity: 0,
                    visibility: "hidden",
                    display: "inline-block"
                });
                if (f.setzindex && !f.autozindex) {
                    i.css("z-index", "100001")
                }
                if (!f.outline) {
                    n.css("outline", "none")
                }
                if (f.transition) {
                    n.css("transition", f.transition);
                    i.css("transition", f.transition)
                }
                n.attr("aria-hidden", true);
                if (f.background && !e("#" + t.id + "_background").length) {
                    r.prepend('<div id="' + t.id + '_background" class="popup_background"></div>');
                    var v = e("#" + t.id + "_background");
                    v.css({
                        opacity: 0,
                        visibility: "hidden",
                        backgroundColor: f.color,
                        position: "fixed",
                        top: 0,
                        right: 0,
                        bottom: 0,
                        left: 0
                    });
                    if (f.setzindex && !f.autozindex) {
                        v.css("z-index", "100000")
                    }
                    if (f.transition) {
                        v.css("transition", f.transition)
                    }
                }
                if (f.type == "overlay") {
                    n.css({
                        textAlign: "left",
                        position: "relative",
                        verticalAlign: "middle"
                    });
                    c = {
                        position: "fixed",
                        top: 0,
                        right: 0,
                        left: 0,
                        bottom: 0,
                        textAlign: "center"
                    };
                    if (f.backgroundactive) {
                        c.position = "relative";
                        c.height = "0";
                        c.overflow = "visible"
                    }
                    i.css(c);
                    i.append('<div class="popup_align" />');
                    e(".popup_align").css({
                        display: "inline-block",
                        verticalAlign: "middle",
                        height: "100%"
                    })
                }
                n.attr("role", "dialog");
                var m = f.openelement ? f.openelement : "." + t.id + u;
                e(m).each(function(t, n) {
                    e(n).attr("data-popup-ordinal", t);
                    if (!n.id) {
                        e(n).attr("id", "open_" + parseInt(Math.random() * 1e8, 10))
                    }
                });
                if (!(n.attr("aria-labelledby") || n.attr("aria-label"))) {
                    n.attr("aria-labelledby", e(m).attr("id"))
                }
                e(document).on("click", m, function(n) {
                    n.preventDefault();
                    var r = e(this).data("popup-ordinal");
                    setTimeout(function() {
                        h.show(t, r)
                    }, 0)
                });
                var g = f.closeelement ? f.closeelement : "." + t.id + a;
                e(document).on("click", g, function(e) {
                    h.hide(t);
                    e.preventDefault()
                });
                if (f.detach) {
                    n.hide().detach()
                } else {
                    i.hide()
                }
            },
            show: function(n, u) {
                var d = e(n);
                if (d.data("popup-visible")) return;
                if (!d.data("popup-initialized")) {
                    h._init(n)
                }
                d.attr("data-popup-initialized", "true");
                var v = e("body");
                var m = d.data("popupoptions");
                var g = e("#" + n.id + "_wrapper");
                var y = e("#" + n.id + "_background");
                p(n, u, m.beforeopen);
                i[n.id] = u;
                setTimeout(function() {
                    f.push(n.id)
                }, 0);
                if (m.autozindex) {
                    var b = document.getElementsByTagName("*");
                    var w = b.length;
                    var E = 0;
                    for (var S = 0; S < w; S++) {
                        var x = e(b[S]).css("z-index");
                        if (x !== "auto") {
                            x = parseInt(x, 10);
                            if (E < x) {
                                E = x
                            }
                        }
                    }
                    r[n.id] = E;
                    if (m.background) {
                        if (r[n.id] > 0) {
                            e("#" + n.id + "_background").css({
                                zIndex: r[n.id] + 1
                            })
                        }
                    }
                    if (r[n.id] > 0) {
                        g.css({
                            zIndex: r[n.id] + 2
                        })
                    }
                }
                if (m.detach) {
                    g.prepend(n);
                    d.show()
                } else {
                    g.show()
                }
                c = setTimeout(function() {
                    g.css({
                        visibility: "visible",
                        opacity: 1
                    });
                    e("html").addClass("popup_visible").addClass("popup_visible_" + n.id);
                    d.addClass("popup_content_visible")
                }, 20);
                if (m.scrolllock) {
                    v.css("overflow", "hidden");
                    if (v.height() > t.height()) {
                        v.css("margin-right", o + s)
                    }
                }
                if (m.backgroundactive) {
                    d.css({
                        top: (t.height() - (d.get(0).offsetHeight + parseInt(d.css("margin-top"), 10) + parseInt(d.css("margin-bottom"), 10))) / 2 + "px"
                    })
                }
                d.css({
                    visibility: "visible",
                    opacity: 1
                });
                if (m.background) {
                    y.css({
                        visibility: "visible",
                        opacity: m.opacity
                    });
                    setTimeout(function() {
                        y.css({
                            opacity: m.opacity
                        })
                    }, 0)
                }
                d.data("popup-visible", true);
                h.reposition(n, u);
                d.data("focusedelementbeforepopup", document.activeElement);
                if (m.keepfocus) {
                    d.attr("tabindex", -1);
                    setTimeout(function() {
                        if (m.focuselement === "closebutton") {
                            e("#" + n.id + " ." + n.id + a + ":first").focus()
                        } else if (m.focuselement) {
                            e(m.focuselement).focus()
                        } else {
                            d.focus()
                        }
                    }, m.focusdelay)
                }
                e(m.pagecontainer).attr("aria-hidden", true);
                d.attr("aria-hidden", false);
                p(n, u, m.onopen);
                if (l) {
                    g.one("transitionend", function() {
                        p(n, u, m.opentransitionend)
                    })
                } else {
                    p(n, u, m.opentransitionend)
                }
            },
            hide: function(t) {
                if (c) clearTimeout(c);
                var n = e("body");
                var r = e(t);
                var s = r.data("popupoptions");
                var u = e("#" + t.id + "_wrapper");
                var a = e("#" + t.id + "_background");
                r.data("popup-visible", false);
                if (f.length === 1) {
                    e("html").removeClass("popup_visible").removeClass("popup_visible_" + t.id)
                } else {
                    e("html").removeClass("popup_visible_" + t.id)
                }
                f.pop();
                r.removeClass("popup_content_visible");
                if (s.keepfocus) {
                    setTimeout(function() {
                        if (e(r.data("focusedelementbeforepopup")).is(":visible")) {
                            r.data("focusedelementbeforepopup").focus()
                        }
                    }, 0)
                }
                u.css({
                    visibility: "hidden",
                    opacity: 0
                });
                r.css({
                    visibility: "hidden",
                    opacity: 0
                });
                if (s.background) {
                    a.css({
                        visibility: "hidden",
                        opacity: 0
                    })
                }
                e(s.pagecontainer).attr("aria-hidden", false);
                r.attr("aria-hidden", true);
                p(t, i[t.id], s.onclose);
                if (l && r.css("transition-duration") !== "0s") {
                    r.one("transitionend", function(e) {
                        if (!r.data("popup-visible")) {
                            if (s.detach) {
                                r.hide().detach()
                            } else {
                                u.hide()
                            }
                        }
                        if (s.scrolllock) {
                            setTimeout(function() {
                                n.css({
                                    overflow: "visible",
                                    "margin-right": o
                                })
                            }, 10)
                        }
                        p(t, i[t.id], s.closetransitionend)
                    })
                } else {
                    if (s.detach) {
                        r.hide().detach()
                    } else {
                        u.hide()
                    }
                    if (s.scrolllock) {
                        setTimeout(function() {
                            n.css({
                                overflow: "visible",
                                "margin-right": o
                            })
                        }, 10)
                    }
                    p(t, i[t.id], s.closetransitionend)
                }
            },
            toggle: function(t, n) {
                if (e(t).data("popup-visible")) {
                    h.hide(t)
                } else {
                    setTimeout(function() {
                        h.show(t, n)
                    }, 0)
                }
            },
            reposition: function(n, r) {
                var i = e(n);
                var s = i.data("popupoptions");
                var o = e("#" + n.id + "_wrapper");
                var a = e("#" + n.id + "_background");
                r = r || 0;
                if (s.type == "tooltip") {
                    o.css({
                        position: "absolute"
                    });
                    var f;
                    if (s.tooltipanchor) {
                        f = e(s.tooltipanchor)
                    } else if (s.openelement) {
                        f = e(s.openelement).filter('[data-popup-ordinal="' + r + '"]')
                    } else {
                        f = e("." + n.id + u + '[data-popup-ordinal="' + r + '"]')
                    }
                    var l = f.offset();
                    if (s.horizontal == "right") {
                        o.css("left", l.left + f.outerWidth() + s.offsetleft)
                    } else if (s.horizontal == "leftedge") {
                        o.css("left", l.left + f.outerWidth() - f.outerWidth() + s.offsetleft)
                    } else if (s.horizontal == "left") {
                        o.css("right", t.width() - l.left - s.offsetleft)
                    } else if (s.horizontal == "rightedge") {
                        o.css("right", t.width() - l.left - f.outerWidth() - s.offsetleft)
                    } else {
                        o.css("left", l.left + f.outerWidth() / 2 - i.outerWidth() / 2 - parseFloat(i.css("marginLeft")) + s.offsetleft)
                    }
                    if (s.vertical == "bottom") {
                        o.css("top", l.top + f.outerHeight() + s.offsettop)
                    } else if (s.vertical == "bottomedge") {
                        o.css("top", l.top + f.outerHeight() - i.outerHeight() + s.offsettop)
                    } else if (s.vertical == "top") {
                        o.css("bottom", t.height() - l.top - s.offsettop)
                    } else if (s.vertical == "topedge") {
                        o.css("bottom", t.height() - l.top - i.outerHeight() - s.offsettop)
                    } else {
                        o.css("top", l.top + f.outerHeight() / 2 - i.outerHeight() / 2 - parseFloat(i.css("marginTop")) + s.offsettop)
                    }
                } else if (s.type == "overlay") {
                    if (s.horizontal) {
                        o.css("text-align", s.horizontal)
                    } else {
                        o.css("text-align", "center")
                    }
                    if (s.vertical) {
                        i.css("vertical-align", s.vertical)
                    } else {
                        i.css("vertical-align", "middle")
                    }
                }
            }
        };
        var p = function(t, r, i) {
            var s = n.openelement ? n.openelement : "." + t.id + u;
            var o = e(s + '[data-popup-ordinal="' + r + '"]');
            if (typeof i == "function") {
                i(o)
            }
        };
        e(document).on("keydown", function(t) {
            if (f.length) {
                var n = f[f.length - 1];
                var r = document.getElementById(n);
                if (e(r).data("popupoptions").escape && t.keyCode == 27 && e(r).data("popup-visible")) {
                    h.hide(r)
                }
            }
        });
        e(document).on("click touchstart", function(t) {
            if (f.length) {
                var n = f[f.length - 1];
                var r = document.getElementById(n);
                if (e(r).data("popupoptions").blur && !e(t.target).parents().andSelf().is("#" + n) && e(r).data("popup-visible") && t.which !== 2) {
                    h.hide(r);
                    if (e(r).data("popupoptions").type === "overlay") {
                        t.preventDefault()
                    }
                }
            }
        });
        e(document).on("focusin", function(t) {
            if (f.length) {
                var n = f[f.length - 1];
                var r = document.getElementById(n);
                if (e(r).data("popupoptions").keepfocus) {
                    if (!r.contains(t.target)) {
                        t.stopPropagation();
                        r.focus()
                    }
                }
            }
        });
        e.fn.popup = function(t) {
            return this.each(function() {
                $el = e(this);
                if (typeof t === "object") {
                    var r = e.extend({}, e.fn.popup.defaults, t);
                    $el.data("popupoptions", r);
                    n = $el.data("popupoptions");
                    h._init(this)
                } else if (typeof t === "string") {
                    if (!$el.data("popupoptions")) {
                        $el.data("popupoptions", e.fn.popup.defaults);
                        n = $el.data("popupoptions")
                    }
                    h[t].call(this, this)
                } else {
                    if (!$el.data("popupoptions")) {
                        $el.data("popupoptions", e.fn.popup.defaults);
                        n = $el.data("popupoptions")
                    }
                    h._init(this)
                }
            })
        };
        e.fn.popup.defaults = {
            type: "overlay",
            autoopen: false,
            background: true,
            backgroundactive: false,
            color: "black",
            opacity: "0.5",
            horizontal: "center",
            vertical: "middle",
            offsettop: 0,
            offsetleft: 0,
            escape: true,
            blur: true,
            setzindex: true,
            autozindex: false,
            scrolllock: false,
            keepfocus: true,
            focuselement: null,
            focusdelay: 50,
            outline: false,
            pagecontainer: null,
            detach: false,
            openelement: null,
            closeelement: null,
            transition: null,
            tooltipanchor: null,
            beforeopen: null,
            onclose: null,
            onopen: null,
            opentransitionend: null,
            closetransitionend: null
        }
    })(jQuery);

    SparkDNCWriteOverlayBody();

    site = $('#mpartners_link').attr('data-site');
    buyerlist = $('#mpartners_link').attr('data-databuyers');
    SparkWriteMPartnersOverlayBody(site, buyerlist);

    adjustStyle($(this).width());
    $(window).resize(function() {
        adjustStyle($(this).width());
    });

    SparkWriteStyles();

    if ($('#dnc_opt_out_checkbox').length > 0) {

        if ($('#DNC_OPT_OUT').length > 0) {
            if ($('#DNC_OPT_OUT').val() == "1") {
                $('#dnc_opt_out_checkbox').prop('checked', 'checked');
            }
        };

        $("#invm_overlay_body").popup({
            opacity: 0.3,
            transition: 'all 0.3s'
        });

        $("#invm_overlay_mpartners_body").popup({
            opacity: 0.3,
            transition: 'all 0.3s'
        });


        $('#dnc_opt_out_link').click(function(e) { // this is the terms link to click
            e.preventDefault();
            $("#invm_overlay_body").popup('show');
            return false;

        });

        $('#mpartners_link').click(function(e) {
            e.preventDefault();
            $("#invm_overlay_mpartners_body").popup('show');
            return false;

        });

        $('#inovum_overlay_correct_now,#invm_overlay_close').click(function(e) {
            e.preventDefault();
            if ($('#dnc_opt_out_checkbox').prop('checked')) {
                $('#DNC_OPT_OUT').val("1");
            } else {
                $('#DNC_OPT_OUT').val("0");
            };
            $("#invm_overlay_body").popup('hide');
            return false;

        });

        $('#invm_overlay_mpartners_close').click(function(e) {
            e.preventDefault();
            $("#invm_overlay_mpartners_body").popup('hide');
            return false;

        });
    };

}

function SparkJqvWriteOverlayBody() {

    var text = '<span style="font-size:1.2rem;font-weight:bold;">Please correct the following errors:</span><br/><br/> <div id="sparkjqv_errors"></div> <br/> <input type="button" id="sparkjqv_overlay_correct_now"  value="Correct Now" class="btn button" style="margin-bottom:0px;" />';

    body = '<div style="width: 100%;padding:25px 25px 25px 25px;background-color:#fff;font-family: Arial, Helvetica, sans-serif;font-size:12px;float:left;text-align:left;">' + text + '</div>';
    ob = '<div id="sparkjqv_overlay_body" class="simple_overlay" style="padding: 0px; margin: 0px;display:none;z-index:10000;background-color:#333;border:1px solid #666;-moz-box-shadow:0 0 40px 5px #666;-webkit-box-shadow: 0 0 40px #666;"> <div id="sparkjqv_overlay_wrapper" style="width: 100%; margin: 0px auto 0px auto;"> <a id="sparkjqv_overlay_close" style="background-image:url(//docs.corepassage.com/JSLibraries/OptOutOverlay/close.png);position:absolute;right:-15px;top:-15px;cursor:pointer;height:35px;width:35px;"></a> ' + body + ' </div> </div>';
    $('body').prepend(ob);
}

/* --- tool tipster bundle min ------ */
/*! tooltipster v4.1.6 */
! function(a, b) {
    "function" == typeof define && define.amd ? define(["jquery"], function(a) {
        return b(a)
    }) : "object" == typeof exports ? module.exports = b(require("jquery")) : b(jQuery)
}(this, function(a) {
    function b(a) {
        this.$container, this.constraints = null, this.__$tooltip, this.__init(a)
    }

    function c(b, c) {
        var d = !0;
        return a.each(b, function(a, e) {
            return void 0 === c[a] || b[a] !== c[a] ? (d = !1, !1) : void 0
        }), d
    }

    function d(b) {
        var c = b.attr("id"),
            d = c ? h.window.document.getElementById(c) : null;
        return d ? d === b[0] : a.contains(h.window.document.body, b[0])
    }

    function e() {
        if (!g) return !1;
        var a = g.document.body || g.document.documentElement,
            b = a.style,
            c = "transition",
            d = ["Moz", "Webkit", "Khtml", "O", "ms"];
        if ("string" == typeof b[c]) return !0;
        c = c.charAt(0).toUpperCase() + c.substr(1);
        for (var e = 0; e < d.length; e++)
            if ("string" == typeof b[d[e] + c]) return !0;
        return !1
    }
    var f = {
            animation: "fade",
            animationDuration: 350,
            content: null,
            contentAsHTML: !1,
            contentCloning: !1,
            debug: !0,
            delay: 300,
            delayTouch: [300, 500],
            functionInit: null,
            functionBefore: null,
            functionReady: null,
            functionAfter: null,
            functionFormat: null,
            IEmin: 6,
            interactive: !1,
            multiple: !1,
            parent: "body",
            plugins: ["sideTip"],
            repositionOnScroll: !1,
            restoration: "none",
            selfDestruction: !0,
            theme: [],
            timer: 0,
            trackerInterval: 500,
            trackOrigin: !1,
            trackTooltip: !1,
            trigger: "hover",
            triggerClose: {
                click: !1,
                mouseleave: !1,
                originClick: !1,
                scroll: !1,
                tap: !1,
                touchleave: !1
            },
            triggerOpen: {
                click: !1,
                mouseenter: !1,
                tap: !1,
                touchstart: !1
            },
            updateAnimation: "rotate",
            zIndex: 9999999
        },
        g = "undefined" != typeof window ? window : null,
        h = {
            hasTouchCapability: !(!g || !("ontouchstart" in g || g.DocumentTouch && g.document instanceof g.DocumentTouch || g.navigator.maxTouchPoints)),
            hasTransitions: e(),
            IE: !1,
            semVer: "4.1.6",
            window: g
        },
        i = function() {
            this.__$emitterPrivate = a({}), this.__$emitterPublic = a({}), this.__instancesLatestArr = [], this.__plugins = {}, this._env = h
        };
    i.prototype = {
        __bridge: function(b, c, d) {
            if (!c[d]) {
                var e = function() {};
                e.prototype = b;
                var g = new e;
                g.__init && g.__init(c), a.each(b, function(a, b) {
                    0 != a.indexOf("__") && (c[a] ? f.debug && console.log("The " + a + " method of the " + d + " plugin conflicts with another plugin or native methods") : (c[a] = function() {
                        return g[a].apply(g, Array.prototype.slice.apply(arguments))
                    }, c[a].bridged = g))
                }), c[d] = g
            }
            return this
        },
        __setWindow: function(a) {
            return h.window = a, this
        },
        _getRuler: function(a) {
            return new b(a)
        },
        _off: function() {
            return this.__$emitterPrivate.off.apply(this.__$emitterPrivate, Array.prototype.slice.apply(arguments)), this
        },
        _on: function() {
            return this.__$emitterPrivate.on.apply(this.__$emitterPrivate, Array.prototype.slice.apply(arguments)), this
        },
        _one: function() {
            return this.__$emitterPrivate.one.apply(this.__$emitterPrivate, Array.prototype.slice.apply(arguments)), this
        },
        _plugin: function(b) {
            var c = this;
            if ("string" == typeof b) {
                var d = b,
                    e = null;
                return d.indexOf(".") > 0 ? e = c.__plugins[d] : a.each(c.__plugins, function(a, b) {
                    return b.name.substring(b.name.length - d.length - 1) == "." + d ? (e = b, !1) : void 0
                }), e
            }
            if (b.name.indexOf(".") < 0) throw new Error("Plugins must be namespaced");
            return c.__plugins[b.name] = b, b.core && c.__bridge(b.core, c, b.name), this
        },
        _trigger: function() {
            var a = Array.prototype.slice.apply(arguments);
            return "string" == typeof a[0] && (a[0] = {
                type: a[0]
            }), this.__$emitterPrivate.trigger.apply(this.__$emitterPrivate, a), this.__$emitterPublic.trigger.apply(this.__$emitterPublic, a), this
        },
        instances: function(b) {
            var c = [],
                d = b || ".tooltipstered";
            return a(d).each(function() {
                var b = a(this),
                    d = b.data("tooltipster-ns");
                d && a.each(d, function(a, d) {
                    c.push(b.data(d))
                })
            }), c
        },
        instancesLatest: function() {
            return this.__instancesLatestArr
        },
        off: function() {
            return this.__$emitterPublic.off.apply(this.__$emitterPublic, Array.prototype.slice.apply(arguments)), this
        },
        on: function() {
            return this.__$emitterPublic.on.apply(this.__$emitterPublic, Array.prototype.slice.apply(arguments)), this
        },
        one: function() {
            return this.__$emitterPublic.one.apply(this.__$emitterPublic, Array.prototype.slice.apply(arguments)), this
        },
        origins: function(b) {
            var c = b ? b + " " : "";
            return a(c + ".tooltipstered").toArray()
        },
        setDefaults: function(b) {
            return a.extend(f, b), this
        },
        triggerHandler: function() {
            return this.__$emitterPublic.triggerHandler.apply(this.__$emitterPublic, Array.prototype.slice.apply(arguments)), this
        }
    }, a.tooltipster = new i, a.Tooltipster = function(b, c) {
        this.__callbacks = {
            close: [],
            open: []
        }, this.__closingTime, this.__Content, this.__contentBcr, this.__destroyed = !1, this.__destroying = !1, this.__$emitterPrivate = a({}), this.__$emitterPublic = a({}), this.__enabled = !0, this.__garbageCollector, this.__Geometry, this.__lastPosition, this.__namespace = "tooltipster-" + Math.round(1e6 * Math.random()), this.__options, this.__$originParents, this.__pointerIsOverOrigin = !1, this.__previousThemes = [], this.__state = "closed", this.__timeouts = {
            close: [],
            open: null
        }, this.__touchEvents = [], this.__tracker = null, this._$origin, this._$tooltip, this.__init(b, c)
    }, a.Tooltipster.prototype = {
        __init: function(b, c) {
            var d = this;
            if (d._$origin = a(b), d.__options = a.extend(!0, {}, f, c), d.__optionsFormat(), !h.IE || h.IE >= d.__options.IEmin) {
                var e = null;
                if (void 0 === d._$origin.data("tooltipster-initialTitle") && (e = d._$origin.attr("title"), void 0 === e && (e = null), d._$origin.data("tooltipster-initialTitle", e)), null !== d.__options.content) d.__contentSet(d.__options.content);
                else {
                    var g, i = d._$origin.attr("data-tooltip-content");
                    i && (g = a(i)), g && g[0] ? d.__contentSet(g.first()) : d.__contentSet(e)
                }
                d._$origin.removeAttr("title").addClass("tooltipstered"), d.__prepareOrigin(), d.__prepareGC(), a.each(d.__options.plugins, function(a, b) {
                    d._plug(b)
                }), h.hasTouchCapability && a("body").on("touchmove." + d.__namespace + "-triggerOpen", function(a) {
                    d._touchRecordEvent(a)
                }), d._on("created", function() {
                    d.__prepareTooltip()
                })._on("repositioned", function(a) {
                    d.__lastPosition = a.position
                })
            } else d.__options.disabled = !0
        },
        __contentInsert: function() {
            var a = this,
                b = a._$tooltip.find(".tooltipster-content"),
                c = a.__Content,
                d = function(a) {
                    c = a
                };
            return a._trigger({
                type: "format",
                content: a.__Content,
                format: d
            }), a.__options.functionFormat && (c = a.__options.functionFormat.call(a, a, {
                origin: a._$origin[0]
            }, a.__Content)), "string" != typeof c || a.__options.contentAsHTML ? b.empty().append(c) : b.text(c), a
        },
        __contentSet: function(b) {
            return b instanceof a && this.__options.contentCloning && (b = b.clone(!0)), this.__Content = b, this._trigger({
                type: "updated",
                content: b
            }), this
        },
        __destroyError: function() {
            throw new Error("This tooltip has been destroyed and cannot execute your method call.")
        },
        __geometry: function() {
            var b = this,
                c = b._$origin,
                d = b._$origin.is("area");
            if (d) {
                var e = b._$origin.parent().attr("name");
                c = a('img[usemap="#' + e + '"]')
            }
            var f = c[0].getBoundingClientRect(),
                g = a(h.window.document),
                i = a(h.window),
                j = c,
                k = {
                    available: {
                        document: null,
                        window: null
                    },
                    document: {
                        size: {
                            height: g.height(),
                            width: g.width()
                        }
                    },
                    window: {
                        scroll: {
                            left: h.window.scrollX || h.window.document.documentElement.scrollLeft,
                            top: h.window.scrollY || h.window.document.documentElement.scrollTop
                        },
                        size: {
                            height: i.height(),
                            width: i.width()
                        }
                    },
                    origin: {
                        fixedLineage: !1,
                        offset: {},
                        size: {
                            height: f.bottom - f.top,
                            width: f.right - f.left
                        },
                        usemapImage: d ? c[0] : null,
                        windowOffset: {
                            bottom: f.bottom,
                            left: f.left,
                            right: f.right,
                            top: f.top
                        }
                    }
                };
            if (d) {
                var l = b._$origin.attr("shape"),
                    m = b._$origin.attr("coords");
                if (m && (m = m.split(","), a.map(m, function(a, b) {
                        m[b] = parseInt(a)
                    })), "default" != l) switch (l) {
                    case "circle":
                        var n = m[0],
                            o = m[1],
                            p = m[2],
                            q = o - p,
                            r = n - p;
                        k.origin.size.height = 2 * p, k.origin.size.width = k.origin.size.height, k.origin.windowOffset.left += r, k.origin.windowOffset.top += q;
                        break;
                    case "rect":
                        var s = m[0],
                            t = m[1],
                            u = m[2],
                            v = m[3];
                        k.origin.size.height = v - t, k.origin.size.width = u - s, k.origin.windowOffset.left += s, k.origin.windowOffset.top += t;
                        break;
                    case "poly":
                        for (var w = 0, x = 0, y = 0, z = 0, A = "even", B = 0; B < m.length; B++) {
                            var C = m[B];
                            "even" == A ? (C > y && (y = C, 0 === B && (w = y)), w > C && (w = C), A = "odd") : (C > z && (z = C, 1 == B && (x = z)), x > C && (x = C), A = "even")
                        }
                        k.origin.size.height = z - x, k.origin.size.width = y - w, k.origin.windowOffset.left += w, k.origin.windowOffset.top += x
                }
            }
            var D = function(a) {
                k.origin.size.height = a.height, k.origin.windowOffset.left = a.left, k.origin.windowOffset.top = a.top, k.origin.size.width = a.width
            };
            for (b._trigger({
                    type: "geometry",
                    edit: D,
                    geometry: {
                        height: k.origin.size.height,
                        left: k.origin.windowOffset.left,
                        top: k.origin.windowOffset.top,
                        width: k.origin.size.width
                    }
                }), k.origin.windowOffset.right = k.origin.windowOffset.left + k.origin.size.width, k.origin.windowOffset.bottom = k.origin.windowOffset.top + k.origin.size.height, k.origin.offset.left = k.origin.windowOffset.left + k.window.scroll.left, k.origin.offset.top = k.origin.windowOffset.top + k.window.scroll.top, k.origin.offset.bottom = k.origin.offset.top + k.origin.size.height, k.origin.offset.right = k.origin.offset.left + k.origin.size.width, k.available.document = {
                    bottom: {
                        height: k.document.size.height - k.origin.offset.bottom,
                        width: k.document.size.width
                    },
                    left: {
                        height: k.document.size.height,
                        width: k.origin.offset.left
                    },
                    right: {
                        height: k.document.size.height,
                        width: k.document.size.width - k.origin.offset.right
                    },
                    top: {
                        height: k.origin.offset.top,
                        width: k.document.size.width
                    }
                }, k.available.window = {
                    bottom: {
                        height: Math.max(k.window.size.height - Math.max(k.origin.windowOffset.bottom, 0), 0),
                        width: k.window.size.width
                    },
                    left: {
                        height: k.window.size.height,
                        width: Math.max(k.origin.windowOffset.left, 0)
                    },
                    right: {
                        height: k.window.size.height,
                        width: Math.max(k.window.size.width - Math.max(k.origin.windowOffset.right, 0), 0)
                    },
                    top: {
                        height: Math.max(k.origin.windowOffset.top, 0),
                        width: k.window.size.width
                    }
                };
                "html" != j[0].tagName.toLowerCase();) {
                if ("fixed" == j.css("position")) {
                    k.origin.fixedLineage = !0;
                    break
                }
                j = j.parent()
            }
            return k
        },
        __optionsFormat: function() {
            return "number" == typeof this.__options.animationDuration && (this.__options.animationDuration = [this.__options.animationDuration, this.__options.animationDuration]), "number" == typeof this.__options.delay && (this.__options.delay = [this.__options.delay, this.__options.delay]), "number" == typeof this.__options.delayTouch && (this.__options.delayTouch = [this.__options.delayTouch, this.__options.delayTouch]), "string" == typeof this.__options.theme && (this.__options.theme = [this.__options.theme]), "string" == typeof this.__options.parent && (this.__options.parent = a(this.__options.parent)), "hover" == this.__options.trigger ? (this.__options.triggerOpen = {
                mouseenter: !0,
                touchstart: !0
            }, this.__options.triggerClose = {
                mouseleave: !0,
                originClick: !0,
                touchleave: !0
            }) : "click" == this.__options.trigger && (this.__options.triggerOpen = {
                click: !0,
                tap: !0
            }, this.__options.triggerClose = {
                click: !0,
                tap: !0
            }), this._trigger("options"), this
        },
        __prepareGC: function() {
            var b = this;
            return b.__options.selfDestruction ? b.__garbageCollector = setInterval(function() {
                var c = (new Date).getTime();
                b.__touchEvents = a.grep(b.__touchEvents, function(a, b) {
                    return c - a.time > 6e4
                }), d(b._$origin) || b.destroy()
            }, 2e4) : clearInterval(b.__garbageCollector), b
        },
        __prepareOrigin: function() {
            var a = this;
            if (a._$origin.off("." + a.__namespace + "-triggerOpen"), h.hasTouchCapability && a._$origin.on("touchstart." + a.__namespace + "-triggerOpen touchend." + a.__namespace + "-triggerOpen touchcancel." + a.__namespace + "-triggerOpen", function(b) {
                    a._touchRecordEvent(b)
                }), a.__options.triggerOpen.click || a.__options.triggerOpen.tap && h.hasTouchCapability) {
                var b = "";
                a.__options.triggerOpen.click && (b += "click." + a.__namespace + "-triggerOpen "), a.__options.triggerOpen.tap && h.hasTouchCapability && (b += "touchend." + a.__namespace + "-triggerOpen"), a._$origin.on(b, function(b) {
                    a._touchIsMeaningfulEvent(b) && a._open(b)
                })
            }
            if (a.__options.triggerOpen.mouseenter || a.__options.triggerOpen.touchstart && h.hasTouchCapability) {
                var b = "";
                a.__options.triggerOpen.mouseenter && (b += "mouseenter." + a.__namespace + "-triggerOpen "), a.__options.triggerOpen.touchstart && h.hasTouchCapability && (b += "touchstart." + a.__namespace + "-triggerOpen"), a._$origin.on(b, function(b) {
                    !a._touchIsTouchEvent(b) && a._touchIsEmulatedEvent(b) || (a.__pointerIsOverOrigin = !0, a._openShortly(b))
                })
            }
            if (a.__options.triggerClose.mouseleave || a.__options.triggerClose.touchleave && h.hasTouchCapability) {
                var b = "";
                a.__options.triggerClose.mouseleave && (b += "mouseleave." + a.__namespace + "-triggerOpen "), a.__options.triggerClose.touchleave && h.hasTouchCapability && (b += "touchend." + a.__namespace + "-triggerOpen touchcancel." + a.__namespace + "-triggerOpen"), a._$origin.on(b, function(b) {
                    a._touchIsMeaningfulEvent(b) && (a.__pointerIsOverOrigin = !1)
                })
            }
            return a
        },
        __prepareTooltip: function() {
            var b = this,
                c = b.__options.interactive ? "auto" : "";
            return b._$tooltip.attr("id", b.__namespace).css({
                "pointer-events": c,
                zIndex: b.__options.zIndex
            }), a.each(b.__previousThemes, function(a, c) {
                b._$tooltip.removeClass(c)
            }), a.each(b.__options.theme, function(a, c) {
                b._$tooltip.addClass(c)
            }), b.__previousThemes = a.merge([], b.__options.theme), b
        },
        __scrollHandler: function(b) {
            var c = this;
            if (c.__options.triggerClose.scroll) c._close(b);
            else {
                if (b.target === h.window.document) c.__Geometry.origin.fixedLineage || c.__options.repositionOnScroll && c.reposition(b);
                else {
                    var d = c.__geometry(),
                        e = !1;
                    if ("fixed" != c._$origin.css("position") && c.__$originParents.each(function(b, c) {
                            var f = a(c),
                                g = f.css("overflow-x"),
                                h = f.css("overflow-y");
                            if ("visible" != g || "visible" != h) {
                                var i = c.getBoundingClientRect();
                                if ("visible" != g && (d.origin.windowOffset.left < i.left || d.origin.windowOffset.right > i.right)) return e = !0, !1;
                                if ("visible" != h && (d.origin.windowOffset.top < i.top || d.origin.windowOffset.bottom > i.bottom)) return e = !0, !1
                            }
                            return "fixed" == f.css("position") ? !1 : void 0
                        }), e) c._$tooltip.css("visibility", "hidden");
                    else if (c._$tooltip.css("visibility", "visible"), c.__options.repositionOnScroll) c.reposition(b);
                    else {
                        var f = d.origin.offset.left - c.__Geometry.origin.offset.left,
                            g = d.origin.offset.top - c.__Geometry.origin.offset.top;
                        c._$tooltip.css({
                            left: c.__lastPosition.coord.left + f,
                            top: c.__lastPosition.coord.top + g
                        })
                    }
                }
                c._trigger({
                    type: "scroll",
                    event: b
                })
            }
            return c
        },
        __stateSet: function(a) {
            return this.__state = a, this._trigger({
                type: "state",
                state: a
            }), this
        },
        __timeoutsClear: function() {
            return clearTimeout(this.__timeouts.open), this.__timeouts.open = null, a.each(this.__timeouts.close, function(a, b) {
                clearTimeout(b)
            }), this.__timeouts.close = [], this
        },
        __trackerStart: function() {
            var a = this,
                b = a._$tooltip.find(".tooltipster-content");
            return a.__options.trackTooltip && (a.__contentBcr = b[0].getBoundingClientRect()), a.__tracker = setInterval(function() {
                if (d(a._$origin) && d(a._$tooltip)) {
                    if (a.__options.trackOrigin) {
                        var e = a.__geometry(),
                            f = !1;
                        c(e.origin.size, a.__Geometry.origin.size) && (a.__Geometry.origin.fixedLineage ? c(e.origin.windowOffset, a.__Geometry.origin.windowOffset) && (f = !0) : c(e.origin.offset, a.__Geometry.origin.offset) && (f = !0)), f || (a.__options.triggerClose.mouseleave ? a._close() : a.reposition())
                    }
                    if (a.__options.trackTooltip) {
                        var g = b[0].getBoundingClientRect();
                        g.height === a.__contentBcr.height && g.width === a.__contentBcr.width || (a.reposition(), a.__contentBcr = g)
                    }
                } else a._close()
            }, a.__options.trackerInterval), a
        },
        _close: function(b, c) {
            var d = this,
                e = !0;
            if (d._trigger({
                    type: "close",
                    event: b,
                    stop: function() {
                        e = !1
                    }
                }), e || d.__destroying) {
                c && d.__callbacks.close.push(c), d.__callbacks.open = [], d.__timeoutsClear();
                var f = function() {
                    a.each(d.__callbacks.close, function(a, c) {
                        c.call(d, d, {
                            event: b,
                            origin: d._$origin[0]
                        })
                    }), d.__callbacks.close = []
                };
                if ("closed" != d.__state) {
                    var g = !0,
                        i = new Date,
                        j = i.getTime(),
                        k = j + d.__options.animationDuration[1];
                    if ("disappearing" == d.__state && k > d.__closingTime && (g = !1), g) {
                        d.__closingTime = k, "disappearing" != d.__state && d.__stateSet("disappearing");
                        var l = function() {
                            clearInterval(d.__tracker), d._trigger({
                                type: "closing",
                                event: b
                            }), d._$tooltip.off("." + d.__namespace + "-triggerClose").removeClass("tooltipster-dying"), a(h.window).off("." + d.__namespace + "-triggerClose"), d.__$originParents.each(function(b, c) {
                                a(c).off("scroll." + d.__namespace + "-triggerClose")
                            }), d.__$originParents = null, a("body").off("." + d.__namespace + "-triggerClose"), d._$origin.off("." + d.__namespace + "-triggerClose"), d._off("dismissable"), d.__stateSet("closed"), d._trigger({
                                type: "after",
                                event: b
                            }), d.__options.functionAfter && d.__options.functionAfter.call(d, d, {
                                event: b,
                                origin: d._$origin[0]
                            }), f()
                        };
                        h.hasTransitions ? (d._$tooltip.css({
                            "-moz-animation-duration": d.__options.animationDuration[1] + "ms",
                            "-ms-animation-duration": d.__options.animationDuration[1] + "ms",
                            "-o-animation-duration": d.__options.animationDuration[1] + "ms",
                            "-webkit-animation-duration": d.__options.animationDuration[1] + "ms",
                            "animation-duration": d.__options.animationDuration[1] + "ms",
                            "transition-duration": d.__options.animationDuration[1] + "ms"
                        }), d._$tooltip.clearQueue().removeClass("tooltipster-show").addClass("tooltipster-dying"), d.__options.animationDuration[1] > 0 && d._$tooltip.delay(d.__options.animationDuration[1]), d._$tooltip.queue(l)) : d._$tooltip.stop().fadeOut(d.__options.animationDuration[1], l)
                    }
                } else f()
            }
            return d
        },
        _off: function() {
            return this.__$emitterPrivate.off.apply(this.__$emitterPrivate, Array.prototype.slice.apply(arguments)), this
        },
        _on: function() {
            return this.__$emitterPrivate.on.apply(this.__$emitterPrivate, Array.prototype.slice.apply(arguments)), this
        },
        _one: function() {
            return this.__$emitterPrivate.one.apply(this.__$emitterPrivate, Array.prototype.slice.apply(arguments)), this
        },
        _open: function(b, c) {
            var e = this;
            if (!e.__destroying && d(e._$origin) && e.__enabled) {
                var f = !0;
                if ("closed" == e.__state && (e._trigger({
                        type: "before",
                        event: b,
                        stop: function() {
                            f = !1
                        }
                    }), f && e.__options.functionBefore && (f = e.__options.functionBefore.call(e, e, {
                        event: b,
                        origin: e._$origin[0]
                    }))), f !== !1 && null !== e.__Content) {
                    c && e.__callbacks.open.push(c), e.__callbacks.close = [], e.__timeoutsClear();
                    var g, i = function() {
                        "stable" != e.__state && e.__stateSet("stable"), a.each(e.__callbacks.open, function(a, b) {
                            b.call(e, e, {
                                origin: e._$origin[0],
                                tooltip: e._$tooltip[0]
                            })
                        }), e.__callbacks.open = []
                    };
                    if ("closed" !== e.__state) g = 0, "disappearing" === e.__state ? (e.__stateSet("appearing"), h.hasTransitions ? (e._$tooltip.clearQueue().removeClass("tooltipster-dying").addClass("tooltipster-show"), e.__options.animationDuration[0] > 0 && e._$tooltip.delay(e.__options.animationDuration[0]), e._$tooltip.queue(i)) : e._$tooltip.stop().fadeIn(i)) : "stable" == e.__state && i();
                    else {
                        if (e.__stateSet("appearing"), g = e.__options.animationDuration[0], e.__contentInsert(), e.reposition(b, !0), h.hasTransitions ? (e._$tooltip.addClass("tooltipster-" + e.__options.animation).addClass("tooltipster-initial").css({
                                "-moz-animation-duration": e.__options.animationDuration[0] + "ms",
                                "-ms-animation-duration": e.__options.animationDuration[0] + "ms",
                                "-o-animation-duration": e.__options.animationDuration[0] + "ms",
                                "-webkit-animation-duration": e.__options.animationDuration[0] + "ms",
                                "animation-duration": e.__options.animationDuration[0] + "ms",
                                "transition-duration": e.__options.animationDuration[0] + "ms"
                            }), setTimeout(function() {
                                "closed" != e.__state && (e._$tooltip.addClass("tooltipster-show").removeClass("tooltipster-initial"), e.__options.animationDuration[0] > 0 && e._$tooltip.delay(e.__options.animationDuration[0]), e._$tooltip.queue(i))
                            }, 0)) : e._$tooltip.css("display", "none").fadeIn(e.__options.animationDuration[0], i), e.__trackerStart(), a(h.window).on("resize." + e.__namespace + "-triggerClose", function(b) {
                                var c = a(document.activeElement);
                                (c.is("input") || c.is("textarea")) && a.contains(e._$tooltip[0], c[0]) || e.reposition(b)
                            }).on("scroll." + e.__namespace + "-triggerClose", function(a) {
                                e.__scrollHandler(a)
                            }), e.__$originParents = e._$origin.parents(), e.__$originParents.each(function(b, c) {
                                a(c).on("scroll." + e.__namespace + "-triggerClose", function(a) {
                                    e.__scrollHandler(a)
                                })
                            }), e.__options.triggerClose.mouseleave || e.__options.triggerClose.touchleave && h.hasTouchCapability) {
                            e._on("dismissable", function(a) {
                                a.dismissable ? a.delay ? (m = setTimeout(function() {
                                    e._close(a.event)
                                }, a.delay), e.__timeouts.close.push(m)) : e._close(a) : clearTimeout(m)
                            });
                            var j = e._$origin,
                                k = "",
                                l = "",
                                m = null;
                            e.__options.interactive && (j = j.add(e._$tooltip)), e.__options.triggerClose.mouseleave && (k += "mouseenter." + e.__namespace + "-triggerClose ", l += "mouseleave." + e.__namespace + "-triggerClose "), e.__options.triggerClose.touchleave && h.hasTouchCapability && (k += "touchstart." + e.__namespace + "-triggerClose", l += "touchend." + e.__namespace + "-triggerClose touchcancel." + e.__namespace + "-triggerClose"), j.on(l, function(a) {
                                if (e._touchIsTouchEvent(a) || !e._touchIsEmulatedEvent(a)) {
                                    var b = "mouseleave" == a.type ? e.__options.delay : e.__options.delayTouch;
                                    e._trigger({
                                        delay: b[1],
                                        dismissable: !0,
                                        event: a,
                                        type: "dismissable"
                                    })
                                }
                            }).on(k, function(a) {
                                !e._touchIsTouchEvent(a) && e._touchIsEmulatedEvent(a) || e._trigger({
                                    dismissable: !1,
                                    event: a,
                                    type: "dismissable"
                                })
                            })
                        }
                        e.__options.triggerClose.originClick && e._$origin.on("click." + e.__namespace + "-triggerClose", function(a) {
                            e._touchIsTouchEvent(a) || e._touchIsEmulatedEvent(a) || e._close(a)
                        }), (e.__options.triggerClose.click || e.__options.triggerClose.tap && h.hasTouchCapability) && setTimeout(function() {
                            if ("closed" != e.__state) {
                                var b = "";
                                e.__options.triggerClose.click && (b += "click." + e.__namespace + "-triggerClose "), e.__options.triggerClose.tap && h.hasTouchCapability && (b += "touchend." + e.__namespace + "-triggerClose"), a("body").on(b, function(b) {
                                    e._touchIsMeaningfulEvent(b) && (e._touchRecordEvent(b), e.__options.interactive && a.contains(e._$tooltip[0], b.target) || e._close(b))
                                }), e.__options.triggerClose.tap && h.hasTouchCapability && a("body").on("touchstart." + e.__namespace + "-triggerClose", function(a) {
                                    e._touchRecordEvent(a)
                                })
                            }
                        }, 0), e._trigger("ready"), e.__options.functionReady && e.__options.functionReady.call(e, e, {
                            origin: e._$origin[0],
                            tooltip: e._$tooltip[0]
                        })
                    }
                    if (e.__options.timer > 0) {
                        var m = setTimeout(function() {
                            e._close()
                        }, e.__options.timer + g);
                        e.__timeouts.close.push(m)
                    }
                }
            }
            return e
        },
        _openShortly: function(a) {
            var b = this,
                c = !0;
            if ("stable" != b.__state && "appearing" != b.__state && !b.__timeouts.open && (b._trigger({
                    type: "start",
                    event: a,
                    stop: function() {
                        c = !1
                    }
                }), c)) {
                var d = 0 == a.type.indexOf("touch") ? b.__options.delayTouch : b.__options.delay;
                d[0] ? b.__timeouts.open = setTimeout(function() {
                    b.__timeouts.open = null, b.__pointerIsOverOrigin && b._touchIsMeaningfulEvent(a) ? (b._trigger("startend"), b._open(a)) : b._trigger("startcancel")
                }, d[0]) : (b._trigger("startend"), b._open(a))
            }
            return b
        },
        _optionsExtract: function(b, c) {
            var d = this,
                e = a.extend(!0, {}, c),
                f = d.__options[b];
            return f || (f = {}, a.each(c, function(a, b) {
                var c = d.__options[a];
                void 0 !== c && (f[a] = c)
            })), a.each(e, function(b, c) {
                void 0 !== f[b] && ("object" != typeof c || c instanceof Array || null == c || "object" != typeof f[b] || f[b] instanceof Array || null == f[b] ? e[b] = f[b] : a.extend(e[b], f[b]))
            }), e
        },
        _plug: function(b) {
            var c = a.tooltipster._plugin(b);
            if (!c) throw new Error('The "' + b + '" plugin is not defined');
            return c.instance && a.tooltipster.__bridge(c.instance, this, c.name), this
        },
        _touchIsEmulatedEvent: function(a) {
            for (var b = !1, c = (new Date).getTime(), d = this.__touchEvents.length - 1; d >= 0; d--) {
                var e = this.__touchEvents[d];
                if (!(c - e.time < 500)) break;
                e.target === a.target && (b = !0)
            }
            return b
        },
        _touchIsMeaningfulEvent: function(a) {
            return this._touchIsTouchEvent(a) && !this._touchSwiped(a.target) || !this._touchIsTouchEvent(a) && !this._touchIsEmulatedEvent(a)
        },
        _touchIsTouchEvent: function(a) {
            return 0 == a.type.indexOf("touch")
        },
        _touchRecordEvent: function(a) {
            return this._touchIsTouchEvent(a) && (a.time = (new Date).getTime(), this.__touchEvents.push(a)), this
        },
        _touchSwiped: function(a) {
            for (var b = !1, c = this.__touchEvents.length - 1; c >= 0; c--) {
                var d = this.__touchEvents[c];
                if ("touchmove" == d.type) {
                    b = !0;
                    break
                }
                if ("touchstart" == d.type && a === d.target) break
            }
            return b
        },
        _trigger: function() {
            var b = Array.prototype.slice.apply(arguments);
            return "string" == typeof b[0] && (b[0] = {
                type: b[0]
            }), b[0].instance = this, b[0].origin = this._$origin ? this._$origin[0] : null, b[0].tooltip = this._$tooltip ? this._$tooltip[0] : null, this.__$emitterPrivate.trigger.apply(this.__$emitterPrivate, b), a.tooltipster._trigger.apply(a.tooltipster, b), this.__$emitterPublic.trigger.apply(this.__$emitterPublic, b), this
        },
        _unplug: function(b) {
            var c = this;
            if (c[b]) {
                var d = a.tooltipster._plugin(b);
                d.instance && a.each(d.instance, function(a, d) {
                    c[a] && c[a].bridged === c[b] && delete c[a]
                }), c[b].__destroy && c[b].__destroy(), delete c[b]
            }
            return c
        },
        close: function(a) {
            return this.__destroyed ? this.__destroyError() : this._close(null, a), this
        },
        content: function(a) {
            var b = this;
            if (void 0 === a) return b.__Content;
            if (b.__destroyed) b.__destroyError();
            else if (b.__contentSet(a), null !== b.__Content) {
                if ("closed" !== b.__state && (b.__contentInsert(), b.reposition(), b.__options.updateAnimation))
                    if (h.hasTransitions) {
                        var c = b.__options.updateAnimation;
                        b._$tooltip.addClass("tooltipster-update-" + c), setTimeout(function() {
                            "closed" != b.__state && b._$tooltip.removeClass("tooltipster-update-" + c)
                        }, 1e3)
                    } else b._$tooltip.fadeTo(200, .5, function() {
                        "closed" != b.__state && b._$tooltip.fadeTo(200, 1)
                    })
            } else b._close();
            return b
        },
        destroy: function() {
            var b = this;
            return b.__destroyed ? b.__destroyError() : b.__destroying || (b.__destroying = !0, b._close(null, function() {
                b._trigger("destroy"), b.__destroying = !1, b.__destroyed = !0, b._$origin.removeData(b.__namespace).off("." + b.__namespace + "-triggerOpen"), a("body").off("." + b.__namespace + "-triggerOpen");
                var c = b._$origin.data("tooltipster-ns");
                if (c)
                    if (1 === c.length) {
                        var d = null;
                        "previous" == b.__options.restoration ? d = b._$origin.data("tooltipster-initialTitle") : "current" == b.__options.restoration && (d = "string" == typeof b.__Content ? b.__Content : a("<div></div>").append(b.__Content).html()), d && b._$origin.attr("title", d), b._$origin.removeClass("tooltipstered"), b._$origin.removeData("tooltipster-ns").removeData("tooltipster-initialTitle")
                    } else c = a.grep(c, function(a, c) {
                        return a !== b.__namespace
                    }), b._$origin.data("tooltipster-ns", c);
                b._trigger("destroyed"), b._off(), b.off(), b.__Content = null, b.__$emitterPrivate = null, b.__$emitterPublic = null, b.__options.parent = null, b._$origin = null, b._$tooltip = null, a.tooltipster.__instancesLatestArr = a.grep(a.tooltipster.__instancesLatestArr, function(a, c) {
                    return b !== a
                }), clearInterval(b.__garbageCollector)
            })), b
        },
        disable: function() {
            return this.__destroyed ? (this.__destroyError(), this) : (this._close(), this.__enabled = !1, this)
        },
        elementOrigin: function() {
            return this.__destroyed ? void this.__destroyError() : this._$origin[0]
        },
        elementTooltip: function() {
            return this._$tooltip ? this._$tooltip[0] : null
        },
        enable: function() {
            return this.__enabled = !0, this
        },
        hide: function(a) {
            return this.close(a)
        },
        instance: function() {
            return this
        },
        off: function() {
            return this.__destroyed || this.__$emitterPublic.off.apply(this.__$emitterPublic, Array.prototype.slice.apply(arguments)), this
        },
        on: function() {
            return this.__destroyed ? this.__destroyError() : this.__$emitterPublic.on.apply(this.__$emitterPublic, Array.prototype.slice.apply(arguments)), this
        },
        one: function() {
            return this.__destroyed ? this.__destroyError() : this.__$emitterPublic.one.apply(this.__$emitterPublic, Array.prototype.slice.apply(arguments)), this
        },
        open: function(a) {
            return this.__destroyed || this.__destroying ? this.__destroyError() : this._open(null, a), this
        },
        option: function(b, c) {
            return void 0 === c ? this.__options[b] : (this.__destroyed ? this.__destroyError() : (this.__options[b] = c, this.__optionsFormat(), a.inArray(b, ["trigger", "triggerClose", "triggerOpen"]) >= 0 && this.__prepareOrigin(), "selfDestruction" === b && this.__prepareGC()), this)
        },
        reposition: function(a, b) {
            var c = this;
            return c.__destroyed ? c.__destroyError() : "closed" != c.__state && d(c._$origin) && (b || d(c._$tooltip)) && (b || c._$tooltip.detach(), c.__Geometry = c.__geometry(), c._trigger({
                type: "reposition",
                event: a,
                helper: {
                    geo: c.__Geometry
                }
            })), c
        },
        show: function(a) {
            return this.open(a)
        },
        status: function() {
            return {
                destroyed: this.__destroyed,
                destroying: this.__destroying,
                enabled: this.__enabled,
                open: "closed" !== this.__state,
                state: this.__state
            }
        },
        triggerHandler: function() {
            return this.__destroyed ? this.__destroyError() : this.__$emitterPublic.triggerHandler.apply(this.__$emitterPublic, Array.prototype.slice.apply(arguments)), this
        }
    }, a.fn.tooltipster = function() {
        var b = Array.prototype.slice.apply(arguments),
            c = "You are using a single HTML element as content for several tooltips. You probably want to set the contentCloning option to TRUE.";
        if (0 === this.length) return this;
        if ("string" == typeof b[0]) {
            var d = "#*$~&";
            return this.each(function() {
                var e = a(this).data("tooltipster-ns"),
                    f = e ? a(this).data(e[0]) : null;
                if (!f) throw new Error("You called Tooltipster's \"" + b[0] + '" method on an uninitialized element');
                if ("function" != typeof f[b[0]]) throw new Error('Unknown method "' + b[0] + '"');
                this.length > 1 && "content" == b[0] && (b[1] instanceof a || "object" == typeof b[1] && null != b[1] && b[1].tagName) && !f.__options.contentCloning && f.__options.debug && console.log(c);
                var g = f[b[0]](b[1], b[2]);
                return g !== f || "instance" === b[0] ? (d = g, !1) : void 0
            }), "#*$~&" !== d ? d : this
        }
        a.tooltipster.__instancesLatestArr = [];
        var e = b[0] && void 0 !== b[0].multiple,
            g = e && b[0].multiple || !e && f.multiple,
            h = b[0] && void 0 !== b[0].content,
            i = h && b[0].content || !h && f.content,
            j = b[0] && void 0 !== b[0].contentCloning,
            k = j && b[0].contentCloning || !j && f.contentCloning,
            l = b[0] && void 0 !== b[0].debug,
            m = l && b[0].debug || !l && f.debug;
        return this.length > 1 && (i instanceof a || "object" == typeof i && null != i && i.tagName) && !k && m && console.log(c), this.each(function() {
            var c = !1,
                d = a(this),
                e = d.data("tooltipster-ns"),
                f = null;
            e ? g ? c = !0 : m && (console.log("Tooltipster: one or more tooltips are already attached to the element below. Ignoring."), console.log(this)) : c = !0, c && (f = new a.Tooltipster(this, b[0]), e || (e = []), e.push(f.__namespace), d.data("tooltipster-ns", e), d.data(f.__namespace, f), f.__options.functionInit && f.__options.functionInit.call(f, f, {
                origin: this
            }), f._trigger("init")), a.tooltipster.__instancesLatestArr.push(f)
        }), this
    }, b.prototype = {
        __init: function(b) {
            this.__$tooltip = b, this.__$tooltip.css({
                left: 0,
                overflow: "hidden",
                position: "absolute",
                top: 0
            }).find(".tooltipster-content").css("overflow", "auto"), this.$container = a('<div class="tooltipster-ruler"></div>').append(this.__$tooltip).appendTo("body")
        },
        __forceRedraw: function() {
            var a = this.__$tooltip.parent();
            this.__$tooltip.detach(), this.__$tooltip.appendTo(a)
        },
        constrain: function(a, b) {
            return this.constraints = {
                width: a,
                height: b
            }, this.__$tooltip.css({
                display: "block",
                height: "",
                overflow: "auto",
                width: a
            }), this
        },
        destroy: function() {
            this.__$tooltip.detach().find(".tooltipster-content").css({
                display: "",
                overflow: ""
            }), this.$container.remove()
        },
        free: function() {
            return this.constraints = null, this.__$tooltip.css({
                display: "",
                height: "",
                overflow: "visible",
                width: ""
            }), this
        },
        measure: function() {
            this.__forceRedraw();
            var a = this.__$tooltip[0].getBoundingClientRect(),
                b = {
                    size: {
                        height: a.height || a.bottom,
                        width: a.width || a.right
                    }
                };
            if (this.constraints) {
                var c = this.__$tooltip.find(".tooltipster-content"),
                    d = this.__$tooltip.outerHeight(),
                    e = c[0].getBoundingClientRect(),
                    f = {
                        height: d <= this.constraints.height,
                        width: a.width <= this.constraints.width && e.width >= c[0].scrollWidth - 1
                    };
                b.fits = f.height && f.width
            }
            return h.IE && h.IE <= 11 && b.size.width !== h.window.document.documentElement.clientWidth && (b.size.width = Math.ceil(b.size.width) + 1), b
        }
    };
    var j = navigator.userAgent.toLowerCase(); - 1 != j.indexOf("msie") ? h.IE = parseInt(j.split("msie")[1]) : -1 !== j.toLowerCase().indexOf("trident") && -1 !== j.indexOf(" rv:11") ? h.IE = 11 : -1 != j.toLowerCase().indexOf("edge/") && (h.IE = parseInt(j.toLowerCase().split("edge/")[1]));
    var k = "tooltipster.sideTip";
    return a.tooltipster._plugin({
        name: k,
        instance: {
            __defaults: function() {
                return {
                    arrow: !0,
                    distance: 6,
                    functionPosition: null,
                    maxWidth: null,
                    minIntersection: 16,
                    minWidth: 0,
                    position: null,
                    side: "top",
                    viewportAware: !0
                }
            },
            __init: function(a) {
                var b = this;
                b.__instance = a, b.__namespace = "tooltipster-sideTip-" + Math.round(1e6 * Math.random()), b.__previousState = "closed", b.__options, b.__optionsFormat(), b.__instance._on("state." + b.__namespace, function(a) {
                    "closed" == a.state ? b.__close() : "appearing" == a.state && "closed" == b.__previousState && b.__create(), b.__previousState = a.state
                }), b.__instance._on("options." + b.__namespace, function() {
                    b.__optionsFormat()
                }), b.__instance._on("reposition." + b.__namespace, function(a) {
                    b.__reposition(a.event, a.helper)
                })
            },
            __close: function() {
                this.__instance.content() instanceof a && this.__instance.content().detach(), this.__instance._$tooltip.remove(), this.__instance._$tooltip = null
            },
            __create: function() {
                var b = a('<div class="tooltipster-base tooltipster-sidetip"><div class="tooltipster-box"><div class="tooltipster-content"></div></div><div class="tooltipster-arrow"><div class="tooltipster-arrow-uncropped"><div class="tooltipster-arrow-border"></div><div class="tooltipster-arrow-background"></div></div></div></div>');
                this.__options.arrow || b.find(".tooltipster-box").css("margin", 0).end().find(".tooltipster-arrow").hide(), this.__options.minWidth && b.css("min-width", this.__options.minWidth + "px"), this.__options.maxWidth && b.css("max-width", this.__options.maxWidth + "px"), this.__instance._$tooltip = b, this.__instance._trigger("created")
            },
            __destroy: function() {
                this.__instance._off("." + self.__namespace)
            },
            __optionsFormat: function() {
                var b = this;
                if (b.__options = b.__instance._optionsExtract(k, b.__defaults()),
                    b.__options.position && (b.__options.side = b.__options.position), "object" != typeof b.__options.distance && (b.__options.distance = [b.__options.distance]), b.__options.distance.length < 4 && (void 0 === b.__options.distance[1] && (b.__options.distance[1] = b.__options.distance[0]), void 0 === b.__options.distance[2] && (b.__options.distance[2] = b.__options.distance[0]), void 0 === b.__options.distance[3] && (b.__options.distance[3] = b.__options.distance[1]), b.__options.distance = {
                        top: b.__options.distance[0],
                        right: b.__options.distance[1],
                        bottom: b.__options.distance[2],
                        left: b.__options.distance[3]
                    }), "string" == typeof b.__options.side) {
                    var c = {
                        top: "bottom",
                        right: "left",
                        bottom: "top",
                        left: "right"
                    };
                    b.__options.side = [b.__options.side, c[b.__options.side]], "left" == b.__options.side[0] || "right" == b.__options.side[0] ? b.__options.side.push("top", "bottom") : b.__options.side.push("right", "left")
                }
                6 === a.tooltipster._env.IE && b.__options.arrow !== !0 && (b.__options.arrow = !1)
            },
            __reposition: function(b, c) {
                var d, e = this,
                    f = e.__targetFind(c),
                    g = [];
                e.__instance._$tooltip.detach();
                var h = e.__instance._$tooltip.clone(),
                    i = a.tooltipster._getRuler(h),
                    j = !1,
                    k = e.__instance.option("animation");
                switch (k && h.removeClass("tooltipster-" + k), a.each(["window", "document"], function(d, k) {
                    var l = null;
                    if (e.__instance._trigger({
                            container: k,
                            helper: c,
                            satisfied: j,
                            takeTest: function(a) {
                                l = a
                            },
                            results: g,
                            type: "positionTest"
                        }), 1 == l || 0 != l && 0 == j && ("window" != k || e.__options.viewportAware))
                        for (var d = 0; d < e.__options.side.length; d++) {
                            var m = {
                                    horizontal: 0,
                                    vertical: 0
                                },
                                n = e.__options.side[d];
                            "top" == n || "bottom" == n ? m.vertical = e.__options.distance[n] : m.horizontal = e.__options.distance[n], e.__sideChange(h, n), a.each(["natural", "constrained"], function(a, d) {
                                if (l = null, e.__instance._trigger({
                                        container: k,
                                        event: b,
                                        helper: c,
                                        mode: d,
                                        results: g,
                                        satisfied: j,
                                        side: n,
                                        takeTest: function(a) {
                                            l = a
                                        },
                                        type: "positionTest"
                                    }), 1 == l || 0 != l && 0 == j) {
                                    var h = {
                                            container: k,
                                            distance: m,
                                            fits: null,
                                            mode: d,
                                            outerSize: null,
                                            side: n,
                                            size: null,
                                            target: f[n],
                                            whole: null
                                        },
                                        o = "natural" == d ? i.free() : i.constrain(c.geo.available[k][n].width - m.horizontal, c.geo.available[k][n].height - m.vertical),
                                        p = o.measure();
                                    if (h.size = p.size, h.outerSize = {
                                            height: p.size.height + m.vertical,
                                            width: p.size.width + m.horizontal
                                        }, "natural" == d ? c.geo.available[k][n].width >= h.outerSize.width && c.geo.available[k][n].height >= h.outerSize.height ? h.fits = !0 : h.fits = !1 : h.fits = p.fits, "window" == k && (h.fits ? "top" == n || "bottom" == n ? h.whole = c.geo.origin.windowOffset.right >= e.__options.minIntersection && c.geo.window.size.width - c.geo.origin.windowOffset.left >= e.__options.minIntersection : h.whole = c.geo.origin.windowOffset.bottom >= e.__options.minIntersection && c.geo.window.size.height - c.geo.origin.windowOffset.top >= e.__options.minIntersection : h.whole = !1), g.push(h), h.whole) j = !0;
                                    else if ("natural" == h.mode && (h.fits || h.size.width <= c.geo.available[k][n].width)) return !1
                                }
                            })
                        }
                }), e.__instance._trigger({
                    edit: function(a) {
                        g = a
                    },
                    event: b,
                    helper: c,
                    results: g,
                    type: "positionTested"
                }), g.sort(function(a, b) {
                    if (a.whole && !b.whole) return -1;
                    if (!a.whole && b.whole) return 1;
                    if (a.whole && b.whole) {
                        var c = e.__options.side.indexOf(a.side),
                            d = e.__options.side.indexOf(b.side);
                        return d > c ? -1 : c > d ? 1 : "natural" == a.mode ? -1 : 1
                    }
                    if (a.fits && !b.fits) return -1;
                    if (!a.fits && b.fits) return 1;
                    if (a.fits && b.fits) {
                        var c = e.__options.side.indexOf(a.side),
                            d = e.__options.side.indexOf(b.side);
                        return d > c ? -1 : c > d ? 1 : "natural" == a.mode ? -1 : 1
                    }
                    return "document" == a.container && "bottom" == a.side && "natural" == a.mode ? -1 : 1
                }), d = g[0], d.coord = {}, d.side) {
                    case "left":
                    case "right":
                        d.coord.top = Math.floor(d.target - d.size.height / 2);
                        break;
                    case "bottom":
                    case "top":
                        d.coord.left = Math.floor(d.target - d.size.width / 2)
                }
                switch (d.side) {
                    case "left":
                        d.coord.left = c.geo.origin.windowOffset.left - d.outerSize.width;
                        break;
                    case "right":
                        d.coord.left = c.geo.origin.windowOffset.right + d.distance.horizontal;
                        break;
                    case "top":
                        d.coord.top = c.geo.origin.windowOffset.top - d.outerSize.height;
                        break;
                    case "bottom":
                        d.coord.top = c.geo.origin.windowOffset.bottom + d.distance.vertical
                }
                "window" == d.container ? "top" == d.side || "bottom" == d.side ? d.coord.left < 0 ? c.geo.origin.windowOffset.right - this.__options.minIntersection >= 0 ? d.coord.left = 0 : d.coord.left = c.geo.origin.windowOffset.right - this.__options.minIntersection - 1 : d.coord.left > c.geo.window.size.width - d.size.width && (c.geo.origin.windowOffset.left + this.__options.minIntersection <= c.geo.window.size.width ? d.coord.left = c.geo.window.size.width - d.size.width : d.coord.left = c.geo.origin.windowOffset.left + this.__options.minIntersection + 1 - d.size.width) : d.coord.top < 0 ? c.geo.origin.windowOffset.bottom - this.__options.minIntersection >= 0 ? d.coord.top = 0 : d.coord.top = c.geo.origin.windowOffset.bottom - this.__options.minIntersection - 1 : d.coord.top > c.geo.window.size.height - d.size.height && (c.geo.origin.windowOffset.top + this.__options.minIntersection <= c.geo.window.size.height ? d.coord.top = c.geo.window.size.height - d.size.height : d.coord.top = c.geo.origin.windowOffset.top + this.__options.minIntersection + 1 - d.size.height) : (d.coord.left > c.geo.window.size.width - d.size.width && (d.coord.left = c.geo.window.size.width - d.size.width), d.coord.left < 0 && (d.coord.left = 0)), e.__sideChange(h, d.side), c.tooltipClone = h[0], c.tooltipParent = e.__instance.option("parent").parent[0], c.mode = d.mode, c.whole = d.whole, c.origin = e.__instance._$origin[0], c.tooltip = e.__instance._$tooltip[0], delete d.container, delete d.fits, delete d.mode, delete d.outerSize, delete d.whole, d.distance = d.distance.horizontal || d.distance.vertical;
                var l = a.extend(!0, {}, d);
                if (e.__instance._trigger({
                        edit: function(a) {
                            d = a
                        },
                        event: b,
                        helper: c,
                        position: l,
                        type: "position"
                    }), e.__options.functionPosition) {
                    var m = e.__options.functionPosition.call(e, e.__instance, c, l);
                    m && (d = m)
                }
                i.destroy();
                var n, o;
                "top" == d.side || "bottom" == d.side ? (n = {
                    prop: "left",
                    val: d.target - d.coord.left
                }, o = d.size.width - this.__options.minIntersection) : (n = {
                    prop: "top",
                    val: d.target - d.coord.top
                }, o = d.size.height - this.__options.minIntersection), n.val < this.__options.minIntersection ? n.val = this.__options.minIntersection : n.val > o && (n.val = o);
                var p;
                p = c.geo.origin.fixedLineage ? c.geo.origin.windowOffset : {
                    left: c.geo.origin.windowOffset.left + c.geo.window.scroll.left,
                    top: c.geo.origin.windowOffset.top + c.geo.window.scroll.top
                }, d.coord = {
                    left: p.left + (d.coord.left - c.geo.origin.windowOffset.left),
                    top: p.top + (d.coord.top - c.geo.origin.windowOffset.top)
                }, e.__sideChange(e.__instance._$tooltip, d.side), c.geo.origin.fixedLineage ? e.__instance._$tooltip.css("position", "fixed") : e.__instance._$tooltip.css("position", ""), e.__instance._$tooltip.css({
                    left: d.coord.left,
                    top: d.coord.top,
                    height: d.size.height,
                    width: d.size.width
                }).find(".tooltipster-arrow").css({
                    left: "",
                    top: ""
                }).css(n.prop, n.val), e.__instance._$tooltip.appendTo(e.__instance.option("parent")), e.__instance._trigger({
                    type: "repositioned",
                    event: b,
                    position: d
                })
            },
            __sideChange: function(a, b) {
                a.removeClass("tooltipster-bottom").removeClass("tooltipster-left").removeClass("tooltipster-right").removeClass("tooltipster-top").addClass("tooltipster-" + b)
            },
            __targetFind: function(a) {
                var b = {},
                    c = this.__instance._$origin[0].getClientRects();
                if (c.length > 1) {
                    var d = this.__instance._$origin.css("opacity");
                    1 == d && (this.__instance._$origin.css("opacity", .99), c = this.__instance._$origin[0].getClientRects(), this.__instance._$origin.css("opacity", 1))
                }
                if (c.length < 2) b.top = Math.floor(a.geo.origin.windowOffset.left + a.geo.origin.size.width / 2), b.bottom = b.top, b.left = Math.floor(a.geo.origin.windowOffset.top + a.geo.origin.size.height / 2), b.right = b.left;
                else {
                    var e = c[0];
                    b.top = Math.floor(e.left + (e.right - e.left) / 2), e = c.length > 2 ? c[Math.ceil(c.length / 2) - 1] : c[0], b.right = Math.floor(e.top + (e.bottom - e.top) / 2), e = c[c.length - 1], b.bottom = Math.floor(e.left + (e.right - e.left) / 2), e = c.length > 2 ? c[Math.ceil((c.length + 1) / 2) - 1] : c[c.length - 1], b.left = Math.floor(e.top + (e.bottom - e.top) / 2)
                }
                return b
            }
        }
    }), a
});
/* --------------- */

InitializeOverlayScript();


/* 2017-09-01 */
$('#dnc_opt_out_link_2').click(function() {
    $('#dnc_opt_out_div').show();

});
$('#DNC_OPT_OUT').click(function() {
    if ($(this).prop('checked')) {
        $('#TERMS').removeAttr('required');
        $('#TERMS').removeAttr('checked');
    } else {
        $('#TERMS').attr('required', 'required');
    }
});

$('#TERMS').click(function() {
    if ($(this).prop('checked')) {
        $('#DNC_OPT_OUT').removeAttr('checked');
    } else {
        $('#DNC_OPT_OUT').attr('checked', 'checked');
    }
});




/* 2019-02-06 <!-- Generate a TrustedForm Certificate --> */
//<script type = "text/javascript">
if ($("#HOME_PHONE_AREA").length) {
    (function() {
        var field = 'xxTrustedFormCertUrl';
        var provideReferrer = false;
        var tf = document.createElement('script');
        tf.type = 'text/javascript';
        tf.async = true;
        tf.src = 'http' + ('https:' == document.location.protocol ? 's' : '') +
            '://api.trustedform.com/trustedform.js?provide_referrer=' + escape(provideReferrer) + '&field=' + escape(field) + '&l=' + new Date().getTime() + Math.random();
        var s = document.getElementsByTagName('script')[0];
        s.parentNode.insertBefore(tf, s);
    })();
}
//</script>
//<noscript><img src = "http://api.trustedform.com/ns.gif" /></noscript>



/* BROWSERINFORMATION CLIENT SIDE */

function isMobileDevice() {
    return (typeof window.orientation !== "undefined") || (navigator.userAgent.indexOf('IEMobile') !== -1);
};


//document.addEventListener('DOMContentLoaded', init, false);

//function init() {
//    sparkAdsBlocked(function(blocked) {
//        $.get("/AjaxHandler.aspx?ab=" + (blocked ? "1" : "0") + "&sw=" + $(window).width() + "&dw=" + $(document).width() + "&im=" + (isMobileDevice() ? "1" : "0"), function(data) {});

//        //if (blocked) {
//        //console.log('ads are blocked');  //document.getElementById('result').innerHTML = 'ads are blocked';
//        //$.get("/AjaxHandler.aspx?adb=1", function (data) { });
//        //} else {
//        //console.log('ads are not blocked'); //document.getElementById('result').innerHTML = 'ads are not blocked';
//        //}
//    })
//}

function sparkAdsBlocked(callback) {
    var testURL = 'https://pagead2.googlesyndication.com/pagead/js/adsbygoogle.js'

    var myInit = {
        method: 'HEAD',
        mode: 'no-cors'
    };

    var mySparkRequest = new Request(testURL, myInit);

    fetch(mySparkRequest).then(function(response) {
        return response;
    }).then(function(response) {
        console.log(response);
        callback(false)
    }).catch(function(e) {
        console.log(e)
        callback(true)
    });
}
/* END ADBLOCK DETECT */



/*!
 * Parsley.js
 * Version 2.7.0 - built Wed, Mar 1st 2017, 3:53 pm
 * http://parsleyjs.org
 * Guillaume Potier - <guillaume@wisembly.com>
 * Marc-Andre Lafortune - <petroselinum@marc-andre.ca>
 * MIT Licensed
 */

// The source code below is generated by babel as
// Parsley is written in ECMAScript 6
//
var _slice = Array.prototype.slice;

var _slicedToArray = (function() {
    function sliceIterator(arr, i) {
        var _arr = [];
        var _n = true;
        var _d = false;
        var _e = undefined;
        try {
            for (var _i = arr[Symbol.iterator](), _s; !(_n = (_s = _i.next()).done); _n = true) {
                _arr.push(_s.value);
                if (i && _arr.length === i) break;
            }
        } catch (err) {
            _d = true;
            _e = err;
        } finally {
            try {
                if (!_n && _i['return']) _i['return']();
            } finally {
                if (_d) throw _e;
            }
        }
        return _arr;
    }
    return function(arr, i) {
        if (Array.isArray(arr)) {
            return arr;
        } else if (Symbol.iterator in Object(arr)) {
            return sliceIterator(arr, i);
        } else {
            throw new TypeError('Invalid attempt to destructure non-iterable instance');
        }
    };
})();

function _toConsumableArray(arr) {
    if (Array.isArray(arr)) {
        for (var i = 0, arr2 = Array(arr.length); i < arr.length; i++) arr2[i] = arr[i];
        return arr2;
    } else {
        return Array.from(arr);
    }
}

(function(global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? module.exports = factory(require('jquery')) : typeof define === 'function' && define.amd ? define(['jquery'], factory) : global.parsley = factory(global.jQuery);
})(this, function($) {
    'use strict';

    var globalID = 1;
    var pastWarnings = {};

    var Utils__Utils = {
        // Parsley DOM-API
        // returns object from dom attributes and values
        attr: function attr($element, namespace, obj) {
            var i;
            var attribute;
            var attributes;
            var regex = new RegExp('^' + namespace, 'i');

            if ('undefined' === typeof obj) obj = {};
            else {
                // Clear all own properties. This won't affect prototype's values
                for (i in obj) {
                    if (obj.hasOwnProperty(i)) delete obj[i];
                }
            }

            if ('undefined' === typeof $element || 'undefined' === typeof $element[0]) return obj;

            attributes = $element[0].attributes;
            for (i = attributes.length; i--;) {
                attribute = attributes[i];

                if (attribute && attribute.specified && regex.test(attribute.name)) {
                    obj[this.camelize(attribute.name.slice(namespace.length))] = this.deserializeValue(attribute.value);
                }
            }

            return obj;
        },

        checkAttr: function checkAttr($element, namespace, _checkAttr) {
            return $element.is('[' + namespace + _checkAttr + ']');
        },

        setAttr: function setAttr($element, namespace, attr, value) {
            $element[0].setAttribute(this.dasherize(namespace + attr), String(value));
        },

        generateID: function generateID() {
            return '' + globalID++;
        },

        /** Third party functions **/
        // Zepto deserialize function
        deserializeValue: function deserializeValue(value) {
            var num;

            try {
                return value ? value == "true" || (value == "false" ? false : value == "null" ? null : !isNaN(num = Number(value)) ? num : /^[\[\{]/.test(value) ? $.parseJSON(value) : value) : value;
            } catch (e) {
                return value;
            }
        },

        // Zepto camelize function
        camelize: function camelize(str) {
            return str.replace(/-+(.)?/g, function(match, chr) {
                return chr ? chr.toUpperCase() : '';
            });
        },

        // Zepto dasherize function
        dasherize: function dasherize(str) {
            return str.replace(/::/g, '/').replace(/([A-Z]+)([A-Z][a-z])/g, '$1_$2').replace(/([a-z\d])([A-Z])/g, '$1_$2').replace(/_/g, '-').toLowerCase();
        },

        warn: function warn() {
            var _window$console;

            if (window.console && 'function' === typeof window.console.warn)(_window$console = window.console).warn.apply(_window$console, arguments);
        },

        warnOnce: function warnOnce(msg) {
            if (!pastWarnings[msg]) {
                pastWarnings[msg] = true;
                this.warn.apply(this, arguments);
            }
        },

        _resetWarnings: function _resetWarnings() {
            pastWarnings = {};
        },

        trimString: function trimString(string) {
            return string.replace(/^\s+|\s+$/g, '');
        },

        parse: {
            date: function date(string) {
                var parsed = string.match(/^(\d{4,})-(\d\d)-(\d\d)$/);
                if (!parsed) return null;

                var _parsed$map = parsed.map(function(x) {
                    return parseInt(x, 10);
                });

                var _parsed$map2 = _slicedToArray(_parsed$map, 4);

                var _ = _parsed$map2[0];
                var year = _parsed$map2[1];
                var month = _parsed$map2[2];
                var day = _parsed$map2[3];

                var date = new Date(year, month - 1, day);
                if (date.getFullYear() !== year || date.getMonth() + 1 !== month || date.getDate() !== day) return null;
                return date;
            },
            string: function string(_string) {
                return _string;
            },
            integer: function integer(string) {
                if (isNaN(string)) return null;
                return parseInt(string, 10);
            },
            number: function number(string) {
                if (isNaN(string)) throw null;
                return parseFloat(string);
            },
            'boolean': function _boolean(string) {
                return !/^\s*false\s*$/i.test(string);
            },
            object: function object(string) {
                return Utils__Utils.deserializeValue(string);
            },
            regexp: function regexp(_regexp) {
                var flags = '';

                // Test if RegExp is literal, if not, nothing to be done, otherwise, we need to isolate flags and pattern
                if (/^\/.*\/(?:[gimy]*)$/.test(_regexp)) {
                    // Replace the regexp literal string with the first match group: ([gimy]*)
                    // If no flag is present, this will be a blank string
                    flags = _regexp.replace(/.*\/([gimy]*)$/, '$1');
                    // Again, replace the regexp literal string with the first match group:
                    // everything excluding the opening and closing slashes and the flags
                    _regexp = _regexp.replace(new RegExp('^/(.*?)/' + flags + '$'), '$1');
                } else {
                    // Anchor regexp:
                    _regexp = '^' + _regexp + '$';
                }
                return new RegExp(_regexp, flags);
            }
        },

        parseRequirement: function parseRequirement(requirementType, string) {
            var converter = this.parse[requirementType || 'string'];
            if (!converter) throw 'Unknown requirement specification: "' + requirementType + '"';
            var converted = converter(string);
            if (converted === null) throw 'Requirement is not a ' + requirementType + ': "' + string + '"';
            return converted;
        },

        namespaceEvents: function namespaceEvents(events, namespace) {
            events = this.trimString(events || '').split(/\s+/);
            if (!events[0]) return '';
            return $.map(events, function(evt) {
                return evt + '.' + namespace;
            }).join(' ');
        },

        difference: function difference(array, remove) {
            // This is O(N^2), should be optimized
            var result = [];
            $.each(array, function(_, elem) {
                if (remove.indexOf(elem) == -1) result.push(elem);
            });
            return result;
        },

        // Alter-ego to native Promise.all, but for jQuery
        all: function all(promises) {
            // jQuery treats $.when() and $.when(singlePromise) differently; let's avoid that and add spurious elements
            return $.when.apply($, _toConsumableArray(promises).concat([42, 42]));
        },

        // Object.create polyfill, see https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Object/create#Polyfill
        objectCreate: Object.create || (function() {
            var Object = function Object() {};
            return function(prototype) {
                if (arguments.length > 1) {
                    throw Error('Second argument not supported');
                }
                if (typeof prototype != 'object') {
                    throw TypeError('Argument must be an object');
                }
                Object.prototype = prototype;
                var result = new Object();
                Object.prototype = null;
                return result;
            };
        })(),

        _SubmitSelector: 'input[type="submit"], button:submit'
    };

    var Utils__default = Utils__Utils;

    // All these options could be overriden and specified directly in DOM using
    // `data-parsley-` default DOM-API
    // eg: `inputs` can be set in DOM using `data-parsley-inputs="input, textarea"`
    // eg: `data-parsley-stop-on-first-failing-constraint="false"`

    var Defaults = {
        // ### General

        // Default data-namespace for DOM API
        namespace: 'data-parsley-',

        // Supported inputs by default
        inputs: 'input, textarea, select',

        // Excluded inputs by default
        excluded: 'input[type=button], input[type=submit], input[type=reset], input[type=hidden]',

        // Stop validating field on highest priority failing constraint
        priorityEnabled: true,

        // ### Field only

        // identifier used to group together inputs (e.g. radio buttons...)
        multiple: null,

        // identifier (or array of identifiers) used to validate only a select group of inputs
        group: null,

        // ### UI
        // Enable\Disable error messages
        uiEnabled: true,

        // Key events threshold before validation
        validationThreshold: 3,

        // Focused field on form validation error. 'first'|'last'|'none'
        focus: 'first',

        // event(s) that will trigger validation before first failure. eg: `input`...
        trigger: false,

        // event(s) that will trigger validation after first failure.
        triggerAfterFailure: 'input',

        // Class that would be added on every failing validation Parsley field
        errorClass: 'parsley-error',

        // Same for success validation
        successClass: 'parsley-success',

        // Return the `$element` that will receive these above success or error classes
        // Could also be (and given directly from DOM) a valid selector like `'#div'`
        classHandler: function classHandler(Field) {},

        // Return the `$element` where errors will be appended
        // Could also be (and given directly from DOM) a valid selector like `'#div'`
        errorsContainer: function errorsContainer(Field) {},

        // ul elem that would receive errors' list
        errorsWrapper: '<ul class="parsley-errors-list"></ul>',

        // li elem that would receive error message
        errorTemplate: '<li></li>'
    };

    var Base = function Base() {
        this.__id__ = Utils__default.generateID();
    };

    Base.prototype = {
        asyncSupport: true, // Deprecated

        _pipeAccordingToValidationResult: function _pipeAccordingToValidationResult() {
            var _this = this;

            var pipe = function pipe() {
                var r = $.Deferred();
                if (true !== _this.validationResult) r.reject();
                return r.resolve().promise();
            };
            return [pipe, pipe];
        },

        actualizeOptions: function actualizeOptions() {
            Utils__default.attr(this.$element, this.options.namespace, this.domOptions);
            if (this.parent && this.parent.actualizeOptions) this.parent.actualizeOptions();
            return this;
        },

        _resetOptions: function _resetOptions(initOptions) {
            this.domOptions = Utils__default.objectCreate(this.parent.options);
            this.options = Utils__default.objectCreate(this.domOptions);
            // Shallow copy of ownProperties of initOptions:
            for (var i in initOptions) {
                if (initOptions.hasOwnProperty(i)) this.options[i] = initOptions[i];
            }
            this.actualizeOptions();
        },

        _listeners: null,

        // Register a callback for the given event name
        // Callback is called with context as the first argument and the `this`
        // The context is the current parsley instance, or window.Parsley if global
        // A return value of `false` will interrupt the calls
        on: function on(name, fn) {
            this._listeners = this._listeners || {};
            var queue = this._listeners[name] = this._listeners[name] || [];
            queue.push(fn);

            return this;
        },

        // Deprecated. Use `on` instead
        subscribe: function subscribe(name, fn) {
            $.listenTo(this, name.toLowerCase(), fn);
        },

        // Unregister a callback (or all if none is given) for the given event name
        off: function off(name, fn) {
            var queue = this._listeners && this._listeners[name];
            if (queue) {
                if (!fn) {
                    delete this._listeners[name];
                } else {
                    for (var i = queue.length; i--;)
                        if (queue[i] === fn) queue.splice(i, 1);
                }
            }
            return this;
        },

        // Deprecated. Use `off`
        unsubscribe: function unsubscribe(name, fn) {
            $.unsubscribeTo(this, name.toLowerCase());
        },

        // Trigger an event of the given name
        // A return value of `false` interrupts the callback chain
        // Returns false if execution was interrupted
        trigger: function trigger(name, target, extraArg) {
            target = target || this;
            var queue = this._listeners && this._listeners[name];
            var result;
            var parentResult;
            if (queue) {
                for (var i = queue.length; i--;) {
                    result = queue[i].call(target, target, extraArg);
                    if (result === false) return result;
                }
            }
            if (this.parent) {
                return this.parent.trigger(name, target, extraArg);
            }
            return true;
        },

        asyncIsValid: function asyncIsValid(group, force) {
            Utils__default.warnOnce("asyncIsValid is deprecated; please use whenValid instead");
            return this.whenValid({
                group: group,
                force: force
            });
        },

        _findRelated: function _findRelated() {
            return this.options.multiple ? this.parent.$element.find('[' + this.options.namespace + 'multiple="' + this.options.multiple + '"]') : this.$element;
        }
    };

    var convertArrayRequirement = function convertArrayRequirement(string, length) {
        var m = string.match(/^\s*\[(.*)\]\s*$/);
        if (!m) throw 'Requirement is not an array: "' + string + '"';
        var values = m[1].split(',').map(Utils__default.trimString);
        if (values.length !== length) throw 'Requirement has ' + values.length + ' values when ' + length + ' are needed';
        return values;
    };

    var convertExtraOptionRequirement = function convertExtraOptionRequirement(requirementSpec, string, extraOptionReader) {
        var main = null;
        var extra = {};
        for (var key in requirementSpec) {
            if (key) {
                var value = extraOptionReader(key);
                if ('string' === typeof value) value = Utils__default.parseRequirement(requirementSpec[key], value);
                extra[key] = value;
            } else {
                main = Utils__default.parseRequirement(requirementSpec[key], string);
            }
        }
        return [main, extra];
    };

    // A Validator needs to implement the methods `validate` and `parseRequirements`

    var Validator = function Validator(spec) {
        $.extend(true, this, spec);
    };

    Validator.prototype = {
        // Returns `true` iff the given `value` is valid according the given requirements.
        validate: function validate(value, requirementFirstArg) {
            if (this.fn) {
                // Legacy style validator

                if (arguments.length > 3) // If more args then value, requirement, instance...
                    requirementFirstArg = [].slice.call(arguments, 1, -1); // Skip first arg (value) and last (instance), combining the rest
                return this.fn(value, requirementFirstArg);
            }

            if ($.isArray(value)) {
                if (!this.validateMultiple) throw 'Validator `' + this.name + '` does not handle multiple values';
                return this.validateMultiple.apply(this, arguments);
            } else {
                var instance = arguments[arguments.length - 1];
                if (this.validateDate && instance._isDateInput()) {
                    arguments[0] = Utils__default.parse.date(arguments[0]);
                    if (arguments[0] === null) return false;
                    return this.validateDate.apply(this, arguments);
                }
                if (this.validateNumber) {
                    if (isNaN(value)) return false;
                    arguments[0] = parseFloat(arguments[0]);
                    return this.validateNumber.apply(this, arguments);
                }
                if (this.validateString) {
                    return this.validateString.apply(this, arguments);
                }
                throw 'Validator `' + this.name + '` only handles multiple values';
            }
        },

        // Parses `requirements` into an array of arguments,
        // according to `this.requirementType`
        parseRequirements: function parseRequirements(requirements, extraOptionReader) {
            if ('string' !== typeof requirements) {
                // Assume requirement already parsed
                // but make sure we return an array
                return $.isArray(requirements) ? requirements : [requirements];
            }
            var type = this.requirementType;
            if ($.isArray(type)) {
                var values = convertArrayRequirement(requirements, type.length);
                for (var i = 0; i < values.length; i++) values[i] = Utils__default.parseRequirement(type[i], values[i]);
                return values;
            } else if ($.isPlainObject(type)) {
                return convertExtraOptionRequirement(type, requirements, extraOptionReader);
            } else {
                return [Utils__default.parseRequirement(type, requirements)];
            }
        },
        // Defaults:
        requirementType: 'string',

        priority: 2

    };

    var ValidatorRegistry = function ValidatorRegistry(validators, catalog) {
        this.__class__ = 'ValidatorRegistry';

        // Default Parsley locale is en
        this.locale = 'en';

        this.init(validators || {}, catalog || {});
    };

    var typeTesters = {
        email: /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$/i,

        // Follow https://www.w3.org/TR/html5/infrastructure.html#floating-point-numbers
        number: /^-?(\d*\.)?\d+(e[-+]?\d+)?$/i,

        integer: /^-?\d+$/,

        digits: /^\d+$/,

        alphanum: /^\w+$/i,

        date: {
            test: function test(value) {
                return Utils__default.parse.date(value) !== null;
            }
        },

        url: new RegExp("^" +
            // protocol identifier
            "(?:(?:https?|ftp)://)?" + // ** mod: make scheme optional
            // user:pass authentication
            "(?:\\S+(?::\\S*)?@)?" + "(?:" +
            // IP address exclusion
            // private & local networks
            // "(?!(?:10|127)(?:\\.\\d{1,3}){3})" +   // ** mod: allow local networks
            // "(?!(?:169\\.254|192\\.168)(?:\\.\\d{1,3}){2})" +  // ** mod: allow local networks
            // "(?!172\\.(?:1[6-9]|2\\d|3[0-1])(?:\\.\\d{1,3}){2})" +  // ** mod: allow local networks
            // IP address dotted notation octets
            // excludes loopback network 0.0.0.0
            // excludes reserved space >= 224.0.0.0
            // excludes network & broacast addresses
            // (first & last IP address of each class)
            "(?:[1-9]\\d?|1\\d\\d|2[01]\\d|22[0-3])" + "(?:\\.(?:1?\\d{1,2}|2[0-4]\\d|25[0-5])){2}" + "(?:\\.(?:[1-9]\\d?|1\\d\\d|2[0-4]\\d|25[0-4]))" + "|" +
            // host name
            '(?:(?:[a-z\\u00a1-\\uffff0-9]-*)*[a-z\\u00a1-\\uffff0-9]+)' +
            // domain name
            '(?:\\.(?:[a-z\\u00a1-\\uffff0-9]-*)*[a-z\\u00a1-\\uffff0-9]+)*' +
            // TLD identifier
            '(?:\\.(?:[a-z\\u00a1-\\uffff]{2,}))' + ")" +
            // port number
            "(?::\\d{2,5})?" +
            // resource path
            "(?:/\\S*)?" + "$", 'i')
    };
    typeTesters.range = typeTesters.number;

    // See http://stackoverflow.com/a/10454560/8279
    var decimalPlaces = function decimalPlaces(num) {
        var match = ('' + num).match(/(?:\.(\d+))?(?:[eE]([+-]?\d+))?$/);
        if (!match) {
            return 0;
        }
        return Math.max(0,
            // Number of digits right of decimal point.
            (match[1] ? match[1].length : 0) - (
                // Adjust for scientific notation.
                match[2] ? +match[2] : 0));
    };

    // parseArguments('number', ['1', '2']) => [1, 2]
    var ValidatorRegistry__parseArguments = function ValidatorRegistry__parseArguments(type, args) {
        return args.map(Utils__default.parse[type]);
    };
    // operatorToValidator returns a validating function for an operator function, applied to the given type
    var ValidatorRegistry__operatorToValidator = function ValidatorRegistry__operatorToValidator(type, operator) {
        return function(value) {
            for (var _len = arguments.length, requirementsAndInput = Array(_len > 1 ? _len - 1 : 0), _key = 1; _key < _len; _key++) {
                requirementsAndInput[_key - 1] = arguments[_key];
            }

            requirementsAndInput.pop(); // Get rid of `input` argument
            return operator.apply(undefined, [value].concat(_toConsumableArray(ValidatorRegistry__parseArguments(type, requirementsAndInput))));
        };
    };

    var ValidatorRegistry__comparisonOperator = function ValidatorRegistry__comparisonOperator(operator) {
        return {
            validateDate: ValidatorRegistry__operatorToValidator('date', operator),
            validateNumber: ValidatorRegistry__operatorToValidator('number', operator),
            requirementType: operator.length <= 2 ? 'string' : ['string', 'string'], // Support operators with a 1 or 2 requirement(s)
            priority: 30
        };
    };

    ValidatorRegistry.prototype = {
        init: function init(validators, catalog) {
            this.catalog = catalog;
            // Copy prototype's validators:
            this.validators = $.extend({}, this.validators);

            for (var name in validators) this.addValidator(name, validators[name].fn, validators[name].priority);

            window.Parsley.trigger('parsley:validator:init');
        },

        // Set new messages locale if we have dictionary loaded in ParsleyConfig.i18n
        setLocale: function setLocale(locale) {
            if ('undefined' === typeof this.catalog[locale]) throw new Error(locale + ' is not available in the catalog');

            this.locale = locale;

            return this;
        },

        // Add a new messages catalog for a given locale. Set locale for this catalog if set === `true`
        addCatalog: function addCatalog(locale, messages, set) {
            if ('object' === typeof messages) this.catalog[locale] = messages;

            if (true === set) return this.setLocale(locale);

            return this;
        },

        // Add a specific message for a given constraint in a given locale
        addMessage: function addMessage(locale, name, message) {
            if ('undefined' === typeof this.catalog[locale]) this.catalog[locale] = {};

            this.catalog[locale][name] = message;

            return this;
        },

        // Add messages for a given locale
        addMessages: function addMessages(locale, nameMessageObject) {
            for (var name in nameMessageObject) this.addMessage(locale, name, nameMessageObject[name]);

            return this;
        },

        // Add a new validator
        //
        //    addValidator('custom', {
        //        requirementType: ['integer', 'integer'],
        //        validateString: function(value, from, to) {},
        //        priority: 22,
        //        messages: {
        //          en: "Hey, that's no good",
        //          fr: "Aye aye, pas bon du tout",
        //        }
        //    })
        //
        // Old API was addValidator(name, function, priority)
        //
        addValidator: function addValidator(name, arg1, arg2) {
            if (this.validators[name]) Utils__default.warn('Validator "' + name + '" is already defined.');
            else if (Defaults.hasOwnProperty(name)) {
                Utils__default.warn('"' + name + '" is a restricted keyword and is not a valid validator name.');
                return;
            }
            return this._setValidator.apply(this, arguments);
        },

        updateValidator: function updateValidator(name, arg1, arg2) {
            if (!this.validators[name]) {
                Utils__default.warn('Validator "' + name + '" is not already defined.');
                return this.addValidator.apply(this, arguments);
            }
            return this._setValidator.apply(this, arguments);
        },

        removeValidator: function removeValidator(name) {
            if (!this.validators[name]) Utils__default.warn('Validator "' + name + '" is not defined.');

            delete this.validators[name];

            return this;
        },

        _setValidator: function _setValidator(name, validator, priority) {
            if ('object' !== typeof validator) {
                // Old style validator, with `fn` and `priority`
                validator = {
                    fn: validator,
                    priority: priority
                };
            }
            if (!validator.validate) {
                validator = new Validator(validator);
            }
            this.validators[name] = validator;

            for (var locale in validator.messages || {}) this.addMessage(locale, name, validator.messages[locale]);

            return this;
        },

        getErrorMessage: function getErrorMessage(constraint) {
            var message;

            // Type constraints are a bit different, we have to match their requirements too to find right error message
            if ('type' === constraint.name) {
                var typeMessages = this.catalog[this.locale][constraint.name] || {};
                message = typeMessages[constraint.requirements];
            } else message = this.formatMessage(this.catalog[this.locale][constraint.name], constraint.requirements);

            return message || this.catalog[this.locale].defaultMessage || this.catalog.en.defaultMessage;
        },

        // Kind of light `sprintf()` implementation
        formatMessage: function formatMessage(string, parameters) {
            if ('object' === typeof parameters) {
                for (var i in parameters) string = this.formatMessage(string, parameters[i]);

                return string;
            }

            return 'string' === typeof string ? string.replace(/%s/i, parameters) : '';
        },

        // Here is the Parsley default validators list.
        // A validator is an object with the following key values:
        //  - priority: an integer
        //  - requirement: 'string' (default), 'integer', 'number', 'regexp' or an Array of these
        //  - validateString, validateMultiple, validateNumber: functions returning `true`, `false` or a promise
        // Alternatively, a validator can be a function that returns such an object
        //
        validators: {
            notblank: {
                validateString: function validateString(value) {
                    return (/\S/.test(value));
                },
                priority: 2
            },
            required: {
                validateMultiple: function validateMultiple(values) {
                    return values.length > 0;
                },
                validateString: function validateString(value) {
                    return (/\S/.test(value));
                },
                priority: 512
            },
            type: {
                validateString: function validateString(value, type) {
                    var _ref = arguments.length <= 2 || arguments[2] === undefined ? {} : arguments[2];

                    var _ref$step = _ref.step;
                    var step = _ref$step === undefined ? 'any' : _ref$step;
                    var _ref$base = _ref.base;
                    var base = _ref$base === undefined ? 0 : _ref$base;

                    var tester = typeTesters[type];
                    if (!tester) {
                        throw new Error('validator type `' + type + '` is not supported');
                    }
                    if (!tester.test(value)) return false;
                    if ('number' === type) {
                        if (!/^any$/i.test(step || '')) {
                            var nb = Number(value);
                            var decimals = Math.max(decimalPlaces(step), decimalPlaces(base));
                            if (decimalPlaces(nb) > decimals) // Value can't have too many decimals
                                return false;
                            // Be careful of rounding errors by using integers.
                            var toInt = function toInt(f) {
                                return Math.round(f * Math.pow(10, decimals));
                            };
                            if ((toInt(nb) - toInt(base)) % toInt(step) != 0) return false;
                        }
                    }
                    return true;
                },
                requirementType: {
                    '': 'string',
                    step: 'string',
                    base: 'number'
                },
                priority: 256
            },
            pattern: {
                validateString: function validateString(value, regexp) {
                    return regexp.test(value);
                },
                requirementType: 'regexp',
                priority: 64
            },
            minlength: {
                validateString: function validateString(value, requirement) {
                    return value.length >= requirement;
                },
                requirementType: 'integer',
                priority: 30
            },
            maxlength: {
                validateString: function validateString(value, requirement) {
                    return value.length <= requirement;
                },
                requirementType: 'integer',
                priority: 30
            },
            length: {
                validateString: function validateString(value, min, max) {
                    return value.length >= min && value.length <= max;
                },
                requirementType: ['integer', 'integer'],
                priority: 30
            },
            mincheck: {
                validateMultiple: function validateMultiple(values, requirement) {
                    return values.length >= requirement;
                },
                requirementType: 'integer',
                priority: 30
            },
            maxcheck: {
                validateMultiple: function validateMultiple(values, requirement) {
                    return values.length <= requirement;
                },
                requirementType: 'integer',
                priority: 30
            },
            check: {
                validateMultiple: function validateMultiple(values, min, max) {
                    return values.length >= min && values.length <= max;
                },
                requirementType: ['integer', 'integer'],
                priority: 30
            },
            min: ValidatorRegistry__comparisonOperator(function(value, requirement) {
                return value >= requirement;
            }),
            max: ValidatorRegistry__comparisonOperator(function(value, requirement) {
                return value <= requirement;
            }),
            range: ValidatorRegistry__comparisonOperator(function(value, min, max) {
                return value >= min && value <= max;
            }),
            equalto: {
                validateString: function validateString(value, refOrValue) {
                    var $reference = $(refOrValue);
                    if ($reference.length) return value === $reference.val();
                    else return value === refOrValue;
                },
                priority: 256
            }
        }
    };

    var UI = {};

    var diffResults = function diffResults(newResult, oldResult, deep) {
        var added = [];
        var kept = [];

        for (var i = 0; i < newResult.length; i++) {
            var found = false;

            for (var j = 0; j < oldResult.length; j++)
                if (newResult[i].assert.name === oldResult[j].assert.name) {
                    found = true;
                    break;
                }

            if (found) kept.push(newResult[i]);
            else added.push(newResult[i]);
        }

        return {
            kept: kept,
            added: added,
            removed: !deep ? diffResults(oldResult, newResult, true).added : []
        };
    };

    UI.Form = {

        _actualizeTriggers: function _actualizeTriggers() {
            var _this2 = this;

            this.$element.on('submit.Parsley', function(evt) {
                _this2.onSubmitValidate(evt);
            });
            this.$element.on('click.Parsley', Utils__default._SubmitSelector, function(evt) {
                _this2.onSubmitButton(evt);
            });

            // UI could be disabled
            if (false === this.options.uiEnabled) return;

            this.$element.attr('novalidate', '');
        },

        focus: function focus() {
            this._focusedField = null;

            if (true === this.validationResult || 'none' === this.options.focus) return null;

            for (var i = 0; i < this.fields.length; i++) {
                var field = this.fields[i];
                if (true !== field.validationResult && field.validationResult.length > 0 && 'undefined' === typeof field.options.noFocus) {
                    this._focusedField = field.$element;
                    if ('first' === this.options.focus) break;
                }
            }

            if (null === this._focusedField) return null;

            return this._focusedField.focus();
        },

        _destroyUI: function _destroyUI() {
            // Reset all event listeners
            this.$element.off('.Parsley');
        }

    };

    UI.Field = {

        _reflowUI: function _reflowUI() {
            this._buildUI();

            // If this field doesn't have an active UI don't bother doing something
            if (!this._ui) return;

            // Diff between two validation results
            var diff = diffResults(this.validationResult, this._ui.lastValidationResult);

            // Then store current validation result for next reflow
            this._ui.lastValidationResult = this.validationResult;

            // Handle valid / invalid / none field class
            this._manageStatusClass();

            // Add, remove, updated errors messages
            this._manageErrorsMessages(diff);

            // Triggers impl
            this._actualizeTriggers();

            // If field is not valid for the first time, bind keyup trigger to ease UX and quickly inform user
            if ((diff.kept.length || diff.added.length) && !this._failedOnce) {
                this._failedOnce = true;
                this._actualizeTriggers();
            }
        },

        // Returns an array of field's error message(s)
        getErrorsMessages: function getErrorsMessages() {
            // No error message, field is valid
            if (true === this.validationResult) return [];

            var messages = [];

            for (var i = 0; i < this.validationResult.length; i++) messages.push(this.validationResult[i].errorMessage || this._getErrorMessage(this.validationResult[i].assert));

            return messages;
        },

        // It's a goal of Parsley that this method is no longer required [#1073]
        addError: function addError(name) {
            var _ref2 = arguments.length <= 1 || arguments[1] === undefined ? {} : arguments[1];

            var message = _ref2.message;
            var assert = _ref2.assert;
            var _ref2$updateClass = _ref2.updateClass;
            var updateClass = _ref2$updateClass === undefined ? true : _ref2$updateClass;

            this._buildUI();
            this._addError(name, {
                message: message,
                assert: assert
            });

            if (updateClass) this._errorClass();
        },

        // It's a goal of Parsley that this method is no longer required [#1073]
        updateError: function updateError(name) {
            var _ref3 = arguments.length <= 1 || arguments[1] === undefined ? {} : arguments[1];

            var message = _ref3.message;
            var assert = _ref3.assert;
            var _ref3$updateClass = _ref3.updateClass;
            var updateClass = _ref3$updateClass === undefined ? true : _ref3$updateClass;

            this._buildUI();
            this._updateError(name, {
                message: message,
                assert: assert
            });

            if (updateClass) this._errorClass();
        },

        // It's a goal of Parsley that this method is no longer required [#1073]
        removeError: function removeError(name) {
            var _ref4 = arguments.length <= 1 || arguments[1] === undefined ? {} : arguments[1];

            var _ref4$updateClass = _ref4.updateClass;
            var updateClass = _ref4$updateClass === undefined ? true : _ref4$updateClass;

            this._buildUI();
            this._removeError(name);

            // edge case possible here: remove a standard Parsley error that is still failing in this.validationResult
            // but highly improbable cuz' manually removing a well Parsley handled error makes no sense.
            if (updateClass) this._manageStatusClass();
        },

        _manageStatusClass: function _manageStatusClass() {
            if (this.hasConstraints() && this.needsValidation() && true === this.validationResult) this._successClass();
            else if (this.validationResult.length > 0) this._errorClass();
            else this._resetClass();
        },

        _manageErrorsMessages: function _manageErrorsMessages(diff) {
            if ('undefined' !== typeof this.options.errorsMessagesDisabled) return;

            // Case where we have errorMessage option that configure an unique field error message, regardless failing validators
            if ('undefined' !== typeof this.options.errorMessage) {
                if (diff.added.length || diff.kept.length) {
                    this._insertErrorWrapper();

                    if (0 === this._ui.$errorsWrapper.find('.parsley-custom-error-message').length) this._ui.$errorsWrapper.append($(this.options.errorTemplate).addClass('parsley-custom-error-message'));

                    return this._ui.$errorsWrapper.addClass('filled').find('.parsley-custom-error-message').html(this.options.errorMessage);
                }

                return this._ui.$errorsWrapper.removeClass('filled').find('.parsley-custom-error-message').remove();
            }

            // Show, hide, update failing constraints messages
            for (var i = 0; i < diff.removed.length; i++) this._removeError(diff.removed[i].assert.name);

            for (i = 0; i < diff.added.length; i++) this._addError(diff.added[i].assert.name, {
                message: diff.added[i].errorMessage,
                assert: diff.added[i].assert
            });

            for (i = 0; i < diff.kept.length; i++) this._updateError(diff.kept[i].assert.name, {
                message: diff.kept[i].errorMessage,
                assert: diff.kept[i].assert
            });
        },

        _addError: function _addError(name, _ref5) {
            var message = _ref5.message;
            var assert = _ref5.assert;

            this._insertErrorWrapper();
            this._ui.$errorsWrapper.addClass('filled').append($(this.options.errorTemplate).addClass('parsley-' + name).html(message || this._getErrorMessage(assert)));
        },

        _updateError: function _updateError(name, _ref6) {
            var message = _ref6.message;
            var assert = _ref6.assert;

            this._ui.$errorsWrapper.addClass('filled').find('.parsley-' + name).html(message || this._getErrorMessage(assert));
        },

        _removeError: function _removeError(name) {
            this._ui.$errorsWrapper.removeClass('filled').find('.parsley-' + name).remove();
        },

        _getErrorMessage: function _getErrorMessage(constraint) {
            var customConstraintErrorMessage = constraint.name + 'Message';

            if ('undefined' !== typeof this.options[customConstraintErrorMessage]) return window.Parsley.formatMessage(this.options[customConstraintErrorMessage], constraint.requirements);

            return window.Parsley.getErrorMessage(constraint);
        },

        _buildUI: function _buildUI() {
            // UI could be already built or disabled
            if (this._ui || false === this.options.uiEnabled) return;

            var _ui = {};

            // Give field its Parsley id in DOM
            this.$element.attr(this.options.namespace + 'id', this.__id__);

            /** Generate important UI elements and store them in this **/
            // $errorClassHandler is the $element that woul have parsley-error and parsley-success classes
            _ui.$errorClassHandler = this._manageClassHandler();

            // $errorsWrapper is a div that would contain the various field errors, it will be appended into $errorsContainer
            _ui.errorsWrapperId = 'parsley-id-' + (this.options.multiple ? 'multiple-' + this.options.multiple : this.__id__);
            _ui.$errorsWrapper = $(this.options.errorsWrapper).attr('id', _ui.errorsWrapperId);

            // ValidationResult UI storage to detect what have changed bwt two validations, and update DOM accordingly
            _ui.lastValidationResult = [];
            _ui.validationInformationVisible = false;

            // Store it in this for later
            this._ui = _ui;
        },

        // Determine which element will have `parsley-error` and `parsley-success` classes
        _manageClassHandler: function _manageClassHandler() {
            // An element selector could be passed through DOM with `data-parsley-class-handler=#foo`
            if ('string' === typeof this.options.classHandler && $(this.options.classHandler).length) return $(this.options.classHandler);

            // Class handled could also be determined by function given in Parsley options
            var $handler = this.options.classHandler.call(this, this);

            // If this function returned a valid existing DOM element, go for it
            if ('undefined' !== typeof $handler && $handler.length) return $handler;

            return this._inputHolder();
        },

        _inputHolder: function _inputHolder() {
            // if simple element (input, texatrea, select...) it will perfectly host the classes and precede the error container
            if (!this.options.multiple || this.$element.is('select')) return this.$element;

            // But if multiple element (radio, checkbox), that would be their parent
            return this.$element.parent();
        },

        _insertErrorWrapper: function _insertErrorWrapper() {
            var $errorsContainer;

            // Nothing to do if already inserted
            if (0 !== this._ui.$errorsWrapper.parent().length) return this._ui.$errorsWrapper.parent();

            if ('string' === typeof this.options.errorsContainer) {
                if ($(this.options.errorsContainer).length) return $(this.options.errorsContainer).append(this._ui.$errorsWrapper);
                else Utils__default.warn('The errors container `' + this.options.errorsContainer + '` does not exist in DOM');
            } else if ('function' === typeof this.options.errorsContainer) $errorsContainer = this.options.errorsContainer.call(this, this);

            if ('undefined' !== typeof $errorsContainer && $errorsContainer.length) return $errorsContainer.append(this._ui.$errorsWrapper);

            return this._inputHolder().after(this._ui.$errorsWrapper);
        },

        _actualizeTriggers: function _actualizeTriggers() {
            var _this3 = this;

            var $toBind = this._findRelated();
            var trigger;

            // Remove Parsley events already bound on this field
            $toBind.off('.Parsley');
            if (this._failedOnce) $toBind.on(Utils__default.namespaceEvents(this.options.triggerAfterFailure, 'Parsley'), function() {
                _this3._validateIfNeeded();
            });
            else if (trigger = Utils__default.namespaceEvents(this.options.trigger, 'Parsley')) {
                $toBind.on(trigger, function(event) {
                    _this3._validateIfNeeded(event);
                });
            }
        },

        _validateIfNeeded: function _validateIfNeeded(event) {
            var _this4 = this;

            // For keyup, keypress, keydown, input... events that could be a little bit obstrusive
            // do not validate if val length < min threshold on first validation. Once field have been validated once and info
            // about success or failure have been displayed, always validate with this trigger to reflect every yalidation change.
            if (event && /key|input/.test(event.type))
                if (!(this._ui && this._ui.validationInformationVisible) && this.getValue().length <= this.options.validationThreshold) return;

            if (this.options.debounce) {
                window.clearTimeout(this._debounced);
                this._debounced = window.setTimeout(function() {
                    return _this4.validate();
                }, this.options.debounce);
            } else this.validate();
        },

        _resetUI: function _resetUI() {
            // Reset all event listeners
            this._failedOnce = false;
            this._actualizeTriggers();

            // Nothing to do if UI never initialized for this field
            if ('undefined' === typeof this._ui) return;

            // Reset all errors' li
            this._ui.$errorsWrapper.removeClass('filled').children().remove();

            // Reset validation class
            this._resetClass();

            // Reset validation flags and last validation result
            this._ui.lastValidationResult = [];
            this._ui.validationInformationVisible = false;
        },

        _destroyUI: function _destroyUI() {
            this._resetUI();

            if ('undefined' !== typeof this._ui) this._ui.$errorsWrapper.remove();

            delete this._ui;
        },

        _successClass: function _successClass() {
            this._ui.validationInformationVisible = true;
            this._ui.$errorClassHandler.removeClass(this.options.errorClass).addClass(this.options.successClass);
        },
        _errorClass: function _errorClass() {
            this._ui.validationInformationVisible = true;
            this._ui.$errorClassHandler.removeClass(this.options.successClass).addClass(this.options.errorClass);
        },
        _resetClass: function _resetClass() {
            this._ui.$errorClassHandler.removeClass(this.options.successClass).removeClass(this.options.errorClass);
        }
    };

    var Form = function Form(element, domOptions, options) {
        this.__class__ = 'Form';

        this.$element = $(element);
        this.domOptions = domOptions;
        this.options = options;
        this.parent = window.Parsley;

        this.fields = [];
        this.validationResult = null;
    };

    var Form__statusMapping = {
        pending: null,
        resolved: true,
        rejected: false
    };

    Form.prototype = {
        onSubmitValidate: function onSubmitValidate(event) {
            var _this5 = this;

            // This is a Parsley generated submit event, do not validate, do not prevent, simply exit and keep normal behavior
            if (true === event.parsley) return;

            // If we didn't come here through a submit button, use the first one in the form
            var $submitSource = this._$submitSource || this.$element.find(Utils__default._SubmitSelector).first();
            this._$submitSource = null;
            this.$element.find('.parsley-synthetic-submit-button').prop('disabled', true);
            if ($submitSource.is('[formnovalidate]')) return;

            var promise = this.whenValidate({
                event: event
            });

            if ('resolved' === promise.state() && false !== this._trigger('submit')) {
                // All good, let event go through. We make this distinction because browsers
                // differ in their handling of `submit` being called from inside a submit event [#1047]
            } else {
                // Rejected or pending: cancel this submit
                event.stopImmediatePropagation();
                event.preventDefault();
                if ('pending' === promise.state()) promise.done(function() {
                    _this5._submit($submitSource);
                });
            }
        },

        onSubmitButton: function onSubmitButton(event) {
            this._$submitSource = $(event.currentTarget);
        },
        // internal
        // _submit submits the form, this time without going through the validations.
        // Care must be taken to "fake" the actual submit button being clicked.
        _submit: function _submit($submitSource) {
            if (false === this._trigger('submit')) return;
            // Add submit button's data
            if ($submitSource) {
                var $synthetic = this.$element.find('.parsley-synthetic-submit-button').prop('disabled', false);
                if (0 === $synthetic.length) $synthetic = $('<input class="parsley-synthetic-submit-button" type="hidden">').appendTo(this.$element);
                $synthetic.attr({
                    name: $submitSource.attr('name'),
                    value: $submitSource.attr('value')
                });
            }

            this.$element.trigger($.extend($.Event('submit'), {
                parsley: true
            }));
        },

        // Performs validation on fields while triggering events.
        // @returns `true` if all validations succeeds, `false`
        // if a failure is immediately detected, or `null`
        // if dependant on a promise.
        // Consider using `whenValidate` instead.
        validate: function validate(options) {
            if (arguments.length >= 1 && !$.isPlainObject(options)) {
                Utils__default.warnOnce('Calling validate on a parsley form without passing arguments as an object is deprecated.');

                var _arguments = _slice.call(arguments);

                var group = _arguments[0];
                var force = _arguments[1];
                var event = _arguments[2];

                options = {
                    group: group,
                    force: force,
                    event: event
                };
            }
            return Form__statusMapping[this.whenValidate(options).state()];
        },

        whenValidate: function whenValidate() {
            var _Utils__default$all$done$fail$always,
                _this6 = this;

            var _ref7 = arguments.length <= 0 || arguments[0] === undefined ? {} : arguments[0];

            var group = _ref7.group;
            var force = _ref7.force;
            var event = _ref7.event;

            this.submitEvent = event;
            if (event) {
                this.submitEvent = $.extend({}, event, {
                    preventDefault: function preventDefault() {
                        Utils__default.warnOnce("Using `this.submitEvent.preventDefault()` is deprecated; instead, call `this.validationResult = false`");
                        _this6.validationResult = false;
                    }
                });
            }
            this.validationResult = true;

            // fire validate event to eventually modify things before every validation
            this._trigger('validate');

            // Refresh form DOM options and form's fields that could have changed
            this._refreshFields();

            var promises = this._withoutReactualizingFormOptions(function() {
                return $.map(_this6.fields, function(field) {
                    return field.whenValidate({
                        force: force,
                        group: group
                    });
                });
            });

            return (_Utils__default$all$done$fail$always = Utils__default.all(promises).done(function() {
                _this6._trigger('success');
            }).fail(function() {
                _this6.validationResult = false;
                _this6.focus();
                _this6._trigger('error');
            }).always(function() {
                _this6._trigger('validated');
            })).pipe.apply(_Utils__default$all$done$fail$always, _toConsumableArray(this._pipeAccordingToValidationResult()));
        },

        // Iterate over refreshed fields, and stop on first failure.
        // Returns `true` if all fields are valid, `false` if a failure is detected
        // or `null` if the result depends on an unresolved promise.
        // Prefer using `whenValid` instead.
        isValid: function isValid(options) {
            if (arguments.length >= 1 && !$.isPlainObject(options)) {
                Utils__default.warnOnce('Calling isValid on a parsley form without passing arguments as an object is deprecated.');

                var _arguments2 = _slice.call(arguments);

                var group = _arguments2[0];
                var force = _arguments2[1];

                options = {
                    group: group,
                    force: force
                };
            }
            return Form__statusMapping[this.whenValid(options).state()];
        },

        // Iterate over refreshed fields and validate them.
        // Returns a promise.
        // A validation that immediately fails will interrupt the validations.
        whenValid: function whenValid() {
            var _this7 = this;

            var _ref8 = arguments.length <= 0 || arguments[0] === undefined ? {} : arguments[0];

            var group = _ref8.group;
            var force = _ref8.force;

            this._refreshFields();

            var promises = this._withoutReactualizingFormOptions(function() {
                return $.map(_this7.fields, function(field) {
                    return field.whenValid({
                        group: group,
                        force: force
                    });
                });
            });
            return Utils__default.all(promises);
        },

        // Reset UI
        reset: function reset() {
            // Form case: emit a reset event for each field
            for (var i = 0; i < this.fields.length; i++) this.fields[i].reset();

            this._trigger('reset');
        },

        // Destroy Parsley instance (+ UI)
        destroy: function destroy() {
            // Field case: emit destroy event to clean UI and then destroy stored instance
            this._destroyUI();

            // Form case: destroy all its fields and then destroy stored instance
            for (var i = 0; i < this.fields.length; i++) this.fields[i].destroy();

            this.$element.removeData('Parsley');
            this._trigger('destroy');
        },

        _refreshFields: function _refreshFields() {
            return this.actualizeOptions()._bindFields();
        },

        _bindFields: function _bindFields() {
            var _this8 = this;

            var oldFields = this.fields;

            this.fields = [];
            this.fieldsMappedById = {};

            this._withoutReactualizingFormOptions(function() {
                _this8.$element.find(_this8.options.inputs).not(_this8.options.excluded).each(function(_, element) {
                    var fieldInstance = new window.Parsley.Factory(element, {}, _this8);

                    // Only add valid and not excluded `Field` and `FieldMultiple` children
                    if (('Field' === fieldInstance.__class__ || 'FieldMultiple' === fieldInstance.__class__) && true !== fieldInstance.options.excluded) {
                        var uniqueId = fieldInstance.__class__ + '-' + fieldInstance.__id__;
                        if ('undefined' === typeof _this8.fieldsMappedById[uniqueId]) {
                            _this8.fieldsMappedById[uniqueId] = fieldInstance;
                            _this8.fields.push(fieldInstance);
                        }
                    }
                });

                $.each(Utils__default.difference(oldFields, _this8.fields), function(_, field) {
                    field.reset();
                });
            });
            return this;
        },

        // Internal only.
        // Looping on a form's fields to do validation or similar
        // will trigger reactualizing options on all of them, which
        // in turn will reactualize the form's options.
        // To avoid calling actualizeOptions so many times on the form
        // for nothing, _withoutReactualizingFormOptions temporarily disables
        // the method actualizeOptions on this form while `fn` is called.
        _withoutReactualizingFormOptions: function _withoutReactualizingFormOptions(fn) {
            var oldActualizeOptions = this.actualizeOptions;
            this.actualizeOptions = function() {
                return this;
            };
            var result = fn();
            this.actualizeOptions = oldActualizeOptions;
            return result;
        },

        // Internal only.
        // Shortcut to trigger an event
        // Returns true iff event is not interrupted and default not prevented.
        _trigger: function _trigger(eventName) {
            return this.trigger('form:' + eventName);
        }

    };

    var Constraint = function Constraint(parsleyField, name, requirements, priority, isDomConstraint) {
        var validatorSpec = window.Parsley._validatorRegistry.validators[name];
        var validator = new Validator(validatorSpec);

        $.extend(this, {
            validator: validator,
            name: name,
            requirements: requirements,
            priority: priority || parsleyField.options[name + 'Priority'] || validator.priority,
            isDomConstraint: true === isDomConstraint
        });
        this._parseRequirements(parsleyField.options);
    };

    var capitalize = function capitalize(str) {
        var cap = str[0].toUpperCase();
        return cap + str.slice(1);
    };

    Constraint.prototype = {
        validate: function validate(value, instance) {
            var _validator;

            return (_validator = this.validator).validate.apply(_validator, [value].concat(_toConsumableArray(this.requirementList), [instance]));
        },

        _parseRequirements: function _parseRequirements(options) {
            var _this9 = this;

            this.requirementList = this.validator.parseRequirements(this.requirements, function(key) {
                return options[_this9.name + capitalize(key)];
            });
        }
    };

    var Field = function Field(field, domOptions, options, parsleyFormInstance) {
        this.__class__ = 'Field';

        this.$element = $(field);

        // Set parent if we have one
        if ('undefined' !== typeof parsleyFormInstance) {
            this.parent = parsleyFormInstance;
        }

        this.options = options;
        this.domOptions = domOptions;

        // Initialize some properties
        this.constraints = [];
        this.constraintsByName = {};
        this.validationResult = true;

        // Bind constraints
        this._bindConstraints();
    };

    var parsley_field__statusMapping = {
        pending: null,
        resolved: true,
        rejected: false
    };

    Field.prototype = {
        // # Public API
        // Validate field and trigger some events for mainly `UI`
        // @returns `true`, an array of the validators that failed, or
        // `null` if validation is not finished. Prefer using whenValidate
        validate: function validate(options) {
            if (arguments.length >= 1 && !$.isPlainObject(options)) {
                Utils__default.warnOnce('Calling validate on a parsley field without passing arguments as an object is deprecated.');
                options = {
                    options: options
                };
            }
            var promise = this.whenValidate(options);
            if (!promise) // If excluded with `group` option
                return true;
            switch (promise.state()) {
                case 'pending':
                    return null;
                case 'resolved':
                    return true;
                case 'rejected':
                    return this.validationResult;
            }
        },

        // Validate field and trigger some events for mainly `UI`
        // @returns a promise that succeeds only when all validations do
        // or `undefined` if field is not in the given `group`.
        whenValidate: function whenValidate() {
            var _whenValid$always$done$fail$always,
                _this10 = this;

            var _ref9 = arguments.length <= 0 || arguments[0] === undefined ? {} : arguments[0];

            var force = _ref9.force;
            var group = _ref9.group;

            // do not validate a field if not the same as given validation group
            this.refreshConstraints();
            if (group && !this._isInGroup(group)) return;

            this.value = this.getValue();

            // Field Validate event. `this.value` could be altered for custom needs
            this._trigger('validate');

            return (_whenValid$always$done$fail$always = this.whenValid({
                force: force,
                value: this.value,
                _refreshed: true
            }).always(function() {
                _this10._reflowUI();
            }).done(function() {
                _this10._trigger('success');
            }).fail(function() {
                _this10._trigger('error');
            }).always(function() {
                _this10._trigger('validated');
            })).pipe.apply(_whenValid$always$done$fail$always, _toConsumableArray(this._pipeAccordingToValidationResult()));
        },

        hasConstraints: function hasConstraints() {
            return 0 !== this.constraints.length;
        },

        // An empty optional field does not need validation
        needsValidation: function needsValidation(value) {
            if ('undefined' === typeof value) value = this.getValue();

            // If a field is empty and not required, it is valid
            // Except if `data-parsley-validate-if-empty` explicitely added, useful for some custom validators
            if (!value.length && !this._isRequired() && 'undefined' === typeof this.options.validateIfEmpty) return false;

            return true;
        },

        _isInGroup: function _isInGroup(group) {
            if ($.isArray(this.options.group)) return -1 !== $.inArray(group, this.options.group);
            return this.options.group === group;
        },

        // Just validate field. Do not trigger any event.
        // Returns `true` iff all constraints pass, `false` if there are failures,
        // or `null` if the result can not be determined yet (depends on a promise)
        // See also `whenValid`.
        isValid: function isValid(options) {
            if (arguments.length >= 1 && !$.isPlainObject(options)) {
                Utils__default.warnOnce('Calling isValid on a parsley field without passing arguments as an object is deprecated.');

                var _arguments3 = _slice.call(arguments);

                var force = _arguments3[0];
                var value = _arguments3[1];

                options = {
                    force: force,
                    value: value
                };
            }
            var promise = this.whenValid(options);
            if (!promise) // Excluded via `group`
                return true;
            return parsley_field__statusMapping[promise.state()];
        },

        // Just validate field. Do not trigger any event.
        // @returns a promise that succeeds only when all validations do
        // or `undefined` if the field is not in the given `group`.
        // The argument `force` will force validation of empty fields.
        // If a `value` is given, it will be validated instead of the value of the input.
        whenValid: function whenValid() {
            var _this11 = this;

            var _ref10 = arguments.length <= 0 || arguments[0] === undefined ? {} : arguments[0];

            var _ref10$force = _ref10.force;
            var force = _ref10$force === undefined ? false : _ref10$force;
            var value = _ref10.value;
            var group = _ref10.group;
            var _refreshed = _ref10._refreshed;

            // Recompute options and rebind constraints to have latest changes
            if (!_refreshed) this.refreshConstraints();
            // do not validate a field if not the same as given validation group
            if (group && !this._isInGroup(group)) return;

            this.validationResult = true;

            // A field without constraint is valid
            if (!this.hasConstraints()) return $.when();

            // Value could be passed as argument, needed to add more power to 'field:validate'
            if ('undefined' === typeof value || null === value) value = this.getValue();

            if (!this.needsValidation(value) && true !== force) return $.when();

            var groupedConstraints = this._getGroupedConstraints();
            var promises = [];
            $.each(groupedConstraints, function(_, constraints) {
                // Process one group of constraints at a time, we validate the constraints
                // and combine the promises together.
                var promise = Utils__default.all($.map(constraints, function(constraint) {
                    return _this11._validateConstraint(value, constraint);
                }));
                promises.push(promise);
                if (promise.state() === 'rejected') return false; // Interrupt processing if a group has already failed
            });
            return Utils__default.all(promises);
        },

        // @returns a promise
        _validateConstraint: function _validateConstraint(value, constraint) {
            var _this12 = this;

            var result = constraint.validate(value, this);
            // Map false to a failed promise
            if (false === result) result = $.Deferred().reject();
            // Make sure we return a promise and that we record failures
            return Utils__default.all([result]).fail(function(errorMessage) {
                if (!(_this12.validationResult instanceof Array)) _this12.validationResult = [];
                _this12.validationResult.push({
                    assert: constraint,
                    errorMessage: 'string' === typeof errorMessage && errorMessage
                });
            });
        },

        // @returns Parsley field computed value that could be overrided or configured in DOM
        getValue: function getValue() {
            var value;

            // Value could be overriden in DOM or with explicit options
            if ('function' === typeof this.options.value) value = this.options.value(this);
            else if ('undefined' !== typeof this.options.value) value = this.options.value;
            else value = this.$element.val();

            // Handle wrong DOM or configurations
            if ('undefined' === typeof value || null === value) return '';

            return this._handleWhitespace(value);
        },

        // Reset UI
        reset: function reset() {
            this._resetUI();
            return this._trigger('reset');
        },

        // Destroy Parsley instance (+ UI)
        destroy: function destroy() {
            // Field case: emit destroy event to clean UI and then destroy stored instance
            this._destroyUI();
            this.$element.removeData('Parsley');
            this.$element.removeData('FieldMultiple');
            this._trigger('destroy');
        },

        // Actualize options that could have change since previous validation
        // Re-bind accordingly constraints (could be some new, removed or updated)
        refreshConstraints: function refreshConstraints() {
            return this.actualizeOptions()._bindConstraints();
        },

        /**
         * Add a new constraint to a field
         *
         * @param {String}   name
         * @param {Mixed}    requirements      optional
         * @param {Number}   priority          optional
         * @param {Boolean}  isDomConstraint   optional
         */
        addConstraint: function addConstraint(name, requirements, priority, isDomConstraint) {

            if (window.Parsley._validatorRegistry.validators[name]) {
                var constraint = new Constraint(this, name, requirements, priority, isDomConstraint);

                // if constraint already exist, delete it and push new version
                if ('undefined' !== this.constraintsByName[constraint.name]) this.removeConstraint(constraint.name);

                this.constraints.push(constraint);
                this.constraintsByName[constraint.name] = constraint;
            }

            return this;
        },

        // Remove a constraint
        removeConstraint: function removeConstraint(name) {
            for (var i = 0; i < this.constraints.length; i++)
                if (name === this.constraints[i].name) {
                    this.constraints.splice(i, 1);
                    break;
                }
            delete this.constraintsByName[name];
            return this;
        },

        // Update a constraint (Remove + re-add)
        updateConstraint: function updateConstraint(name, parameters, priority) {
            return this.removeConstraint(name).addConstraint(name, parameters, priority);
        },

        // # Internals

        // Internal only.
        // Bind constraints from config + options + DOM
        _bindConstraints: function _bindConstraints() {
            var constraints = [];
            var constraintsByName = {};

            // clean all existing DOM constraints to only keep javascript user constraints
            for (var i = 0; i < this.constraints.length; i++)
                if (false === this.constraints[i].isDomConstraint) {
                    constraints.push(this.constraints[i]);
                    constraintsByName[this.constraints[i].name] = this.constraints[i];
                }

            this.constraints = constraints;
            this.constraintsByName = constraintsByName;

            // then re-add Parsley DOM-API constraints
            for (var name in this.options) this.addConstraint(name, this.options[name], undefined, true);

            // finally, bind special HTML5 constraints
            return this._bindHtml5Constraints();
        },

        // Internal only.
        // Bind specific HTML5 constraints to be HTML5 compliant
        _bindHtml5Constraints: function _bindHtml5Constraints() {
            // html5 required
            if (this.$element.attr('required')) this.addConstraint('required', true, undefined, true);

            // html5 pattern
            if ('string' === typeof this.$element.attr('pattern')) this.addConstraint('pattern', this.$element.attr('pattern'), undefined, true);

            // range
            if ('undefined' !== typeof this.$element.attr('min') && 'undefined' !== typeof this.$element.attr('max')) this.addConstraint('range', [this.$element.attr('min'), this.$element.attr('max')], undefined, true);

            // HTML5 min
            else if ('undefined' !== typeof this.$element.attr('min')) this.addConstraint('min', this.$element.attr('min'), undefined, true);

            // HTML5 max
            else if ('undefined' !== typeof this.$element.attr('max')) this.addConstraint('max', this.$element.attr('max'), undefined, true);

            // length
            if ('undefined' !== typeof this.$element.attr('minlength') && 'undefined' !== typeof this.$element.attr('maxlength')) this.addConstraint('length', [this.$element.attr('minlength'), this.$element.attr('maxlength')], undefined, true);

            // HTML5 minlength
            else if ('undefined' !== typeof this.$element.attr('minlength')) this.addConstraint('minlength', this.$element.attr('minlength'), undefined, true);

            // HTML5 maxlength
            else if ('undefined' !== typeof this.$element.attr('maxlength')) this.addConstraint('maxlength', this.$element.attr('maxlength'), undefined, true);

            // html5 types
            var type = this.$element.attr('type');

            if ('undefined' === typeof type) return this;

            // Small special case here for HTML5 number: integer validator if step attribute is undefined or an integer value, number otherwise
            if ('number' === type) {
                return this.addConstraint('type', ['number', {
                    step: this.$element.attr('step') || '1',
                    base: this.$element.attr('min') || this.$element.attr('value')
                }], undefined, true);
                // Regular other HTML5 supported types
            } else if (/^(email|url|range|date)$/i.test(type)) {
                return this.addConstraint('type', type, undefined, true);
            }
            return this;
        },

        // Internal only.
        // Field is required if have required constraint without `false` value
        _isRequired: function _isRequired() {
            if ('undefined' === typeof this.constraintsByName.required) return false;

            return false !== this.constraintsByName.required.requirements;
        },

        // Internal only.
        // Shortcut to trigger an event
        _trigger: function _trigger(eventName) {
            return this.trigger('field:' + eventName);
        },

        // Internal only
        // Handles whitespace in a value
        // Use `data-parsley-whitespace="squish"` to auto squish input value
        // Use `data-parsley-whitespace="trim"` to auto trim input value
        _handleWhitespace: function _handleWhitespace(value) {
            if (true === this.options.trimValue) Utils__default.warnOnce('data-parsley-trim-value="true" is deprecated, please use data-parsley-whitespace="trim"');

            if ('squish' === this.options.whitespace) value = value.replace(/\s{2,}/g, ' ');

            if ('trim' === this.options.whitespace || 'squish' === this.options.whitespace || true === this.options.trimValue) value = Utils__default.trimString(value);

            return value;
        },

        _isDateInput: function _isDateInput() {
            var c = this.constraintsByName.type;
            return c && c.requirements === 'date';
        },

        // Internal only.
        // Returns the constraints, grouped by descending priority.
        // The result is thus an array of arrays of constraints.
        _getGroupedConstraints: function _getGroupedConstraints() {
            if (false === this.options.priorityEnabled) return [this.constraints];

            var groupedConstraints = [];
            var index = {};

            // Create array unique of priorities
            for (var i = 0; i < this.constraints.length; i++) {
                var p = this.constraints[i].priority;
                if (!index[p]) groupedConstraints.push(index[p] = []);
                index[p].push(this.constraints[i]);
            }
            // Sort them by priority DESC
            groupedConstraints.sort(function(a, b) {
                return b[0].priority - a[0].priority;
            });

            return groupedConstraints;
        }

    };

    var parsley_field = Field;

    var Multiple = function Multiple() {
        this.__class__ = 'FieldMultiple';
    };

    Multiple.prototype = {
        // Add new `$element` sibling for multiple field
        addElement: function addElement($element) {
            this.$elements.push($element);

            return this;
        },

        // See `Field.refreshConstraints()`
        refreshConstraints: function refreshConstraints() {
            var fieldConstraints;

            this.constraints = [];

            // Select multiple special treatment
            if (this.$element.is('select')) {
                this.actualizeOptions()._bindConstraints();

                return this;
            }

            // Gather all constraints for each input in the multiple group
            for (var i = 0; i < this.$elements.length; i++) {

                // Check if element have not been dynamically removed since last binding
                if (!$('html').has(this.$elements[i]).length) {
                    this.$elements.splice(i, 1);
                    continue;
                }

                fieldConstraints = this.$elements[i].data('FieldMultiple').refreshConstraints().constraints;

                for (var j = 0; j < fieldConstraints.length; j++) this.addConstraint(fieldConstraints[j].name, fieldConstraints[j].requirements, fieldConstraints[j].priority, fieldConstraints[j].isDomConstraint);
            }

            return this;
        },

        // See `Field.getValue()`
        getValue: function getValue() {
            // Value could be overriden in DOM
            if ('function' === typeof this.options.value) return this.options.value(this);
            else if ('undefined' !== typeof this.options.value) return this.options.value;

            // Radio input case
            if (this.$element.is('input[type=radio]')) return this._findRelated().filter(':checked').val() || '';

            // checkbox input case
            if (this.$element.is('input[type=checkbox]')) {
                var values = [];

                this._findRelated().filter(':checked').each(function() {
                    values.push($(this).val());
                });

                return values;
            }

            // Select multiple case
            if (this.$element.is('select') && null === this.$element.val()) return [];

            // Default case that should never happen
            return this.$element.val();
        },

        _init: function _init() {
            this.$elements = [this.$element];

            return this;
        }
    };

    var Factory = function Factory(element, options, parsleyFormInstance) {
        this.$element = $(element);

        // If the element has already been bound, returns its saved Parsley instance
        var savedparsleyFormInstance = this.$element.data('Parsley');
        if (savedparsleyFormInstance) {

            // If the saved instance has been bound without a Form parent and there is one given in this call, add it
            if ('undefined' !== typeof parsleyFormInstance && savedparsleyFormInstance.parent === window.Parsley) {
                savedparsleyFormInstance.parent = parsleyFormInstance;
                savedparsleyFormInstance._resetOptions(savedparsleyFormInstance.options);
            }

            if ('object' === typeof options) {
                $.extend(savedparsleyFormInstance.options, options);
            }

            return savedparsleyFormInstance;
        }

        // Parsley must be instantiated with a DOM element or jQuery $element
        if (!this.$element.length) throw new Error('You must bind Parsley on an existing element.');

        if ('undefined' !== typeof parsleyFormInstance && 'Form' !== parsleyFormInstance.__class__) throw new Error('Parent instance must be a Form instance');

        this.parent = parsleyFormInstance || window.Parsley;
        return this.init(options);
    };

    Factory.prototype = {
        init: function init(options) {
            this.__class__ = 'Parsley';
            this.__version__ = '2.7.0';
            this.__id__ = Utils__default.generateID();

            // Pre-compute options
            this._resetOptions(options);

            // A Form instance is obviously a `<form>` element but also every node that is not an input and has the `data-parsley-validate` attribute
            if (this.$element.is('form') || Utils__default.checkAttr(this.$element, this.options.namespace, 'validate') && !this.$element.is(this.options.inputs)) return this.bind('parsleyForm');

            // Every other element is bound as a `Field` or `FieldMultiple`
            return this.isMultiple() ? this.handleMultiple() : this.bind('parsleyField');
        },

        isMultiple: function isMultiple() {
            return this.$element.is('input[type=radio], input[type=checkbox]') || this.$element.is('select') && 'undefined' !== typeof this.$element.attr('multiple');
        },

        // Multiples fields are a real nightmare :(
        // Maybe some refactoring would be appreciated here...
        handleMultiple: function handleMultiple() {
            var _this13 = this;

            var name;
            var multiple;
            var parsleyMultipleInstance;

            // Handle multiple name
            if (this.options.multiple); // We already have our 'multiple' identifier
            else if ('undefined' !== typeof this.$element.attr('name') && this.$element.attr('name').length) this.options.multiple = name = this.$element.attr('name');
            else if ('undefined' !== typeof this.$element.attr('id') && this.$element.attr('id').length) this.options.multiple = this.$element.attr('id');

            // Special select multiple input
            if (this.$element.is('select') && 'undefined' !== typeof this.$element.attr('multiple')) {
                this.options.multiple = this.options.multiple || this.__id__;
                return this.bind('parsleyFieldMultiple');

                // Else for radio / checkboxes, we need a `name` or `data-parsley-multiple` to properly bind it
            } else if (!this.options.multiple) {
                Utils__default.warn('To be bound by Parsley, a radio, a checkbox and a multiple select input must have either a name or a multiple option.', this.$element);
                return this;
            }

            // Remove special chars
            this.options.multiple = this.options.multiple.replace(/(:|\.|\[|\]|\{|\}|\$)/g, '');

            // Add proper `data-parsley-multiple` to siblings if we have a valid multiple name
            if ('undefined' !== typeof name) {
                $('input[name="' + name + '"]').each(function(i, input) {
                    if ($(input).is('input[type=radio], input[type=checkbox]')) $(input).attr(_this13.options.namespace + 'multiple', _this13.options.multiple);
                });
            }

            // Check here if we don't already have a related multiple instance saved
            var $previouslyRelated = this._findRelated();
            for (var i = 0; i < $previouslyRelated.length; i++) {
                parsleyMultipleInstance = $($previouslyRelated.get(i)).data('Parsley');
                if ('undefined' !== typeof parsleyMultipleInstance) {

                    if (!this.$element.data('FieldMultiple')) {
                        parsleyMultipleInstance.addElement(this.$element);
                    }

                    break;
                }
            }

            // Create a secret Field instance for every multiple field. It will be stored in `data('FieldMultiple')`
            // And will be useful later to access classic `Field` stuff while being in a `FieldMultiple` instance
            this.bind('parsleyField', true);

            return parsleyMultipleInstance || this.bind('parsleyFieldMultiple');
        },

        // Return proper `Form`, `Field` or `FieldMultiple`
        bind: function bind(type, doNotStore) {
            var parsleyInstance;

            switch (type) {
                case 'parsleyForm':
                    parsleyInstance = $.extend(new Form(this.$element, this.domOptions, this.options), new Base(), window.ParsleyExtend)._bindFields();
                    break;
                case 'parsleyField':
                    parsleyInstance = $.extend(new parsley_field(this.$element, this.domOptions, this.options, this.parent), new Base(), window.ParsleyExtend);
                    break;
                case 'parsleyFieldMultiple':
                    parsleyInstance = $.extend(new parsley_field(this.$element, this.domOptions, this.options, this.parent), new Multiple(), new Base(), window.ParsleyExtend)._init();
                    break;
                default:
                    throw new Error(type + 'is not a supported Parsley type');
            }

            if (this.options.multiple) Utils__default.setAttr(this.$element, this.options.namespace, 'multiple', this.options.multiple);

            if ('undefined' !== typeof doNotStore) {
                this.$element.data('FieldMultiple', parsleyInstance);

                return parsleyInstance;
            }

            // Store the freshly bound instance in a DOM element for later access using jQuery `data()`
            this.$element.data('Parsley', parsleyInstance);

            // Tell the world we have a new Form or Field instance!
            parsleyInstance._actualizeTriggers();
            parsleyInstance._trigger('init');

            return parsleyInstance;
        }
    };

    var vernums = $.fn.jquery.split('.');
    if (parseInt(vernums[0]) <= 1 && parseInt(vernums[1]) < 8) {
        throw "The loaded version of jQuery is too old. Please upgrade to 1.8.x or better.";
    }
    if (!vernums.forEach) {
        Utils__default.warn('Parsley requires ES5 to run properly. Please include https://github.com/es-shims/es5-shim');
    }
    // Inherit `on`, `off` & `trigger` to Parsley:
    var Parsley = $.extend(new Base(), {
        $element: $(document),
        actualizeOptions: null,
        _resetOptions: null,
        Factory: Factory,
        version: '2.7.0'
    });

    // Supplement Field and Form with Base
    // This way, the constructors will have access to those methods
    $.extend(parsley_field.prototype, UI.Field, Base.prototype);
    $.extend(Form.prototype, UI.Form, Base.prototype);
    // Inherit actualizeOptions and _resetOptions:
    $.extend(Factory.prototype, Base.prototype);

    // ### jQuery API
    // `$('.elem').parsley(options)` or `$('.elem').psly(options)`
    $.fn.parsley = $.fn.psly = function(options) {
        if (this.length > 1) {
            var instances = [];

            this.each(function() {
                instances.push($(this).parsley(options));
            });

            return instances;
        }

        // Return undefined if applied to non existing DOM element
        if (!$(this).length) {
            Utils__default.warn('You must bind Parsley on an existing element.');

            return;
        }

        return new Factory(this, options);
    };

    // ### Field and Form extension
    // Ensure the extension is now defined if it wasn't previously
    if ('undefined' === typeof window.ParsleyExtend) window.ParsleyExtend = {};

    // ### Parsley config
    // Inherit from ParsleyDefault, and copy over any existing values
    Parsley.options = $.extend(Utils__default.objectCreate(Defaults), window.ParsleyConfig);
    window.ParsleyConfig = Parsley.options; // Old way of accessing global options

    // ### Globals
    window.Parsley = window.psly = Parsley;
    Parsley.Utils = Utils__default;
    window.ParsleyUtils = {};
    $.each(Utils__default, function(key, value) {
        if ('function' === typeof value) {
            window.ParsleyUtils[key] = function() {
                Utils__default.warnOnce('Accessing `window.ParsleyUtils` is deprecated. Use `window.Parsley.Utils` instead.');
                return Utils__default[key].apply(Utils__default, arguments);
            };
        }
    });

    // ### Define methods that forward to the registry, and deprecate all access except through window.Parsley
    var registry = window.Parsley._validatorRegistry = new ValidatorRegistry(window.ParsleyConfig.validators, window.ParsleyConfig.i18n);
    window.ParsleyValidator = {};
    $.each('setLocale addCatalog addMessage addMessages getErrorMessage formatMessage addValidator updateValidator removeValidator'.split(' '), function(i, method) {
        window.Parsley[method] = $.proxy(registry, method);
        window.ParsleyValidator[method] = function() {
            var _window$Parsley;

            Utils__default.warnOnce('Accessing the method \'' + method + '\' through Validator is deprecated. Simply call \'window.Parsley.' + method + '(...)\'');
            return (_window$Parsley = window.Parsley)[method].apply(_window$Parsley, arguments);
        };
    });

    // ### UI
    // Deprecated global object
    window.Parsley.UI = UI;
    window.ParsleyUI = {
        removeError: function removeError(instance, name, doNotUpdateClass) {
            var updateClass = true !== doNotUpdateClass;
            Utils__default.warnOnce('Accessing UI is deprecated. Call \'removeError\' on the instance directly. Please comment in issue 1073 as to your need to call this method.');
            return instance.removeError(name, {
                updateClass: updateClass
            });
        },
        getErrorsMessages: function getErrorsMessages(instance) {
            Utils__default.warnOnce('Accessing UI is deprecated. Call \'getErrorsMessages\' on the instance directly.');
            return instance.getErrorsMessages();
        }
    };
    $.each('addError updateError'.split(' '), function(i, method) {
        window.ParsleyUI[method] = function(instance, name, message, assert, doNotUpdateClass) {
            var updateClass = true !== doNotUpdateClass;
            Utils__default.warnOnce('Accessing UI is deprecated. Call \'' + method + '\' on the instance directly. Please comment in issue 1073 as to your need to call this method.');
            return instance[method](name, {
                message: message,
                assert: assert,
                updateClass: updateClass
            });
        };
    });

    // ### PARSLEY auto-binding
    // Prevent it by setting `ParsleyConfig.autoBind` to `false`
    if (false !== window.ParsleyConfig.autoBind) {
        $(function() {
            // Works only on `data-parsley-validate`.
            if ($('[data-parsley-validate]').length) $('[data-parsley-validate]').parsley();
        });
    }

    var o = $({});
    var deprecated = function deprecated() {
        Utils__default.warnOnce("Parsley's pubsub module is deprecated; use the 'on' and 'off' methods on parsley instances or window.Parsley");
    };

    // Returns an event handler that calls `fn` with the arguments it expects
    function adapt(fn, context) {
        // Store to allow unbinding
        if (!fn.parsleyAdaptedCallback) {
            fn.parsleyAdaptedCallback = function() {
                var args = Array.prototype.slice.call(arguments, 0);
                args.unshift(this);
                fn.apply(context || o, args);
            };
        }
        return fn.parsleyAdaptedCallback;
    }

    var eventPrefix = 'parsley:';
    // Converts 'parsley:form:validate' into 'form:validate'
    function eventName(name) {
        if (name.lastIndexOf(eventPrefix, 0) === 0) return name.substr(eventPrefix.length);
        return name;
    }

    // $.listen is deprecated. Use Parsley.on instead.
    $.listen = function(name, callback) {
        var context;
        deprecated();
        if ('object' === typeof arguments[1] && 'function' === typeof arguments[2]) {
            context = arguments[1];
            callback = arguments[2];
        }

        if ('function' !== typeof callback) throw new Error('Wrong parameters');

        window.Parsley.on(eventName(name), adapt(callback, context));
    };

    $.listenTo = function(instance, name, fn) {
        deprecated();
        if (!(instance instanceof parsley_field) && !(instance instanceof Form)) throw new Error('Must give Parsley instance');

        if ('string' !== typeof name || 'function' !== typeof fn) throw new Error('Wrong parameters');

        instance.on(eventName(name), adapt(fn));
    };

    $.unsubscribe = function(name, fn) {
        deprecated();
        if ('string' !== typeof name || 'function' !== typeof fn) throw new Error('Wrong arguments');
        window.Parsley.off(eventName(name), fn.parsleyAdaptedCallback);
    };

    $.unsubscribeTo = function(instance, name) {
        deprecated();
        if (!(instance instanceof parsley_field) && !(instance instanceof Form)) throw new Error('Must give Parsley instance');
        instance.off(eventName(name));
    };

    $.unsubscribeAll = function(name) {
        deprecated();
        window.Parsley.off(eventName(name));
        $('form,input,textarea,select').each(function() {
            var instance = $(this).data('Parsley');
            if (instance) {
                instance.off(eventName(name));
            }
        });
    };

    // $.emit is deprecated. Use jQuery events instead.
    $.emit = function(name, instance) {
        var _instance;

        deprecated();
        var instanceGiven = instance instanceof parsley_field || instance instanceof Form;
        var args = Array.prototype.slice.call(arguments, instanceGiven ? 2 : 1);
        args.unshift(eventName(name));
        if (!instanceGiven) {
            instance = window.Parsley;
        }
        (_instance = instance).trigger.apply(_instance, _toConsumableArray(args));
    };

    var pubsub = {};

    $.extend(true, Parsley, {
        asyncValidators: {
            'default': {
                fn: function fn(xhr) {
                    // By default, only status 2xx are deemed successful.
                    // Note: we use status instead of state() because responses with status 200
                    // but invalid messages (e.g. an empty body for content type set to JSON) will
                    // result in state() === 'rejected'.
                    return xhr.status >= 200 && xhr.status < 300;
                },
                url: false
            },
            reverse: {
                fn: function fn(xhr) {
                    // If reverse option is set, a failing ajax request is considered successful
                    return xhr.status < 200 || xhr.status >= 300;
                },
                url: false
            }
        },

        addAsyncValidator: function addAsyncValidator(name, fn, url, options) {
            Parsley.asyncValidators[name] = {
                fn: fn,
                url: url || false,
                options: options || {}
            };

            return this;
        }

    });

    Parsley.addValidator('remote', {
        requirementType: {
            '': 'string',
            'validator': 'string',
            'reverse': 'boolean',
            'options': 'object'
        },

        validateString: function validateString(value, url, options, instance) {
            var data = {};
            var ajaxOptions;
            var csr;
            var validator = options.validator || (true === options.reverse ? 'reverse' : 'default');

            if ('undefined' === typeof Parsley.asyncValidators[validator]) throw new Error('Calling an undefined async validator: `' + validator + '`');

            url = Parsley.asyncValidators[validator].url || url;

            // Fill current value
            if (url.indexOf('{value}') > -1) {
                url = url.replace('{value}', encodeURIComponent(value));
            } else {
                data[instance.$element.attr('name') || instance.$element.attr('id')] = value;
            }

            // Merge options passed in from the function with the ones in the attribute
            var remoteOptions = $.extend(true, options.options || {}, Parsley.asyncValidators[validator].options);

            // All `$.ajax(options)` could be overridden or extended directly from DOM in `data-parsley-remote-options`
            ajaxOptions = $.extend(true, {}, {
                url: url,
                data: data,
                type: 'GET'
            }, remoteOptions);

            // Generate store key based on ajax options
            instance.trigger('field:ajaxoptions', instance, ajaxOptions);

            csr = $.param(ajaxOptions);

            // Initialise querry cache
            if ('undefined' === typeof Parsley._remoteCache) Parsley._remoteCache = {};

            // Try to retrieve stored xhr
            var xhr = Parsley._remoteCache[csr] = Parsley._remoteCache[csr] || $.ajax(ajaxOptions);

            var handleXhr = function handleXhr() {
                var result = Parsley.asyncValidators[validator].fn.call(instance, xhr, url, options);
                if (!result) // Map falsy results to rejected promise
                    result = $.Deferred().reject();
                return $.when(result);
            };

            return xhr.then(handleXhr, handleXhr);
        },

        priority: -1
    });

    Parsley.on('form:submit', function() {
        Parsley._remoteCache = {};
    });

    window.ParsleyExtend.addAsyncValidator = function() {
        Utils.warnOnce('Accessing the method `addAsyncValidator` through an instance is deprecated. Simply call `Parsley.addAsyncValidator(...)`');
        return Parsley.addAsyncValidator.apply(Parsley, arguments);
    };

    // This is included with the Parsley library itself,
    // thus there is no use in adding it to your project.
    Parsley.addMessages('en', {
        defaultMessage: "This value seems to be invalid.",
        type: {
            email: "This value should be a valid email.",
            url: "This value should be a valid url.",
            number: "This value should be a valid number.",
            integer: "This value should be a valid integer.",
            digits: "This value should be digits.",
            alphanum: "This value should be alphanumeric."
        },
        notblank: "This value should not be blank.",
        required: "This value is required.",
        pattern: "This value seems to be invalid.",
        min: "This value should be greater than or equal to %s.",
        max: "This value should be lower than or equal to %s.",
        range: "This value should be between %s and %s.",
        minlength: "This value is too short. It should have %s characters or more.",
        maxlength: "This value is too long. It should have %s characters or fewer.",
        length: "This value length is invalid. It should be between %s and %s characters long.",
        mincheck: "You must select at least %s choices.",
        maxcheck: "You must select %s choices or fewer.",
        check: "You must select between %s and %s choices.",
        equalto: "This value should be the same."
    });

    Parsley.setLocale('en');

    /**
     * inputevent - Alleviate browser bugs for input events
     * https://github.com/marcandre/inputevent
     * @version v0.0.3 - (built Thu, Apr 14th 2016, 5:58 pm)
     * @author Marc-Andre Lafortune <github@marc-andre.ca>
     * @license MIT
     */

    function InputEvent() {
        var _this14 = this;

        var globals = window || global;

        // Slightly odd way construct our object. This way methods are force bound.
        // Used to test for duplicate library.
        $.extend(this, {

            // For browsers that do not support isTrusted, assumes event is native.
            isNativeEvent: function isNativeEvent(evt) {
                return evt.originalEvent && evt.originalEvent.isTrusted !== false;
            },

            fakeInputEvent: function fakeInputEvent(evt) {
                if (_this14.isNativeEvent(evt)) {
                    $(evt.target).trigger('input');
                }
            },

            misbehaves: function misbehaves(evt) {
                if (_this14.isNativeEvent(evt)) {
                    _this14.behavesOk(evt);
                    $(document).on('change.inputevent', evt.data.selector, _this14.fakeInputEvent);
                    _this14.fakeInputEvent(evt);
                }
            },

            behavesOk: function behavesOk(evt) {
                if (_this14.isNativeEvent(evt)) {
                    $(document) // Simply unbinds the testing handler
                        .off('input.inputevent', evt.data.selector, _this14.behavesOk).off('change.inputevent', evt.data.selector, _this14.misbehaves);
                }
            },

            // Bind the testing handlers
            install: function install() {
                if (globals.inputEventPatched) {
                    return;
                }
                globals.inputEventPatched = '0.0.3';
                var _arr = ['select', 'input[type="checkbox"]', 'input[type="radio"]', 'input[type="file"]'];
                for (var _i = 0; _i < _arr.length; _i++) {
                    var selector = _arr[_i];
                    $(document).on('input.inputevent', selector, {
                        selector: selector
                    }, _this14.behavesOk).on('change.inputevent', selector, {
                        selector: selector
                    }, _this14.misbehaves);
                }
            },

            uninstall: function uninstall() {
                delete globals.inputEventPatched;
                $(document).off('.inputevent');
            }

        });
    };

    var inputevent = new InputEvent();

    inputevent.install();

    var parsley = Parsley;

    return parsley;
});

//# sourceMappingURL=parsley.js.map

_sparkJqvMode = 0; // 0=Tooltips,1=Popover,2=Inline
if (typeof(SparkJqvMode) == 'undefined')
    _sparkJqvMode = 0;
else
    _sparkJqvMode = SparkJqvMode;


_sparkJqvOnChange = false;
if (typeof(SparkJqvOnChange) == 'undefined')
    _sparkJqvOnChange = false;
else
    _sparkJqvOnChange = SparkJqvOnChange;

_sparkJqvSetTypes = true;
if (typeof(SparkJqvSetTypes) == 'undefined')
    _sparkJqvSetTypes = false;
else
    _sparkJqvSetTypes = SparkJqvSetTypes;


$('head').append($('<link rel="stylesheet" type="text/css" />').attr('href', 'https://docs.corepassage.com/JSLibraries/SparkJQValidation/sparkjqv.parsley.css'));


function sparkjqv_Event_GroupValidation() {
    //if there are validation groups then validate only if radio button is checked:
    $('[data-validates-group]').each(function(k, v) {

        groupid = $(v).attr('data-validates-group');
        e = v;
        if (!$(e).is("input")) //fix issues with asp.net span wrapping
            e = $(e).children('input');


        if ($(e).prop('checked')) {
            $('[data-validation-group="' + groupid + '"]').prop('required', 'required'); //input
        } else {
            $('[data-validation-group="' + groupid + '"]').prop('required', ''); //#input
        }

    });
}

function sparkjqv_Event_PhoneValidation() {

    //if there are 2 phone groups, only one is required
    if ($('#HOME_PHONE_AREA').length != 0 && $('#MOBILE_PHONE_AREA').length != 0) {

        $("#HOME_PHONE_AREA,#HOME_PHONE_PREFIX,#HOME_PHONE_SUFFIX,#MOBILE_PHONE_AREA,#MOBILE_PHONE_PREFIX,#MOBILE_PHONE_SUFFIX").attr('required', '');
        $("#HOME_PHONE_AREA,#HOME_PHONE_PREFIX,#HOME_PHONE_SUFFIX,#MOBILE_PHONE_AREA,#MOBILE_PHONE_PREFIX,#MOBILE_PHONE_SUFFIX").parsley('addConstraint', {
            required: true
        });

        if ($("#HOME_PHONE_AREA").parsley().isValid() &&
            $("#HOME_PHONE_PREFIX").parsley().isValid() &&
            $("#HOME_PHONE_SUFFIX").parsley().isValid()) {
            $("#MOBILE_PHONE_AREA,#MOBILE_PHONE_PREFIX,#MOBILE_PHONE_SUFFIX").removeAttr('required');
            $("#MOBILE_PHONE_AREA,#MOBILE_PHONE_PREFIX,#MOBILE_PHONE_SUFFIX").parsley('addConstraint', {
                required: false
            });
        } else if (
            $("#MOBILE_PHONE_AREA").parsley().isValid() &&
            $("#MOBILE_PHONE_PREFIX").parsley().isValid() &&
            $("#MOBILE_PHONE_SUFFIX").parsley().isValid()) {
            $("#HOME_PHONE_AREA,#HOME_PHONE_PREFIX,#HOME_PHONE_SUFFIX").removeAttr('required');
            $("#HOME_PHONE_AREA,#HOME_PHONE_PREFIX,#HOME_PHONE_SUFFIX").parsley('addConstraint', {
                required: false
            });
        }

    }

}



function sparkjqv_setgenericval(id, type, required) {

    if (required == null)
        required = true;

    if ($(id).length != 0) {
        if (required)
            $(id).attr('required', '');

        if (_sparkJqvOnChange)
            $(id).attr('data-parsley-trigger', 'change');

        $(id).addClass('tooltipster');

        if (type == "zip") {
            $(id).attr('data-parsley-type', 'digits');
            $(id).attr('data-parsley-length', '[5, 5]');
            if (_sparkJqvSetTypes && $(id).attr('type') != 'hidden')
                $(id).attr('type', 'tel');
        } else if (type == "name") {
            $(id).attr('data-parsley-pattern', "^[a-zA-Z]{1}([a-zA-Z-' ]{0,39})$");
            $(id).attr('data-parsley-minlength', '2');
        } else if (type == "middlename") {
            $(id).attr('data-parsley-pattern', "^[a-zA-Z]{1}([a-zA-Z-' ]{0,39})$");
            $(id).attr('data-parsley-minlength', '1');
        } else if (type == "city") {
            $(id).attr('data-parsley-pattern', "^[a-zA-Z-'. ]{2,50}$");
            $(id).attr('data-parsley-minlength', '2');
        } else if (type == "middleinitial") {
            $(id).attr('data-parsley-pattern', "^[a-zA-Z]{1}$");
            $(id).attr('data-parsley-maxlength', '1');
        } else if (type == "phone_area" || type == "phone_prefix" || type == "phone_suffix") {
            $(id).attr('data-parsley-type', 'digits');
            if (_sparkJqvSetTypes)
                $(id).attr('type', 'tel');

            if (type == "phone_suffix")
                $(id).attr('data-parsley-length', '[4, 4]');
            else
                $(id).attr('data-parsley-length', '[3, 3]');
        } else if (type == "email") {
            if (_sparkJqvSetTypes && $(id).attr('type') != 'hidden')
                $(id).attr('type', 'email');
            $(id).attr('data-parsley-type', 'email');
        } else if (type == "ssn1") {
            if (_sparkJqvSetTypes)
                $(id).attr('type', 'tel');
            $(id).attr('data-parsley-type', 'digits');
            $(id).attr('data-parsley-length', '[3, 3]');
        } else if (type == "ssn2") {
            if (_sparkJqvSetTypes)
                $(id).attr('type', 'tel');
            $(id).attr('data-parsley-type', 'digits');
            $(id).attr('data-parsley-length', '[2, 2]');
        } else if (type == "ssn3") {
            if (_sparkJqvSetTypes)
                $(id).attr('type', 'tel');
            $(id).attr('data-parsley-type', 'digits');
            $(id).attr('data-parsley-length', '[4, 4]');
        } else if (type == "initials") {
            //$(id).attr('data-parsley-type', 'digits');
            //$(id).attr('data-parsley-length', '[4, 4]');

            window.Parsley
                .addValidator('initials', {
                    requirementType: ['string', 'string'],
                    validateString: function(value, req1, req2) {
                        return value.toLowerCase() == ($('#' + req1).val()[0] + $('#' + req2).val()[0]).toLowerCase();
                    },
                    messages: {
                        en: 'This value should match your First and Last Names'
                    }
                });

        } else if (type == "residenceyears") {
            $(id).attr('data-parsley-minlength', '1');


            $(id).attr('data-parsley-residenceyears', 'RESIDENCE_MONTHS');

            window.Parsley.addValidator('residenceyears', {
                requirementType: 'string',
                validateString: function(value, req2) {
                    val1 = $(id).val();
                    val2 = $('#' + req2).val();

                    return (!(val1 == "0" && val2 == "0"));
                },
                messages: {
                    en: 'Residence years and months can&#39;t be both 0'
                }
            });


        } else if (type == "residencemonths") {
            $(id).attr('data-parsley-minlength', '1');

            $(id).attr('data-parsley-residencemonths', 'RESIDENCE_YEARS');

            window.Parsley.addValidator('residencemonths', {
                requirementType: 'string',
                validateString: function(value, req2) {
                    val2 = $(id).val();
                    val1 = $('#' + req2).val();

                    return (!(val1 == "0" && val2 == "0"));
                },
                messages: {
                    en: 'Residence years and months can&#39;t be both 0'
                }
            });
        } else if (type == "address" || type == "address1" || type == "address2") {
            if (type == "address" || type == "address1") {
                $(id).attr('data-parsley-pattern', "^\\d{1,} [0-9a-zA-Z '.,#]{2,120}");
            } else {
                $(id).attr('data-parsley-pattern', "^[0-9a-zA-Z '.#]{1,50}");
            }

            //$(id).attr('data-parsley-minlength', '3');

            if (id == "#ADDRESS1" && $('#ADDRESS2').length != 0) {
                $(id).attr('data-parsley-address', 'ADDRESS2');
            }
            if (id == "#ADDRESS2") {
                $(id).attr('data-parsley-address2', 'ADDRESS1');
            }

            if ($(id).attr('data-parsley-address') != '') {

                window.Parsley
                    .addValidator('address2', {
                        requirementType: 'string',
                        validateString: function(value, fieldcompare) {
                            addr2 = value; //$(id).val();
                            addr1 = $('#' + fieldcompare).val();

                            return ((addr1.length > 2 && addr2.length < 1) ||
                                (addr1.length > 2 && addr2.length >= 1 && addr1 != addr2));
                        },
                        messages: {
                            en: 'Home address is required, and if address 2 is filled, it must be different than address 1'
                        }
                    });
            } else if ($(id).attr('data-parsley-address2') != '') {

                window.Parsley
                    .addValidator('address', {
                        requirementType: 'string',
                        validateString: function(value, fieldcompare) {
                            addr1 = value; //$(id).val();
                            addr2 = $('#' + fieldcompare).val();

                            return ((addr1.length > 2 && addr2.length < 1) ||
                                (addr1.length > 2 && addr2.length >= 1 && addr1 != addr2));
                        },
                        messages: {
                            en: 'Home address is required, and if address 2 is filled, it must be different than address 1'
                        }
                    });
            }
        }
    } else if (type == "dob_year" || type == "dob_month" || type == "dob_day") {

        if (id == "#DOB_YEAR" || id == "#DOB_MONTH" || id == "#DOB_DAY") {
            $(id).attr('data-parsley-dob', '[DOB_MONTH,DOB_DAY,DOB_YEAR]');
        }

        window.Parsley
            .addValidator('dob', {
                requirementType: ['string', 'string', 'string'],
                validateString: function(value, req1, req2, req3) {
                    if ($('#' + req2).val() == '' || $('#' + req1).val() == '' || $('#' + req3).val() == '')
                        return true;

                    s = $('#' + req2).val() + '/' + $('#' + req1).val() + '/' + $('#' + req3).val();
                    isvalid = sparkjqv_isValidDate(s);
                    if (isvalid) {
                        $('#' + req2 + ',#' + req1 + ',#' + req3).removeClass('parsley-error').addClass('parsley-success');
                    }
                    return isvalid;

                },
                messages: {
                    en: 'Your Date of Birth should be a valid date.'
                }
            });

    }

}

function sparkjqv_isValidDate(s) {
    var bits = s.split('/');
    var d = new Date(bits[2], bits[1] - 1, bits[0]);
    return d && (d.getMonth() + 1) == bits[1];
}

///* Disable submit until fully loaded */
//$('[data-validates-form]').attr('href-disabled', $('[data-validates-form]').attr('href'));
//$('[data-validates-form]').attr('href', 'javascript:;');


/* this is required to be able to bind to postback events in ASP.NET */

/*
 * Copyright (c) 2013 Peter Morlion
 * Licensed under the MIT license.
 * http://petermorlion.blogspot.com
 */

var old__doPostBack;
var spark_isSubmitting = false;