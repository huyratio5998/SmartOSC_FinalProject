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
            var mydata={
                 Id : $('#hidId').val(),
                 UserName : $('#txtUserName').val(),
                 FullName : $('#txtFullName').val(),
                 Password : $('#txtOldPassword').val(),
                 Email : $('#txtEmail').val(),
                 UrlAvatar : $('#txtUrlAvatar').val()
            };
           // mydata.__RequestVerificationToken = $('#myForm input[name="__RequestVerificationToken"]').val();
            $.ajax({
                url: "/Account/EditACC",
                data: mydata,
                data: { MyAccount : mydata },
                type: 'POST',
               // type: 'GET',
                dataType: 'json',
                success: function (response) {
                    $.notify("save data done", "success");
                    loadData();
                },
                error: function (err) {
                    $.notify("save error", "error");
                }
            });
            //save(Id, FullName, Email, Password, UserName, UrlAvatar);
        });
        $('body').on('change', 'txtUrlAvatar', function (e) {
            e.preventDefault();
            var UrlAvatar = $('#txtUrlAvatar').val();
            show(UrlAvatar);
        });          
    }
    function show(UrlAvatar) {

        $('#uimgurl').append('<img width="400"  data-path="' + UrlAvatar + '" src="' + UrlAvatar + '"></div>');;
    }
    
    function resetFormMaintainance() {
        $//('#txtUserName').prop('disabled', disabled);
        $('#txtOldPassword').val('');
        $('#txtPassword').val('');
        $('#txtConfirmPassword').val('');
        $('input[name="ckRoles"]').removeAttr('checked');

    }
    function save(Id, FullName, Email, Password, UserName, UrlAvatar) {
        $.ajax({
            url: "/Account/EditACC",
            data: {
                Id: Id,
                FullName: FullName,
                Email: Email,
                Password: Password,
                UserName: UserName,               
                UrlAvatar: UrlAvatar                                
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