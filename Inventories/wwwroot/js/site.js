$(function () {
    $('#Isbreak').change(function () {
        $('#ShowHideMe').toggle($(this).is(':checked'));
    });
});