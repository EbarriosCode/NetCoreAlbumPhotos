using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using NetCoreAnexsoft.Models.ViewModels;
using Service;

namespace NetCoreAnexsoft.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly IPhotoService _photoService;

        public PhotoController(IAlbumService albumService, IPhotoService photoService)
        {
            _albumService = albumService;
            _photoService = photoService;
        }

        // GET: Photo
        public ActionResult Index(int id)
        {
            return View(_albumService.Get(id));
        }

        [HttpPost]
        public IActionResult Insert(PhotoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", model);
            }

            var path = $"wwwroot\\Uploads\\{model.Photo.FileName}";
            using (var stream = new FileStream(path, FileMode.Create))
            {
                model.Photo.CopyTo(stream);
            }

            var photo = new Photo
            {
                AlbumId = model.AlbumId,
                PhotoLink = $"/Uploads/{model.Photo.FileName}"
            };

            _photoService.Create(photo);

            return RedirectToAction("Index", new { id = model.AlbumId });
        }
    }
}