using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class MetaData
    {
        [Key]
        [ForeignKey(nameof(Photo))]
        public Guid Photo_Id { get; set; }
        
        public Photo Photo { get; set; }

        public string GeoLocation { get; set; }
        public string Tags { get; set; }
        public DateTime CapturedDate { get; set; }
        public string CapturedBy { get; set; }

    }
}
