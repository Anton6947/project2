using DataLayer.Entities;
using LogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhotoAlbumSystem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbumSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Add _addServices;
        private readonly Search _searchServices;
        private readonly Update _updateServices;
        private readonly GetAll _getAllServices;
        private readonly Delete _deleteServices;


        public HomeController(ILogger<HomeController> logger , Add addServices , Search searchServices, Update updateServices, GetAll getAllServices, Delete deleteServices)
        {
            _logger = logger;
            _addServices = addServices;
            _searchServices = searchServices;
            _updateServices = updateServices;
            _getAllServices = getAllServices;
            _deleteServices = deleteServices;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        public IActionResult Photo(Photo photo)
        {
            var photos = _getAllServices.GetPhotos();
            return View(photos);
        }
        public IActionResult PhotoCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PhotoCreate(PhotoView photo)
        {

            var photoInput = new Photo()
            {
                Photo_Id = Guid.NewGuid(),
                FileName = photo.FileName.ToString(),
                Album_Id = photo.Album_Id
            };

            if (photo.FileName != null)
            {
                bool response = _addServices.AddPhoto(photoInput.FileName, photoInput.Album_Id);
            }

            return RedirectToAction("Photo");
        }

        public IActionResult Album(Album album)
        {
            var albums = _getAllServices.GetAlbums();
            return View(albums);
        }

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
