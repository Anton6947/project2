﻿using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface Delete
    {        
        void DeleteMetaData(Guid Photo_Id, string GeoLocation, string Tags, DateTime CapturedDate, string CapturedByUser_Id);

        void DeletePhoto(Guid Photo_Id, string FileName, Guid Album_Id);

        void DeleteAlbum(Guid Album_Id, string AlbumName);

        void DeleteAlbumAccess(Guid AlbumAccess_Id, DateTime Date, string User_Id, Guid Album_Id, Guid AccessType_Id);

        void DeletePhotoAccess(Guid PhotoAccess_Id, DateTime Date, string User_Id, Guid Photo_Id, Guid AccessType_Id);

    }
}
