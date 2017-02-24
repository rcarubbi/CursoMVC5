using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliadorGastronomico.Domain.Queries
{
    public static class RestauranteQueries
    {
        public static Restaurante FindById(this IQueryable<Restaurante> instance, int id)
        {
            return instance.SingleOrDefault(c => c.Id == id);
        }
    }
}
