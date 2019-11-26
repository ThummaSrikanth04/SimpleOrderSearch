using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleOrderSearchConsole.SimpleSearchOrder;

namespace SimpleOrderSearchConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// Making Service Call...
            /// </summary>
            
            SearchOrderServiceSoapClient service = new SearchOrderServiceSoapClient();
            SearchCriteria criteria = new SearchCriteria();

            /// <summary>
            /// User Giving Inputs as per requirement ((OrderId || (MSA && Status)) && CompletionDte)...
            /// </summary>

            Console.Write("Please provide OrderId (If known otherwise enter): ");
            if(int.TryParse(Console.ReadLine(),out int orderId)) 
            {
                criteria.OrderId = orderId; 
            }

            Console.Write("Please provide MSA(If known otherwise enter): ");
            if (int.TryParse(Console.ReadLine(), out int msa)) 
            {
                criteria.MSA = msa; 
            }

            Console.Write("Please provide Status(If known otherwise enter):");
            if (int.TryParse(Console.ReadLine(), out int status)) 
            {
                criteria.Status = status; 
            }

            Console.Write("Please provide Completion Date(YYYY-MM-DD):");
            if (DateTime.TryParse(Console.ReadLine().ToString(), out DateTime dt))
            {
                criteria.CompletionDte = dt;
            }

            // Calling service method for getting the Orders Data...
            var data = service.SearchOrder(criteria);
            if (data?.Any() ?? false)
            {
                Console.WriteLine("Orders for Criteria: ");
                Console.WriteLine();
                foreach (var item in data)
                {
                    Console.WriteLine("OrderId: " +item.OrderId);
                    Console.WriteLine("ShipperId: " +item.ShipperId);
                    Console.WriteLine("DriverId: " +item.DriverId);
                    Console.WriteLine("CompletionDte: " +item.CompletionDte);
                    Console.WriteLine("Status: " +item.Status);
                    Console.WriteLine("Code: " +item.Code);
                    Console.WriteLine("MSA: " +item.MSA);
                    Console.WriteLine("Duration: " +item.Duration);
                    Console.WriteLine("OfferType: " +item.OfferType);
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("There is no Data for the Criteria entered. ");
            }
            Console.ReadKey();
        }
    }
}
