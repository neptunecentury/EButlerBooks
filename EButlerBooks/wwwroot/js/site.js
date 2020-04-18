// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
+function () {

    // Functions
    function getBackgroundUrl(size) {
        return appGlobal.backgroundImage.replace("{0}", "-" + size);
    }

    function applyBackground(imgUrl) {
        $('body').css("background-image", "url('" + imgUrl + "')");
    }


    // Register plugins and handlers
    // Register media queries
    enquire.register("screen and (min-width: 992px)", {

        // If supplied, triggered when a media query matches.
        match: function () {
            var _desktopBackground = getBackgroundUrl("xl");
            applyBackground(_desktopBackground);
        },
        unmatch: function () {
            var _desktopBackground = getBackgroundUrl("lg");
            applyBackground(_desktopBackground);
        },
        setup: function () {
            var _desktopBackground = getBackgroundUrl("lg");
            applyBackground(_desktopBackground);
        }


    }, true);

    
    
}();