using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MS.DataAccess;
using MS.DataAccess.Models;
using MS.Service.Interface;
using ProjectManagerSystem.Models;

namespace ProjectManagerSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;
        private readonly IRoleService _roleService;
        private readonly IProjectMemberService _projectMemberService;
        private readonly IProjectService _projectService;
        private readonly ITasksService _taskService;

        public UserController()
        {
        }

        public UserController(IUserService userService, IUserRoleService userRoleService, IRoleService roleService, IProjectMemberService projectMemberService, IProjectService projectService, ITasksService taskService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
            _roleService = roleService;
            _projectMemberService = projectMemberService;
            _projectService = projectService;
            _taskService = taskService;
        }
        // GET: User
        public ActionResult Index()
        {
             // lay list user index          
            var A = (from u in _userService.GetAll()
                     join ur in _userRoleService.GetAll() on u.Id equals ur.UserId 
                     join r in _roleService.GetAll() on ur.RoleId equals r.Id
                     join pm in (from pmm in _projectMemberService.GetAll() join p in _projectService.GetAll().Where(p=>p.isDeleted==false) on pmm.ProjectId equals p.Id select new { pmm.UserId , pmm.ProjectId} )              
                     on u.Id equals pm.UserId into j1
                     from j2 in j1.DefaultIfEmpty()
                     group new { u, ur, r, j2 } by new { u.Id, u.Email, u.UserName, u.UrlAvatar, r.Name } into b                
                     select new { b.Key.UrlAvatar, Role = b.Key.Name, b.Key.Id, b.Key.UserName, b.Key.Email, TotalProject = (b.Count(m => m.j2?.ProjectId != null)) }).ToList();

            var B = (from tt in _taskService.GetAll()
                     join u in _userService.GetAll() on tt.UserId equals u.Id                     
                     join p in _projectService.GetAll().Where(p => p.isDeleted == false) on tt.ProjectId equals p.Id
                     group new { tt, u } by new { u.Id,taskID= tt.Id } into dd
                     select new { dd.Key.Id,dd.Key.taskID , TotalU = (dd.Count(m => m.tt.Id != null)) }
                    ).ToList();

            var model = (from a in A
                         join bb in B on a.Id equals bb.Id into j1
                         from j2 in j1.DefaultIfEmpty()
                         group new { a, j2 } by new { a.Id, a.UserName, a.TotalProject, a.UrlAvatar, a.Role } into mo
                         select new {mo.Key.Id, mo.Key.UrlAvatar, mo.Key.UserName, mo.Key.Role, Projects = mo.Key.TotalProject, Tasks = (mo.Count(m => m.j2?.taskID != null)) }).ToList();
            //
            var Users = new List<AspNetUsersViewModel>();
            foreach (var item in model)
            {
                var user = new AspNetUsersViewModel();
                user.Id = item.Id;
                user.Avatar = item.UrlAvatar;
                user.UserName = item.UserName;
                user.Role = item.Role;
                user.Projects = item.Projects;
                user.Tasks = item.Tasks;
                Users.Add(user);
            }            

            return View(Users);
        }

        // GET: User/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUsersViewModel aspNetUsersViewModel = Mapper.Map<AspNetUser, AspNetUsersViewModel>(_userService.GetAspNetUser(id));
            if (aspNetUsersViewModel == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUsersViewModel);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            var lstRole = (new MsContext()).Roles.ToList();
            ViewBag.lstRole = new SelectList(lstRole, "Name", "Name");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AspNetUsersViewModel aspNetUsersViewModel, string Role)
        {
            if (ModelState.IsValid)
            {
                aspNetUsersViewModel.Role = Role;
                var model = Mapper.Map<AspNetUsersViewModel, AspNetUser>(aspNetUsersViewModel);
                _userService.AddAspNetUser(model, aspNetUsersViewModel.Role, aspNetUsersViewModel.Password);

                return RedirectToAction("Index");
            }

            return View(aspNetUsersViewModel);
        }

        // GET: User/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lstRole = (new MsContext()).Roles.ToList();
            ViewBag.lstRole = new SelectList(lstRole, "Name", "Name");
            var user = _userService.GetAspNetUser(id);            
            AspNetUsersViewModel aspNetUsersViewModel = Mapper.Map<AspNetUser, AspNetUsersViewModel>(user);
            var x = _userRoleService.GetAll().Where(p=>p.UserId== aspNetUsersViewModel.Id).First();
            var y = _roleService.GetAspNetRole(x.RoleId);
            aspNetUsersViewModel.Role = y.Name.ToString();

            if (aspNetUsersViewModel == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUsersViewModel);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,Email,Password,UserName,Avatar,Role")] AspNetUsersViewModel aspNetUsersViewModel)
        {
            if (ModelState.IsValid)
            {
                
                var roleId=_roleService.GetAll().Where(p => p.Name == aspNetUsersViewModel.Role).First().Id;
                var aspuser = Mapper.Map<AspNetUsersViewModel, AspNetUser>(aspNetUsersViewModel);
                _userService.UpdateAspNetUser(aspuser);
                var ur = _userRoleService.GetAll().Where(p => p.UserId == aspuser.Id).First();
                ur.RoleId = roleId;
                _userRoleService.UpdateAspNetUserRole(ur);
                 _userService.SaveChange();                

                return RedirectToAction("Index");
            }
            return View(aspNetUsersViewModel);
        }

        // GET: User/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUsersViewModel aspNetUsersViewModel = Mapper.Map<AspNetUser, AspNetUsersViewModel>(_userService.GetAspNetUser(id));
            if (aspNetUsersViewModel == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUsersViewModel);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AspNetUsersViewModel aspNetUsersViewModel = Mapper.Map<AspNetUser, AspNetUsersViewModel>(_userService.GetAspNetUser(id));
            _userService.DeleteAspNetUser(Mapper.Map<AspNetUsersViewModel, AspNetUser>(aspNetUsersViewModel));
            //    _userService.SaveChange();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}