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
    public class AddImpl : Add
    {
        private readonly DatabaseContext ourDatabase;
        public AddImpl(DatabaseContext db)
        {
            ourDatabase = db;
        }
        public MetaData AddMetaData(Guid Photo_Id, string GeoLocation, string Tags, DateTime CapturedDate, string CapturedByUser_Id)
        {
            var metaData = new MetaData()
            {
                Photo_Id = Guid.NewGuid(),
                GeoLocation = GeoLocation,
                Tags = Tags,
                CapturedDate = CapturedDate,
                CapturedByUser_Id = CapturedByUser_Id
            };
            ourDatabase.Add(metaData);
            ourDatabase.SaveChanges();
            return metaData;
        }
        public async Task AddPhoto(string FileName, Guid? Album_Id)
        {
            var photo = new Photo()
            {
                Photo_Id = Guid.NewGuid(),
                FileName = FileName,
                Album_Id = Album_Id
            };
            ourDatabase.Add(photo);
            await ourDatabase.SaveChangesAsync();
            
        }
        public bool AddAlbum(Guid Album_Id, string AlbumName)
        {
            var album = new Album()
            {
                Album_Id = Guid.NewGuid(),
                AlbumName = AlbumName
            };
            ourDatabase.Add(album);
            ourDatabase.SaveChanges();
            return true;
        }
        public PhotoAccess AddPhotoAccess(Guid PhotoAccess_Id, DateTime Date, string User_Id, Guid Photo_Id, Guid AccessType_Id)
        {
            var photoAccess = new PhotoAccess()
            {
                PhotoAccess_Id = Guid.NewGuid(),
                Date = Date,
                User_Id = User_Id,
                Photo_Id = Photo_Id,
                AccessType_Id = AccessType_Id
            };
            ourDatabase.Add(photoAccess);
            ourDatabase.SaveChanges();
            return photoAccess;
        }

        public AlbumAccess AddAlbumAccess(Guid AlbumAccess_Id, DateTime Date, string User_Id, Guid Album_Id, Guid AccessType_Id)
        {
            var albumAccess = new AlbumAccess()
            {
                AlbumAccess_Id = Guid.NewGuid(),
                Date = Date,
                User_Id = User_Id,
                Album_Id = Album_Id,
                AccessType_Id = AccessType_Id
            };
            ourDatabase.Add(albumAccess);
            ourDatabase.SaveChanges();
            return albumAccess;

        }
    }
}
