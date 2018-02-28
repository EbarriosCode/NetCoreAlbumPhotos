using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAnexsoft.Views.Shared.Components.AlbumGallery
{
    public class AlbumGallery : ViewComponent
    {
        private readonly IAlbumService _albumService;

        public AlbumGallery(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_albumService.GetAll());
        }
    }
}
