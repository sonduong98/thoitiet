function openPopupForm(link) {

    var modal1 = $('#modal-placeholder .modal.show');
    var url = $(event.target).data('url');
    if (link) url = link;

    var placeholderElement = $('#modal-placeholder');
    if (modal1.length) placeholderElement = $('#modal-placeholder2');

    $.get(url).done(function (data) {
        placeholderElement.html(data);
        placeholderElement.find('.modal').modal('show');
        //var form = placeholderElement.find('form');
        //$.validator.unobtrusive.parse(form);
        //$('.modal').on('shown.bs.modal', function () {
        //    $('.focused').focus();
        //});
    });
}