using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        public ProAgilContext _context { get; }

        public ProAgilRepository(ProAgilContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        //GERAL
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
            return (await _context.SaveChangesAsync()) > 0; //Se no mínimo 1 alteração for salva, retorna True.
        }

        //EVENTO
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(c => c.Lotes)
            .Include(c => c.RedesSociais);

            if(includePalestrantes){
                query = query
                .Include(pe => pe.PalestrantesEventos)
                .ThenInclude(p => p.Palestrante);
                //Necessário incluir, pois é a entidade "junção" de Palestrante e Evento, depois incluo somente Palestrante.
            }

            query = query.OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetEventosAsyncByTema(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(c => c.Lotes)
            .Include(c => c.RedesSociais);

            if(includePalestrantes){
                query = query
                .Include(pe => pe.PalestrantesEventos)
                .ThenInclude(p => p.Palestrante);
                //Necessário incluir, pois é a entidade "junção" de Palestrante e Evento, depois incluo somente Palestrante.
            }

            query = query.OrderByDescending(c => c.DataEvento)
            .Where(c => c.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoAsyncById(int EventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(c => c.Lotes)
            .Include(c => c.RedesSociais);

            if(includePalestrantes){
                query = query
                .Include(pe => pe.PalestrantesEventos)
                .ThenInclude(p => p.Palestrante);
                //Necessário incluir, pois é a entidade "junção" de Palestrante e Evento, depois incluo somente Palestrante.
            }

            query = query.OrderByDescending(c => c.DataEvento)
            .Where(c => c.Id == EventoId);

            return await query.FirstOrDefaultAsync();
        }

        //PALESTRANTE
        public async Task<Palestrante> GetPalestranteAsyncById(int PalestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(c => c.RedesSociais);

            if(includeEventos){
                query = query
                .Include(pe => pe.PalestrantesEventos)
                .ThenInclude(e => e.Evento);
                //Necessário incluir, pois é a entidade "junção" de Palestrante e Evento, depois incluo somente Evento.
            }

            query = query.OrderBy(p => p.Nome)
            .Where(p => p.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetPalestrantesAsyncByName(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(c => c.RedesSociais);

            if(includeEventos){
                query = query
                .Include(pe => pe.PalestrantesEventos)
                .ThenInclude(e => e.Evento);
                //Necessário incluir, pois é a entidade "junção" de Palestrante e Evento, depois incluo somente Evento.
            }

            query = query
            .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}