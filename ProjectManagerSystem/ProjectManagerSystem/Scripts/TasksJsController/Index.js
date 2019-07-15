var TaskController = function () {

    this.intialize = function () {
        loadAllTasks();
        loadDataSelectList();
        registerEvent();
    }

    function loadDataSelectList() {
        loadProject();
        loadAssignee()
        loadAssigneeToModal();
        loadStatusToModal();
    }

    function loadAllTasks() {
        $(document).ready(function () {
            var render = '';
            var template = $('#dataTasks').html();
            $.ajax({
                url: "/Tasks/LoadAllTasks",
                type: 'GET',
                datatype: 'json',
                success: function (response) {
                    console.log(response);
                    $.each(response.data, function (i, item) {
                        render += Mustache.render(template, {
                            TaskId: item.Id,
                            DeleteId: item.Id,
                            TasksCode: item.SortNameTask,
                            TaskName: item.Name,
                            Status: item.sts.Name
                        })
                    })
                    $('#tblTasks').html(render);
                }
            })
        })
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
                        })
                    })
                    $('#ProjectData').html(render);
                }
            })
        })
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
    function loadAssigneeToModal() {
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
                    $('#AssigneeNameModalData').html(render);
                }
            })
        })
    }
    function loadStatusToModal() {
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
                    $('#StatusNameModalData').html(render);
                }
            })
        })
    }

    function registerEvent() {
        changeSelect();
        searchEvent();
        modalEvent();
        UpdateEvent();
        DeleteModalEvent();
    }

    function changeSelect() {
        var projectId, UserId;
        $(document).ready(function () {
            $('#AssigneeData').change(function (e) {
                projectId = $('#ProjectData').val();
                UserId = $('#AssigneeData').val();
                GetTasks(projectId, UserId);
            })
            $('#ProjectData').change(function (e) {
                projectId = $('#ProjectData').val();
                UserId = $('#AssigneeData').val();
                GetTasks(projectId, UserId);
            })
        })
    }
    function searchEvent() {
        var TasksName;
        $(document).ready(function () {
            $('#SearchTasks').click(function (e) {
                e.preventDefault();
                TasksName = $('#InputSearch').val();
                GetTasksFromName(TasksName);
            })
        })
    }

    function refreshEnvent() {
        $(document).ready(function (e) {
            $('#Refresh').click(function (e) {
                projectId = $('#ProjectData').val();
                UserId = $('#AssigneeData').val();
                GetTasks(projectId, UserId);
            })
        })
    }

    function modalEvent() {
        $(document).ready(function () {
            $('body').on('click', '#myBtn', function (e) {
                e.preventDefault();
                var id = $(this).data("id");
                GetTasksById(id);
                $("#myModal").modal('show');
                refreshEnvent();
            })
        })
    }

    function DeleteModalEvent() {
        $(document).ready(function () {
            $('body').on('click', '#DeleteModalbtn', function (e) {
                e.preventDefault();
                var id = $(this).data("id");
                $("#DeleteModal").modal('show');
                $('body').on('click', '#AcceptDeleteTasks', function (e) {
                    DeleteTasksbyId(id);
                    $("#DeleteModal").modal('hide');
                })
            })
        })
    }

    function DeleteTasksbyId(id) {
        $.ajax({
            url: '/Tasks/DeleteTasks',
            data: {
                taskId: id,
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                alert("Delete Success !")
                loadAllTasks();
            }
        })
    }

    function UpdateEvent() {
        $('body').on('click', '#UpdateModalData', function (e) {
            e.preventDefault();
            var tasksId = $("#testTaskId").data("id");
            var projectId = $('#ProjectData').val();
            var UserId = $('#AssigneeNameModalData').val();
            var statusId = $('#StatusNameModalData').val();
            var tasksName = $('#TasksNameModalData').val();
            var descriptionTasks = $('#DescriptionModalData').val();
            UpdateTasks(tasksId, projectId, UserId, statusId, tasksName, descriptionTasks);
        })
    }

    function UpdateTasks(tasksId, projectId, UserId, statusId, tasksName, descriptionTasks) {
        $.ajax({
            url: '/Tasks/UpdateTasks',
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
                restform();
                alert('Update Success !');
                $('#AddNameTask').val("");
                $('#Description').val("");
                $("#myModal").modal('hide');
                GetTasks(projectId, UserId);
            }
        })
    }

    function GetTasksById(id) {
        $.ajax({
            url: "/Tasks/GetTasksbyId",
            data: {
                tasksId: id,
            },
            type: 'GET',
            datatype: 'json',
            success: function (response) {
                var render = '';
                var template = $('#TasksNameModal').html();
                $.each(response.data, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        tasksNameModal: item.Name,
                        projectNameModal: item.prt.Name,
                        statusNameModal: item.sts.Name,
                        description: item.Description
                    })
                })
                $('#DetailsTasksModal').html(render);
            }
        })
    }
    function restform() {
        $("#TasksIdData").val(' ')
    }
    function GetTasks(projectId, UserId) {
        $(document).ready(function () {
            var render = '';
            var template = $('#dataTasks').html();
            $.ajax({
                url: "/Tasks/GetTasks",
                data: {
                    projectId: projectId,
                    UserId: UserId
                },
                type: 'GET',
                datatype: 'json',
                success: function (response) {
                    $.each(response.data, function (i, item) {
                        render += Mustache.render(template, {
                            TaskId: item.Id,
                            DeleteId: item.Id,
                            TasksCode: item.SortNameTask,
                            TaskName: item.Name,
                            Status: item.sts.Name
                        })
                    })
                    $('#tblTasks').html(render);
                }
            })
        })
    }
    function GetTasksFromName(TasksName) {
        $(document).ready(function () {
            var render = '';
            var template = $('#dataTasks').html();
            $.ajax({
                url: "/Tasks/SearchTasks",
                data: {
                    tasksName: TasksName
                },
                type: 'GET',
                datatype: 'json',
                success: function (response) {
                    $.each(response.data, function (i, item) {
                        render += Mustache.render(template, {
                            TasksCode: item.SortNameTask,
                            TaskName: item.Name,
                            Status: item.sts.Name
                        })
                    })
                    $('#tblTasks').html(render);
                }
            })
        })
    }
}