using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvaliadorGastronomico.WebUI.Models
{
    public class AlteracaoSenhaViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha Atual")]
        public string SenhaAtual { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter ao menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        public string NovaSenha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a nova senha")]
        [Compare("NovaSenha", ErrorMessage = "A nova senha não confere com a confirmação.")]
        public string ConfirmacaoSenha { get; set; }
    }
}