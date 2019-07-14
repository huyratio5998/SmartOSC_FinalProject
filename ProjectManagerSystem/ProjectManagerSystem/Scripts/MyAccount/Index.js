var MyAccountController = function () {
    this.init = function () {
        loadData();
        registerEvents();
    }
    var registerEvents = function () {
        $('body').on('click', '#changepass', function (e) {
            e.preventDefault();
            $('#exampleModal1').modal('show');
        });
        $('#btnSelectImg').on('click', function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (url) {
                $('#txtUrlAvatar').val(url);
            };
            finder.popup();
        });

        $("#fileInputImageM").on('change', function () {
            var fileUpload = $(this).get(0);
            var files = fileUpload.files;
            var data = new FormData();
            fileInputImage(files, data);
        });
        $('body').on('click', '#Savechanges', function (e) {
            e.preventDefault();
            var Id = $('#hidId').val();
            var UserName = $('#txtUserName').val();
            var FullName = $('#txtFullName').val();            
            var Password = $('#txtOldPassword').val();
            var Email = $('#txtEmail').val();
            var UrlAvatar = $('#txtUrlAvatar').val();
            save(Id, UserName, FullName, Password, UrlAvatar, Email);
        });
        
    }
    function resetFormMaintainance() {
        $//('#txtUserName').prop('disabled', disabled);
        $('#txtOldPassword').val('');
        $('#txtPassword').val('');
        $('#txtConfirmPassword').val('');
        $('input[name="ckRoles"]').removeAttr('checked');

    }
    function save(Id, UserName, FullName, Password, UrlAvatar, Email) {
        $.ajax({
            url: '/MyAccount/save',
            data: {
                Id: Id,
                UserName: UserName,
                FullName: FullName,
                Password: Password,
                UrlAvatar: UrlAvatar,
                Email: Email
                
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
    function loadData() {
        $.ajax({
            type: "GET",
            url: "/MyAccount/GetAccount",
            dataType: "json",
            success: function (response) {
                var data = response.data;
                console.log(data);
                $('#hidId').val(data.Id);
                $('#txtFullName').val(data.FullName);
                $('#txtUserName').val(data.UserName);
                $('#txtOldPassword').val(data.Password);
                $('#txtEmail').val(data.Email);
                $('#txtUrlAvatar').val(data.UrlAvatar);
                $('#txtRole').val(data.Role);
                //$.notify("load data done", "success");
                
            },
            error: function () {
                $.notify('Có lỗi xảy ra', 'error');
            }
        });
       
    };
}