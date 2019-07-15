using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MS.DataAccess.Models;
using MS.Repository.Interface;
using MS.Service.Interface;
using ProjectManagerSystem.Authorization;
using ProjectManagerSystem.Models;

namespace ProjectManagerSystem.Controllers
{
    public class StatusController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IStatusService _statusService;
        public StatusController()
        {

        }
        public StatusController(IUnitOfWork unitOfWork, IStatusService statusService)
        {
            _statusService = statusService;
            _unitOfWork = unitOfWork;
        }
        [Route("configuration.html")]
        [CustomAuthorize]
        public ActionResult Index()
        {
            var Status = Mapper.Map<IEnumerable<Status>, IEnumerable<StatusViewModel>>(_statusService.GetAll());
            return View();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var model = Mapper.Map<IEnumerable<Status>, IEnumerable<StatusViewModel>>(_statusService.GetAll());
            return Json(new
            {
                data = model,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        [CustomAuthorize]
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            var Status = Mapper.Map<IEnumerable<Status>, IEnumerable<StatusViewModel>>(_statusService.GetAll());
            Status mode = _statusService.GetStatus(ID);
            _statusService.DeleteStatus(mode);
            _statusService.SaveChange();
            return Json(new
            {
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        public IEnumerable<StatusViewModel> CheckEqual(string Name)
        {
            var statusdata = Mapper.Map<IEnumerable<Status>, IEnumerable<StatusViewModel>>(_statusService.GetAll());
            var mode = (from s in statusdata where s.Name == Name select s).ToList();
            return mode;
        }
        [CustomAuthorize]
        [HttpPost]
        public ActionResult save([Bind(Include = "Id,Name")] StatusViewModel statusView)
        {
            bool status = false;
            if ((statusView.Id == 0) && (statusView.Name == null))
            {
                status = false;
                return Json(new
                {
                    status = status
                }, JsonRequestBehavior.AllowGet);
            }
            if (statusView.Id == 0)
            {

                if (CheckEqual(statusView.Name).Count() > 0)
                {
                    status = false;
                    return Json(new
                    {
                        status = status
                    }, JsonRequestBehavior.AllowGet);
                }
                _statusService.AddStatus(Mapper.Map<StatusViewModel, Status>(statusView));
                _statusService.SaveChange();
                status = true;
            }
            else
            {

                _statusService.UpdateStatus(Mapper.Map<StatusViewModel, Status>(statusView));
                _statusService.SaveChange();
                status = true;
            }
            return Json(new
            {
                status = status
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetDetails(int ID)
        {
            var Status = Mapper.Map<Status, StatusViewModel>(_statusService.GetStatus(ID));
            return Json(new
            {
                data = Status
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetDetailsSearch(string Name)
        {
            var Status = Mapper.Map<Status, StatusViewModel>(_statusService.FindStatus(Name));
            return Json(new
            {
                data = Status
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
