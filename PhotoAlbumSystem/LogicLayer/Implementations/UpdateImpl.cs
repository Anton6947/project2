using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Implementations
{
    public class UpdateImpl
    {
        private readonly DatabaseContext ourDatabase;

        public UpdateImpl(DatabaseContext db)
        {
            ourDatabase = db;
        }

        public Photo UpdatePhoto(Guid Photo_Id,string FileName, Guid Album_Id)
        {
            var photo = new Photo()
            {
                Photo_Id = Photo_Id,
                FileName = FileName,
                Album_Id = Album_Id
            };
            ourDatabase.Update(photo);
            ourDatabase.SaveChanges();
            return photo;
        }
        public Album UpdateAlbum(Guid Album_Id, string AlbumName)
        {
            var album = new Album()
            {          
                Album_Id = Album_Id,
                AlbumName = AlbumName
            };
            ourDatabase.Update(album);
            ourDatabase.SaveChanges();
            return album;
        }
    }
}
