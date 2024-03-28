function registerDatatable(elementName, columns, urlApi) {
    $(elementName).DataTable({
        columnDefs: [{
            targets: [0],
            orderData: [0, 1]
        }, {
            targets: [1],
            orderData: [1, 0]
        }, {
            targets: [4],
            orderData: [4, 0]
        }],
        processing: true, // Sử dụng dấu ":" thay vì "="
        serverSide: true, // Sử dụng dấu ":" thay vì "="
        ajax: {
            url: urlApi, // Sử dụng biến urlApi thay vì 'urlApi'
            type: 'POST',
            dataType: 'json'
        }
    });
}