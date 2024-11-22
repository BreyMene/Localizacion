using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    /*
    * Interface de Roles que define los métodos que deben ser implementados
    * por cualquier clase que la herede, en este caso, RolesRepositorio.
    */
    public interface IRolesRepositorio
    {
        void Configurar(string string_conexion);

        // Método para listar todos los registros de Roles.
        List<Roles> Listar();

        // Método para buscar registros de Roles que cumplan con ciertas condiciones.
        // Usa una expresión lambda que define los criterios de búsqueda.
        List<Roles> Buscar(Expression<Func<Roles, bool>> condiciones);

        // Método para guardar una nueva entidad de Roles en la base de datos.
        Roles Guardar(Roles entidad);

        // Método para modificar una entidad existente de Roles en la base de datos.
        Roles Modificar(Roles entidad);

        // Método para borrar una entidad de Roles de la base de datos.
        Roles Borrar(Roles entidad);
    }
}
