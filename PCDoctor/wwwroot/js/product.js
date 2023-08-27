
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
                            <a href="/admin/product/delete?id=${data}" class="btn btn-danger mx-2 ">
                                <i class="bi bi-trash"></i> Delete
                            </a>
                        </div>
                        `
                    },
                "width": "15%" },
            ]
        });
}

