using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Album 
    {
        [Key]
        public Guid Album_Id { get; set; }

        public string AlbumName { get; set; }


    }
}
