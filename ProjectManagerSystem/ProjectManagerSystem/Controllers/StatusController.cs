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
            });
        }
        [HttpPost]
        public ActionResult save([Bind(Include = "ID,Name")] StatusViewModel statusView)
        {
            bool status = false;

            if (statusView.Id == 0)
            {
                var statusdata = Mapper.Map<IEnumerable<Status>, IEnumerable<StatusViewModel>>(_statusService.GetAll());
                var mode = (from s in statusdata where s.Id == statusView.Id select s.Name).ToString();
                if(mode == statusView.Name)
                {
                    status = false;
                    return Json(new
                    {
                        status = status
                    });
                }
                _statusService.AddStatus(Mapper.Map<StatusViewModel, Status>(statusView));
                _statusService.SaveChange();
                status = true;
            }
            else
            {
                //_statusService.UpdateStatus(Mapper.Map<StatusViewModel, Status>(statusView)).State = EntityState.Modified;
                //_statusService.SaveChange();
                status = true;
            }
            return Json(new
            {
                status = status
            });
        }
        [HttpGet]
        public ActionResult GetById(int id)
        {
            var model = _statusService.GetStatus(id);
            return Json(new
            {
                data = model,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        //[HttpPost]
        //public ActionResult Update(StatusViewModel status)
        //{
        //    _statusService.UpdateStatus(status);
        //    return new OkObjectResult(status);
        //}
        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    _statusService.DeleteStatus(id);
        //    //return new OkObjectResult(id);
        //    return new OkObjectResult(id);

        //}
        // GET: Status/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    StatusViewModels statusViewModels = db.StatusViewModels.Find(id);
        //    if (statusViewModels == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(statusViewModels);
        //}

        //// GET: Status/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Status/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name")] StatusViewModels statusViewModels)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.StatusViewModels.Add(statusViewModels);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(statusViewModels);
        //}

        //// GET: Status/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    StatusViewModels statusViewModels = db.StatusViewModels.Find(id);
        //    if (statusViewModels == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(statusViewModels);
        //}

        //// POST: Status/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name")] StatusViewModels statusViewModels)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(statusViewModels).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(statusViewModels);
        //}

        //// GET: Status/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    StatusViewModels statusViewModels = db.StatusViewModels.Find(id);
        //    if (statusViewModels == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(statusViewModels);
        //}

        //// POST: Status/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    StatusViewModels statusViewModels = db.StatusViewModels.Find(id);
        //    db.StatusViewModels.Remove(statusViewModels);
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
