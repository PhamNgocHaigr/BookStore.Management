function registerDatatable(elementName, columns, urlApi) {
    $(elementName).DataTable({
        processing: true,
        serverSide: true, 
        columns: columns,
        ajax: {
            url: urlApi, // Sử dụng biến urlApi thay vì 'urlApi'
            type: 'POST',
            dataType: 'json'
        }
    });
}