using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Photo
    {
        [Key]
        public Guid Photo_Id { get; set; }
        
        public string FileName { get; set; }
        
        [ForeignKey(nameof(Album))]
        public Guid? Album_Id { get; set; }
        public Album Album { get; set; }

    }
}
