using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using NetCoreAnexsoft.Models.ViewModels;
using NetCoreAnexsoft.Models;
using System.IO;
using Service;

namespace NetCoreAnexsoft.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAlbumService _albumService;

        public HomeController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(AlbumViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", model);
            }

            var path = $"wwwroot\\Uploads\\{model.Photo.FileName}";
            using(var stream = new FileStream(path, FileMode.Create))
            {
                model.Photo.CopyTo(stream);
            }

            var album = new Album
            {
                Name = model.Name,
                Description = model.Description,
                PhotoLink = $"/Uploads/{model.Photo.FileName}"
            };

            _albumService.Create(album);

            return RedirectToAction("Index");
        }
       
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
