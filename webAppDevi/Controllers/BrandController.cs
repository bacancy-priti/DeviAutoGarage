using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webAppDevi.Models;

namespace webAppDevi.Controllers
{
    public class BrandController : Controller
    {
        //
        // GET: /Brand/

        DeviAutoEntities entity = new DeviAutoEntities();

        public ActionResult ViewBrand(bool IsDeleted=false)
        {
            var list = entity.BikeBrands.ToList();
            ViewBag.DeleteMessage = "";
            return View(list);
        }
        public ActionResult AddEdit(int id = 0)
        {
            if (id > 0)
            {
                var sigleBrand = entity.BikeBrands.FirstOrDefault(c => c.BikeBrandId == id);
                if (sigleBrand != null)
                    return View(sigleBrand);
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddEdit(BikeBrand brand)
        {
            int id = brand.BikeBrandId;
            try
            {
                if (id == 0)
                {
                    BikeBrand objBrand = new BikeBrand();
                    objBrand.BikeBrandName = brand.BikeBrandName;
                    objBrand.IsDeleted = false;
                    entity.BikeBrands.Add(objBrand);                    
                }
                else
                {
                    var sigleBrand = entity.BikeBrands.FirstOrDefault(c => c.BikeBrandId == id);
                    sigleBrand.BikeBrandName = brand.BikeBrandName;                    
                }
                ViewBag.SuccessMessage = id==0?"Brand Added":"Brand Updated";
                entity.SaveChanges();
                brand.BikeBrandName = "";
                return View(brand);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            if (id > 0)
            {
                var sigleBrand = entity.BikeBrands.FirstOrDefault(c => c.BikeBrandId == id);
                if (sigleBrand != null)
                {
                    entity.BikeBrands.Remove(sigleBrand);
                    entity.SaveChanges();
                    return RedirectToAction("ViewBrand",new isdeleted=true);
                }
            }
            return View();
        }
    }
}
