using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class PhotoAccess
    {
        [Key]
        public Guid PhotoAccess_Id { get; set; }

        public DateTime Date { get; set; }

        //EntityID Framework for userid

        [ForeignKey(nameof(Photo))]
        public Guid Photo_Id { get; set; }

        public Photo Photo { get; set; }

        [ForeignKey(nameof(AccessType))]
        public Guid AccessType_Id { get; set; }

        public AccessType AccessType { get; set; }
    }
}
