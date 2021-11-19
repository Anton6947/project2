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


        public HomeController(ILogger<HomeController> logger , Add addServices , Search searchServices)
        {
            _logger = logger;
            _addServices = addServices;
            _searchServices = searchServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Album(Album album)
        {
            var albums =_searchServices.GetAlbums();
            return View(albums);
        }
        public IActionResult AlbumCreate(AlbumView album)
        {

            var albumInput = new Album()
            {
                Album_Id = Guid.NewGuid(),
                AlbumName = album.AlbumName
            };
            if (album.AlbumName != null)
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
