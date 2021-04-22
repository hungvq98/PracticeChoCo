using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechEquip.Models.ModelView;

namespace TechEquip.Areas.Admin.Controllers
{
    public class AdminsiteController : Controller
    {
        // GET: Admin/Adminsite
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Product()
        {
            Models.Categoryne c = new Models.Categoryne();
            var q = c.GetAll();
            ViewBag.list_category = q;

            Models.Product_Bussiness pb = new Models.Product_Bussiness();
            var q2 = pb.Getall();
            ViewBag.list_product = q2;
            return View();
        }

        [HttpPost]
        public ActionResult Create_Product(HttpPostedFileBase Img)
        {
            ProductView pv = new ProductView();
            pv.name_product = Request.Form["Name"];
            pv.name_image = Img.FileName;
            pv.description = Request.Form["Decription"];
            pv.price = double.Parse(Request.Form["Price"]);
            pv.id_category = int.Parse(Request.Form["Category_id"]);
            pv.active = Request.Form["Active"].Equals("on") ? true : false;
            string pathUpload = Server.MapPath("~/Areas/Admin/Upload/") + pv.name_image;
            Img.SaveAs(pathUpload);
            Models.Product_Bussiness pb = new Models.Product_Bussiness();
            pb.Cretae(pv);
            return RedirectToAction("Product");
        }


        public ActionResult Edit_Product() {

            return RedirectToAction("Product");
        }
        
        [HttpPost]
        public JsonResult Delete_Product()
        {
            int id = int.Parse(Request.Form["id_Product"]);
            Models.Product_Bussiness pb = new Models.Product_Bussiness();
            var q = pb.Get_id(id);
            pb.Delete(q);
            return Json("Success");
        }


        public ActionResult Store()
        {
            return View();
        }

        public ActionResult Category()
        {
            return View();
        }

    }
}
