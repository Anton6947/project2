using DataLayer;
using DataLayer.Entities;
using LogicLayer.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Implementations
{
    public class PhotoUploadImpl : PhotoUpload
    {

        private readonly DatabaseContext ourDatabase;
        public PhotoUploadImpl(DatabaseContext db)
        {
            ourDatabase = db;
        }


        /*public IEnumerable<Photo> GetAll()
        {
            return ourDatabase.GalleryPhoto;
                *//*.Include(img => img.Tags)*//*
        }*/

        /*public IEnumerable<GalleryPhoto> GetWithTag(string tag)
        {
            return GetAll().Where(img => img.Tags.Any(t => tag.Description == tag));
        }*/



        /*public GalleryPhoto GetById(int id)
        {
            return GetAll.Where(img => img.Id == id)
                .First();
        }*/


        public CloudBlobContainer GetBlobContainer(string azureConectionString, string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(azureConectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            return blobClient.GetContainerReference(containerName);
        }


        public async Task SetPhoto(string FileName, Guid? Album_Id)
        {
            var photo = new Photo
            {
                Photo_Id = Guid.NewGuid(),
                FileName = FileName,
                Album_Id = Album_Id

            };
            ourDatabase.Add(photo);
            await ourDatabase.SaveChangesAsync();
        }

        /*public List<PhotoTag> ParseTags(string tags)
        {
            return tags.Split(",").Select(tag => new PhotoTag
            {
                Descriptio = tag
            }).ToList();

        }*/


    }
}
