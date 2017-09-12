using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Project17.Data
{
    public partial class Artist
    {
        public Artist()
        {
            Album = new HashSet<Album>();
        }

        public int ArtistId { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Album> Album { get; set; }
    }
}
