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
        public Guid PhotoIdToAdd;
        public AddImpl(DatabaseContext db)
        {
            ourDatabase = db;
        }
        public void AddMetaData(Guid Photo_Id, string GeoLocation, string Tags, DateTime CapturedDate, string CapturedByUser)
        {
            var metaData = new MetaData()
            {
                Photo_Id = Photo_Id,
                GeoLocation = GeoLocation,
                Tags = Tags,
                CapturedDate = CapturedDate,
                CapturedByUser = CapturedByUser
            };
            ourDatabase.Add(metaData);
            ourDatabase.SaveChanges();
        }
        public async Task AddPhoto(Guid Photo_Id,string FileName, Guid? Album_Id)
        {
            var photo = new Photo()
            {
                Photo_Id = Photo_Id,
                FileName = FileName,
                Album_Id = Album_Id
            };
            PhotoIdToAdd = photo.Photo_Id;
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
        public void AddPhotoAccess(Guid id,string userId)
        {
            var photoAccess = new PhotoAccess()
            {
                PhotoAccess_Id = Guid.NewGuid(),
                Date = DateTime.Now,
                User_Id = userId,
                Photo_Id =id,               
            };
            ourDatabase.Add(photoAccess);
            ourDatabase.SaveChanges();
        }

        public void AddAlbumAccess(Guid AlbumAccess_Id, DateTime Date, string User_Id, Guid Album_Id, Guid AccessType_Id)
        {
            var albumAccess = new AlbumAccess()
            {
                AlbumAccess_Id = Guid.NewGuid(),
                Date = Date,
                User_Id = User_Id,
                Album_Id = Album_Id,
            };
            ourDatabase.Add(albumAccess);
            ourDatabase.SaveChanges();

        }
    }
}
