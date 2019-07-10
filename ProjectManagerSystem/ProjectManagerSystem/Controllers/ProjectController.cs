using AutoMapper;
using MS.DataAccess.Models;
using MS.Service.Interface;
using ProjectManagerSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjectManagerSystem.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectService _projectService;
        
        private ITaskService _taskService;
        private IUserService _userService;

        public ProjectController(IProjectService projectService, ITaskService taskService, IUserService userService)
        {
            _projectService = projectService;
            _taskService = taskService;
            _userService = userService;
        }



        // GET: Project
        public ActionResult Index()
        {
            
            var model = (from p in _projectService.GetAll()
                         join t in _taskService.GetAll() on p.Id equals t.ProjectId
                         join u in _userService.GetAll() on t.UserId equals u.Id
                         group new { p,t,u} by new { p.SortNameProject, p.Name, u.FullName } into g
                         select new { g.Key.SortNameProject, g.Key.Name, g.Key.FullName, Tasks = ( g.Count(p=>p.t.Id!=null))}).ToList();
            var projects = new List<ProjectViewModel>();
            foreach (var item in model)
            {
                var project = new ProjectViewModel();
                
                project.SortNameProject = item.SortNameProject;
                project.Name = item.Name;
                project.ProjectManager = item.FullName;
                project.Tasks = item.Tasks;
                projects.Add(project);
            }            
            
            //var projects = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(_projectService.GetAll());
            return View(projects);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProjectViewModel Project)
        {

            _projectService.AddProject(Mapper.Map<ProjectViewModel, Project>(Project));
            _projectService.SaveChange();


            return RedirectToAction("Index", "Project");
        }
        public ActionResult Edit(int id)
        {
            var model = Mapper.Map<Project, ProjectViewModel>(_projectService.GetProject(id));
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ProjectViewModel Project)
        {

            _projectService.UpdateProject(Mapper.Map<ProjectViewModel, Project>(Project));
            _projectService.SaveChange();


            return RedirectToAction("Index", "Project");
        }
    }
}