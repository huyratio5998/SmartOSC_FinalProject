var statusController = function () {

    this.init = function () {
        loadData();
        registerEvents();
    }

    var registerEvents = function () {
        $('body').on('click', '#btnAdd', function (e) {
            e.preventDefault();
            $('#exampleModal').modal('show');
        });
        $('body').on('click', '#EditPartial', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            GetDetails(id);
        });
        $('body').on('click', '#Savechanges', function (e) {
            e.preventDefault();
            var id = $('#txtid').val();
            var Name = $('#txtName').val();     
            save(id, Name);
        });
        $('body').on('click', '#Delete', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            DeleteStudent(id);
        });

    }
    function loadData() {
        $(document).ready(function () {
            var html1 = '';
            var template = $('#dataStatus').html();
            $.ajax({
                url: '/Status/GetAll',
                type: 'GET',
                dataType: 'json',
                success: function (response) {
                    if (response.status) {
                        $.each(response.data, function (i, item) {
                            html1 += Mustache.render(template, {
                                Id: item.Id,
                                Name: item.Name
                            });
                            
                            $('#exampleModal').modal('hide');

                        });
                        $('#tblData').html(html1);
                    }
                    $.notify("load data done", "success");
                }

            })
        });
    }
    function save(id, Name) {
        $.ajax({
            url: '/Status/save',
            data: {
                Id: id,
                Name: Name
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                $.notify("save data done", "success");
                loadData();
            },
            error: function (err) {
                $.notify("save error", "error");
            }
        });
    }
    function DeleteStudent(id) {
        $.ajax({
            url: '/Status/Delete',
            data: {

                Id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                $.notify("delete data done", "success");
                loadData();
            },
            error: function (err) {
                $.notify("delete error", "error");
            }
        });
    };
    function GetDetails(id) {
        $.ajax({
            url: '/Status/GetDetails',
            data: {
                Id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {               
                    var data = response.data;
                    $('#txtid').val(data.Id);
                    $('#txtName').val(data.Name);
                $('#exampleModal').modal('show');
                $.notify("Get data done", "success");
            },
            error: function (err) {
                $.notify("get data error", "error");
            }
        });
    };
}