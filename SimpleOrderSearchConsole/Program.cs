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
            SearchOrderServiceSoapClient service = new SearchOrderServiceSoapClient();
            SearchCriteria criteria = new SearchCriteria();
            Console.Write("Please provide OrderId(If known otherwise enter):");
            if(int.TryParse(Console.ReadLine(),out int orderId)) { criteria.OrderId = orderId; }
            Console.Write("Please provide MSA(If known otherwise enter):");
            if (int.TryParse(Console.ReadLine(), out int msa)) { criteria.MSA = msa; }
            Console.Write("Please provide Status(If known otherwise enter):");
            if (int.TryParse(Console.ReadLine(), out int status)) { criteria.Status = status; }

            Console.Write("Please provide Completion Date(YYYY-MM-DD):");
            if (DateTime.TryParse(Console.ReadLine().ToString(), out DateTime dt))
            {
                criteria.CompletionDte = dt;
            }
            int page = 0;
            int pageSize = 25;
            
            if (IsValidCriteria(criteria))
            {
                var data = service.SearchOrder(criteria, page, pageSize);
                if (data?.Any() ?? false)
                {
                    Console.WriteLine("Your Orders: ");
                    data.ToList().ForEach(x =>
                    {
                        Console.WriteLine("OrderID: {0},ShipperID: {1},DriverID: {2},CompletionDte: {3},Status: {4},Code: {5},MSA: {6},Duration: {7},OfferType: {8}",
                            x.OrderId,x.ShipperId,x.DriverId,x.CompletionDte,x.Status,x.Code,x.MSA,x.Duration,x.OfferType);
                    });
                }
                else
                {
                    Console.WriteLine("No data ");
                }
            }
            else
            {
                Console.WriteLine("Please provide valid criteria");
            }
            Console.ReadKey();
        }

        private static bool IsValidCriteria(SearchCriteria model)
        {
            bool bValid = false;
            if (model.CompletionDte.HasValue)
            {
                if (model.OrderId > 0)
                {
                    bValid = true;
                }
                else if (model.MSA > 0 && model.Status > 0)
                {
                    bValid = true;
                }
            }
            return bValid;
        }
    }
}
