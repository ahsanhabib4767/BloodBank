using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LightHouse.Models;
using System.Data.Entity;
using System.Linq.Dynamic;


namespace LightHouse.Controllers
{   [Authorize]
    public class DonorlistController : Controller
    {
        // GET: Donorlist
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Listdonor() {

            TestEntities db = new TestEntities();
            IEnumerable<Donordata> list = db.Donordatas.ToList();
            return View(list);
        }
        [HttpPost]
        public JsonResult LoadData()
        {
            //jQuery DataTables Param
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            //Find paging info
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            //Find order columns info
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault()+ "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            //find search columns info
            var contactName = Request.Form.GetValues("columns[0][search][value]").FirstOrDefault();
            var blood = Request.Form.GetValues("columns[3][search][value]").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt16(start) : 0;
            int recordsTotal = 0;


            using (TestEntities dc = new TestEntities())
            {
                // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
                var v = (from a in dc.Donordatas select a);

                //SEARCHING...
                if (!string.IsNullOrEmpty(contactName))
                {
                    v = v.Where(a => a.Daddress.Contains(contactName));
                }
                if (!string.IsNullOrEmpty(blood))
                {
                    v = v.Where(a => a.Bbloodgroup == blood);
                }
                //SORTING...  (For sorting we need to add a reference System.Linq.Dynamic)
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    v = v.OrderBy(sortColumn + " " + sortColumnDir);
                }

                recordsTotal = v.Count();
                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data },
                    JsonRequestBehavior.AllowGet);

            }
        }
    }
}