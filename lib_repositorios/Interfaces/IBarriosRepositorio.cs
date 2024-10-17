using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    /*
    * Interface de Barrios que define los métodos que deben ser implementados
    * por cualquier clase que la herede, en este caso, BarriosRepositorio.
    */
    public interface IBarriosRepositorio
    {
        void Configurar(string string_conexion);

        // Método para listar todos los registros de Barrios.
        List<Barrios> Listar(); 

        // Método para buscar registros de Barrios que cumplan con ciertas condiciones.
        // Usa una expresión lambda que define los criterios de búsqueda.
        List<Barrios> Buscar(Expression<Func<Barrios, bool>> condiciones); 

        // Método para guardar una nueva entidad de Barrios en la base de datos.
        Barrios Guardar(Barrios entidad);

        // Método para modificar una entidad existente de Barrios en la base de datos.
        Barrios Modificar(Barrios entidad);

        // Método para borrar una entidad de Barrios de la base de datos.
        Barrios Borrar(Barrios entidad);
    }
}
