using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    /* 
    * CoordenadasRepositorio implementa la interface ICoordenadasRepositorio,
    * lo que significa que debe proporcionar implementaciones
    * para los métodos definidos en dicha interfaz.
    */
    public class CoordenadasRepositorio : ICoordenadasRepositorio
    {
        // Objeto de tipo Conexion que permitirá interactuar con la base de datos.
        private Conexion? conexion = null;

        // Constructor que inicializa el objeto de tipo Conexion al instanciar CoordenadasRepositorio.
        public CoordenadasRepositorio(Conexion conexion)
        {
            this.conexion = conexion;  // Asigna el objeto conexion recibido al atributo de la clase.
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        // Método para listar todos los registros de Coordenadas, retorna una lista de entidades de tipo Coordenadas.
        public List<Coordenadas> Listar()
        {
            // Utiliza el método Listar del objeto conexion para obtener todos los registros de la entidad Coordenadas.
            return conexion!.Listar<Coordenadas>();
        }

        // Método para buscar Coordenadas que cumplan con ciertas condiciones, usando expresiones lambda.
        // Recibe una expresión que especifica los criterios de búsqueda.
        public List<Coordenadas> Buscar(Expression<Func<Coordenadas, bool>> condiciones)
        {
            // Utiliza el método Buscar de conexion para obtener registros que cumplen con las condiciones especificadas.
            return conexion!.Buscar(condiciones);
        }

        // Método para guardar un nuevo registro de Coordenadas en la base de datos. Retorna la entidad guardada.
        public Coordenadas Guardar(Coordenadas entidad)
        {
            // Llama al método Guardar del objeto conexion para agregar el nuevo registro.
            conexion!.Guardar(entidad);
            // Guarda los cambios en la base de datos.
            conexion!.GuardarCambios();
            // Retorna la entidad guardada.
            return entidad;
        }

        // Método para modificar un registro existente de Coordenadas. Retorna la entidad modificada.
        public Coordenadas Modificar(Coordenadas entidad)
        {
            // Llama al método Modificar del objeto conexion para actualizar el registro existente.
            conexion!.Modificar(entidad);
            // Guarda los cambios en la base de datos.
            conexion!.GuardarCambios();
            // Retorna la entidad modificada.
            return entidad;
        }

        // Método para borrar un registro de Coordenadas. Retorna la entidad eliminada.
        public Coordenadas Borrar(Coordenadas entidad)
        {
            // Llama al método Borrar del objeto conexion para eliminar el registro.
            conexion!.Borrar(entidad);
            // Guarda los cambios en la base de datos.
            conexion!.GuardarCambios();
            // Retorna la entidad eliminada.
            return entidad;
        }
    }
}
