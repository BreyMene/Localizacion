using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    /*
    * Interface de Barrios que define los métodos que deben ser implementados
    * por cualquier clase que la herede, en este caso, AuditoriasRepositorio.
    */
    public interface IAuditoriasRepositorio
    {
        void Configurar(string string_conexion);

        // Método para listar todos los registros de Barrios.
        List<Barrios> Listar();

        // Método para buscar registros de Barrios que cumplan con ciertas condiciones.
        // Usa una expresión lambda que define los criterios de búsqueda.
        List<Barrios> Buscar(Expression<Func<Barrios, bool>> condiciones);

        // Método para guardar una nueva entidad de Barrios en la base de datos.
        Barrios Guardar(Barrios entidad);
    }
}
