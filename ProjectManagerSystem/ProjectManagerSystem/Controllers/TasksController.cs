﻿using AutoMapper;
using MS.DataAccess.Models;
using MS.Repository.Interface;
using MS.Service;
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

        private readonly ITasksService _TasksService;
        private readonly IProjectService _ProjectService;
        private readonly IUserService _UserService;
        private readonly IStatusService _StatusService;

        public TasksController(ITasksService tasksService, IProjectService projectService, IUserService userService, IStatusService statusService)
        {
            _TasksService = tasksService;
            _ProjectService = projectService;
            _UserService = userService;
            _StatusService = statusService;
        }

        // GET: Tasks
        public ActionResult Index()
        {
            return View();
        }

        // GET: Tasks/Details/5

        public JsonResult LoadProject()
        {
            var listProject = _ProjectService.GetAll().OrderBy(x => x.StartDate);

            var models = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(listProject);

            return Json(new
            {
                data = models
            }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult LoadAssignee()
        {
            var listUser = _UserService.GetAll();

            var models = Mapper.Map<IEnumerable<AspNetUser>, IEnumerable<AspNetUsersViewModel>>(listUser);

            return Json(new
            {
                data = models
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTasks(int projectId, string userId)
        {
            var ListTasks = _TasksService.GetAll().Where(x => x.ProjectId == projectId && x.UserId == userId);

            var models = Mapper.Map<IEnumerable<Tasks>, IEnumerable<TasksViewModel>>(ListTasks);

            return Json(new
            {
                data = models
            }, JsonRequestBehavior.AllowGet);
        }
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
            _TasksService.SaveChange();

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