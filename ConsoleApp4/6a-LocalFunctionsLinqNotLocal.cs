using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFunctionSamples
{
    class Program
    {
        public static void main()
        {
            var orders = GetOrders(true, true, true);
            Console.ReadKey();
        }

        static List<Order> GetOrders(bool includeActive, bool includeHistorical, bool includeOpen)
        {
            var orders = new List<Order>();
            var ordersInDatabase = new List<Order>();

            if (includeActive == true) orders.AddRange(ordersInDatabase.Where(s => s.StartDateTime.HasValue && (s.EndDateTime.HasValue == false || s.EndDateTime.Value >= DateTime.Now)));
            if (includeHistorical) orders.AddRange(ordersInDatabase.Where(s => s.StartDateTime.HasValue && s.EndDateTime.HasValue && s.EndDateTime.Value < DateTime.Now));
            if (includeOpen) orders.AddRange(ordersInDatabase.Where(s => s.StartDateTime.HasValue == false && s.EndDateTime.HasValue == false));
            return orders;
        }
    }

    class Order
    {
        public int OrderNumber { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
    }
}
