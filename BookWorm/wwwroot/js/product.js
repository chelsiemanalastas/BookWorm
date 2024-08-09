
var dataTable;

1$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblProductList').DataTable({
        "ajax": { url: '/admin/product/getall'},
        "columns": [
            { data: 'title', "width": "20%"},
            { data: 'isbn', "width": "15%" },
            { data: 'author', "width": "15%" },
            { data: 'category.name', "width": "15%" },
            { data: 'price', "width": "15%" },
            { data: 'price', "width": "15%" },
            //{
            //    data: 'id',
            //    render: function (data) {
            //        return `<div class="btn-group" role="group">
            //            <a href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-fill"></i> Edit </a>
            //            <a onClick=Delete('/admin/product/delete/${data}') class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i> Delete </a>
            //            </div>`
            //    },
            //    width: "20%"
            //}
        ]
    });
}


function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                ur: url,
                type: 'DELETE',
                success: function (data) {

                    dataTable.ajax.reload();

                    Swal.fire({
                        title: "Deleted!",
                        text: data.message,
                        icon: "success"
                    });

                }
            })
        }
    });
}

