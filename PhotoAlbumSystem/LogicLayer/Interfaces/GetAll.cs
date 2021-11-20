﻿using DataLayer.Entities;
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
    }
}