﻿var TaskController = function () {

    this.intialize = function () {
        
        loadDataSelectList();
        loadPage();
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
    }

    function loadPage() {
        $(document).ready(function () {
                projectId = $('#ProjectData').val();
                UserId = $('#AssigneeData').val();
                GetTasks(projectId, UserId);
        })
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

    function GetTasks(projectId, UserId) {
        $(document).ready(function () {
            var render = '';
            var template = $('#dataTasks').html();
            var statusId;
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
                }
            })
        })

    }
}