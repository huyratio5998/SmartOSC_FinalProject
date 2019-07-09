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
                                ID: item.Id,
                                Name: item.Name
                            });
                            $('#exampleModal').modal('hide');

                        });
                        $('#tblData').html(html1);
                    }
                }

            })
        });
    }
    function save(id, Name) {
        $.ajax({
            url: '/Status/save',
            data: {
                ID: id,
                Name: Name
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                alert('done');
                loadData();
            },
            error: function (err) {
                alert('error')
            }
        });
    }
    function DeleteStudent(id) {
        $.ajax({
            url: '/Status/Delete',
            data: {

                ID: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                alert('delete done');


                loadData();
            },
            error: function (err) {
                alert('error')
            }
        });
    };
}