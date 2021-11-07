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
        public Album AddAlbum(Guid Album_Id,string AlbumName )
        {
            var album = new Album()
            {
                Album_Id = Guid.NewGuid(),
                AlbumName = AlbumName
            };
            ourDatabase.Add(album);
            ourDatabase.SaveChanges();
            return album;  //test comment
        }
        public PhotoAccess AddPhotoAccess(Guid PhotoAccess_Id, DateTime Date, string User_Id, Guid Photo_Id, Guid AccessType_Id)
        {
            var photoaccess = new PhotoAccess()
            {
                PhotoAccess_Id = Guid.NewGuid(),
                Date = Date,
                User_Id = User_Id,
                Photo_Id = Photo_Id,
                AccessType_Id = AccessType_Id
            };
            ourDatabase.Add(photoaccess);
            ourDatabase.SaveChanges();
            return photoaccess;
        }
    }
}
