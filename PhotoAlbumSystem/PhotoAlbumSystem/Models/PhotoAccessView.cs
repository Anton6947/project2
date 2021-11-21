using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbumSystem.Models
{
    public class PhotoAccessView
    {
        public Guid Photo_Id { get; set; }

        public string FileName { get; set; }

        public DateTime Date { get; set; }

        public string User_Id { get; set; }




    }  
}
