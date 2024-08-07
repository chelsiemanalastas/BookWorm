
$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblProductList').DataTable({
        "ajax": { url: '/admin/product/getall'},
        "columns": [
            { data: 'title' },
            { data: 'isbn' },
            { data: 'author' },
            { data: 'price' }
        ]
    });
}