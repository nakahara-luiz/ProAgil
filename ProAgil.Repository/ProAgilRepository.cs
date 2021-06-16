using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Entity;
using ProAgil.Repository.Data;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        public ProAgilContext _context { get; }

        public ProAgilRepository(ProAgilContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrantes) {
                query = query.Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderByDescending(e => e.Data);

            return await query.ToArrayAsync();
        }

        //Evento
        public async Task<Evento> GetAllEventoAsyncById(int EventoId, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrantes) {
                query = query.Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderByDescending(e => e.Data)
                .Where(c => c.Id == EventoId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrantes) {
                query = query.Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderByDescending(e => e.Data)
                .Where(c => c.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        //Palestrante
        public async Task<Palestrante> GetAllPalestrantesAsync(int PalestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(e => e.RedesSociais);

            if (includeEventos) {
                query = query.Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderByDescending(e => e.Nome)
                .Where(c => c.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(e => e.RedesSociais);

            if (includeEventos) {
                query = query.Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderByDescending(e => e.Nome);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsyncByName(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(e => e.RedesSociais);

            if (includeEventos) {
                query = query.Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderByDescending(e => e.Nome)
                .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}