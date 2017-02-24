using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AvaliadorGastronomico.Domain
{
    public class Critica : IValidatableObject
    {
        public virtual int Id { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public virtual string Corpo { get; set; }

        [Range(1, 10)]
        public virtual int Nota { get; set; }

        public virtual DateTime DataCriacao { get; set; }

        [DisplayName("Data da refeição")]
        //[DisplayFormat(DataFormatString="{0:d}", ApplyFormatInEditMode=true)]
        [DataType(DataType.Date)]
        public virtual DateTime DataRefeicao { get; set; }

        [ForeignKey("Restaurante_Id")]
        public virtual Restaurante Restaurante { get; set; }

        public virtual int Restaurante_Id { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Slide 36 - atribuição das validações às propriedades é necessaria
            var propriedades = new[] { "DataRefeicao" };

            if (DataRefeicao > DateTime.Now)
            {
                yield return new ValidationResult("A Data de Refeição não pode ser futura", propriedades);
            }

            if (DataRefeicao < DateTime.Now.AddYears(-1))
            {
                yield return new ValidationResult("A Data de Refeição não pode ser tão antiga", propriedades);
            }
        }
    }
}
