$(function () {
    var PlaceHolderElement = $('#PlaceHolderHere');
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url'); // Corrected the syntax here
        var decodeurl = decodeURIComponent(url);
        $.get(decodeurl).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        });
    });

    $(document).on('click', '[data-save="modal"]', function (event) { // Corrected the selector here
        event.preventDefault();
        var form = $(this).parents('.modal').find('form');
        var actionurl = form.attr('action');
        var senddata = form.serialize();
        $.post(actionurl, senddata).done(function (data) {
            PlaceHolderElement.find('.modal').modal('hide');
        });
    });
});


