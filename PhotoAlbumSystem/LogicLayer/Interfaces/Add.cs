using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface Add
    {
        void AddMetaData(Guid Photo_Id, string GeoLocation, string Tags, DateTime CapturedDate, string CapturedByUser);
        Task AddPhoto(Guid Photo_Id, string FileName, Guid? Album_Id);
        bool AddAlbum(Guid Album_Id, string AlbumName);
        PhotoAccess AddPhotoAccess(Guid PhotoAccess_Id, DateTime Date, string User_Id, Guid Photo_Id, Guid AccessType_Id);
        AlbumAccess AddAlbumAccess(Guid AlbumAccess_Id, DateTime Date, string User_Id, Guid Album_Id, Guid AccessType_Id);
    }
}
