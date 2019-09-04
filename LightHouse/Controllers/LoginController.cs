using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LightHouse.Models;
using System.Web.Security;
using System.Data.Entity.Validation;

namespace LightHouse.Controllers
{

    public class LoginController : Controller
    {
        // GET: Account
        
        public ActionResult Login()
        {   
      
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.Member model)
        {
            using (var context = new TestEntities())
            {
                bool isValid = context.UserProfiles.Any(x => x.Dusername == model.Dusername && x.Dpassword == model.Dpassword);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Dusername, false);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid username and password");
                return View();
            }
        }
        private TestEntities db = new TestEntities();
        public ActionResult Signup()
        {
            
            return View();
        }

        
        [HttpPost]
        public ActionResult Signup(Donate model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    TestEntities db = new TestEntities();
                    Donordata nw = new Donordata();
                    nw.D_id = model.D_id;
                    nw.Dname = model.Dname;
                    nw.Daddress = model.Daddress;
                    nw.Dusername = model.Dusername;
                    nw.Dpassword = model.Dpassword;

                    nw.Bbloodgroup = model.Bbloodgroup;
                    nw.DPhone = model.DPhone;
                    nw.Dthana = "A";
                    nw.Ddistrict = "Dhaka";
                    nw.DdonateDate = DateTime.Now;
                    nw.Dactive = true;
                    db.Donordatas.Add(nw);
                    db.SaveChanges();
                    int latestdis = nw.D_id;
                    UserProfile ur = new UserProfile();
                    
                    ur.D_id = latestdis;
                    ur.Dusername = model.Dusername;
                    ur.Dpassword = model.Dpassword;
                    db.UserProfiles.Add(ur);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
               
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}