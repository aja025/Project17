using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Project17.Data
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceItem = new HashSet<InvoiceItem>();
        }

        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostalCode { get; set; }
        public decimal Total { get; set; }

        [JsonIgnore]
        public Customer Customer { get; set; }

        [JsonIgnore]
        public ICollection<InvoiceItem> InvoiceItem { get; set; }
    }
}
