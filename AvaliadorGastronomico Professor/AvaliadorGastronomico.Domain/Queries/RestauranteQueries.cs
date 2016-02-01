using System.Linq;
using AvaliadorGastronomico.Domain;

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