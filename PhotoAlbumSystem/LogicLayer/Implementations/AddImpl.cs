using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Implementations
{
    public class AddImpl
    {
        private readonly DatabaseContext ourDatabase;
        public AddImpl(DatabaseContext db) 
        {
            ourDatabase = db;
        }
        public Photo AddPhoto(string FileName, Guid Album_Id)
        {
            var photo = new Photo()
            {
                Photo_Id = Guid.NewGuid(),
                FileName = FileName,
                Album_Id = Album_Id
            };
            ourDatabase.Add(photo);
            ourDatabase.SaveChanges();
            return photo;
        }
    }
}
