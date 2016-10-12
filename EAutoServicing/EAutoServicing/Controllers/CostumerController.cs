using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using EAutoServicing.Utilities;
using PagedList;
using PagedList.Mvc;

using EAutoServicing.Models;
using System.Web.Security;
namespace EAutoServicing.Controllers
{
[Authorize(Roles="Admin")]
    public class CostumerController : Controller
    {
        

        EAutoServicingContext db = new EAutoServicingContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Detail(string Name,string Gender,string Address, int?page)
        {
            var model = db.Costumers
                .Where(x =>
                        (string.IsNullOrEmpty(Name) || x.Name.StartsWith(Name)) &&
                        (Gender == null || x.Gender == Gender) &&
                        (string.IsNullOrEmpty(Address) || x.Address.StartsWith(Address))&&
                        (x.Status == (int)DataStatus.Active)
                        ).ToList().ToPagedList(page ?? 1, 10); 

           //ViewBag.Name = Name;
           //ViewBag.Address = Address;he
            return View(model);
        }

        #region Create
        public ActionResult Create()
        {
           // ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Costumer model)
        {
            List<string> errors = new List<string>();
            try
            {
                model.Status = (int)DataStatus.Active;
                model.EntryDate = DateTime.Now;
                model.EntryBy = Utility.Currentuser.Id;
               
               
                //db.SaveChanges();
                //return RedirectToAction("index");

                if (ModelState.IsValid)
                {
                    db.Costumers.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("index");
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
            //ViewBag.GenderId   = new SelectList(db.Genders, "Id", "Name");


            return View(model);  
        }
        #endregion

        public ActionResult Edit(int id)
        {
            var model = db.Costumers.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Costumer model)
        {
            List<string> errors = new List<string>();
            try
            {
                var _Oldmodel = db.Costumers.Find(model.Id);
                _Oldmodel.Name = model.Name;
                _Oldmodel.Gender = model.Gender;
                _Oldmodel.Address = model.Address;
                _Oldmodel.Email = model.Email;
                _Oldmodel.PhoneNumber = model.PhoneNumber;
                //db.Entry(_Oldmodel).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("index");
                if (ModelState.IsValid)
                {
                    db.Entry(_Oldmodel).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("index");
                }
                foreach (var item in ModelState.Where(x => x.Value.Errors.Any()))
                {
                    errors.Add(item.Value.Errors.FirstOrDefault().ErrorMessage);
                }

}
            catch(Exception ex)
            {
                errors.Add(ex.Message);
               
            }
            if (errors.Count > 0)
                TempData["Errors"] = errors;
            return View();
        }



        public ActionResult Delete(int id)
        {

            List<string> errors = new List<string>();
            try
            {
                var model = db.Costumers.Find(id);
                if (model == null)
                    return HttpNotFound("The page you are looking for doesnot exists");
                //db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                model.Status = (int)DataStatus.Deleted;
                model.DeletedDate = DateTime.Now;
                model.DeletedBy = Utility.Currentuser.Id;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
            }
            if (errors.Count > 0)
                TempData["errors"] = errors;
            return RedirectToAction("index");
            
        }

        //ServiceBooking code Start
        #region ServiceBooking
        public ActionResult CreateBooking(int costumerId)
        {
            var Costumer = db.Costumers.Find(costumerId);
            ViewBag.costumer = Costumer;
           

            ViewBag.CostumerId = new SelectList(db.Costumers, "Id", "Name");
                 
            ViewBag.ServicedBy = new SelectList(db.Employees.Where(x=>(x.Status==1)), "Id", "Name");
            
            var model = new ServiceBooking { CostumerId = Costumer.Id };
            
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateBooking(ServiceBooking model)
        {
            List<string> errors = new List<string>();
            
         
            try
            {
                model.Status = (int)DataStatus.Active;
                model.EntryBy = Utility.Currentuser.Id;
                model.EntryDate = DateTime.Now;
                if(ModelState.IsValid)
                {
                    db.ServiceBookings.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("CreateBooking", new { costumerid = model.CostumerId });

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
            if(errors.Count>0)
            {
                TempData["Errors"] = errors;
            }
            ViewBag.CostumerId = new SelectList(db.Costumers, "Id", "Name");
            ViewBag.ServicedBy = new SelectList(db.Employees.Where(x => (x.Status == 1)), "Id", "Name");

            //ViewBag.ServicedBy = new SelectList(db.Employees, "Id", "Name");
           
            
           
            return View(model);
           
        }
        public ActionResult ServiceBookingList(int costumerid)
        {
            var model = db.ServiceBookings.Where(x => (x.CostumerId == costumerid) &&
                (x.Status == (int)DataStatus.Active))
                .ToList();
            ViewBag.costumer = model;
            return View(model);
        }

        public ActionResult EditBooking(int id)
        {
            var model = db.ServiceBookings.Find(id);
            ViewBag.costumer = model;
            
            if(model==null)
            {
                return HttpNotFound();
            }
            ViewBag.CostumerId = new SelectList(db.Costumers, "Id", "Name",model.CostumerId);
           // ViewBag.ServicedBy = new SelectList(db.Employees, "Id", "Name",model.ServicedBy);
            ViewBag.ServicedBy = new SelectList(db.Employees.Where(x => (x.Status == 1)), "Id", "Name",model.ServicedBy);

           
            return View(model);
        }
        [HttpPost]
        public ActionResult EditBooking(ServiceBooking model)
        {
            List<string> errors = new List<string>();
            try
            {
                var _oldmodel = db.ServiceBookings.Find(model.Id);
              
                _oldmodel.VehicleNumber = model.VehicleNumber;
                _oldmodel.ServicedBy = model.ServicedBy;
                _oldmodel.ServicedDate = model.ServicedDate;
                _oldmodel.NextServiceDate = model.NextServiceDate;
                if(ModelState.IsValid)
                {
                    db.Entry(_oldmodel).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("CreateBooking", new { costumerid = model.CostumerId });
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
            if (errors.Count > 0)
                TempData["Errors"] = errors;
            //ViewBag.ServicedBy = new SelectList(db.Employees, "Id", "Name",model.ServicedBy);
            ViewBag.ServicedBy = new SelectList(db.Employees.Where(x =>  (x.Status == 1)), "Id", "Name",model.ServicedBy);

            return View();

        }

       public ActionResult DeleteBooking(int id)
        {
            List<string> errors = new List<string>();
            var test = db.ServiceBookings.Find(id);
            try
            {
                var model = db.ServiceBookings.Find(id);
                if(model==null)
                {
                    return HttpNotFound();
                }
                model.Status = (int)DataStatus.Deleted;
                model.DeletedDate = DateTime.Now;
                model.DeletedBy = Utility.Currentuser.Id;
                db.SaveChanges();
            }
           catch(Exception ex)
            {
                errors.Add(ex.Message);
            }
           if(errors.Count>0)
           {
               TempData["errors"] = errors;
           }
          return RedirectToAction("CreateBooking", new { costumerid = test.CostumerId });
        }

        #endregion


    }
}
