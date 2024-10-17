using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    /*
    * Interface de Paises que define los métodos que deben ser implementados
    * por cualquier clase que la herede, en este caso, PaisesRepositorio.
    */
    public interface IPaisesRepositorio
    {
        void Configurar(string string_conexion);

        // Método para listar todos los registros de Paises.
        List<Paises> Listar();

        // Método para buscar registros de Paises que cumplan con ciertas condiciones.
        // Usa una expresión lambda que define los criterios de búsqueda.
        List<Paises> Buscar(Expression<Func<Paises, bool>> condiciones);

        // Método para guardar una nueva entidad de Paises en la base de datos.
        Paises Guardar(Paises entidad);

        // Método para modificar una entidad existente de Paises en la base de datos.
        Paises Modificar(Paises entidad);

        // Método para borrar una entidad de Paises de la base de datos.
        Paises Borrar(Paises entidad);
    }
}
