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
    public class AlbumAccess
    {
        [Key]
        public Guid AlbumAccess_Id { get; set; }


        public DateTime Date { get; set; }


        

        [ForeignKey(nameof(IdentityUser))]

        public Guid User_Id { get; set; }

        public IdentityUser IdentityUser { get; set; }


        [ForeignKey(nameof(Album))]

        public Guid Album_Id { get; set; }

        public Album Album { get; set; }

        [ForeignKey(nameof(AccessType))]

        public Guid AccessType_Id { get; set; }

        public AccessType AccessType { get; set; }



    }
}
