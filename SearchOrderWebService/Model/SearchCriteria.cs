using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SearchOrderWebService.Model
{
    [DataContract]
    public class SearchCriteria
    {
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public int MSA { get; set; }
        [DataMember]
        public DateTime? CompletionDte { get; set; }
        [DataMember]
        public int Status { get; set; }

        public bool IsValid()
        {
            bool bValid = false;
            if (CompletionDte.HasValue)
            {
                if (OrderId > 0)
                {
                    bValid = true;
                }
                else if (MSA > 0 && Status > 0)
                {
                    bValid = true;
                }
            }
           
           
            return bValid;
        }
    }
}