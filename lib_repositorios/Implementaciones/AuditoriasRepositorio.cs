using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    /* 
    * AuditoriasRepositorio implementa la interface IAuditoriasRepositorio,
    * lo que significa que debe proporcionar implementaciones
    * para los métodos definidos en dicha interfaz.
    */
    public class AuditoriasRepositorio : IAuditoriasRepositorio
    {
        // Objeto de tipo Conexion que permitirá interactuar con la base de datos.
        private Conexion? conexion = null;

        // Constructor que inicializa el objeto de tipo Conexion al instanciar AuditoriasRepositorio.
        public AuditoriasRepositorio(Conexion conexion)
        {
            this.conexion = conexion;  // Asigna el objeto conexion recibido al atributo de la clase.
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        // Método para listar todos los registros de Auditorias, retorna una lista de entidades de tipo Auditorias.
        public List<Auditorias> Listar()
        {
            // Utiliza el método Listar del objeto conexion para obtener todos los registros de la entidad Auditorias.
            return conexion!.Listar<Auditorias>();
        }

        // Método para buscar Auditorias que cumplan con ciertas condiciones, usando expresiones lambda.
        // Recibe una expresión que especifica los criterios de búsqueda.
        public List<Auditorias> Buscar(Expression<Func<Auditorias, bool>> condiciones)
        {
            // Utiliza el método Buscar de conexion para obtener registros que cumplen con las condiciones especificadas.
            return conexion!.Buscar(condiciones);
        }

        // Método para guardar un nuevo registro de Auditorias en la base de datos. Retorna la entidad guardada.
        public Auditorias Guardar(Auditorias entidad)
        {
            // Llama al método Guardar del objeto conexion para agregar el nuevo registro.
            conexion!.Guardar(entidad);
            // Guarda los cambios en la base de datos.
            conexion!.GuardarCambios();
            // Retorna la entidad guardada.
            return entidad;
        }
    }
}