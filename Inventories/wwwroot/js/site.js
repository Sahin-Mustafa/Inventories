$(function () {
    $('#Isbreak').change(function () {
        if ($('#Isbreak').is(":checked")) {
            $('#ShowHideMe').toggle($(this).is(':checked'));
            // it is checked
        }
        else
        {
            $('.employmentdate').val("null")
        }

    });
});