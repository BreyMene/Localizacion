using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using mst_pruebas.nucleo;

namespace mst_pruebas.Repositorios
{
    // Clase de prueba unitaria para la funcionalidad de la entidad Barrios
    [TestClass]
    public class BarriosPruebaUnitaria
    {
        // Se define una instancia de IBarriosRepositorio para usar los métodos del repositorio
        private IBarriosRepositorio? iRepositorio = null;

        // Se define una entidad Barrios para almacenar la entidad sobre la cual se harán las pruebas
        private Barrios? entidad = null;

        // Constructor de la clase de prueba unitaria
        public BarriosPruebaUnitaria()
        {
            // Se crea una nueva instancia de la clase Conexion para manejar la base de datos
            var conexion = new Conexion();

            // Se define la cadena de conexión para la base de datos SQL Server
            conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");

            // Se inicializa el repositorio de Barrios con la conexión a la base de datos
            iRepositorio = new BarriosRepositorio(conexion);
        }

        // Método que ejecuta todas las pruebas unitarias para la entidad Barrios
        [TestMethod]
        public void Ejecutar()
        {
            Guardar();   // Prueba para guardar una entidad
            Listar();    // Prueba para listar entidades
            Buscar();    // Prueba para buscar una entidad
            Modificar(); // Prueba para modificar una entidad
            Borrar();    // Prueba para borrar una entidad
        }

        // Método que prueba la funcionalidad de guardar una nueva entidad Barrios
        private void Guardar()
        {
            // Se crea una nueva instancia de Barrios con un nombre y una ciudad
            entidad = new Barrios()
            {
                Nombre = "robledo", // Nombre del barrio
                Ciudad = 1          // ID de la ciudad
            };

            // Se guarda la nueva entidad utilizando el repositorio
            entidad = iRepositorio!.Guardar(entidad);

            // Verifica que la entidad tenga un ID distinto de 0 (lo que indica que se ha guardado correctamente)
            Assert.IsTrue(entidad.Id != 0);
        }

        // Método que prueba la funcionalidad de listar todas las entidades Barrios
        private void Listar()
        {
            // Obtiene una lista de todos los Barrios
            var lista = iRepositorio!.Listar();

            // Verifica que la lista tenga al menos un elemento (lo que indica que se ha recuperado correctamente)
            Assert.IsTrue(lista.Count > 0);
        }

        // Método que prueba la funcionalidad de buscar una entidad Barrios por su ID
        public void Buscar()
        {
            // Busca un barrio por su ID utilizando una expresión lambda
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la lista de resultados no esté vacía (lo que indica que se encontró un barrio)
            Assert.IsTrue(lista.Count > 0);
        }

        // Método que prueba la funcionalidad de modificar una entidad Barrios
        private void Modificar()
        {
            // Modifica el nombre del barrio de "robledo" a "Robledo"
            entidad!.Nombre = "Robledo";

            // Actualiza la entidad en la base de datos
            entidad = iRepositorio!.Modificar(entidad!);

            // Busca el barrio modificado por su ID
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que el barrio modificado aún existe en la base de datos
            Assert.IsTrue(lista.Count > 0);
        }

        // Método que prueba la funcionalidad de borrar una entidad Barrios
        private void Borrar()
        {
            // Borra el barrio utilizando el repositorio
            entidad = iRepositorio!.Borrar(entidad!);

            // Intenta buscar el barrio que fue borrado
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la lista de resultados esté vacía (lo que indica que el barrio fue eliminado)
            Assert.IsTrue(lista.Count == 0);
        }
    }
}
