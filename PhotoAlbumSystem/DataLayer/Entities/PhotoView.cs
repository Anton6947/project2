using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class PhotoView
    {

        [Key]
        public Guid Photo_Id { get; set; }

        [NotMapped]
        public IFormFile FileName { get; set; }

        public Guid? Album_Id { get; set; }
        public string AlbumName { get; set; }
        public string GeoLocation { get; set; }
        public string Tags { get; set; }
        public DateTime CapturedDate { get; set; }
        public string CapturedByUser { get; set; }

    }
}
