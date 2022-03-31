using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace LocalFunctionSamples
{
    class Program
    {
        public static void Main()
        {
            var orders = GetOrdersByType( OrderType.Active);
            var getOrdersUsingLF = GetOrdersUsingLF(OrderType.Active);
            Console.ReadKey();
        }

        static List<Order> GetOrdersByType(OrderType orderType)
        {
            IQueryable<Order> ordersInDatabase = SampleOrders.GetOrders();
            var result = ordersInDatabase;

            switch (orderType)
            {
                case OrderType.Active:
                    result = ordersInDatabase.Where(s => s.StartDateTime.HasValue && (s.EndDateTime.HasValue == false || s.EndDateTime.Value >= DateTime.Now));
                    break;
                case OrderType.Historic:
                    result = ordersInDatabase.Where(s => s.StartDateTime.HasValue && s.EndDateTime.HasValue && s.EndDateTime.Value < DateTime.Now);
                    break;
                case OrderType.Open:
                    result = ordersInDatabase.Where(s => s.StartDateTime.HasValue == false && s.EndDateTime.HasValue == false);
                    break;
            }

            return result.ToList();
        }

        //References to local functions are now disallowed in expression trees, which may or may not change in the future(Previously 
        //they were generated as a reference to a mangled method name, which seemed wrong). Added a new error for this.
        //https://github.com/dotnet/roslyn/pull/3849
        static List<Order> GetOrdersUsingLF(OrderType orderType)
        {
            IEnumerable<Order> ordersInDatabase = SampleOrders.GetOrders(); ; //queries on the server
            //IQueryable<Order> ordersInDatabase = SampleOrders.GetOrders();; //queries on the database
            var result = ordersInDatabase;

            switch (orderType)
            {
                case OrderType.Active:
                    result = result.Where(s => active(s));
                    break;
                case OrderType.Historic:
                    result = result.Where(s => historical(s));
                    break;
                case OrderType.Open:
                    result.Where(s => open(s));
                    break; 
            }
            return result.ToList();

            bool active(Order s) => s.StartDateTime.HasValue && (s.EndDateTime.HasValue == false || s.EndDateTime.Value >= DateTime.Now);
            bool historical(Order s) => s.StartDateTime.HasValue && s.EndDateTime.HasValue && s.EndDateTime.Value < DateTime.Now;
            bool open(Order s) => s.StartDateTime.HasValue == false && s.EndDateTime.HasValue == false;
        }

        enum OrderType
        {
            Active,
            Historic,
            Open
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