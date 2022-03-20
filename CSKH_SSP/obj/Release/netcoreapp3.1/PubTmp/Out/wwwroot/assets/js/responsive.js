$(document).ready(function () {
    
    $(window).resize(function () {
        if ($(window).width() <= 1370) {
            document.body.classList.add("toggle-menu");
        } else {
            document.body.classList.remove("toggle-menu");
        }
    });
    if ($(window).width() <= 1370) {
        document.body.classList.add("toggle-menu");
    } else {
        document.body.classList.remove("toggle-menu");
    }

});