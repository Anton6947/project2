using Microsoft.AspNetCore.Identity;
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

        [ForeignKey(nameof(IdentityUser))]
        public string User_Id { get; set; }

        public IdentityUser IdentityUser { get; set; }

        [ForeignKey(nameof(Photo))]
        public Guid Photo_Id { get; set; }

        public Photo Photo { get; set; }

    }
}
