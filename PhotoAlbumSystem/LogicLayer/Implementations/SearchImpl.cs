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
    public class SearchImpl : Search
    {
        private readonly DatabaseContext ourDataBase;

        public SearchImpl(DatabaseContext db)
        {
            ourDataBase = db;
        }

        public void SearchMetaData(Guid Photo_Id, string GeoLocation, string Tags, DateTime CapturedDate, string CapturedByUser_Id)
        {

            var metaData = new MetaData()
            {
                Photo_Id = Photo_Id,
                GeoLocation = GeoLocation,
                CapturedDate = CapturedDate,
                CapturedByUser_Id = CapturedByUser_Id
            };

            var list = ourDataBase.MetaDatas.AsNoTracking().ToList();
            var entity = ourDataBase.MetaDatas.AsNoTracking().FirstOrDefault(x => x.CapturedByUser_Id == metaData.CapturedByUser_Id);
            
            

            
        }

        public void SearchPhoto(Guid Photo_Id, string FileName, Guid Album_Id)
        {
            var photo = new Photo()
            {
                Photo_Id = Photo_Id,
                FileName = FileName,
                Album_Id = Album_Id
            };

            var list = ourDataBase.Photos.AsNoTracking().ToList();
            var entity = ourDataBase.Photos.AsNoTracking().FirstOrDefault(x => x.FileName == photo.FileName);

        }

        public void SearchAlbum(Guid Album_Id, string AlbumName)
        {
            var album = new Album()
            {
                Album_Id = Album_Id,
                AlbumName = AlbumName,
               
            };

            var list = ourDataBase.Albums.AsNoTracking().ToList();
            var entity = ourDataBase.Albums.AsNoTracking().FirstOrDefault(x => x.AlbumName == album.AlbumName);

        }

    }
}
