using DataLayer;
using DataLayer.Entities;
using LogicLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Implementations
{
    public class GetAllImpl : GetAll
    {
        private readonly DatabaseContext ourDataBase;

        public GetAllImpl(DatabaseContext db)
        {
            ourDataBase = db;
        }
        public IEnumerable<Album> GetAlbums()
        {
            var album = from o in ourDataBase.Albums select o;
            return album.ToList();
        }

        public IEnumerable<Photo> GetPhotos()
        {
            var photo = from o in ourDataBase.Photos select o;
            return photo.ToList();
        }

        public IEnumerable<MetaData> GetMetaData()
        {
            var metaData = from o in ourDataBase.MetaDatas select o;
            return metaData.ToList();
        }
        public IEnumerable<PhotoAccess> GetPhotoAccessors()
        {
            var photoAccesses = from o in ourDataBase.PhotoAccessors select o;
            return photoAccesses.ToList();
        }
        public IEnumerable<AlbumAccess> GetAlbumAccessors()
        {
            var albumAccesses = from o in ourDataBase.AlbumAccessors select o;
            return albumAccesses.ToList();
        }
        public MetaData GetMetaDataSpecific(Guid Photo_Id)
        {
            var metDataRetrieved = ourDataBase.MetaDatas.AsNoTracking().FirstOrDefault(x => x.Photo_Id == Photo_Id);

            return metDataRetrieved;
        }
        public PhotoAccess GetPhotoAccessSpecific(Guid Photo_Id)
        {
            var photoAccess = ourDataBase.PhotoAccessors.AsNoTracking().FirstOrDefault(x => x.Photo_Id == Photo_Id);

            return photoAccess;
        }
        public string GetUser(string Username)
        {
            var User = ourDataBase.Users.AsNoTracking().FirstOrDefault(x => x.UserName == Username);
            return User.Id;
        }
        public Guid? GetAlbumId(string albumName)
        {
            var album = ourDataBase.Albums.AsNoTracking().FirstOrDefault(x => x.AlbumName == albumName);
            return album.Album_Id;
        }
        public Guid GetPhotoId(string fileName)
        {
            var photo = ourDataBase.Photos.AsNoTracking().FirstOrDefault(x => x.FileName == fileName);
            return photo.Photo_Id;
        }
    }
}

