var TaskController = function () {

    this.intialize = function () {
        registerEvent();
    }

    function registerEvent() {
        var projectId, UserId;
        $(document).ready(function () {
            $('#ShowButton').click(function () {
                projectId = $('#ProjectId').val();
                UserId = $('#AssigneeId').val();
                loadData(projectId,UserId);
            })
        })
    }

    function loadData() {
        $.ajax({
            url: "Tasks/GetData",
            type: 'GET',
            datatype: 'json',
            success: function (response) {
                var template = $('#data-template').html();
                var render = "";
                $.each(response.data, function (i, item) {
                    render += Mustache.render(template, {
                        TaskId: item.TaskId,
                        TaskName: item.TaskName,
                        Assignee: item.UserId,
                        Status : item.Status
                    })
                })
                $('#tblData').html(render);
            }
        })
    }

}