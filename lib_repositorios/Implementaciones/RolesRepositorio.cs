using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    /* 
    * RolesRepositorio implementa la interface IRolesRepositorio,
    * lo que significa que debe proporcionar implementaciones
    * para los métodos definidos en dicha interfaz.
    */
    public class RolesRepositorio : IRolesRepositorio
    {
        // Objeto de tipo Conexion que permitirá interactuar con la base de datos.
        private Conexion? conexion = null;

        // Constructor que inicializa el objeto de tipo Conexion al instanciar RolesRepositorio.
        public RolesRepositorio(Conexion conexion)
        {
            this.conexion = conexion;  // Asigna el objeto conexion recibido al atributo de la clase.
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        // Método para listar todos los registros de Roles, retorna una lista de entidades de tipo Roles.
        public List<Roles> Listar()
        {
            // Utiliza el método Listar del objeto conexion para obtener todos los registros de la entidad Roles.
            return conexion!.Listar<Roles>();
        }

        // Método para buscar Roles que cumplan con ciertas condiciones, usando expresiones lambda.
        // Recibe una expresión que especifica los criterios de búsqueda.
        public List<Roles> Buscar(Expression<Func<Roles, bool>> condiciones)
        {
            // Utiliza el método Buscar de conexion para obtener registros que cumplen con las condiciones especificadas.
            return conexion!.Buscar(condiciones);
        }

        // Método para guardar un nuevo registro de Roles en la base de datos. Retorna la entidad guardada.
        public Roles Guardar(Roles entidad)
        {
            // Llama al método Guardar del objeto conexion para agregar el nuevo registro.
            conexion!.Guardar(entidad);
            // Guarda los cambios en la base de datos.
            conexion!.GuardarCambios();
            // Retorna la entidad guardada.
            return entidad;
        }

        // Método para modificar un registro existente de Roles. Retorna la entidad modificada.
        public Roles Modificar(Roles entidad)
        {
            // Llama al método Modificar del objeto conexion para actualizar el registro existente.
            conexion!.Modificar(entidad);
            // Guarda los cambios en la base de datos.
            conexion!.GuardarCambios();
            // Retorna la entidad modificada.
            return entidad;
        }

        // Método para borrar un registro de Roles. Retorna la entidad eliminada.
        public Roles Borrar(Roles entidad)
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
