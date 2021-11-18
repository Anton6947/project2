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
    public class UpdateImpl : Update
    {
        private readonly DatabaseContext ourDatabase;

        public UpdateImpl(DatabaseContext db)
        {
            ourDatabase = db;
        }
        public MetaData UpdateMetaData(Guid Photo_Id, string GeoLocation, string Tags, DateTime CapturedDate, string CapturedByUser_Id)
        {
            var metaData = new MetaData()
            {
                Photo_Id = Guid.NewGuid(),
                GeoLocation = GeoLocation,
                Tags = Tags,
                CapturedDate = CapturedDate,
                CapturedByUser_Id = CapturedByUser_Id
            };
            ourDatabase.Update(metaData);
            ourDatabase.SaveChanges();
            return metaData;
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

        public PhotoAccess UpdatePhotoAccess(Guid PhotoAccess_Id, DateTime Date, string User_Id, Guid Photo_Id, Guid AccessType_Id)
        {
            var photoAccess = new PhotoAccess()
            {
                PhotoAccess_Id = Guid.NewGuid(),
                Date = Date,
                User_Id = User_Id,
                Photo_Id = Photo_Id,
                AccessType_Id = AccessType_Id
            };
            ourDatabase.Update(photoAccess);
            ourDatabase.SaveChanges();
            return photoAccess;
        }
        public AlbumAccess UpdateAlbumAccess(Guid AlbumAccess_Id, DateTime Date, string User_Id, Guid Album_Id, Guid AccessType_Id)
        {
            var albumAccess = new AlbumAccess()
            {
                AlbumAccess_Id = Guid.NewGuid(),
                Date = Date,
                User_Id = User_Id,
                Album_Id = Album_Id,
                AccessType_Id = AccessType_Id
            };
            ourDatabase.Update(albumAccess);
            ourDatabase.SaveChanges();
            return albumAccess;
        }

    }
}
