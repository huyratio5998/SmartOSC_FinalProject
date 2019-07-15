using AutoMapper;
using Microsoft.AspNet.Identity.Owin;
using MS.DataAccess;
using MS.DataAccess.Models;
using MS.Service.Interface;
using ProjectManagerSystem.Authorization;
using ProjectManagerSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProjectManagerSystem.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectService _projectService;
        private IProjectMemberService _projectMemberService;
        private ITasksService _taskService;
        private IUserService _userService;
        private IUserRoleService _userRoleService;
        private IRoleService _roleService;
        private string lstPM;
        public ProjectController(IProjectService projectService, IProjectMemberService projectMemberService, ITasksService taskService, IUserService userService, IUserRoleService userRoleService, IRoleService roleService)
        {
            _projectService = projectService;
            _projectMemberService = projectMemberService;
            _taskService = taskService;
            _userService = userService;
            _userRoleService = userRoleService;
            _roleService = roleService;
        }


        //
        // GET: Project
        [CustomAuthorize(Roles = "Admin,Project Manager")]
        public ActionResult Index()
        {
          

 // select p.Id, p.SortNameProject, p.Name, p.PmId, COUNT(t.Id) as Tasks from Projects p
 //left join AspNetUsers u on u.Id=p.PmId
 //left join Tasks t on p.Id = t.ProjectId 
 //where p.isDeleted = 'false' group by p.Id, p.Name, p.SortNameProject, p.PmId
            var x = _userService.GetAll();            
            var Pdemo = (from p in _projectService.GetAll().Where(p=>p.isDeleted==false)                                              
                         join u in _userService.GetAll() on p.PmId equals u.Id into j1
                         from j2 in j1.DefaultIfEmpty() 
                         join t in _taskService.GetAll() on p.Id equals t.ProjectId into j3
                         from j4 in j3.DefaultIfEmpty()
                         group new { p, j2, j4 } by new {p.Id, p.SortNameProject, p.Name, p.PmId} into g                         
                         select new {g.Key.Id, g.Key.SortNameProject, g.Key.Name, g.Key.PmId, Tasks = (g.Count(p => p.j4?.Id != null )) }).ToList();
            var model = (from u in _userService.GetAll().ToList()
                         join P in Pdemo on u.Id equals P.PmId
                         select new { P.Id, P.SortNameProject, P.Name, u.FullName, P.Tasks }).ToList();
var projects = new List<ProjectViewModel>();
            foreach (var item in model)
            {
                var project = new ProjectViewModel();
                project.Id = item.Id;
                project.SortNameProject = item.SortNameProject;
                project.Name = item.Name;
                project.ProjectManagerName = item.FullName;
                project.Tasks = item.Tasks;
                projects.Add(project);
            }

            //var projects = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(_projectService.GetAll());
            return View(projects);
        }
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create()
        {
            // lay list ProjectMember
            try
            {               
                var model = (from u in _userService.GetAll()
                             join ur in _userRoleService.GetAll() on u.Id equals ur.UserId
                             join r in _roleService.GetAll() on ur.RoleId equals r.Id
                             where r.Name == "Project Manager"
                             select new { u.Id, u.FullName }).ToList();
                var lstPM = new List<PMViewModel>();
                foreach (var item in model)
                {
                    var k = new PMViewModel();
                    k.Id = item.Id;
                    k.Name = item.FullName;
                    
                    lstPM.Add(k);
                }
                ViewBag.lstPM = new SelectList(lstPM, "Id", "Name");
            }catch(Exception e)
            {
                ViewBag.lstPM = null;
            }
            // lay list user khong phai PM
            try
            {              
                var user = (from u in _userService.GetAll()
                            join ur in _userRoleService.GetAll() on u.Id equals ur.UserId
                            join r in _roleService.GetAll() on ur.RoleId equals r.Id
                            where r.Name == "User"
                            select new { u.Id, u.FullName }).ToList();
                var lstUser = new List<AspNetUsersViewModel>();
                foreach (var item in user)
                {
                    var k = new AspNetUsersViewModel();
                    k.Id = item.Id;
                    k.FullName = item.FullName;
                    lstUser.Add(k);
                }
                ViewBag.lstUser = lstUser;
            }
            catch (Exception e)
            {
                ViewBag.lstUser = null;
            }
            
          
            return View();
        }
        [HttpPost]        
        public int SaveProject(string project, bool  edit=false)
        {
            JavaScriptSerializer seri = new JavaScriptSerializer();
            // take project object.
            ProjectViewModel objProject = seri.Deserialize<ProjectViewModel>(project);
           
                var Project = new Project();
                if (edit == false)
                {
                    // take pm object            
                    Project = _projectService.AddProject(Mapper.Map<ProjectViewModel, Project>(objProject));
                }
                else
                {
                    Project = Mapper.Map<ProjectViewModel, Project>(objProject);
                    _projectService.UpdateProject(Project);

                }

                _projectService.SaveChange();
                return Project.Id;
                    
        }
        [HttpPost]        
        public JsonResult SavePM(string projectMember, bool edit=false)
        {
            JavaScriptSerializer seri = new JavaScriptSerializer();
            IEnumerable<ProjectMemberViewModel> lstPM = seri.Deserialize<IEnumerable<ProjectMemberViewModel>>(projectMember);
            if (edit == true)
            {                              
                //lay pm id 
                var PId = 0;
                foreach (ProjectMemberViewModel item in lstPM)
                {
                    PId = item.ProjectId;
                    break;
                }
                var x = _projectMemberService.GetAll().Where(p => p.ProjectId == PId).ToList();
                // xoa het pm co id project ben tren.
                foreach (var item in x)
                {
                    _projectMemberService.DeleteProjectMember(item);
                }
                _projectMemberService.SaveChange();
                // Add lai list moi.
                foreach (var item in lstPM)
                {
                    _projectMemberService.AddProjectMember(Mapper.Map<ProjectMemberViewModel, ProjectMember>(item));
                }             
            }
            else
            {
                foreach (ProjectMemberViewModel item in lstPM)
                {
                    _projectMemberService.AddProjectMember(Mapper.Map<ProjectMemberViewModel, ProjectMember>(item));
                }
            }
           
            
            _projectMemberService.SaveChange();
            return Json(Url.Action("Index", "Project"));
            //return RedirectToAction("Index", "Project");
        }
        [CustomAuthorize(Roles = "Admin,Project Manager")]
        public ActionResult Edit(int id)
        {
            try
            {
                // lay list PM
                var model = (from u in _userService.GetAll()
                             join ur in _userRoleService.GetAll() on u.Id equals ur.UserId
                             join r in _roleService.GetAll() on ur.RoleId equals r.Id
                             where r.Name == "Project Manager"
                             select new { u.Id, u.FullName }).ToList();
                var lstPM = new List<PMViewModel>();
                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var k = new PMViewModel();
                        k.Id = item.Id;
                        k.Name = item.FullName;
                        lstPM.Add(k);
                    }
                }
                ViewBag.lstPM = new SelectList(lstPM, "Id", "Name");
            }
            catch (Exception e)
            {
                ViewBag.lstPM = null;
            }

            // lay projectviewmodel
            var Project = Mapper.Map<Project, ProjectViewModel>(_projectService.GetProject(id));

            try
            { // lay list user khong phai PM và chưa thuộc project.(Project.Id)
                var user = (from u in _userService.GetAll()
                            join ur in _userRoleService.GetAll() on u.Id equals ur.UserId                             
                            join r in _roleService.GetAll() on ur.RoleId equals r.Id
                            where r.Name == "User" &&  !(from pm in _projectMemberService.GetAll() where pm.ProjectId == Project.Id select pm.UserId).Contains(u.Id)
                            select new { u.Id, u.FullName }).ToList();

                var lstUser = new List<AspNetUsersViewModel>();

                foreach (var item in user)
                {
                    var k = new AspNetUsersViewModel();
                    k.Id = item.Id;
                    k.FullName = item.FullName;
                    lstUser.Add(k);
                }

                ViewBag.lstUser = lstUser;
            } catch (Exception e) {
                ViewBag.lstUser = null;
            }

            try
            {
                // lay list user trong project, (user + manager)
                //select * from ProjectMembers pm inner join AspNetUsers u on u.Id = pm.UserId where pm.ProjectId = 14
                var uPM = (from u in _userService.GetAll()                          
                           join pm in _projectMemberService.GetAll().OrderBy(p=>p.Id) on u.Id equals pm.UserId
                           where pm.ProjectId == Project.Id 
                           select new { u.Id, u.FullName }).ToList();

                var lstUPM = new List<AspNetUsersViewModel>();
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
                ViewBag.lstUPM = lstUPM;
                //khong can reverse nua
                // ViewBag.lstUPM = lstUPM.AsEnumerable().Reverse();
            }
            catch(Exception e)
            {
                ViewBag.lstUPM = null;
            }

            return View(Project);
        }
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var x = _projectService.GetProject(id);
            if (x != null)
            {
                x.isDeleted = true;
                _projectService.SaveChange();
            }            
            return RedirectToAction("Index", "Project");
        }
    }
}