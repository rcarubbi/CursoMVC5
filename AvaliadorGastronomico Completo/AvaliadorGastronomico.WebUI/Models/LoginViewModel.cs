using System.ComponentModel.DataAnnotations;

namespace AvaliadorGastronomico.WebUI.Models
{
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