using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface ICiudadesPresentacion
    {
        Task<List<Ciudades>> Listar();
        Task<List<Ciudades>> Buscar(Ciudades entidad, string tipo);
        Task<Ciudades> Guardar(Ciudades entidad);
        Task<Ciudades> Modificar(Ciudades entidad);
        Task<Ciudades> Borrar(Ciudades entidad);
    }
}