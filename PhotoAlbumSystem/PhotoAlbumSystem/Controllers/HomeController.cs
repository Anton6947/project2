﻿using DataLayer.Entities;
using LogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PhotoAlbumSystem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PhotoAlbumSystem.Controllers
{
    public class HomeController : Controller
    {

        private IConfiguration _config;
        private string AzureConectionString { get; }
        private PhotoUpload _photoUploadServices;


        private readonly ILogger<HomeController> _logger;
        private readonly Add _addServices;
        private readonly Search _searchServices;
        private readonly Update _updateServices;
        private readonly GetAll _getAllServices;
        private readonly Delete _deleteServices;       


        public HomeController(ILogger<HomeController> logger , Add addServices , Search searchServices, Update updateServices, 
            GetAll getAllServices, Delete deleteServices, IConfiguration config , PhotoUpload photoUploadServices)
        {

            _config = config;
            AzureConectionString = _config["AzureStorageConectionString"];


            _logger = logger;
            _addServices = addServices;
            _searchServices = searchServices;
            _updateServices = updateServices;
            _getAllServices = getAllServices;
            _deleteServices = deleteServices;
            _photoUploadServices = photoUploadServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //    Photo Get All

        public IActionResult Photo(Photo photo)
        {
            var photos = _getAllServices.GetPhotos();
            return View(photos);
        }
        public IActionResult MetaDataView(Guid id)
        {            
            var metaDataInput = _getAllServices.GetMetaDataSpecific(id);
            return View(metaDataInput);
        }
        public IActionResult UpdateMetaData(Guid id)
        {            
            var metaData = _getAllServices.GetMetaDataSpecific(id);
            return View(metaData);
        }
        [HttpPost]
        public IActionResult UpdateMetaData(MetaData metaData)
        {
            _updateServices.UpdateMetaData(metaData.Photo_Id, metaData.GeoLocation, metaData.Tags, metaData.CapturedDate, metaData.CapturedByUser);
            return View("MetaDataView",metaData);
        }

        //    Photo Create

        public IActionResult PhotoCreate()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PhotoUpload(IFormFile file , Guid? Album_Id,MetaData metaData)
        {

            
            var container = _photoUploadServices.GetBlobContainer(AzureConectionString, "images");
            var content = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
            var fileName = content.FileName.Trim('"');

            var blockBlob = container.GetBlockBlobReference(fileName);

            await blockBlob.UploadFromStreamAsync(file.OpenReadStream());
            var photo = new Photo()
            {
                Photo_Id = Guid.NewGuid(),
                FileName = fileName,
                Album_Id = Album_Id
            };
            await _addServices.AddPhoto(photo.Photo_Id, fileName, Album_Id);

            _addServices.AddMetaData(photo.Photo_Id, metaData.GeoLocation, metaData.Tags, metaData.CapturedDate, metaData.CapturedByUser);

            return RedirectToAction("Photo");
        }
       
        //  Grant Photo Access
        public IActionResult GivePhotoAccess()
        {
            return View();
        }
        //  Photo Delete

        public IActionResult PhotoDelete(Photo photo)
        {
            var photoInput = new Photo()
            {
                Photo_Id = photo.Photo_Id,
                FileName = photo.FileName,
                Album_Id = photo.Album_Id
            };
            if (photo.FileName != null)
            {                              
                _deleteServices.DeletePhoto(photoInput.Photo_Id, photoInput.FileName, photoInput.Album_Id);
                _deleteServices.DeleteMetaData(photoInput.Photo_Id);
            }
            return View();
        }       

        //       Album Get All

        public IActionResult Album(Album album)
        {
            var albums = _getAllServices.GetAlbums();
            return View(albums);
        }

        //      Album Delete
        public IActionResult AlbumDelete(AlbumView album)
        {

            var albumInput = new Album()
            {
                Album_Id = Guid.NewGuid(),
                AlbumName = album.AlbumName
            };
            if (album.AlbumName != null)
            {
                _deleteServices.DeleteAlbum(albumInput.Album_Id, albumInput.AlbumName);
            }
            return View();
        }
        //  Grant Album Access
        public IActionResult GiveAlbumAccess()
        {
            return View();
        }

        //   Album Update

        public IActionResult AlbumUpdate(Guid id)
        {

            var albumInput = _getAllServices.GetAlbums().Where(x => x.Album_Id == id).FirstOrDefault();


            return View(albumInput);
        }
        [HttpPost]
        public IActionResult AlbumUpdate(Album albumInput)
        {
            if (albumInput.AlbumName != null)
            {
                bool response = _updateServices.UpdateAlbum(albumInput.Album_Id, albumInput.AlbumName);
            }


            return RedirectToAction("Album");
        }

        //   Album Create

        public IActionResult AlbumCreate(AlbumView album)
        {

            var albumInput = new Album()
            {
                Album_Id = Guid.NewGuid(),
                AlbumName = album.AlbumName
            };

            if (album.AlbumName != null )
            {
                bool response = _addServices.AddAlbum(albumInput.Album_Id, albumInput.AlbumName);
            }

            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
