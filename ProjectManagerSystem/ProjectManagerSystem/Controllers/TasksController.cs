using AutoMapper;
using MS.DataAccess.Models;
using MS.Repository.Interface;
using MS.Service.Interface;
using ProjectManagerSystem.Models;
using ProjectManagerSystem.Models.CustomTasksViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProjectManagerSystem.Controllers
{
    public class TasksController : Controller
    {
        CustomTasksViewModels customTasksViewModels = new CustomTasksViewModels();

        private readonly ITasksService _TasksService;
        private readonly IProjectService _ProjectService;
        private readonly IUserService _UserService;
        //private readonly IStatus _Status;
        private readonly IUnitOfWork _UnitOfWork;

        public TasksController(ITasksService tasksService, IProjectService projectService, IUserService userService, IUnitOfWork unitOfWork)
        {
            _TasksService = tasksService;
            _ProjectService = projectService;
            _UserService = userService;
            _UnitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return GetData();
        }
        public ActionResult GetData()
        {
            var listProject = _ProjectService.GetAll();

            customTasksViewModels.projectViewModels = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(listProject);

            ViewBag.listProject = new SelectList(listProject, "Id", "Name");

            var listAssignee = _UserService.GetAll();

            customTasksViewModels.aspNetUsersViewModels = Mapper.Map<IEnumerable<AspNetUser>, IEnumerable<AspNetUsersViewModel>>(listAssignee);

            ViewBag.listAssignee = new SelectList(listAssignee, "Id", "FullName");

            return View(customTasksViewModels);
            
        }

        public JsonResult LoadData(int projectId, string UserId)
        {
            // kiểm tra user đăng nhập có id là gì , quyền user đấy
            // nếu là admin => hiển thị full
            // project manager => hiển thị task mà project manager quản lý
            // user => hiển thị task mà nó đang làm

            //load task với id user

            var customTaskShowViewModel = new CustomTaskShowViewModel();


            var listTask = _TasksService.GetAll(UserId,projectId);


           // var listAssigneeName = _UserService.GetAspNetUser(UserId).FullName;

           // var listShortNameProject = _ProjectService.GetProject(projectId).SortNameProject;

            //var shortNameTask = _ProjectService.GetProject(projectId).SortNameProject + _TasksService.GetAll().Where(x => x.ProjectId == projectId);

            Mapper.Map<IEnumerable<Tasks>, IEnumerable<TasksViewModel>>(listTask);

            return Json(new
            {
              //  data = listTask,listAssigneeName,shortNameTask
                data = listTask
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult loadStatus(string userId, int projectId)
        {
            var status = _StatusService.get
            return Json(new
            {
                data = status
            }, JsonRequestBehavior.AllowGet); 
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tasks/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
