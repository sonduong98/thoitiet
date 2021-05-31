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
function searchClick1() {
    var refreshUrl = window.location.pathname + '?keyword=' + $(".search-input").val();
    $('[data-url-refresh]').attr('data-url-refresh', refreshUrl);
    window.history.pushState('page2', 'Title', refreshUrl);
    reloadPage();
}

$(document).on('keyup', '.filter_area input', function () {
    if (event.keyCode === 13) {
        var area = $(event.target).parents('.filter_area');
        area.find('button').click();
    }
});


