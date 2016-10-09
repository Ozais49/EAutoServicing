using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EAutoServicing.Models;
using EAutoServicing.Utilities;
using System.Web.Security;
using System.Data.Entity;

namespace EAutoServicing.Controllers
{
    

    public class AppUserController : Controller
    {
        //
        // GET: /AppUser/
        EAutoServicingContext db = new EAutoServicingContext();
        [Authorize(Roles = "Admin")]

        public ActionResult List()
        {
            var model = db.AppUsers.Where(x=>x.Status==(int)DataStatus.Active).ToList();
           return View(model);
        }
        [Authorize(Roles = "Admin")]

         public ActionResult Create()
        {
            ViewBag.UserRoleId = new SelectList(db.UserRoles, "Id", "Name");
            return View();
        }

        [HttpPost]
         public ActionResult Create(AppUser model)
         {
             List<string> errors = new List<string>();
             try
             {
                 
               model.Status=(int)DataStatus.Active;
                 if (ModelState.IsValid)
                 {
                     db.AppUsers.Add(model);
                     db.SaveChanges();
                     return RedirectToAction("list");
                 }

                 foreach (var item in ModelState.Where(x => x.Value.Errors.Any()))
                 {
                     errors.Add(item.Value.Errors.FirstOrDefault().ErrorMessage);
                 }
             }
             catch (Exception ex)
             {
                 errors.Add(ex.Message);
             }
             if (errors.Count > 0)
                 TempData["Errors"] = errors;
             ViewBag.UserRoleId = new SelectList(db.UserRoles, "Id", "Name");
             return View(model);
         }
        public ActionResult Edit(int id)
        {
            var model = db.AppUsers.Find(id);
            if(model==null)
            {
                return HttpNotFound();
            }
            ViewBag.UserRoleId = new SelectList(db.UserRoles, "Id", "Name",model.UserRoleId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(AppUser model)
        {
            List<string> errors = new List<string>();
            try
            {
                var _oldmodel = db.AppUsers.Find(model.Id);
                _oldmodel.UserName = model.UserName;
                _oldmodel.UserRoleId = model.UserRoleId;
                if(ModelState.IsValid)
                {
                    db.Entry(_oldmodel).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("list");

                 }
                foreach(var item in ModelState.Where(x=>x.Value.Errors.Any()))
                {
                    errors.Add(item.Value.Errors.FirstOrDefault().ErrorMessage);
                }

            }
            catch(Exception ex)
            {
                errors.Add(ex.Message);
            }
            if(errors.Count > 0)
            {
                TempData["Errors"]=errors;
            }
            ViewBag.UserRoleId = new SelectList(db.UserRoles, "Id", "Name");
            return View();            
            
            
        }

        public ActionResult Delete(int id)
        {
            List<string> errors = new List<string>();
            try
            {
                var model = db.AppUsers.Find(id);
                if(model==null)
                {
                    return HttpNotFound();
                }
               
                model.Status = (int)DataStatus.Deleted;
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
            }
            if (errors.Count > 0)
                TempData["errors"] = errors;
            return RedirectToAction("list");
        }
        public ActionResult index()
        {
            if(Request.IsAuthenticated)
            {
                return RedirectToAction("list");
            }
            return View("login");
        }
        [HttpPost]
        public ActionResult index(AppUser model)
        {
            List<string> errors = new List<string>();
            var appuser = db.AppUsers.Where(x =>
               (x.UserName == model.UserName &&
                x.Password == model.Password &&
                x.Status == (int)DataStatus.Active)).FirstOrDefault();

          
            if (appuser == null)
            {
                ModelState.AddModelError("UserName", "Invalid Username or Password ");
                errors.Add("Invalid Username or password");
            }

           

            if (errors.Count < 1)
            {
                //Login here
                FormsAuthentication.SetAuthCookie(appuser.UserName, model.RememberMe);
                return RedirectToAction("list");
            }
            
            return View("login", model);
        }

        public ActionResult logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index");
        }

	}
}