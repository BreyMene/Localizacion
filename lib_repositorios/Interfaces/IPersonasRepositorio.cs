using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    /*
    * Interface de Personas que define los métodos que deben ser implementados
    * por cualquier clase que la herede, en este caso, PersonasRepositorio.
    */
    public interface IPersonasRepositorio
    {
        void Configurar(string string_conexion);

        // Método para listar todos los registros de Personas.
        List<Personas> Listar();

        // Método para buscar registros de Personas que cumplan con ciertas condiciones.
        // Usa una expresión lambda que define los criterios de búsqueda.
        List<Personas> Buscar(Expression<Func<Personas, bool>> condiciones);

        // Método para guardar una nueva entidad de Personas en la base de datos.
        Personas Guardar(Personas entidad);

        // Método para modificar una entidad existente de Personas en la base de datos.
        Personas Modificar(Personas entidad);

        // Método para borrar una entidad de Personas de la base de datos.
        Personas Borrar(Personas entidad);
    }
}
