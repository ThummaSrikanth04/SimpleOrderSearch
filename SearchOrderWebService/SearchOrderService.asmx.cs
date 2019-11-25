using Newtonsoft.Json;
using SearchOrderWebService.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SearchOrderWebService
{
    /// <summary>
    /// Summary description for SearchOrderService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SearchOrderService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";            
        }
        [WebMethod]
        public void TestSearchOrder()
        {
            var data = SearchOrder(new SearchCriteria {OrderId=39,CompletionDte=DateTime.Parse("2018-01-31T05:10:00") }, 0, 10);
        }
        [WebMethod]
        public List<OrderInfo> SearchOrder(SearchCriteria criteria, int page, int pageSize)
        {
            List<OrderInfo> returnData = new List<OrderInfo>();
            if (criteria?.IsValid() ?? false)
            {
                var data = GetJsondata();
                if (data?.Any() ?? false)
                {
                    returnData = data
                        .Where(x => (x.OrderId == criteria.OrderId || (x.MSA == criteria.MSA && x.Status == criteria.Status)) && x.CompletionDte.Value.Date == criteria.CompletionDte.Value.Date)?
                        .Skip(page * pageSize).Take(pageSize).ToList();

                }
            }
            return returnData;
        }

        private List<OrderInfo> GetJsondata()
        {
            using (StreamReader r = new StreamReader(Server.MapPath("~/Data/OrderInfo.json")))
            {
                string json = r.ReadToEnd();
                List<OrderInfo> ro = JsonConvert.DeserializeObject<List<OrderInfo>>(json);
                return ro;
            }
        }

    }
}
