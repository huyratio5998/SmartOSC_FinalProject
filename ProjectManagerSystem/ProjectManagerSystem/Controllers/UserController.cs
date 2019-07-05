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
        private readonly IMapper _mapper;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public UserController()
        { }
        // GET: User
        public ActionResult Index()
        {
            
            var Users = _mapper.Map<AspNetUser,AspNetUsersViewModel>(_userService.GetAspNetUser("4dc89eb1-b01b-41a6-a7a3-3114b103b3f2"));
            

            return View();
        }

        // GET: User/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AspNetUsersViewModel aspNetUsersViewModel = _userService.GetAspNetUser(id);
        //    if (aspNetUsersViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(aspNetUsersViewModel);
        //}

        //// GET: User/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: User/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,FullName,Email,Password,UserName,Avatar,Role")] AspNetUsersViewModel aspNetUsersViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _userService.Add(aspNetUsersViewModel);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(aspNetUsersViewModel);
        //}

        //// GET: User/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AspNetUsersViewModel aspNetUsersViewModel = _userService.Find(id);
        //    if (aspNetUsersViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(aspNetUsersViewModel);
        //}

        //// POST: User/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,FullName,Email,Password,UserName,Avatar,Role")] AspNetUsersViewModel aspNetUsersViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(aspNetUsersViewModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(aspNetUsersViewModel);
        //}

        //// GET: User/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AspNetUsersViewModel aspNetUsersViewModel = _userService.Find(id);
        //    if (aspNetUsersViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(aspNetUsersViewModel);
        //}

        //// POST: User/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    AspNetUsersViewModel aspNetUsersViewModel = _userService.Find(id);
        //    _userService.Remove(aspNetUsersViewModel);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
