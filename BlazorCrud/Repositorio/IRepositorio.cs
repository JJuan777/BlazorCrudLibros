using BlazorCrud.Modelos;

namespace BlazorCrud.Repositorio
{
    public interface IRepositorio
    {
        public Task<List<Libro>> GetLibro();
        public Task<Libro> GetLibroId(int id);
        public Task<Libro> CrearLibro(Libro crearLibro);
        public Task<Libro> ActualizarLibro(int libroId, Libro actualizarLibro);
        public Task EliminarLibro(int libroId);

    }
}
