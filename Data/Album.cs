using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Project17.Data
{
    public partial class Album
    {
        public Album()
        {
            Track = new HashSet<Track>();
        }

        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }

        [JsonIgnore]
        public Artist Artist { get; set; }

        [JsonIgnore]
        public ICollection<Track> Track { get; set; }
    }
}
