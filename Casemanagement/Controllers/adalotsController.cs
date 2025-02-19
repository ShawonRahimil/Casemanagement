using Casemanagement.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casemanagement.Controllers
{
    public class adalotsController : Controller
    {
        private readonly CaseContext db= new CaseContext();
        public ActionResult Index()
        {
            var model=db.Adalot.ToList();

            return View(model);
        }
        public ActionResult Create()
        { 
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(Adalot entity)
        {

            db.Adalot.Add(entity);
            if (ModelState.IsValid)
            {
                if (entity.Picture!=null) {
                    var ext = Path.GetExtension(entity.Picture.FileName).ToLower();
                    if (ext==".jpg"||ext==".png"||ext==".jpeg")
                    {
                        string foldertosave = Path.Combine(Server.MapPath("~/"),"Picture");
                        if (!Directory.Exists(foldertosave))
                        {
                            Directory.CreateDirectory(foldertosave);

                        }
                        string filename = entity.Name + ext;
                        string filetosave = Path.Combine(foldertosave, filename);
                        entity.Picture.SaveAs(filetosave);
                        entity.logoPath = "~/Picture/" + filename;
                        if (db.SaveChanges() > 0)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Save Failed");

                        }
                    }
                    else
                    {

                        ModelState.AddModelError("", "Please Provide Image .jpg|.png|jpeg");
                    }
                
                
                
                }
                else
                {
                    ModelState.AddModelError("", "Please Provide Image");
                }


            }

            else {
                var message = string.Join("|", ModelState.Values.SelectMany(e => e.Errors).Select(m => m.ErrorMessage));
                ModelState.AddModelError("", message);

            }

           



            return View(entity);
        }
          
        public ActionResult Edit(int Id)
        {
            return View(db.Adalot.Find(Id));
        }
        [HttpPost]
        public ActionResult Edit(Adalot entity)
        {
            if (ModelState.IsValid)
            {
                var update = db.Adalot.Find(entity.Id);
                update.Name = entity.Name;
                update.Description = entity.Description;
               
                if (entity.Picture != null) {

                     string oldpath = Path.Combine(Server.MapPath("~/"), entity.logoPath).Replace("~","");
                    var ext = Path.GetExtension(entity.Picture.FileName).ToLower();
                    if (ext==".jpg"||ext==".jpeg"||ext==".png")
                    {
                        string foldertosave = Path.Combine(Server.MapPath("~/"), "Picture");
                        if (!Directory.Exists(foldertosave))
                        {
                            Directory.CreateDirectory(foldertosave);

                        }
                        if (System.IO.File.Exists(oldpath))
                        {
                            System.IO.File.Delete(oldpath  );

                        }

                        string filename = entity.Name + ext;
                        string filetosave = Path.Combine(foldertosave, filename);
                        entity.Picture.SaveAs(filetosave);
                        update.logoPath= "~/Picture/"+filename;
                 

                    }


                    else
                    {
                        //ModelState.AddModelError("","please provide Image type jpg|png|jpeg");

                        update.Picture = entity.Picture;
                    }

                }

                db.Entry(update).State = System.Data.Entity.EntityState.Modified;


                if (db.SaveChanges() > 0)
                {
                   
                    return RedirectToAction("Index");

                }
                else
                {
                    ModelState.AddModelError("", "Save Failed");
                }






            }
            else
            {
                var message = string.Join("|", ModelState.Values.SelectMany(e => e.Errors).Select(m=>m.ErrorMessage));
                ModelState.AddModelError("", message);
            }


            return View(entity);
        }
        public ActionResult Delete (int Id){
            var delete = db.Adalot.Find(Id);
            db.Adalot.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}