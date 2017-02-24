using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvaliadorGastronomico.WebUI.Models
{
    // slide 51
    public class CadastroViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string NomeConta { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter ao menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Senha", ErrorMessage = "A senha não confere com a confirmação.")]
        public string ConfirmacaoSenha { get; set; }
    }
}