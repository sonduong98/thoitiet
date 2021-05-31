function reloadPage() {
    var refreshArea = $('[data-url-refresh]').last();
    var url = refreshArea.attr('data-url-refresh');
    $.get(url).done(function (data) {
        var refreshedData = $(data).find('[data-url-refresh]').html();
        refreshArea.html(refreshedData);
    });
}
function openPopupForm(link) {

    var modal1 = $('#modal-placeholder .modal.show');
    var url = $(event.target).data('url');
    if (link) url = link;

    var placeholderElement = $('#modal-placeholder');
    if (modal1.length) placeholderElement = $('#modal-placeholder2');

    $.get(url).done(function (data) {
        placeholderElement.html(data);
        placeholderElement.find('.modal').modal('show');
        var form = placeholderElement.find('form');
        $.validator.unobtrusive.parse(form);
        $('.modal').on('shown.bs.modal', function () {
            $('.focused').focus();
        });
    });
}

function savePopupForm() {
    //var id = $('#idbank').val();
    //$('#bankId').val(id);
    event.preventDefault();
    var form = $(event.target).parents('.modal').find('form')[0];
    var isValid = $(form).valid();
    if (!isValid) return;

    var actionUrl = $(event.target).parents('.modal').find('form').attr('action');
    var formData = new FormData(form);
    $.ajax({
        type: "POST",
        enctype: 'multipart/form-data',
        url: actionUrl,
        data: formData,
        processData: false,
        contentType: false,
        cache: false,
        timeout: 600000,
        success: function (data) {
            var newBody = $('.modal-body', data);
            var placeholderElement = $('#modal-placeholder');

            var modal2 = $('#modal-placeholder2 .modal.show');
            if (modal2.length) placeholderElement = $('#modal-placeholder2');

            placeholderElement.find('.modal-body').replaceWith(newBody);

            // find IsValid input field and check it's value
            // if it's valid then hide modal window
            //var isValid = newBody.find('[name="IsValid"]').val() == 'True';
            //if (isValid) {
            //    placeholderElement.find('.modal').modal('hide');
            //    placeholderElement.find('.modal').empty();
            //    showSuccessMessage("Successful implementation!");
            //    reloadPage();
            //}
            placeholderElement.find('.modal').modal('hide');
            placeholderElement.find('.modal').empty();
            showSuccessMessage("Successful implementation!");
            reloadPage();

        }
    });
}
//test save category child

function reloadGridPage(pageIndex) {

    var refreshUrl = $('[data-url-refresh]').last().attr('data-url-refresh');
    if (refreshUrl.indexOf("?") === -1) {
        refreshUrl += '?';
    }
    var pattern = /pageindex=[0-9]+/g;
    refreshUrl = refreshUrl.replace(pattern, '');

    var lastChar = refreshUrl.substr(-1);
    if (lastChar !== '?' && lastChar != '&') refreshUrl += '&';

    refreshUrl += 'pageindex=' + pageIndex;
    $('[data-url-refresh]').attr('data-url-refresh', refreshUrl);
    window.history.pushState('page2', 'Title', refreshUrl);
    reloadPage();
    return;

    var url = window.location.href;
    if (url.indexOf("?pageIndex") != -1) {
        urlSplit = url.split("?pageIndex")[0];
        url = urlSplit + "?pageIndex=" + pageIndex;
    }
    if (url.indexOf("&pageIndex") != -1) {
        urlSplit = url.split("&pageIndex")[0];
        url = urlSplit + "&pageIndex=" + pageIndex;
    }

    if (url.indexOf("?pageIndex") == -1 && url.indexOf("&pageIndex") == -1 && url.indexOf("?") == -1) {
        url += "?pageIndex=" + pageIndex;
    }
    if (url.indexOf("?pageIndex") == -1 && url.indexOf("&pageIndex") == -1 && url.indexOf("?") != -1) {
        url += "&pageIndex=" + pageIndex;
    }
    $('[data-url-refresh]').attr('data-url-refresh', url);
    reloadPage();
    window.history.pushState('page2', 'Title', url);
}
function searchClick() {
    var refreshUrl = window.location.pathname + '?keyword=' + $(".search-input").val();
    $('[data-url-refresh]').attr('data-url-refresh', refreshUrl);
    window.history.pushState('page2', 'Title', refreshUrl);
    reloadPage();
}
$(document).ready(function () {
    $('body').delegate('input', 'blur', function () {
        $("[for-slug]").blur(function () {
            var name = $(event.target).attr('for-slug');
            text = $(event.target).val();
            text = text.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ|Á|À|Ả|Ã|Ạ|Ă|Ắ|Ằ|Ẳ|Ẵ|Ặ|Â|Ấ|Ầ|Ẩ|Ẫ|Ậ/g, "a").replace(/Đ|đ/g, "d").replace(/'/g, "").replace(/đ/g, "d").replace(/ỳ|ý|ỵ|ỷ|ỹ|Ý|Ỳ|Ỷ|Ỹ|Ỵ/g, "y").replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ|Ú|Ù|Ủ|Ũ|Ụ|Ư|Ứ|Ừ|Ử|Ữ|Ự/g, "u").replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ.|Ó|Ò|Ỏ|Õ|Ọ|Ô|Ố|Ồ|Ổ|Ỗ|Ộ|Ơ|Ớ|Ờ|Ở|Ỡ|Ợ+/g, "o").replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ|É|È|Ẻ|Ẽ|Ẹ|Ê|Ế|Ề|Ể|Ễ|Ệ/g, "e").replace(/ì|í|ị|ỉ|ĩ|Í|Ì|Ỉ|Ĩ|Ị/g, "i").replace(/[^\w\s]/gi, ' ').replace(/  +/g, '-');
            var text = text.split(" ").join("-").toLowerCase();
            $('[Name="' + name + '"]').val(text);
        })
    })
});
$(document).on('keyup', '.filter_area input', function () {
    if (event.keyCode === 13) {
        var area = $(event.target).parents('.filter_area');
        area.find('button').click();
    }
});


function deleteItem(url) {
    window.deleteUrl = url;
    var placeholderElement = $('#modal-placeholder');
    var modal1 = $('#modal-placeholder .modal.show');
    if (modal1.length) placeholderElement = $('#modal-placeholder2');

    var text = document.getElementById('exampleModal').outerHTML;
    placeholderElement.html(text);
    placeholderElement.find('.modal').modal('show');
}
function requestDelete() {
    $.get(window.deleteUrl).done(function (data) {
        reloadPage();
        showSuccessMessage("Successful implementation!");
    });
}
$(".js-example-tags").select2({
    tags: true
});
$(document).ready(function () {
    CKEDITOR.replace('Content');
});