
$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblProductList').DataTable({
        "ajax": { url: '/admin/product/getall'},
        "columns": [
            { data: 'title', "width": "15%" },
            { data: 'isbn', "width": "15%" },
            { data: 'author', "width": "15%" },
            { data: 'category.name', "width": "15%" },
            { data: 'price', "width": "15%" }
        ]
    });
}