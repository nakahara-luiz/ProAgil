using System.Threading.Tasks;
using ProAgil.Domain.Entity;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {
         void Add<T>(T entity) where T: class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;

         Task<bool> SaveChangesAsync();

         Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes);
         Task<Evento[]> GetAllEventoAsync(bool includePalestrantes);
         Task<Evento> GetAllEventoAsyncById(int EventoId, bool includePalestrantes);

         Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
         Task<Palestrante[]> GetAllPalestrantesAsyncByName(string nome, bool includeEventos);
         Task<Palestrante> GetAllPalestrantesAsync(int PalestranteId, bool includeEventos);
    }
}