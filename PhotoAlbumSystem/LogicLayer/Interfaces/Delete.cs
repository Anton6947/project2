using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface Delete
    {
        Photo DeletePhoto(Guid Photo_Id, string FileName, Guid Album_Id);

        Album DeleteAlbum(Guid Album_Id, string AlbumName);

    }
}
