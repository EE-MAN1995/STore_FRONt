using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STore_FRONt.Models
{
    public class Order
    {
       
        
        public int ID { get; set; }
        public string OrderDate { get; set; }

        public int Total_Price { get; set; }


        public int Sub_Total { get; set; }


        public string Product_Name { get; set; }

        public string Product_Image { get; set; }

        public decimal Price { get; set; }

        public string Size { get; set; }

        [Required(ErrorMessage = "Please Enter The FirstName")]
        public int QUANT { get; set; }


        [Required(ErrorMessage = "Please Enter The FirstName")]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "Please Enter The LastName ")]
        public string Last_Name { get; set; }


        [Required(ErrorMessage = "Please Enter The Phone_Number")]
        public int Phone_Number { get; set; }


        [Required(ErrorMessage = "Please Enter The Adress")]
        public string Adress { get; set; }








  



    }
}