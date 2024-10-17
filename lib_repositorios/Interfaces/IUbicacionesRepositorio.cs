using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    /*
    * Interface de Ubicaciones que define los métodos que deben ser implementados
    * por cualquier clase que la herede, en este caso, UbicacionesRepositorio.
    */
    public interface IUbicacionesRepositorio
    {
        void Configurar(string string_conexion);

        // Método para listar todos los registros de Ubicaciones.
        List<Ubicaciones> Listar();

        // Método para buscar registros de Ubicaciones que cumplan con ciertas condiciones.
        // Usa una expresión lambda que define los criterios de búsqueda.
        List<Ubicaciones> Buscar(Expression<Func<Ubicaciones, bool>> condiciones);

        // Método para guardar una nueva entidad de Ubicaciones en la base de datos.
        Ubicaciones Guardar(Ubicaciones entidad);

        // Método para modificar una entidad existente de Ubicaciones en la base de datos.
        Ubicaciones Modificar(Ubicaciones entidad);

        // Método para borrar una entidad de Ubicaciones de la base de datos.
        Ubicaciones Borrar(Ubicaciones entidad);
    }
}
