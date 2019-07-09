using AutoMapper;
using MS.DataAccess;
using MS.DataAccess.Models;
using MS.Repository;
using MS.Repository.Interface;
using MS.Service.Interface;
using ProjectManagerSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagerSystem.Controllers
{
    public class ProjectController : Controller
    {        
        private  IProjectService projectService;
       
       
        public ProjectController(IProjectService projectService)
        {
         
            this.projectService = projectService;
        }
        // GET: Project
        public ActionResult Index()
        {
            var projects= Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(projectService.GetAll());
            return View(projects);
        }
        public ActionResult Create()
        {
            return View();
        }        
        [HttpPost]
        public ActionResult Create(ProjectViewModel Project)
        {
            
            projectService.AddProject(Mapper.Map<ProjectViewModel, Project>(Project));
            projectService.SaveChange();


            return RedirectToAction("Index", "Project");
        }
        public ActionResult Edit(int id)
        {
            Mapper.Map<Project,ProjectViewModel >(projectService.GetProject(id));
            return View(projectService);
        }
        [HttpPost]
        public ActionResult Edit(ProjectViewModel Project)
        {

            projectService.UpdateProject(Mapper.Map<ProjectViewModel, Project>(Project));
            projectService.SaveChange();


            return RedirectToAction("Index", "Project");
        }
    }
}