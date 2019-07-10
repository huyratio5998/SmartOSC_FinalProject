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
using MS.DataAccess.Models;
using MS.Repository;
using MS.Repository.Interface;
using MS.Service;
using MS.Service.Interface;
using ProjectManagerSystem.Models;

namespace ProjectManagerSystem.Controllers
{
    public class MyAccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMyAccountService _myAccountService;

        public MyAccountController()
        {

        }

        public MyAccountController(UnitOfWork unitOfWork, MyAccountService myAccountService)
        {
            _unitOfWork = unitOfWork;
            _myAccountService = myAccountService;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        // GET: MyAccountbyID
        [HttpGet]
        public ActionResult GetAccount()
        {
            
                string id = User.Identity.GetUserId();
                var model =  _myAccountService.GetAspNetUser(id);

                return Json(new
                {
                    data = model
                }, JsonRequestBehavior.AllowGet);
        }

    }
}
