var ModalController = function () {

    this.intialize = function () {
        loadDataSelectList();
    }

    function loadDataSelectList() {
        loadAssignee();
        loadStatus();
    }
    function loadAssignee() {
        $(document).ready(function () {
            var render = '';
            var template = $('#OptionAssignee').html();
            $.ajax({
                url: "/Tasks/LoadAssignee",
                type: 'GET',
                datatype: 'json',
                success: function (response) {
                    $.each(response.data, function (i, item) {
                        render += Mustache.render(template, {
                            assigneeName: item.FullName,
                            assigneeId: item.Id
                        })
                    })
                    $('#AssigneeData').html(render);
                }
            })
        })
    }
    function loadStatus() {
        $(document).ready(function () {
            var render = '';
            var template = $('#OptionStatus').html();
            $.ajax({
                url: "/Tasks/LoadStatus",
                type: 'GET',
                datatype: 'json',
                success: function (response) {
                    $.each(response.data, function (i, item) {
                        render += Mustache.render(template, {
                            assigneeName: item.FullName,
                            assigneeId: item.Id
                        })
                    })
                    $('#AssigneeData').html(render);
                }
            })
        })
    }
}