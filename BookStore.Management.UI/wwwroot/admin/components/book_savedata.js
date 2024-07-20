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

    document.getElementById('Image').onchange = function () {
        const input = document.getElementById('Image').files[0];
        if (input) {
            document.getElementById('img-book').src = URL.createObjectURL(input);
        }
    }
})();