using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IBarriosPresentacion
    {
        Task<List<Barrios>> Listar();
        Task<List<Barrios>> Buscar(Barrios entidad, string tipo);
        Task<Barrios> Guardar(Barrios entidad);
        Task<Barrios> Modificar(Barrios entidad);
        Task<Barrios> Borrar(Barrios entidad);
    }
}