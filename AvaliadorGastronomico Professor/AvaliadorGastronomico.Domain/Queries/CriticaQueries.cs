using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AvaliadorGastronomico.Domain;

namespace AvaliadorGastronomico.Domain.Queries
{
     #region Slide 19
    public static class CriticaQueries
    {
        
        public static IEnumerable<Critica> RecuperarMaisRecentes(this IQueryable<Critica> instance, int numeroDeCriticas)
        {
            return instance.OrderByDescending(m => m.DataRefeicao).Take(numeroDeCriticas).ToList();
        }

        #region Slide 29
        public static Critica ProcurarMelhorCritica(this IQueryable<Critica> instance)
        {
            return instance.OrderByDescending(c => c.Nota).FirstOrDefault();
        }
        #endregion
        
        #region Slide 55
        public static Critica FindById(this IQueryable<Critica> instance, int id)
        {
            return instance.SingleOrDefault(c => c.Id == id);
        }
        #endregion
    }
    #endregion


}