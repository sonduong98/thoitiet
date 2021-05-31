// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('.input-group.date').datepicker({
    todayBtn: "linked",
    keyboardNavigation: false,
    forceParse: false,
    calendarWeeks: true,
    autoclose: true,
    format: 'dd/mm/yyyy'
});

var opts = {
    lines: 15, // The number of lines to draw
    length: 10, // The length of each line
    width: 4, // The line thickness
    radius: 15, // The radius of the inner circle
    corners: 1, // Corner roundness (0..1)
    rotate: 0, // The rotation offset
    direction: 1, // 1: clockwise, -1: counterclockwise
    color: '#fff', // #rgb or #rrggbb or array of colors
    speed: 1, // Rounds per second
    trail: 60, // Afterglow percentage
    shadow: true, // Whether to render a shadow
    hwaccel: false, // Whether to use hardware acceleration
    className: 'spinner', // The CSS class to assign to the spinner
    zIndex: 2e9, // The z-index (defaults to 2000000000)
    top: '50%', // Top position relative to parent in px
    left: '50%' // Left position relative to parent in px
};
var target = document.getElementById('spinner');
var spinner = new Spinner(opts).spin(target);

function openProcess() {
    $(".loading-indicator").show();
}
function hideProcess() {
    $(".loading-indicator").hide();
}

function showPopupError() {
    $("#popupErrorRequest").modal("show");
}

function renderIcheckBox() {
    $('.i-checks').iCheck({
        checkboxClass: 'icheckbox_square-green',
        radioClass: 'iradio_square-green'
    });
}

// Show success message
function showSuccessMessage(message, center, timeOut) {
    if (!timeOut) {
        timeOut = 2000;
    }
    var centerClass = "gritter-bottom ";
    if (center == null || !center)
        centerClass = "";

    $.gritter.add({
        position: 'bottom-right',
        time: timeOut,
        title: '<i class="fa fa-check-circle"></i>  Message',
        text: message,
        class_name: centerClass + 'gritter-info'
    });

    $('.alert-dismissable').remove();
};

// Show warning message
function showWarningMessage(message, center) {
    // Remove all available messages
    //$.gritter.removeAll();
    $('.alert-dismissable').remove();

    var centerClass = "gritter-center ";
    if (center == null || !center)
        centerClass = "";

    $.gritter.add({
        time: 2000,
        title: '<i class="fas fa-exclamation-triangle"></i> Warning',
        text: message,
        class_name: centerClass + 'gritter-warning'
    });
};

// Show error message
function showErrorMessage(message, center) {
    // Remove all available messages
    removeAllErrorMessages();

    var centerClass = "gritter-center ";
    if (center == null || !center)
        centerClass = "";

    $.gritter.add({
        //time: 5000,
        title: '<i class="fa fa-exclamation-circle"></i> Error',
        sticky: true,
        text: message,
        position: 'bottom-right',
        class_name: ' gritter-error bottom-right'
    });
};

function removeAllErrorMessages() {
    $.each($("#gritter-notice-wrapper div"), function (index, selector) {
        if ($(selector).hasClass("gritter-error")) {
            $(selector).fadeOut(500, function () { $(this).remove(); });
        }
    });

    $('.alert-dismissable').remove();
}

function isEmail(email) {
    var pattern = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
    return pattern.test(email);
};