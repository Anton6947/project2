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
    }
}
