var TaskController = function () {

    this.intialize = function () {
        loadDataSelectList();
        registerEvent();
    }

    function loadDataSelectList() {
        loadProject();
        loadAssignee()
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

    function registerEvent() {
        changeSelect();
        searchEvent();
    }

    function changeSelect() {
        var projectId, UserId;
        $(document).ready(function () {
            $('#ShowData').click(function () {
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

    function modalEvent() {
        $(document).ready(function () {
            $('body').on('click', '#myBtn', function (e) {
                e.preventDefault();
                var id = $(this).data("id");
                GetTasksById(id);
                loadAssigneeToModal();
                loadStatusToModal();
                $("#myModal").modal();

            })
        });
    }

    function updateEvent() {
        $(document).ready(function () {
            $('body').on('click', '#UpdateModalData', function (e) {
                e.preventDefault();
                updateTasks();
            })
        });
    }

    function updateTasks() {
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
                    $('#AssigneeNameModal').html(render);
                }
            })
        })
    }

    function loadAssigneeToModal() {
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
                    $('#AssigneeNameModal').html(render);
                }
            })
        })
    }
    function loadStatusToModal() {
        $(document).ready(function () {
            var render = '';
            var template = $('#OptionProject').html();
            $.ajax({
                url: "/Tasks/LoadStatus",
                type: 'GET',
                datatype: 'json',
                success: function (response) {
                    $.each(response.data, function (i, item) {
                        render += Mustache.render(template, {
                            projectName: item.Name,
                            projectId: item.Id,
                        })
                    })
                    $('#StatusNameModal').html(render);
                }
            })
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
                            TaskName: item.Name,
                            Status: item.sts.Name
                        })
                    })
                    $('#tblTasks').html(render);
                    modalEvent();
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
                            TaskId: item.Id,
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