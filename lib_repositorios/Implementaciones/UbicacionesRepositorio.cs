using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    /* 
    * UbicacionesRepositorio implementa la interface IUbicacionesRepositorio,
    * lo que significa que debe proporcionar implementaciones
    * para los métodos definidos en dicha interfaz.
    */
    public class UbicacionesRepositorio : IUbicacionesRepositorio
    {
        // Objeto de tipo Conexion que permitirá interactuar con la base de datos.
        private Conexion? conexion = null;

        // Constructor que inicializa el objeto de tipo Conexion al instanciar UbicacionesRepositorio.
        public UbicacionesRepositorio(Conexion conexion)
        {
            this.conexion = conexion;  // Asigna el objeto conexion recibido al atributo de la clase.
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        // Método para listar todos los registros de Ubicaciones, retorna una lista de entidades de tipo Ubicaciones.
        public List<Ubicaciones> Listar()
        {
            // Utiliza el método Listar del objeto conexion para obtener todos los registros de la entidad Ubicaciones.
            return conexion!.Listar<Ubicaciones>();
        }

        // Método para buscar Ubicaciones que cumplan con ciertas condiciones, usando expresiones lambda.
        // Recibe una expresión que especifica los criterios de búsqueda.
        public List<Ubicaciones> Buscar(Expression<Func<Ubicaciones, bool>> condiciones)
        {
            // Utiliza el método Buscar de conexion para obtener registros que cumplen con las condiciones especificadas.
            return conexion!.Buscar(condiciones);
        }

        // Método para guardar un nuevo registro de Ubicaciones en la base de datos. Retorna la entidad guardada.
        public Ubicaciones Guardar(Ubicaciones entidad)
        {
            // Llama al método Guardar del objeto conexion para agregar el nuevo registro.
            conexion!.Guardar(entidad);
            // Guarda los cambios en la base de datos.
            conexion!.GuardarCambios();
            // Retorna la entidad guardada.
            return entidad;
        }

        // Método para modificar un registro existente de Ubicaciones. Retorna la entidad modificada.
        public Ubicaciones Modificar(Ubicaciones entidad)
        {
            // Llama al método Modificar del objeto conexion para actualizar el registro existente.
            conexion!.Modificar(entidad);
            // Guarda los cambios en la base de datos.
            conexion!.GuardarCambios();
            // Retorna la entidad modificada.
            return entidad;
        }

        // Método para borrar un registro de Ubicaciones. Retorna la entidad eliminada.
        public Ubicaciones Borrar(Ubicaciones entidad)
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
