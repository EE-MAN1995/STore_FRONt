using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using STore_FRONt.Models;

namespace STore_FRONt.Controllers
{
    public class ORderController : Controller
    {

        public static List<Order> YU = new List<Order>();

        Order ord1 = new Order();

         
        // GET: ORder
        public ActionResult Index()
        {



          


            return View(YU);



            
        }

 





        // GET: ORder/Details/5
        public ActionResult Details()
        {

          

           




            return View( );
        }

        // GET: ORder/Create
        public ActionResult Create()
        {



            return View();
        }

        // POST: ORder/Create
        [HttpPost]
        public   ActionResult   Create( string size  , int id , string ProdName , string ProdImage ,int quant , decimal Price  , string ProdImg  , string Msg    )
        {

           

            try
            {
                // TODO: Add insert logic here


                var s = "succ";
               
                var cs = YU.Find(a => a.Product_Name == ProdName);


                if (cs != null)
                {

                    ViewBag.Result = "You Alrady Add This Product";

                    return RedirectToAction("Details", "Products", new { id = id , Msg = ViewBag.Result });

                }

                var xx2 = YU.Count;
                if (xx2 == 6)
                {

                    ViewBag.Result = "Maxmum Product to purches is 6";

                    return RedirectToAction("Details", "Products", new { id = id, MSG = ViewBag.Result,   MSGG = ViewBag.Result }) ;

                }


                //if we didnt found a result
                else
                {
                    var xx = YU.Count;

                    YU.Add(new Order
                    {




                        ID = xx + 1,


                        Product_Name = ProdName,


                        QUANT = quant,
                        Price = Price,
                        Total_Price = Convert.ToInt32(Price) * quant,
                        Product_Image = ProdImg,
                        Size = size,

                        Sub_Total = Convert.ToInt32(ord1.Total_Price.ToString())


                    }) ;

                    ViewBag.Result =  "Successfuly Add to the Cart";

                    return RedirectToAction("Details", "Products", new { id = id, Msg = ViewBag.Result });
                }





 

                return RedirectToAction("Details", "Products", new { @id = id } );




            }
            catch
            {
                return View();
            }
        }

        // GET: ORder/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ORder/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public List<Order> GetYU()
        {
            return YU;
        }


        [HttpGet]
        public ActionResult deleteAll()
        {



           
            return View(YU);

              

        }

        [HttpPost]
        public   ActionResult deleteAll(string name)
        {

            YU.Clear();
            return RedirectToAction("/Index");



        }


        public  ActionResult DeleteMe()
        {


            YU.Clear();
             
            return View();
      


        }

        // GET: ORder/Delete/5
        public ActionResult Delete(string name)
        {

            var x = YU.Single(c => c.Product_Name == name);

            return View(x);
        }

        // POST: ORder/Delete/5
        [HttpPost]
        public ActionResult Delete(string name, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var x = YU.Single(c => c.Product_Name == name);

                YU.Remove(x);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
