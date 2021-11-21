using DataLayer;
using DataLayer.Entities;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicLayer.Implementations
{
    public class DeleteImpl : Delete
    {

        private readonly DatabaseContext ourDatabase;
        public DeleteImpl(DatabaseContext db)
        {
            ourDatabase = db;
        }

        public void DeleteMetaData(Guid Photo_Id)
        {            
            ourDatabase.Remove(ourDatabase.MetaDatas.FirstOrDefault(x => x.Photo_Id == Photo_Id));
            ourDatabase.SaveChanges();
        }


        public void DeletePhoto(Guid Photo_Id, string FileName, Guid? Album_Id, string url)
        {

            var photo = new Photo()
            {
                Photo_Id = Photo_Id,
                FileName = FileName,
                Album_Id = Album_Id,
                Url = url
            };

            ourDatabase.Remove(ourDatabase.Photos.FirstOrDefault(x=> x.FileName == photo.FileName));
            ourDatabase.SaveChanges();
        }

        public void DeleteAlbum(Guid Album_Id, string AlbumName)
        {

            var album = new Album()
            {
                Album_Id = Album_Id,
                AlbumName = AlbumName,
                
            };

            ourDatabase.Remove(ourDatabase.Albums.FirstOrDefault(x => x.AlbumName == album.AlbumName));
            ourDatabase.SaveChanges();
        }

        public void DeletePhotoAccess(Guid PhotoAccess_Id, DateTime Date, string User_Id, Guid Photo_Id, Guid AccessType_Id)
        {

            var photoAccess = new PhotoAccess()
            {
                PhotoAccess_Id = PhotoAccess_Id,
                Date = Date,
                User_Id = User_Id,
                Photo_Id = Photo_Id


            };

            ourDatabase.Remove(ourDatabase.PhotoAccessors.FirstOrDefault(x => x.User_Id == photoAccess.User_Id));
            ourDatabase.SaveChanges();
        }

        public void DeleteAlbumAccess(Guid AlbumAccess_Id,DateTime Date,string User_Id, Guid Album_Id, Guid AccessType_Id)
        {

            var albumAccess = new AlbumAccess()
            {
                AlbumAccess_Id = AlbumAccess_Id,
                Date = Date,
                User_Id = User_Id,
                Album_Id = Album_Id
            };

            ourDatabase.Remove(ourDatabase.AlbumAccessors.FirstOrDefault(x => x.User_Id == albumAccess.User_Id));
            ourDatabase.SaveChanges();
        }



    }
}

