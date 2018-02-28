using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAnexsoft.Models.ViewModels
{
    public class AlbumViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(10,ErrorMessage ="Debe contener {0} carácteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "Debe contener {0} carácteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]       
        public IFormFile Photo { get; set; }
    }
}
