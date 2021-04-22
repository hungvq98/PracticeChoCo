using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TechEquip.Models.Entity;
using TechEquip.Models.ModelView;

namespace TechEquip.Models
{
    public class Product_Bussiness
    {
        public int Cretae(ProductView item) {
            try
            {
                Information_EquipmentEntities db = new Information_EquipmentEntities();
                Product p = new Product() { name_product = item.name_product, name_image = item.name_image, description = item.description, price = item.price, id_category = item.id_category, active = item.active };
                db.Products.Add(p);
                db.SaveChanges();
                return 1;
            }
            catch (EntityException ex)
            {
                Debug.WriteLine(ex.Message);
                return 0;
            }
        }
        public List<ProductView> Getall() { 
            Information_EquipmentEntities db = new Information_EquipmentEntities();
            var q = db.Products.Where(d => d.active == true).Select(d=>new ProductView {id=d.id,name_product=d.name_product,name_image=d.name_image,description=d.description,price=d.price??0,active=d.active??false,name_category=d.Category.name_category}).ToList();
            return q;
        }

        public ProductView Get_id( int id) { 
            Information_EquipmentEntities db = new Information_EquipmentEntities();
            var q = db.Products.Where(d => d.id == id).Select(d => new ProductView { id = d.id, name_product = d.name_product, name_image = d.name_image, description = d.description, price = d.price ?? 0, active = d.active ?? false, name_category = d.Category.name_category }).FirstOrDefault();
            return q;
        }

        public int Delete(ProductView item) {
            try
            {
                Information_EquipmentEntities db = new Information_EquipmentEntities();
                var q = db.Products.Where(d => d.id == item.id).FirstOrDefault();
                db.Products.Remove(q);
                db.SaveChanges();
                return 1;
            }
            catch (EntityException ex)
            {
                Debug.WriteLine(ex.Message);
                return 0;
            }
        }

        public int Edit(ProductView item) {
            try
            {
                Information_EquipmentEntities db = new Information_EquipmentEntities();
                var q = db.Products.Where(d => d.id == item.id).FirstOrDefault();
                q.name_product = item.name_product;
                q.name_image = item.name_image;
                q.description = item.description;
                q.price = item.price;
                q.id_category = item.id_category;
                q.active = item.active;
                db.SaveChanges();
                return 1;
            }
            catch (EntityException ex)
            {
                Debug.WriteLine(ex.Message);
                return 0;

            }
        }
    }
}