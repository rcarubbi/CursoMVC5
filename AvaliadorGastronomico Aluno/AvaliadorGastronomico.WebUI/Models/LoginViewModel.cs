using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvaliadorGastronomico.WebUI.Models
{
    // slide 51
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string NomeConta { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Display(Name = "Lembrar me?")]
        public bool LembrarMe { get; set; }
    }
}