
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front_STore.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public byte[] ProducImage { get; set; }
        public string About { get; set; }
        public decimal Price { get; set; }
        public int Quant { get; set; }
 
 
    }
}
