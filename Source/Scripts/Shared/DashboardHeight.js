$(document).ready(function () {
    toAdapt();
    $(window).resize(function () {
        toAdapt();
    });
});

function toAdapt() {
    var heights = $(".dashText").map(function () {
            return $(this).height();
        }).get(),

        maxHeight = Math.max.apply(null, heights);
    console.log(heights);
    $(".dashHeader").height(maxHeight);
}