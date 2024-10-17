using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    /*
    * Interface de Departamentos que define los métodos que deben ser implementados
    * por cualquier clase que la herede, en este caso, DepartamentosRepositorio.
    */
    public interface IDepartamentosRepositorio
    {
        void Configurar(string string_conexion);

        // Método para listar todos los registros de Departamentos.
        List<Departamentos> Listar();

        // Método para buscar registros de Departamentos que cumplan con ciertas condiciones.
        // Usa una expresión lambda que define los criterios de búsqueda.
        List<Departamentos> Buscar(Expression<Func<Departamentos, bool>> condiciones);

        // Método para guardar una nueva entidad de Departamentos en la base de datos.
        Departamentos Guardar(Departamentos entidad);

        // Método para modificar una entidad existente de Departamentos en la base de datos.
        Departamentos Modificar(Departamentos entidad);

        // Método para borrar una entidad de Departamentos de la base de datos.
        Departamentos Borrar(Departamentos entidad);
    }
}
