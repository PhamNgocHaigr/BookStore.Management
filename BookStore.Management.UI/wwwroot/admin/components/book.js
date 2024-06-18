(function () {
    const elementName = "#tbl-book";
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
        },
        { data: 'genreName', name: 'genreName', autoWidth: true },
        { data: 'code', name: 'code', autoWidth: true },
        { data: 'title', name: 'name', autoWidth: true },
        { data: 'available', name: 'available', autoWidth: true }, 
        { data: 'cost', name: 'cost', autoWidth: true },
        { data: 'publisher', name: 'publisher', autoWidth: true },
        { data: 'author', name: 'author', autoWidth: true },
        { data: 'createdOn', name: 'createdOn', autoWidth: true }
    ];

    const urlApi = "/admin/book/getbookspagination";
 
    registerDatatable(elementName, columns, urlApi);

  

 

})();