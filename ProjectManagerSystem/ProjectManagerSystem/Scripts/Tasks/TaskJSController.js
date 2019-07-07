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

    function loadData(projectId, UserId) {
        $(document).ready(function () {
            var render = '';
            var template = $('#data-template').html();
            $.ajax({
                url: "Tasks/LoadData",
                data: {
                    projectId: projectId,
                    UserId: UserId
                },
                type: 'GET',
                datatype: 'json',
                success: function (response) {
                    console.log(response);
                    $.each(response.data, function (i, item) {
                        render += Mustache.render(template, {
                            TaskId: item.Id,
                            TaskName: item.Name,
                            Assignee: item.listAssigneeName,
                        })
                    })
                    $('#tblData').html(render);
                }
            })
        })
        
    }
    function loadStatus(projectId, UserId) {
        $(document).ready(function () {
            var render = '';
            var template = $('#status').html();
            $.ajax({
                url: "Tasks/LoadStatus",
                data: {
                    projectId: projectId,
                    UserId: UserId
                },
                type: 'GET',
                datatype: 'json',
                success: function (response) {
                    console.log(response);
                    $.each(response.data, function (i, item) {
                        render += Mustache.render(template, {
                            Status: item.Name
                        })
                    })
                    $('#LOL').html(render);
                }
            })
        })

    }

}