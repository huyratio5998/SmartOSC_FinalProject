var MyAccountController = function () {
    this.init = function () {
        loadData();
        registerEvents();
    }
    var registerEvents = function () {
        $('#btnSelectImg').on('click', function () {
            $('#fileInputImageM').click();
        });

        $("#fileInputImageM").on('change', function () {
            var fileUpload = $(this).get(0);
            var files = fileUpload.files;
            var data = new FormData();
            fileInputImage(files, data);
        });

    }
    function resetFormMaintainance() {
        $//('#txtUserName').prop('disabled', disabled);
        $('#txtOldPassword').val('');
        $('#txtPassword').val('');
        $('#txtConfirmPassword').val('');
        $('input[name="ckRoles"]').removeAttr('checked');

    }
    
    function loadData() {
        $.ajax({
            type: "GET",
            url: "/MyAccount/GetAccount",
            dataType: "json",
            success: function (response) {
                var data = response;
                $('#hidId').val(data.Id);
                $('#txtFullName').val(data.FullName);
                $('#txtUserName').val(data.UserName);
                $('#txtEmail').val(data.Email);
                $('#txtImageM').val(data.UrlAvatar);
                resetFormMaintainance();
                
            },
            error: function (err) {
                alert('error')
            }
        });
       
    };
    function fileInputImage(files, data) {

        for (var i = 0; i < files.length; i++) {
            data.append(files[i].name, files[i]);
        }
        $.ajax({
            type: "POST",
            url: "Upload/UploadImage",
            contentType: false,
            processData: false,
            data: data,
            success: function (path) {
                $('#txtImageM').val(path);
                common.notify('Upload image succesful!', 'success');

            },
            error: function () {
                common.notify('There was error uploading files!', 'error');
            }
        });
    }
}