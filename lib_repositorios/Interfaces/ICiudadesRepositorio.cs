using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    /*
    * Interface de Ciudades que define los métodos que deben ser implementados
    * por cualquier clase que la herede, en este caso, CiudadesRepositorio.
    */
    public interface ICiudadesRepositorio
    {
        void Configurar(string string_conexion);
        // Método para listar todos los registros de Ciudades.
        List<Ciudades> Listar();

        // Método para buscar registros de Ciudades que cumplan con ciertas condiciones.
        // Usa una expresión lambda que define los criterios de búsqueda.
        List<Ciudades> Buscar(Expression<Func<Ciudades, bool>> condiciones);

        // Método para guardar una nueva entidad de Ciudades en la base de datos.
        Ciudades Guardar(Ciudades entidad);

        // Método para modificar una entidad existente de Ciudades en la base de datos.
        Ciudades Modificar(Ciudades entidad);

        // Método para borrar una entidad de Ciudades de la base de datos.
        Ciudades Borrar(Ciudades entidad);
    }
}
