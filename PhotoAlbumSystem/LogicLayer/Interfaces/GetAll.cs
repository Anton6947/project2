using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface GetAll
    {
        IEnumerable<Album> GetAlbums();

        IEnumerable<Photo> GetPhotos();

        IEnumerable<MetaData> GetMetaData();

        MetaData GetMetaDataSpecific(Guid Photo_Id);

        string GetUser(string Username);
        Guid? GetAlbumId(string albumName);
    }
}
