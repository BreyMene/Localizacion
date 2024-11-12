using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface ICoordenadasPresentacion
    {
        Task<List<Coordenadas>> Listar();
        Task<List<Coordenadas>> Buscar(Coordenadas entidad, string tipo);
        Task<Coordenadas> Guardar(Coordenadas entidad);
        Task<Coordenadas> Modificar(Coordenadas entidad);
        Task<Coordenadas> Borrar(Coordenadas entidad);
    }
}