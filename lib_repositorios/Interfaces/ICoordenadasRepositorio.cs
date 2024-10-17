using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    /*
    * Interface de Coordenadas que define los métodos que deben ser implementados
    * por cualquier clase que la herede, en este caso, CoordenadasRepositorio.
    */
    public interface ICoordenadasRepositorio
    {
        void Configurar(string string_conexion);
        // Método para listar todos los registros de Coordenadas.
        List<Coordenadas> Listar();

        // Método para buscar registros de Coordenadas que cumplan con ciertas condiciones.
        // Usa una expresión lambda que define los criterios de búsqueda.
        List<Coordenadas> Buscar(Expression<Func<Coordenadas, bool>> condiciones);

        // Método para guardar una nueva entidad de Coordenadas en la base de datos.
        Coordenadas Guardar(Coordenadas entidad);

        // Método para modificar una entidad existente de Coordenadas en la base de datos.
        Coordenadas Modificar(Coordenadas entidad);

        // Método para borrar una entidad de Coordenadas de la base de datos.
        Coordenadas Borrar(Coordenadas entidad);
    }
}
