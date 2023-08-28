var datatable
$(document).ready(function () {
    loadTable();
})

function loadTable() {

    datatable = $('#mtableData').DataTable(
        {
            "ajax": { url: '/admin/product/getAll' },
       
            "columns": [
                { data: 'name' ,"width": "15%"},               
                { data: 'manufacturer', "width": "15%" },
                { data: 'price', "width": "15%" },
                { data: 'category.name', "width": "15%" },
                { data: 'id', 
                    "render": function (data) {
                        return `
                            <div class="btn-group w-75 bor" role="group">
                            
                            <a href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2 ">
                                <i class="bi bi-pencil-square"></i> &nbsp Edit
                            </a>
                            <a onClick=Delete("/admin/product/delete/${data}") class="btn btn-danger mx-2 ">
                                <i class="bi bi-trash"></i> Delete
                            </a>
                        </div>
                        `
                    },
                "width": "40%" },
            ]
        });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        hideClass: {
            popup: 'animate__animated animate__lightSpeedOutRight'
        },
        showClass: {
            popup: 'animate__animated animate__lightSpeedInLeft'
        },
               
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    datatable.ajax.reload();
                    toaster.success(data.message);
                }
            })
        }
    })
}
