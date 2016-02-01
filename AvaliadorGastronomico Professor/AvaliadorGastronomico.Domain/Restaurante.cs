using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliadorGastronomico.Domain
{
    #region Slide 19
    public class Restaurante
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Critica> Criticas { get; set; }
        public virtual string CaminhoImagem { get; set; }
        public virtual string  NomeChef { get; set; }
    }
    #endregion
}
