using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LightHouse.Models;

namespace LightHouse.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            return View();
        }
        //[HttpPost]
        //public ActionResult Index(RequestMessage model)
        //{
        //    TestEntities db = new TestEntities();
        //    ViewBag.B_id = new SelectList(db.Bloodgroups, "B_id", "BloodName");
        //    ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "DistrictName");
        //    if (ModelState.IsValid)
        //    {
                
        //        RequestData rq = new RequestData();
        //        rq.R_id = model.R_id;
        //        rq.PatiName = model.PatiName;
        //        rq.B_id = model.B_id;
        //        rq.DistrictId = model.DistrictId;
        //        rq.HospitalName = model.HospitalName;
        //        rq.Amountofblood = model.Amountofblood;
        //        rq.Reason = model.Reason;
        //        rq.ReqDate = DateTime.Now;
        //        rq.Dactive = true;
        //        rq.DPhone = "A";
        //        db.RequestDatas.Add(rq);
        //        db.SaveChanges();
                
        //    }
        //    return View();
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}