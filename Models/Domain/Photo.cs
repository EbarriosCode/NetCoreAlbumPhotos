using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Domain
{
    public class Photo
    {
        [Key]
        public int IdPhoto { get; set; }
        public string PhotoLink { get; set; }
        public DateTime CreatedAt { get; set; }

        public Album Album { get; set; }
        public int AlbumId { get; set; }
        
    }
}
