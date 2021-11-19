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

        public HomeController(ILogger<HomeController> logger , Add addServices )
        {
            _logger = logger;
            _addServices = addServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Album(AlbumView album)
        {

            var albumInput = new Album()
            {
                Album_Id = Guid.NewGuid(),
                AlbumName = album.AlbumName
            };
            bool response = _addServices.AddAlbum(albumInput.Album_Id, albumInput.AlbumName);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
