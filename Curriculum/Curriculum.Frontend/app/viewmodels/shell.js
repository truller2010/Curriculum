define([
    'plugins/router', 'durandal/app', 'core/broker', 'core/i18n', 'jquery', 'core/authentication/authenticationBroker', 'core/authentication/securityContext'
], function (router, app, brokerUtils, i18n, $, authenticationBroker, securityContext) {
    return {
        isLoading: ko.computed(function() {
            return brokerUtils.requestCount > 0 || router.isNavigating();
        }),
        router: router,
        brokerUtils: brokerUtils,
        i18n: i18n,
        activate: function() {
            var routes = [];

            routes = [
                { route: '', title: 'Inicio', moduleId: 'viewmodels/welcome', nav: true },
                { route: '404', title: 'Posts', moduleId: 'viewmodels/404', nav: true, hash: '#404' },
            ];

            return router.map(routes).buildNavigationModel().activate();
        },
        attached: function () {

            jQuery(document).ready(function ($) {


                /*
                =============================================== 01. MENU ACTIVATION  ===============================================
                */

                jQuery("ul.sf-menu").supersubs({
                    minWidth: 3,   // minimum width of sub-menus in em units 
                    maxWidth: 20,   // maximum width of sub-menus in em units 
                    extraWidth: 1     // extra width can ensure lines don't sometimes turn over 
                    // due to slight rounding differences and font-family 
                }).superfish({
                    animation: { opacity: 'show' },
                    animationOut: { opacity: 'hide' },
                    speed: 200,           // speed of the opening animation. Equivalent to second parameter of jQuery’s .animate() method
                    speedOut: 'normal',
                    autoArrows: true,               // if true, arrow mark-up generated automatically = cleaner source code at expense of initialisation performance 
                    dropShadows: false,               // completely disable drop shadows by setting this to false 
                    delay: 400               // 1.2 second delay on mouseout 
                });



                /*
                =============================================== 02. GALLERY JAVASCRIPT  ===============================================
                */

                $(window).load(function () {
                    $('.gallery-progression').flexslider({
                        animation: "fade",
                        slideDirection: "horizontal",
                        slideshow: false,
                        slideshowSpeed: 7000,
                        animationDuration: 200,
                        directionNav: true,
                        useCSS: false,
                        controlNav: true
                    });
                });


                $('.synopsis-slider-pro').flexslider({
                    animation: "fade",
                    slideDirection: "horizontal",
                    slideshow: false,
                    slideshowSpeed: 7000,
                    animationDuration: 200,
                    directionNav: false,
                    controlNav: true
                });


                /*
                =============================================== 03. FITVIDES RESPONSIVE VIDEOS  ===============================================
                */

                $("body").fitVids();



                /*
                =============================================== 04. MOBILE SELECT MENU  ===============================================
                */

                $('.sf-menu').mobileMenu({
                    defaultText: 'Navigate to...',
                    className: 'select-menu',
                    subMenuDash: '&ndash;&ndash;'
                });


                /*
                =============================================== 05. prettyPhoto Activation  ===============================================
                */

                jQuery("a[data-rel^='prettyPhoto']").prettyPhoto({
                    animation_speed: 'fast', /* fast/slow/normal */
                    slideshow: 5000, /* false OR interval time in ms */
                    autoplay_slideshow: false, /* true/false */
                    opacity: 0.80, /* Value between 0 and 1 */
                    show_title: false, /* true/false */
                    allow_resize: true, /* Resize the photos bigger than viewport. true/false */
                    default_width: 500,
                    default_height: 344,
                    counter_separator_label: '/', /* The separator for the gallery counter 1 "of" 2 */
                    theme: 'pp_default', /* light_rounded / dark_rounded / light_square / dark_square / facebook */
                    horizontal_padding: 20, /* The padding on each side of the picture */
                    hideflash: false, /* Hides all the flash object on a page, set to TRUE if flash appears over prettyPhoto */
                    wmode: 'opaque', /* Set the flash wmode attribute */
                    autoplay: false, /* Automatically start videos: True/False */
                    modal: false, /* If set to true, only the close button will close the window */
                    deeplinking: false, /* Allow prettyPhoto to update the url to enable deeplinking. */
                    overlay_gallery: false, /* If set to true, a gallery will overlay the fullscreen image on mouse over */
                    keyboard_shortcuts: true, /* Set to false if you open forms inside prettyPhoto */
                    ie6_fallback: true,
                    social_tools: '' /* html or false to disable  <div class="pp_social"><div class="twitter"><a href="http://twitter.com/share" class="twitter-share-button" data-count="none">Tweet</a><script type="text/javascript" src="http://platform.twitter.com/widgets.js"></script></div><div class="facebook"><iframe src="http://www.facebook.com/plugins/like.php?locale=en_US&href='+location.href+'&amp;layout=button_count&amp;show_faces=true&amp;width=500&amp;action=like&amp;font&amp;colorscheme=light&amp;height=23" scrolling="no" frameborder="0" style="border:none; overflow:hidden; width:500px; height:23px;" allowTransparency="true"></iframe></div></div> */
                });


                /*
                =============================================== 06. Form Validation  ===============================================
                */


                $("#CommentForm").validate();


                /*
                =============================================== 07. Light Shortcodes  ===============================================
                */


                // Accordion
                $(".ls-sc-accordion").accordion({ heightStyle: "content" });

                // Toggle
                $(".ls-sc-toggle-trigger").click(function () { $(this).toggleClass("active").next().slideToggle("fast"); return false; });

                // Tabs
                $(".ls-sc-tabs").tabs();





                /*
                =============================================== 08. Backstretch ===============================================
                */

                $('body.resume').imagesLoaded(function () {
                    $("body.home #page-title").backstretch(["images/demo/bigstock-Young-designer-in-office-talki-73186111.jpg"], { fade: 750, });
                    $("body.contact #page-title").backstretch(["images/demo/bigstock-Cheerful-guy-sitting-in-front--53542399.jpg"], { fade: 750, });
                    $("#contact-widget-container").backstretch(["images/demo/map-progression.jpg"], { fade: 750, });
                    $("body.resume #page-title").backstretch(["images/demo/photo-1416339684178-3a239570f315.jpg"], { fade: 750, });
                    $("body.resume #resume-portfolio-widget").backstretch(["images/demo/photo-1421757295538-9c80958e75b0.jpg"], { fade: 750, });
                    $("body.portfolio #page-title").backstretch(["images/demo/tEREUy1vSfuSu8LzTop3_IMG_2538.jpg"], { fade: 750, });
                    $("body.single-portfolio #page-title").backstretch(["images/demo/tEREUy1vSfuSu8LzTop3_IMG_2538.jpg"], { fade: 750, });
                    $("body.blog #page-title").backstretch(["images/demo/photo-1421757295538-9c80958e75b0.jpg"], { fade: 750, });
                    $("body.page #page-title").backstretch(["images/demo/photo-1421757295538-9c80958e75b0.jpg"], { fade: 750, });
                    $("body.blog-post.single-blog.post-id-11 #page-title").backstretch(["images/demo/photodune-792391-close-up-of-business-hand-hold-touch-screen-mobile-phone-and-buttons-m.jpg"], { fade: 750, });
                });

                /*
                =============================================== 09. SCROLLTOFIXED  ===============================================
                */

                $('#sidebar-padding').scrollToFixed({
                    spacerClass: "pro-spacer",
                    marginTop: function () {
                        var marginTop = $(window).height() - $('#sidebar-padding').outerHeight(true) - 0;
                        if (marginTop >= 0) return 0;
                        return marginTop;
                    }
                });


                /*
                =============================================== 10. Show/Hide Sidebar  ===============================================
                */

                $(".show-hide-pro").click(function () {
                    $("body").toggleClass("toggle-active-pro");
                });

                $(".tablet-show-hide").click(function () {
                    $("#sidebar-padding nav").toggleClass("toggle-nav-pro");
                    $("#navigation-sidebar-pro").toggleClass("toggle-nav-pro");
                    $(".tablet-show-hide").toggleClass("toggle-nav-button-pro");
                });

                /*
                =============================================== 11. easyPieChart  ===============================================
                */


                $.each(['chart'], function (i, classname) {
                    var $elements = $('.' + classname)

                    $elements.each(function () {
                        new Waypoint({
                            element: this,
                            handler: function (direction) {

                                $(function () {
                                    $('.chart').easyPieChart({
                                        barColor: '#8f8f8f',
                                        trackColor: '#d4d4d4',
                                        lineWidth: 5,
                                        size: 155,
                                        scaleLength: 0,
                                        onStep: function (from, to, percent) {
                                            $(this.el).find('.percent').text(Math.round(percent));
                                        }
                                    });
                                });
                            },
                            offset: 'bottom-in-view',
                            group: classname
                        })
                    })
                })


                /*
                =============================================== 12. Skills Bar Animations  ===============================================
                */

                $.each(['skill-synopsis'], function (i, classname) {
                    var $elements = $('.' + classname)

                    $elements.each(function () {
                        new Waypoint({
                            element: this,
                            handler: function (direction) {

                                $(this.element).addClass('active-pro')
                            },
                            offset: 'bottom-in-view',
                            group: classname
                        })
                    })
                })


                /*
                =============================================== 13. Isotope  ===============================================
                */

                var $winsize = $(window).width();
                var $guttersize = $winsize * 0.015;

                var $isocontainer = $('.isotope');
                $('.isotope').imagesLoaded(function () {
                    // init Isotope
                    $('.isotope').isotope({ filter: '.init' });
                    var $container = $('.isotope').isotope({
                        itemSelector: '.isotope-item',
                        layoutMode: 'masonry',
                        masonry: { "gutter": $guttersize },
                        transitionDuration: '0.8s'
                    });
                    // filter functions
                    var filterFns = {
                    };
                    // bind filter button click
                    $('#filters').on('click', 'button', function () {
                        var filterValue = $(this).attr('data-filter');
                        // use filterFn if matches value
                        filterValue = filterFns[filterValue] || filterValue;
                        $container.isotope({ filter: filterValue });
                    });
                    // change is-checked class on buttons
                    $('.button-group').each(function (i, buttonGroup) {
                        var $buttonGroup = $(buttonGroup);
                        $buttonGroup.on('click', 'button', function () {
                            $buttonGroup.find('.is-checked').removeClass('is-checked');
                            $(this).addClass('is-checked');
                        });
                    });

                    //Timeout
                    setTimeout(function () {
                        $isocontainer.isotope('layout');
                    }, 120);

                });


                //Isotope Reorder Layout on Window Resize
                var tilefix;
                $(window).on('resize', function () {
                    tilefix = $('.isotope-item').width();
                    $isocontainer.isotope('layout');
                });







                // END
            });
        }
    };
});

