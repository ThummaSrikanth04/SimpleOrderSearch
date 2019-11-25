using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SearchOrderWebService.Model
{
    [DataContract]
    public class OrderInfo
    {
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public int ShipperId { get; set; }
        [DataMember]
        public int DriverId { get; set; }
        [DataMember]
        public DateTime? CompletionDte { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int MSA { get; set; }
        [DataMember]
        public float Duration { get; set; }
        [DataMember]
        public int OfferType { get; set; }
    }
}