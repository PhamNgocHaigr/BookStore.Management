(function () {
    const elementName = "#tbl-genre";
    const columns = [
        {
            data: 'id', name: 'id', width: '30',
            render: function (key) {
                return `
                    <span data-key="${key}">
                        <a href="#" class="btn-edit"><i class="fas fa-pencil-alt"></i></a> &nbsp;
                               <a href="#" class="btn-delete"><i class="fas fa-trash"></i></a>
                    </span>
                `;
            }
             /*   / admin / genre / savedata ? id = ${ key }*/
        },
        { data: 'name', name: 'name', autoWidth: true },
        { data: 'description', name: 'description', autoWidth: true },
        { data: 'isActive', name: 'isActive', autoWidth: true },
        { data: 'createOn', name: 'createOn', autoWidth: true } 

    ];

    const urlApi = "/admin/genre/getgenrepagination";
 
    registerDatatable(elementName, columns, urlApi);

  

    $(document).on('click', '#btn-add', function () {
        $('Id').val(0);
        $('#Name').val('');
        $('#Description').val('');
        $('#genre-modal').modal('show');
    });



    $(document).on('click', '.btn-edit', function () {
        const key = $(this).closest('span').data('key');
   
        $.ajax({
            url: `/admin/genre/getbyid?id=${key}`,
            method: "GET",
            success: function (response) {
                console.log(response);
                if (!response) {
                    showToaster("Error", "Update failed");
                     return;
                }
                else
                {
                    mapObjectToControlView(response);
                    $('#genre-modal').modal('show');
                }              
            }
           
        })
    });

    $(document).on('click', '.btn-delete', function () {

        const key = $(this).closest('span').data('key');
        $.ajax({
            url: `/admin/genre/delete/${key}`,
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



    $('#fromGenre').submit(function (e) {
        e.preventDefault();

        const formdata = $(this).serialize();

        $.ajax({
            url: $(this).attr('action'),
            method: $(this).attr('method'),
            data: formdata,
            success: function (response) {
                console.log(response);
                showToaster("Success", "Update successful");
                $(elementName).DataTable().ajax.reload();
                $('#genre-modal').modal('hide');
            },
            error: function (error) {

            }
        })
    })

})();