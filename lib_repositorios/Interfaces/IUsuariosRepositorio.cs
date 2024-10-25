using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    /*
    * Interface de Usuarios que define los métodos que deben ser implementados
    * por cualquier clase que la herede, en este caso, UsuariosRepositorio.
    */
    public interface IUsuariosRepositorio
    {
        void Configurar(string string_conexion);

        // Método para listar todos los registros de Usuarios.
        List<Usuarios> Listar();

        // Método para buscar registros de Usuarios que cumplan con ciertas condiciones.
        // Usa una expresión lambda que define los criterios de búsqueda.
        List<Usuarios> Buscar(Expression<Func<Usuarios, bool>> condiciones);

        // Método para guardar una nueva entidad de Usuarios en la base de datos.
        Usuarios Guardar(Usuarios entidad);

        // Método para modificar una entidad existente de Usuarios en la base de datos.
        Usuarios Modificar(Usuarios entidad);

        // Método para borrar una entidad de Usuarios de la base de datos.
        Usuarios Borrar(Usuarios entidad);
    }
}
