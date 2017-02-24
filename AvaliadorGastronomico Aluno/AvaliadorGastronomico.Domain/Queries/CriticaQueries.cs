using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliadorGastronomico.Domain.Queries
{
    public static class CriticaQueries
    {

        public static IEnumerable<Critica> RecuperarMaisRecentes(this IQueryable<Critica> instance, int numeroDeCriticas)
        {
            return instance.OrderByDescending(m => m.DataRefeicao).Take(numeroDeCriticas).ToList();
        }

        public static Critica FindById(this IQueryable<Critica> instance, int id)
        {
            return instance.SingleOrDefault(c => c.Id == id);
        }

        public static Critica ProcurarMelhorCritica(this IQueryable<Critica> instance)
        {
            return instance.OrderByDescending(c => c.Nota).FirstOrDefault();
        }


    }
}
