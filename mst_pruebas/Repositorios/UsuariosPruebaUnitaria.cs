using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using mst_pruebas.nucleo;

namespace mst_pruebas.Repositorios
{
    // Clase de prueba unitaria para la funcionalidad de la entidad Usuarios
    [TestClass]
    public class UsuariosPruebaUnitaria
    {
        // Instancia de IUsuariosRepositorio para interactuar con la base de datos a trav�s del repositorio de Usuarios
        private IUsuariosRepositorio? iRepositorio = null;

        // Instancia de la entidad Usuarios que se utilizar� durante las pruebas
        private Usuarios? entidad = null;

        // Constructor de la clase de prueba unitaria
        public UsuariosPruebaUnitaria()
        {
            // Crea una nueva conexi�n a la base de datos
            var conexion = new Conexion();

            // Establece la cadena de conexi�n a la base de datos SQL Server
            conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");

            // Inicializa el repositorio de Usuarios con la conexi�n creada
            iRepositorio = new UsuariosRepositorio(conexion);
        }

        // M�todo que ejecuta todas las pruebas unitarias para la entidad Usuarios
        [TestMethod]
        public void Ejecutar()
        {
            Guardar();   // Prueba para guardar un nuevo Usuario
            Listar();    // Prueba para listar todos los Usuarios
            Buscar();    // Prueba para buscar un Usuario
            Modificar(); // Prueba para modificar los datos de un Usuario
            Borrar();    // Prueba para borrar un Usuario
        }

        // M�todo que prueba la funcionalidad de guardar un nuevo Usuario
        private void Guardar()
        {
            // Crea una nueva instancia de la entidad Usuarios con la c�dula, nombre y contrase�a
            entidad = new Usuarios()
            {
                Cedula = "1111000",  // C�dula del Usuario
                Nombre = "PRUEBA",    // Nombre del Usuario
                Contrasena = "*****",  // Contrase�a del Usuario 
                Rol = 1
            };

            // Guarda la entidad en la base de datos usando el repositorio
            entidad = iRepositorio!.Guardar(entidad);

            // Verifica que el Usuario haya sido guardada con un ID distinto de 0
            Assert.IsTrue(entidad.Id != 0);
        }

        // M�todo que prueba la funcionalidad de listar todas las Usuarios
        private void Listar()
        {
            // Obtiene una lista de todas las Usuarios
            var lista = iRepositorio!.Listar();

            // Verifica que la lista tenga al menos un elemento
            Assert.IsTrue(lista.Count > 0);
        }

        // M�todo que prueba la funcionalidad de buscar un Usuario por su ID
        public void Buscar()
        {
            // Busca un usuario por su ID utilizando una expresi�n lambda
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la lista de resultados no est� vac�a
            Assert.IsTrue(lista.Count > 0);
        }

        // M�todo que prueba la funcionalidad de modificar los datos de un Usuario
        private void Modificar()
        {
            // Cambia el rol del Usuario de "Admin" a "Comun"
            entidad!.Rol = 2;

            // Actualiza el Usuario en la base de datos
            entidad = iRepositorio!.Modificar(entidad!);

            // Busca el Usuario modificada por su ID
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que el Usuario modificada a�n exista en la base de datos
            Assert.IsTrue(lista.Count > 0);
        }

        // M�todo que prueba la funcionalidad de borrar un Usuario
        private void Borrar()
        {
            // Elimina al Usuario utilizando el repositorio
            entidad = iRepositorio!.Borrar(entidad!);

            // Intenta buscar el Usuario que fue eliminada por su ID
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la lista de resultados est� vac�a, indicando que el Usuario fue eliminada
            Assert.IsTrue(lista.Count == 0);
        }
    }
}
