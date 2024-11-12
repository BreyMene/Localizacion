using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IPaisesPresentacion
    {
        Task<List<Paises>> Listar();
        Task<List<Paises>> Buscar(Paises entidad, string tipo);
        Task<Paises> Guardar(Paises entidad);
        Task<Paises> Modificar(Paises entidad);
        Task<Paises> Borrar(Paises entidad);
    }
}