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
        Photo AddPhoto(string FileName, Guid Album_Id);
        Album AddAlbum(Guid Album_Id, string AlbumName);
    }
}
