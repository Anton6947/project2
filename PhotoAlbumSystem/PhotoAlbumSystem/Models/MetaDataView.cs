using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbumSystem.Models
{
    public class MetaDataView
    {
        

        public string GeoLocation { get; set; }
        public string Tags { get; set; }
        public DateTime CapturedDate { get; set; }
        public string CapturedByUser_Id { get; set; }

       
    }
}
