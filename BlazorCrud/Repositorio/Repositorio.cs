using BlazorCrud.Modelos;
using BlazorCrud.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Repositorio
{
    public class Repositorio : IRepositorio
    {
        private readonly ApplicationDbContext _contexto;
        public Repositorio(ApplicationDbContext contexto)
        {
                _contexto = contexto;
        }
        public async Task<Libro> ActualizarLibro(int libroId, Libro actualizarLibro)
        {
            var libroDesdeBd = await _contexto.Libro.FindAsync(libroId);
            libroDesdeBd.Titulo = actualizarLibro.Titulo;
            libroDesdeBd.Descripcion = actualizarLibro.Descripcion;
            libroDesdeBd.Autor = actualizarLibro.Autor;
            libroDesdeBd.Paginas = actualizarLibro.Paginas;
            libroDesdeBd.Precio = actualizarLibro.Precio;

            await _contexto.SaveChangesAsync();
            return libroDesdeBd;
        }

        public async Task<Libro> CrearLibro(Libro crearLibro)
        {
            if (crearLibro != null)
            {
                crearLibro.FechaCreacion = DateTime.Now;
                await _contexto.Libro.AddAsync(crearLibro);
                await _contexto.SaveChangesAsync();
                return crearLibro;
            }
            else
            {
                return new Libro();
            }
        }

        public async Task EliminarLibro(int libroId)
        {
          var libroDesdeDd = await _contexto.Libro.FindAsync(libroId);
            _contexto.Remove(libroDesdeDd);
            await _contexto.SaveChangesAsync();
        }

        public Task<List<Libro>> GetLibro()
        {
            return _contexto.Libro.ToListAsync();
        }

        public async Task<Libro> GetLibroId(int libroId)
        {
            var libroDesdeDd = await _contexto.Libro.FindAsync(libroId);
            if (libroDesdeDd == null)
            {
                return new Libro();
            }
            return libroDesdeDd;
        }
    }
}
