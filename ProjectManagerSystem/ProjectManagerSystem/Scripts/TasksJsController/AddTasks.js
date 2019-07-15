var TaskController = function () {

    this.intialize = function () {
        loadDataSelectList();
        registerEvent();
    }

    function loadDataSelectList() {
        loadProject();
        loadAssignee();
        loadStatus();

        //changeProjectData();
    }


    function loadProject() {
        $(document).ready(function () {
            var render = '';
            var template = $('#OptionProject').html();
            $.ajax({
                url: "/Tasks/LoadProject",
                type: 'GET',
                datatype: 'json',
                success: function (response) {
                    $.each(response.data, function (i, item) {
                        render += Mustache.render(template, {
                            projectName: item.Name,
                            projectId: item.Id,
                        });
                    });
                    $('#ProjectData').html(render);
                }
            });
        });
    }

    //function changeProjectData() {
    //    $('#ProjectData').change(function (e) {
    //        ProjectId = $('#ProjectData').val();
    //        console.log(ProjectId);
    //        loadAssignee(ProjectId);
    //    });
    //}

    function loadAssignee(ProjectId) {
        $(function () {
            var render = '';
            var template = $('#OptionAssignee').html();
            $.ajax({
                url: "/Tasks/LoadAssignee",
                type: 'GET',
                data: {
                    projectId: ProjectId
                },
                datatype: 'json',
                success: function (response) {
                    $.each(response.data, function (i, item) {
                        render += Mustache.render(template, {
                            assigneeName: item.FullName,
                            assigneeId: item.Id
                        });
                    });
                    $('#AssigneeData').html(render);
                }
            });
        });
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
                            statusName: item.Name,
                            statusId: item.Id
                        })
                    })
                    $('#StatusData').html(render);
                }
            })
        })
    }

    function registerEvent() {
        $(document).ready(function () {
            $('#AddTasks').click(function (e) {
                e.preventDefault();
                var tasksId = $('#TasksIdData').val();
                var projectId = $('#ProjectData').val();
                var UserId = $('#AssigneeData').val();
                var statusId = $('#StatusData').val();
                var tasksName = $('#AddNameTask').val();
                var descriptionTasks = $('#Description').val();
                AddTasks(tasksId, projectId, UserId, statusId, tasksName, descriptionTasks);
            })
        })
    }
    function AddTasks(tasksId, projectId, UserId, statusId, tasksName, descriptionTasks) {
        $.ajax({
            url: '/Tasks/CreateTasks',
            data: {
                Id: tasksId,
                ProjectId: projectId,
                UserId: UserId,
                StatusId: statusId,
                Name: tasksName,
                Description: descriptionTasks
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                alert('Add Success !');
                $('#AddNameTask').val("");
                $('#Description').val("");
            }
        })
    }
}