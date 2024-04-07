(function () {
    const elementName = "#tbl-account";
    const columns = [
        {
            data: 'id', name: 'id', width: '50',
            render: function (key) {
                return `
                    <span data-key="${key}">
                        <a href="/admin/account/savedata?id=${key}"><i class="fas fa-pencil-alt"></i></a> &nbsp;
                               <a href="#" class="btn-delete"><i class="fas fa-trash"></i></a>
                    </span>
                `;
            }
        },
        { data: 'username', name: 'username', autoWidth: true },
        { data: 'fullname', name: 'fullname', autoWidth: true },
        { data: 'email', name: 'email', autoWidth: true },
        { data: 'phone', name: 'phone', autoWidth: true },
        { data: 'isActive', name: 'isActive', autoWidth: true }
    ];

    const urlApi = "/admin/account/getaccountpagination";

    registerDatatable(elementName, columns, urlApi);

    $(document).on('click', '.btn-delete', function () {

        const key = $(this).closest('span').data('key');


        $.ajax({
            url: `/admin/account/delete/${key}`,
            dataType: 'json',
            method: 'POST',
            success: function (response) {

                if (!response) {
                    showToaster("Error", "Delete failed");
                    return;
                }
                $(elementName).DataTable().ajax.reload();
                showToaster("Success", "Delete successful");
            }
        })
    });

})();