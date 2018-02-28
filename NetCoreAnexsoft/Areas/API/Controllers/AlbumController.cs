using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace NetCoreAnexsoft.Areas.API.Controllers
{
    [Area("Api")]
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;
        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [Route("api/album/{AlbumId}")]
        public IActionResult Get(int AlbumId)
        {
            var result = _albumService.Get(AlbumId);
            return Ok(
                        new
                        {
                            Name = result.Name,
                            Description = result.Description,
                            Photos = result.Photos.Select(x => x.PhotoLink).ToList()
                        }
                    );
        }
    }
}