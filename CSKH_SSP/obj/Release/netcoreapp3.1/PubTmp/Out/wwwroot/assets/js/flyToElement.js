function flyToElement(begin, target) {
    var target = $('#' + target);
    var beginElement = $("#" + begin);
    beginElement.addClass("animate__animated animate__backOutLeft");
    beginElement.removeClass("animate__animated animate__backOutLeft");
    target.addClass("animate__animated animate__bounce");
    target.removeClass("animate__animated animate__bounce");




    //if (beginElement.length > 0) {
    //    var elementClone = beginElement.clone()
    //        .offset({
    //            top: beginElement.offset().top,
    //            left: beginElement.offset().left
    //        })
    //        .css({
    //            'opacity': '0.7',
    //            'position': 'absolute',
    //            'z-index': '100',
    //            'background-color': '#007bff',
    //            'color': 'white',
    //            'width': 'auto',
    //            'padding': 10
    //        })
    //        .appendTo($('body'))
    //        .animate({
    //            'top': target.offset().top + 10,
    //            'left': target.offset().left + 10,
    //            'width': 'auto',
    //            'height': 'auto',
    //            'padding' : 10
    //        }, 1000, 'easeInOutExpo');

    //    setTimeout(function () {
    //        target.effect("shake", {
    //            times: 2
    //        }, 200);
    //    }, 1500);

    //    elementClone.animate({
    //        'width': 0,
    //        'height': 0
    //    }, function () {
    //        $(this).detach()
    //    });
    //}

}

