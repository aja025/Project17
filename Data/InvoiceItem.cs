using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Project17.Data
{
    public partial class InvoiceItem
    {
        public int InvoiceLineId { get; set; }
        public int InvoiceId { get; set; }
        public int TrackId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public Invoice Invoice { get; set; }

        [JsonIgnore]
        public Track Track { get; set; }
    }
}
