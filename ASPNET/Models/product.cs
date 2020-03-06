using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET.Models
{
    public class product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double CategoryID { get; set; }
        public int OnSale { get; set; }
        public int StockLevel { get; set; }

    }
}
