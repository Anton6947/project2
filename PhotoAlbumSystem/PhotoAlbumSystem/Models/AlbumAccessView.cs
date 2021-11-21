using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbumSystem.Models
{
    public class AlbumAccessView
    {
        public Guid Album_Id { get; set; }
        public string AlbumName { get; set; }
        public DateTime Date { get; set; }

        public string User_Id { get; set; }
       
    }
}
