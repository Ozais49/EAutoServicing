using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using EAutoServicing.Models;
using EAutoServicing.Utilities;
using System.Web.Helpers;
using System.IO;
namespace EAutoServicing.Controllers
{
    [Authorize(Roles = "Admin")]

    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        EAutoServicingContext db = new EAutoServicingContext();
        public ActionResult Index()
        {
            var model = db.Employees.Where(x =>(x.Status == (int)DataStatus.Active)).ToList(); 
                
           
            return View(model);
        }
        public ActionResult Create()
        {
           // ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name");
            //ViewBag.EmployeeTypeid = new SelectList(db.Employeetypes, "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee model)
        {
            List<string> errors = new List<string>();
            try
            {
                if (ModelState.IsValid)
                {
                    if(Request.Files.Count>0)
                    {
                        if(Request.Files[0].ContentLength>0)
                        {
                            var file = Request.Files[0];
                            if(file!=null && file.ContentLength>0)
                            {
                                WebImage img = new WebImage(Request.Files[0].InputStream);
                                img.Resize(440, 300, true, true);
                                string extension = Path.GetExtension(file.FileName.ToString().ToLower());
                                if(extension==".jpg"||extension==".jpeg"||extension==".png")
                                {
                                    string filename = Guid.NewGuid().ToString() + extension;
                                    if(!Directory.Exists(Server.MapPath("~/Uploads")))
                                    {
                                        Directory.CreateDirectory(Server.MapPath("~/Uploads"));
                                    }
                                    if(!Directory.Exists(Server.MapPath("~/Uploads/Images")))
                                    {
                                        Directory.CreateDirectory(Server.MapPath("~/Uploads/Images"));
                                    }
                                    string physicalPath = Server.MapPath("~/Uploads/Images/" + filename);
                                    img.Save(physicalPath);
                                    model.Photo = string.Format("~/Uploads/Images/{0}", filename);
                                }

                            }
                        }
                    }
                    model.EntryBy = Utility.Currentuser.Id;
                    model.EntryDate = DateTime.Now;
                    model.Status = (int)DataStatus.Active;
                    
                    db.Employees.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");

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
            //ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name");
            //ViewBag.EmployeeTypeid = new SelectList(db.Employeetypes, "Id", "Name");
            return View();
        }



        public ActionResult Edit( int Id)
        {
            
            var model = db.Employees.Find(Id);
            if (model == null)
            {
                return HttpNotFound();
            }
            //ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name",model.GenderId);
            //ViewBag.EmployeeTypeid = new SelectList(db.Employeetypes, "Id", "Name",model.EmployeeTypeId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Employee model)
        {
            if (ModelState.IsValid)
            {
                var _oldModel = db.Employees.Find(model.Id);
                //Save Data
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                        WebImage img = new WebImage(Request.Files[0].InputStream);
                        img.Resize(440, 300, true, true);
                        string extension = Path.GetExtension(file.FileName.ToString()).ToLower();
                        if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                        {
                            //Save File
                            string fileName = Guid.NewGuid().ToString() + extension;
                            if (!Directory.Exists(Server.MapPath("~/Uploads")))
                                Directory.CreateDirectory(Server.MapPath("~/Uploads"));
                            if (!Directory.Exists(Server.MapPath("~/Uploads/Images")))
                                Directory.CreateDirectory(Server.MapPath("~/Uploads/Images"));
                            string physicalPath = Server.MapPath("~/Uploads/Images/" + fileName);

                            var _imgmodel = db.Employees.Find(model.Id);
                            if (_imgmodel.Photo != null && System.IO.File.Exists(Server.MapPath(_imgmodel.Photo)))
                                System.IO.File.Delete(Server.MapPath(_imgmodel.Photo));

                            img.Save(physicalPath);
                            _oldModel.Photo = string.Format("~/Uploads/Images/{0}", fileName);
                        }
                    }
                           _oldModel.Name = model.Name;
                           _oldModel.Gender = model.Gender;
                           _oldModel.Address = model.Address;
                           _oldModel.PhoneNumber = model.PhoneNumber;
                           _oldModel.DOB = model.DOB;
                           _oldModel.DateJoined = model.DateJoined;
                          // _oldModel.EmployeeTypeId = model.EmployeeTypeId;
                           _oldModel.Remarks = model.Remarks;
                    db.SaveChanges();
                    return RedirectToAction("index");
                }
            }
            //ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name");
            //ViewBag.EmployeeTypeid = new SelectList(db.Employeetypes, "Id", "Name");
            return View(model);
        }
        //#region codeedit
        //[HttpPost]
        //public ActionResult Edit(Employee model)
        //{
        //    List<string> errors = new List<string>();
        //    try
        //    {
        //        var _Oldmodel = db.Employees.Find(model.Id);
        //        _Oldmodel.Name = model.Name;
        //        _Oldmodel.GenderId = model.GenderId;
        //        _Oldmodel.Address = model.Address;
        //        _Oldmodel.PhoneNumber = model.PhoneNumber;
        //        _Oldmodel.DOB = model.DOB;
        //        _Oldmodel.DateJoined = model.DateJoined;
        //        _Oldmodel.EmployeeTypeId = model.EmployeeTypeId;
        //        _Oldmodel.Remarks = model.Remarks;

        //        if (ModelState.IsValid)
        //        {
                    
        //            db.Entry(_Oldmodel).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("index");
        //        }
        //        foreach (var item in ModelState.Where(x => x.Value.Errors.Any()))
        //        {
        //            errors.Add(item.Value.Errors.FirstOrDefault().ErrorMessage);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        errors.Add(ex.Message);
        //    }
        //    if (errors.Count > 0)
        //        TempData["Errors"] = errors;

        //    ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name");
        //    ViewBag.EmployeeTypeid = new SelectList(db.Employeetypes, "Id", "Name");
        //    return View();
        //}

        //#endregion

        public ActionResult Delete(int id)
        {
            List<string> errors=new List<string>();
            try
            {
                var model = db.Employees.Find(id);
                if(model==null)
                {
                    return HttpNotFound();
                }
                
                model.Status = (int)DataStatus.Deleted;
                model.DeletedBy = Utility.Currentuser.Id;
                model.DeletedDate = DateTime.Now;
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                errors.Add(ex.Message);
            }
            if (errors.Count > 0)
                TempData["errors"] = errors;
            return RedirectToAction("index");
           
        }
	}
}