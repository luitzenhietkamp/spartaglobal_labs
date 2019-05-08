using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labx_01_databases
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public static class NorthwindQueries
    {
        public static List<CustomObject> OrderSummary()
        {
            List<CustomObject> result;
            var entryList = new List<CustomObject>();

            using (var db = new NorthwindEntities())
            {
                result = (from cust in db.Customers
                               join ord in db.Orders on cust.CustomerID equals ord.CustomerID
                               select new CustomObject {
                                   CustomerName = cust.ContactName,
                                   OrderDate = ord.OrderDate,
                                   OrderID = ord.OrderID
                               }).ToList();
            }
            return result;
        }
    }

    public class CustomObject
    {
        public string CustomerName { get; set; }
        public DateTime? OrderDate { get; set; }
        public int OrderID { get; set; }
    }
}
