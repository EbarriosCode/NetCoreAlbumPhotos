using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAnexsoft.Models.ViewModels
{
    public class PhotoViewModel
    {
        [Required]
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]       
        public IFormFile Photo { get; set; }
    }
}
