﻿using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicLayer.Implementations
{
    public class DeleteImpl
    {

        private readonly DatabaseContext ourDatabase;
        public DeleteImpl(DatabaseContext db)
        {
            ourDatabase = db;
        }
    
        public void DeletePhoto(Guid Photo_Id, string FileName, Guid Album_Id)
        {

            var photo = new Photo()
            {
                Photo_Id = Guid.NewGuid(),
                FileName = FileName,
                Album_Id = Album_Id
            };

            ourDatabase.Remove(ourDatabase.Photos.FirstOrDefault(x=> x.Photo_Id == photo.Photo_Id));
            ourDatabase.SaveChanges();
        }

    
     



    }
}

