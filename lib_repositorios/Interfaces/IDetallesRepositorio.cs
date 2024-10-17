using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    /*
    * Interface de Detalles que define los métodos que deben ser implementados
    * por cualquier clase que la herede, en este caso, DetallesRepositorio.
    */
    public interface IDetallesRepositorio
    {
        void Configurar(string string_conexion);
     
        // Método para listar todos los registros de Detalles.
        List<Detalles> Listar();

        // Método para buscar registros de Detalles que cumplan con ciertas condiciones.
        // Usa una expresión lambda que define los criterios de búsqueda.
        List<Detalles> Buscar(Expression<Func<Detalles, bool>> condiciones);

        // Método para guardar una nueva entidad de Detalles en la base de datos.
        Detalles Guardar(Detalles entidad);

        // Método para modificar una entidad existente de Detalles en la base de datos.
        Detalles Modificar(Detalles entidad);

        // Método para borrar una entidad de Detalles de la base de datos.
        Detalles Borrar(Detalles entidad);
    }
}
