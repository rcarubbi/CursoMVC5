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
    #region Slide 19
   /* public class Critica
    {
        public virtual int Id { get; set; }
        public virtual string Corpo { get; set; }
        public virtual DateTime DataCriacao { get; set; }
        public virtual DateTime DataRefeicao { get; set; }
        public virtual int Nota { get; set; }
        
        [ForeignKey("Restaurnate_Id")]
        public virtual Restaurante Restaurante { get; set; }

        public virtual int Restaurante_Id { get; set; }
    }*/
    #endregion

    #region Slide 35
    /*  public class Critica
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual string Corpo { get; set; }

        [Range(1, 10)]
        public virtual int Nota { get; set; }

        public virtual DateTime DataCriacao { get; set; }

        public virtual DateTime DataRefeicao { get; set; }

        [ForeignKey("Restaurante_Id")]
        public virtual Restaurante Restaurante { get; set; }

        public virtual int Restaurante_Id { get; set; }
    }*/
    #endregion 

    #region Slide 36
    /*public class Critica : IValidatableObject
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual string Corpo { get; set; }

        [Range(1, 10)]
        public virtual int Nota { get; set; }

        public virtual DateTime DataCriacao { get; set; }

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
    }*/
    #endregion 

    #region Slide 38
    /*public class Critica : IValidatableObject
    {
        public virtual int Id { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
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
    }*/
    #endregion 

    #region Slide 55.4
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
        //[DataType(DataType.Date)]
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
    #endregion 


    /*
        [Required(ErrorMessageResourceType = typeof(AvaliadorGastronomico.Domain.Resources.ModelsResources), ErrorMessageResourceName = "Critica.ErroCorpoNaoPreenchido")]
       
    
 

       
    }*/


}
