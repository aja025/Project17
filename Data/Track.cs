using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Project17.Data
{
    public partial class Track
    {
        public Track()
        {
            InvoiceItem = new HashSet<InvoiceItem>();
            PlaylistTrack = new HashSet<PlaylistTrack>();
        }

        public int TrackId { get; set; }
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int GenreId { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int Bytes { get; set; }
        public decimal UnitPrice { get; set; }

        [JsonIgnore]
        public Album Album { get; set; }

        [JsonIgnore]
        public Genre Genre { get; set; }

        [JsonIgnore]
        public MediaType MediaType { get; set; }

        [JsonIgnore]
        public ICollection<InvoiceItem> InvoiceItem { get; set; }

        [JsonIgnore]
        public ICollection<PlaylistTrack> PlaylistTrack { get; set; }
    }
}
