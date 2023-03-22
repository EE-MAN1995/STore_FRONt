using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using STore_FRONt.Models;

namespace STore_FRONt.Controllers
{
    public class ProductsController : Controller
    {
        private F_StoreEntities3 db = new F_StoreEntities3();
        public static List<Order> YU = new List<Order>();
        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        [Route("Products/Details/{id:int}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
               
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
             
                return HttpNotFound();
            }
 
            return View(product);
        }


        [Route("Products/Details/id/Msg")]
        public ActionResult Details(int? id , string Msg)
        {
         
            Product product = db.Products.Find(id);
            if (product == null)
            {
            
                return HttpNotFound();
             
            }



            ViewBag.Result = Msg; 
            return View(product);

        }

        [Route("Products/Details/id/MSG/MSGG")]
        public ActionResult Details(int? id, string MSG , string MSGG)
        {

            Product product = db.Products.Find(id);
            if (product == null)
            {

                return HttpNotFound();

            }



            ViewBag.Result = MSG;
            return View(product);
        }



        [HttpGet]
        public ActionResult Search(int id)
        {
            Product product = db.Products.Find(id);

            return View(product);
        }


        [HttpPost]
        public ActionResult Search()
        {

            return View();
        }



        public void Add(string ProdName, string ProdImage, int Quant, decimal Price, string ProdImg, string Msg)
        {
            try
            {
                // TODO: Add insert logic here


                var s = "succ";


                YU.Add(new Order
                {


                    Product_Name = ProdName,
                    QUANT = Quant,
                    Price = Price,
                    Total_Price = Convert.ToInt32(Price) * Quant,
                    Product_Image = ProdImg



                });


                if (YU != null)
                {


                    ViewBag.Result = "Sucess";
                }

                else
                {

                    ViewBag.Result = "Its Empty";
                }



                var e = YU != null ? ViewBag.Result = "Sucess" : ViewBag.Result = "Its Empty";



              


            }
            catch
            {
                 
            }


        }




        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Image,Price,About,Cat_ID,Quant")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Image,Price,About,Cat_ID,Quant")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
