using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Project17.Data
{
    public partial class MediaType
    {
        public MediaType()
        {
            Track = new HashSet<Track>();
        }

        public int MediaTypeId { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Track> Track { get; set; }
    }
}
