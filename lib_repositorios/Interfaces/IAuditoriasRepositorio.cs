using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    /*
    * Interface de Auditorias que define los métodos que deben ser implementados
    * por cualquier clase que la herede, en este caso, AuditoriasRepositorio.
    */
    public interface IAuditoriasRepositorio
    {
        void Configurar(string string_conexion);

        // Método para listar todos los registros de Auditorias.
        List<Auditorias> Listar();

        // Método para buscar registros de Auditorias que cumplan con ciertas condiciones.
        // Usa una expresión lambda que define los criterios de búsqueda.
        List<Auditorias> Buscar(Expression<Func<Auditorias, bool>> condiciones);

        // Método para guardar una nueva entidad de Auditorias en la base de datos.
        Auditorias Guardar(Auditorias entidad);
    }
}
