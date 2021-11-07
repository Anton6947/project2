using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface Search
    {
        Photo SearchPhoto(Guid Photo_Id, string FileName, Guid Album_Id);

        Album SearchAlbum(Guid Album_Id, string AlbumName);

        MetaData SearchMetaData(Guid Photo_Id, string GeoLocation, string Tags, DateTime CapturedDate, string CapturedByUser_Id);
    }
}
