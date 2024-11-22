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
        // Instancia de IRolesRepositorio para interactuar con la base de datos a trav�s del repositorio de pa�ses
        private IRolesRepositorio? iRepositorio = null;

        // Instancia de la entidad Roles que se utilizar� durante las pruebas
        private Roles? entidad = null;

        // Constructor de la clase de prueba unitaria
        public RolesPruebaUnitaria()
        {
            // Crea una nueva conexi�n a la base de datos
            var conexion = new Conexion();

            // Establece la cadena de conexi�n a la base de datos SQL Server
            conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");

            // Inicializa el repositorio de pa�ses con la conexi�n creada
            iRepositorio = new RolesRepositorio(conexion);
        }

        // M�todo que ejecuta todas las pruebas unitarias para la entidad Roles
        [TestMethod]
        public void Ejecutar()
        {
            Guardar();   // Prueba para guardar un nuevo pa�s
            Listar();    // Prueba para listar todos los pa�ses
            Buscar();    // Prueba para buscar un pa�s
            Modificar(); // Prueba para modificar un pa�s
            Borrar();    // Prueba para borrar un pa�s
        }

        // M�todo que prueba la funcionalidad de guardar un nuevo pa�s
        private void Guardar()
        {
            // Crea una nueva instancia de la entidad Roles con un nombre
            entidad = new Roles()
            {
                Nombre = "Visitantr" // Nombre del pa�s
            };

            // Guarda la entidad en la base de datos usando el repositorio
            entidad = iRepositorio!.Guardar(entidad);

            // Verifica que el pa�s haya sido guardado con un ID distinto de 0
            Assert.IsTrue(entidad.Id != 0);
        }

        // M�todo que prueba la funcionalidad de listar todos los pa�ses
        private void Listar()
        {
            // Obtiene una lista de todos los pa�ses
            var lista = iRepositorio!.Listar();

            // Verifica que la lista tenga al menos un elemento
            Assert.IsTrue(lista.Count > 0);
        }

        // M�todo que prueba la funcionalidad de buscar un pa�s por su ID
        public void Buscar()
        {
            // Busca un pa�s por su ID utilizando una expresi�n lambda
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la lista de resultados no est� vac�a
            Assert.IsTrue(lista.Count > 0);
        }

        // M�todo que prueba la funcionalidad de modificar un pa�s
        private void Modificar()
        {
            // Modifica el nombre del pa�s de "alemanisa" a "Alemania"
            entidad!.Nombre = "Visitante";

            // Actualiza el pa�s en la base de datos
            entidad = iRepositorio!.Modificar(entidad!);

            // Busca el pa�s modificado por su ID
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que el pa�s modificado a�n exista en la base de datos
            Assert.IsTrue(lista.Count > 0);
        }

        // M�todo que prueba la funcionalidad de borrar un pa�s
        private void Borrar()
        {
            // Elimina el pa�s utilizando el repositorio
            entidad = iRepositorio!.Borrar(entidad!);

            // Intenta buscar el pa�s que fue eliminado por su ID
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la lista de resultados est� vac�a, indicando que el pa�s fue eliminado
            Assert.IsTrue(lista.Count == 0);
        }
    }
}
