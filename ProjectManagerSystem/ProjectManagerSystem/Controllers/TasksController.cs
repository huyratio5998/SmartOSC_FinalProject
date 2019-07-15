using AutoMapper;
using MS.DataAccess.Models;
using MS.Repository.Interface;
using MS.Service;
using MS.Service.Interface;
using ProjectManagerSystem.Authorization;
using ProjectManagerSystem.Models;
using ProjectManagerSystem.Models.CustomTasksViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProjectManagerSystem.Controllers
{
    public class TasksController : Controller
    {

        private readonly ITasksService _TasksService;
        private readonly IProjectService _ProjectService;
        private readonly IUserService _UserService;
        private readonly IStatusService _StatusService;
        private readonly IProjectMemberService _ProjectMemberService;

        public TasksController(ITasksService tasksService, IProjectService projectService, IUserService userService, IStatusService statusService,IProjectMemberService projectMemberService)
        {
            _TasksService = tasksService;
            _ProjectService = projectService;
            _UserService = userService;
            _StatusService = statusService;
            _ProjectMemberService = projectMemberService;
        }

        // GET: Tasks
        [CustomAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Tasks/Details/5
        [CustomAuthorize]
        public JsonResult LoadProject()
        {
            var listProject = _ProjectService.GetAll().OrderBy(x => x.StartDate);

            var models = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(listProject);

            return Json(new
            {
                data = models
            }, JsonRequestBehavior.AllowGet);
        }

        [CustomAuthorize]
        public JsonResult LoadAssignee()
        {
            var listUser = _UserService.GetAll().ToList();

            var models = Mapper.Map<IEnumerable<AspNetUser>, IEnumerable<AspNetUsersViewModel>>(listUser);

            return Json(new
            {
                data = models
            }, JsonRequestBehavior.AllowGet);
        }
        [CustomAuthorize]
        public JsonResult LoadAssigneeInProject(int projectId)
        {
            var lstUPM = new List<AspNetUsersViewModel>();

            try
            {
                var uPM = (from u in _UserService.GetAll()
                           join pm in _ProjectMemberService.GetAll().OrderBy(p => p.Id) on u.Id equals pm.UserId
                           where pm.ProjectId == projectId
                           select new {u.Id, u.FullName}).ToList();

                if (uPM != null)
                {
                    foreach (var item in uPM)
                    {
                        var k = new AspNetUsersViewModel();
                        k.Id = item.Id;
                        k.FullName = item.FullName;
                        lstUPM.Add(k);
                    }
                }
            }
            catch (Exception)
            {
                lstUPM = null;
            }
            return Json(new
            {
                data = lstUPM
            }, JsonRequestBehavior.AllowGet);
        }
        [CustomAuthorize]
        public JsonResult LoadStatus()
        {
            var listStatus = _StatusService.GetAll();

            var models = Mapper.Map<IEnumerable<Status>, IEnumerable<StatusViewModel>>(listStatus);

            return Json(new
            {
                data = models
            }, JsonRequestBehavior.AllowGet);
        }
        [CustomAuthorize]
        public JsonResult LoadAllTasks()
        {
            var AllTasks = _TasksService.GetAll();

            var models = Mapper.Map<IEnumerable<Tasks>, IEnumerable<TasksViewModel>>(AllTasks);

            return Json(new
            {

                data = models
            }, JsonRequestBehavior.AllowGet);
        }
        [CustomAuthorize]
        public JsonResult GetTasks(int projectId, string userId)
        {
            var ListTasks = _TasksService.GetAll().Where(x => x.ProjectId == projectId && x.UserId == userId);

            var models = Mapper.Map<IEnumerable<Tasks>, IEnumerable<TasksViewModel>>(ListTasks);

            return Json(new
            {
                data = models
            }, JsonRequestBehavior.AllowGet);
        }
        [CustomAuthorize]
        public JsonResult SearchTasks(string tasksName)
        {
            var Result = _TasksService.GetAll().Where(x => x.Name.Contains(tasksName) || x.Description.Contains(tasksName) || x.prt.Name.Contains(tasksName) || x.sts.Name.Contains(tasksName));

            var models = Mapper.Map<IEnumerable<Tasks>, IEnumerable<TasksViewModel>>(Result);
            return Json(new
            {
                data = models
            }, JsonRequestBehavior.AllowGet);
        }
        [CustomAuthorize(Roles = "Admin,Project Manager")]
        public ActionResult AddTasks()
        {
            return View();
        }
        [CustomAuthorize(Roles = "Admin,Project Manager")]
        public JsonResult CreateTasks(TasksViewModel tasksView)
        {
            tasksView.SortNameTask = _ProjectService.GetProject(tasksView.ProjectId).SortNameProject + "- HHHH";

            var status = false;

            if (tasksView.Id == 0)
            {
                var models = Mapper.Map<TasksViewModel, Tasks>(tasksView);
                if (true)
                {
                    _TasksService.AddTasks(models);
                    _TasksService.SaveChange();
                }
            }
            else
            {
                status = true;
            }
            return Json(new
            {
                data = status
            });
        }

        public JsonResult GetTasksbyId(int tasksId)
        {

            var listTask = _TasksService.GetAll().Where(x => x.Id == tasksId);

            var models = Mapper.Map<IEnumerable<Tasks>, IEnumerable<TasksViewModel>>(listTask);

            return Json(new
            {
                data = models
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [CustomAuthorize]
        public JsonResult UpdateTasks(TasksViewModel model)
        {
            var Oldtasks = _TasksService.GetTasks(model.Id);

            Oldtasks.UserId = model.UserId;
            Oldtasks.StatusId = model.StatusId;
            if (model.Name != null)
            {
                Oldtasks.Name = model.Name;
            }
            if (model.Description != null)
            {
                Oldtasks.Description = model.Description;
            }

            _TasksService.SaveChange();

            return Json(new
            {
                data = model
            });
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Admin,Project Manager")]
        public JsonResult DeleteTasks(int taskId)
        {
            var TasksTarget = _TasksService.DeleteTasksbyId(taskId);

            var models = Mapper.Map<Tasks, TasksViewModel>(TasksTarget);

            _TasksService.SaveChange();

            return Json(new
            {
                data = models
            });
        }
    }
}