
(function () {
    const elementName = "#tbl-book";
    const columns = [
        {
            data: 'id', name: 'id', width: '30',
            render: function (key) {
                return `
                    <span data-key="${key}">
                        <a href="/admin/book/savedata?id=${key}" class="btn-edit"><i class="fas fa-pencil-alt"></i></a> &nbsp;
                        <a href="#" class="btn-delete"><i class="fas fa-trash"></i></a>
                    </span>
                `;
            }
        },
        { data: 'genreName', name: 'genreName', autoWidth: true },
        { data: 'code', name: 'code', autoWidth: true },
        { data: 'title', name: 'name', autoWidth: true },
        {
            data: 'available', name: 'available', width: "80px", render: function (data) {

                return `<div class="text-right">${data}</div>`
            }
        }, 
        {
            data: 'cost', name: 'cost', width: "80px", render: function (data) {

                return `<div class="text-right">${data.toLocaleString("vi-VN", {
                    style: 'currency',
                    currency: 'VND'
                })}</div>`
            }
        },
        { data: 'publisher', name: 'publisher', autoWidth: true },
        { data: 'author', name: 'author', autoWidth: true },
        {
            data: 'createdOn', name: 'createdOn', autoWidth: true,
            render: function (data) {
                return `<div class="text-center">${moment(data).format("DD/MM/YYYY")}</div>`
            }  
        },  
    ];

    const urlApi = "/admin/book/getbookspagination";
 
    registerDatatable(elementName, columns, urlApi);

    $(document).on('click', '.btn-delete', function () {

        const key = $(this).closest('span').data('key');

        $.ajax({
            url: `/admin/book/delete/${key}`,
            dataType: 'json',
            method: 'POST',
            success: function (response) {

                if (!response) {
                    showToaster("Error", "Delete failed.");
                    return;
                }

                $(elementName).DataTable().ajax.reload();
                showToaster("Success", "Delete successful");
            }
        })

    });
  

 

})();