using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using MS.DataAccess;
using MS.DataAccess.Models;
using MS.Repository;
using MS.Repository.Interface;
using MS.Service;
using MS.Service.Interface;
using ProjectManagerSystem.Authorization;
using ProjectManagerSystem.Models;
using static ProjectManagerSystem.Controllers.ManageController;

namespace ProjectManagerSystem.Controllers
{
    public class MyAccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMyAccountService _myAccountService;
        private readonly IAspNetUserRolesService _aspNetUserRolesService;
        private readonly IAspNetRolesService _aspNetRolesService;
        




        public MyAccountController()
        {

        }

        public MyAccountController(IAspNetUserRolesService aspNetUserRolesService,  IAspNetRolesService aspNetRolesService, IUnitOfWork unitOfWork, IMyAccountService myAccountService)
        {
            _unitOfWork = unitOfWork;
            _myAccountService = myAccountService;
            _aspNetUserRolesService = aspNetUserRolesService;
            _aspNetRolesService = aspNetRolesService;
          

        }
        [CustomAuthorize]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetAccount()
        {
            string id = User.Identity.GetUserId();
            var aa = _myAccountService.GetAll();
            var bb = _aspNetUserRolesService.GetAll();
            var cc = _aspNetRolesService.GetAll();
            var query = (from a in _myAccountService.GetAll()
                         join b in _aspNetUserRolesService.GetAll() on a.Id equals b.UserId
                         join c in _aspNetRolesService.GetAll() on b.RoleId equals c.Id
                         where (a.Id == id)
                         select new { Id = a.Id, UserName = a.UserName, FullName = a.FullName, Password = a.PasswordHash, Email = a.Email, UrlAvatar = a.UrlAvatar, Role = c.Name }).First();

            return Json(new
            {
                data = query
            }, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public ActionResult save([Bind(Include = "Id,UserName,FullName,Password,UrlAvatar,Email")] MyAccountViewModels MyAccount)
        //{
        //    bool status = false;
        //    if (ModelState.IsValid)
        //    {
        //        status = true;
        //        _myAccountService.UpdateAspNetUser(Mapper.Map<MyAccountViewModels, AspNetUser>(MyAccount));
        //        _myAccountService.SaveChange();
        //    }

        //    return Json(new
        //    {
        //        status = status
        //    });
        //}
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }
    }
}
