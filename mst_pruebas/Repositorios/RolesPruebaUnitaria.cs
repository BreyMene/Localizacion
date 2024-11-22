using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using mst_pruebas.nucleo;

namespace mst_pruebas.Repositorios
{
    // Clase de prueba unitaria para la funcionalidad de la entidad Roles
    [TestClass]
    public class RolesPruebaUnitaria
    {
        // Instancia de IRolesRepositorio para interactuar con la base de datos a través del repositorio de países
        private IRolesRepositorio? iRepositorio = null;

        // Instancia de la entidad Roles que se utilizará durante las pruebas
        private Roles? entidad = null;

        // Constructor de la clase de prueba unitaria
        public RolesPruebaUnitaria()
        {
            // Crea una nueva conexión a la base de datos
            var conexion = new Conexion();

            // Establece la cadena de conexión a la base de datos SQL Server
            conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");

            // Inicializa el repositorio de países con la conexión creada
            iRepositorio = new RolesRepositorio(conexion);
        }

        // Método que ejecuta todas las pruebas unitarias para la entidad Roles
        [TestMethod]
        public void Ejecutar()
        {
            Guardar();   // Prueba para guardar un nuevo país
            Listar();    // Prueba para listar todos los países
            Buscar();    // Prueba para buscar un país
            Modificar(); // Prueba para modificar un país
            Borrar();    // Prueba para borrar un país
        }

        // Método que prueba la funcionalidad de guardar un nuevo país
        private void Guardar()
        {
            // Crea una nueva instancia de la entidad Roles con un nombre
            entidad = new Roles()
            {
                Nombre = "Visitantr" // Nombre del país
            };

            // Guarda la entidad en la base de datos usando el repositorio
            entidad = iRepositorio!.Guardar(entidad);

            // Verifica que el país haya sido guardado con un ID distinto de 0
            Assert.IsTrue(entidad.Id != 0);
        }

        // Método que prueba la funcionalidad de listar todos los países
        private void Listar()
        {
            // Obtiene una lista de todos los países
            var lista = iRepositorio!.Listar();

            // Verifica que la lista tenga al menos un elemento
            Assert.IsTrue(lista.Count > 0);
        }

        // Método que prueba la funcionalidad de buscar un país por su ID
        public void Buscar()
        {
            // Busca un país por su ID utilizando una expresión lambda
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la lista de resultados no esté vacía
            Assert.IsTrue(lista.Count > 0);
        }

        // Método que prueba la funcionalidad de modificar un país
        private void Modificar()
        {
            // Modifica el nombre del país de "alemanisa" a "Alemania"
            entidad!.Nombre = "Visitante";

            // Actualiza el país en la base de datos
            entidad = iRepositorio!.Modificar(entidad!);

            // Busca el país modificado por su ID
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que el país modificado aún exista en la base de datos
            Assert.IsTrue(lista.Count > 0);
        }

        // Método que prueba la funcionalidad de borrar un país
        private void Borrar()
        {
            // Elimina el país utilizando el repositorio
            entidad = iRepositorio!.Borrar(entidad!);

            // Intenta buscar el país que fue eliminado por su ID
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la lista de resultados esté vacía, indicando que el país fue eliminado
            Assert.IsTrue(lista.Count == 0);
        }
    }
}
