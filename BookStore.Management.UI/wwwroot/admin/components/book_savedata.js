(function () {

    $(document).on('click', '#btn-generate', function () {

        $.blockUI();

        $.ajax({
            url: '/admin/book/generatecodebook',
            success: function (response) {
                $('#Code').val(response);
                $.unblockUI();
            },
            error: function () {
                showToaster('error', 'Generate code failed.');
                $.unblockUI();
            }
        })
    });

})();