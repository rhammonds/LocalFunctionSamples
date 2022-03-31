
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LocalFunctionSamples
{
    class Program
    {
        public static void Main()
        {
            var orders = GetOrders(true, true, true);
            orders.ForEach(i => Console.WriteLine(JsonConvert.SerializeObject(i, Formatting.None)));

            var ordersUsingLF = GetOrdersUsingLF(true, true, true);
            Console.WriteLine("");
            ordersUsingLF.ForEach(i => Console.WriteLine(JsonConvert.SerializeObject(i, Formatting.None)));

            Console.ReadKey();
        }

        static List<Order> GetOrders(bool includeActive, bool includeHistorical, bool includeOpen)
        {
            List<Order> orders = new();
            IEnumerable<Order> ordersInDatabase = SampleOrders.GetOrders();

            if (includeActive == true) orders.AddRange(ordersInDatabase.Where(s => s.StartDateTime.HasValue && (s.EndDateTime.HasValue == false || s.EndDateTime.Value >= DateTime.Now)));
            if (includeHistorical) orders.AddRange(ordersInDatabase.Where(s => s.StartDateTime.HasValue && s.EndDateTime.HasValue && s.EndDateTime.Value < DateTime.Now));
            if (includeOpen) orders.AddRange(ordersInDatabase.Where(s => s.StartDateTime.HasValue == false && s.EndDateTime.HasValue == false));
            return orders;
        }

        static List<Order> GetOrdersUsingLF(bool includeActive, bool includeHistorical, bool includeOpen)
        {
            List<Order> orders = new();
            IEnumerable<Order> ordersInDatabase = SampleOrders.GetOrders();

            if (includeActive == true) orders.AddRange(ordersInDatabase.Where(s => active(s)));
            if (includeHistorical) orders.AddRange(ordersInDatabase.Where(s => historical(s)));
            if (includeOpen) orders.AddRange(ordersInDatabase.Where(s => open(s)));
            return orders;

            bool active(Order s) => s.StartDateTime.HasValue && (s.EndDateTime.HasValue == false || s.EndDateTime.Value >= DateTime.Now);
            bool historical(Order s) => s.StartDateTime.HasValue && s.EndDateTime.HasValue && s.EndDateTime.Value < DateTime.Now;
            bool open(Order s) => s.StartDateTime.HasValue == false && s.EndDateTime.HasValue == false;
        }
    }

    static class SampleOrders
    {
        public static IQueryable<Order> GetOrders()
        {
            return new List<Order>
            {
                new Order{ OrderNumber = 1, StartDateTime=DateTime.Now.AddDays(-1)},
                new Order{ OrderNumber = 2, StartDateTime=DateTime.Now.AddDays(-1), EndDateTime = DateTime.Now} ,
                new Order{ OrderNumber = 3},
                new Order{ OrderNumber = 4,StartDateTime=DateTime.Now.AddDays(-5)},
                new Order{ OrderNumber = 5},
                new Order{ OrderNumber = 6,StartDateTime=DateTime.Now.AddDays(-9), EndDateTime = DateTime.Now.AddDays(-3)},
            }.AsQueryable();
        }
    }

    class Order
    {
        public int OrderNumber { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
    }

}
