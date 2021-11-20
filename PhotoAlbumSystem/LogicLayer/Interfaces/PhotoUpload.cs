using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface PhotoUpload
    {
        /*IEnumerable<GalleryPhoto> GetAll();
        GalleryPhoto GetById(int id);*/

        CloudBlobContainer GetBlobContainer(string azureConectionString, string containerName);

        
        Task SetPhoto(string FileName, Guid? Album_Id);

        /*List<PhotoTag> ParseTags(string tags);*/
    }
}
