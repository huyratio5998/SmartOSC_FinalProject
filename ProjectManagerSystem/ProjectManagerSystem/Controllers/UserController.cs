using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MS.DataAccess.Models;
using MS.Service.Interface;
using ProjectManagerSystem.Models;

namespace ProjectManagerSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
       // private  IMapper _mapper;
        
        public UserController()
        { }

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: User
        public ActionResult Index()
        {

            var Users = Mapper.Map<IEnumerable<AspNetUser>, IEnumerable<AspNetUsersViewModel>>(_userService.GetAll());

            return View(Users);
        }

        // GET: User/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUsersViewModel aspNetUsersViewModel =Mapper.Map< AspNetUser, AspNetUsersViewModel>(_userService.GetAspNetUser(id));
            if (aspNetUsersViewModel == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUsersViewModel);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullName,Email,Password,UserName,Avatar,Role")] AspNetUsersViewModel aspNetUsersViewModel)
        {
            if (ModelState.IsValid)
            {
                var model = _userService.AddAspNetUser(Mapper.Map<AspNetUsersViewModel, AspNetUser>(aspNetUsersViewModel));
                //var  Mapper.Map<AspNetUser, AspNetUsersViewModel>(model);
                _userService.SaveChange();
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
            AspNetUsersViewModel aspNetUsersViewModel = Mapper.Map< AspNetUser, AspNetUsersViewModel>( _userService.GetAspNetUser(id));
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
                _userService.UpdateAspNetUser(Mapper.Map<AspNetUsersViewModel, AspNetUser>(aspNetUsersViewModel));
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
            _userService.DeleteAspNetUser(Mapper.Map < AspNetUsersViewModel, AspNetUser > (aspNetUsersViewModel));
            _userService.SaveChange();
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
