using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using mst_pruebas.nucleo;

namespace mst_pruebas.Repositorios
{
    // Clase de prueba unitaria para la funcionalidad de la entidad Detalles
    [TestClass]
    public class DetallesPruebaUnitaria
    {
        // Instancia de IDetallesRepositorio para interactuar con la base de datos a través del repositorio de detalles
        private IDetallesRepositorio? iRepositorio = null;

        // Instancia de la entidad Detalles que se utilizará durante las pruebas
        private Detalles? entidad = null;

        // Constructor de la clase de prueba unitaria
        public DetallesPruebaUnitaria()
        {
            // Crea una nueva conexión a la base de datos
            var conexion = new Conexion();

            // Establece la cadena de conexión a la base de datos SQL Server
            conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");

            // Inicializa el repositorio de detalles con la conexión creada
            iRepositorio = new DetallesRepositorio(conexion);
        }

        // Método que ejecuta todas las pruebas unitarias para la entidad Detalles
        [TestMethod]
        public void Ejecutar()
        {
            Guardar();   // Prueba para guardar un nuevo detalle
            Listar();    // Prueba para listar detalles
            Buscar();    // Prueba para buscar un detalle
            Modificar(); // Prueba para modificar un detalle
            Borrar();    // Prueba para borrar un detalle
        }

        // Método que prueba la funcionalidad de guardar un nuevo detalle
        private void Guardar()
        {
            // Crea una nueva instancia de la entidad Detalles con fecha, persona y ubicación
            entidad = new Detalles()
            {
                Fecha = DateTime.Now, // Fecha actual
                Persona = 1,          // ID de la persona asociada
                Ubicacion = 2,       // ID de la ubicación asociada
            };

            // Guarda la entidad en la base de datos usando el repositorio
            entidad = iRepositorio!.Guardar(entidad);

            // Verifica que el detalle haya sido guardado con un ID distinto de 0
            Assert.IsTrue(entidad.Id != 0);
        }

        // Método que prueba la funcionalidad de listar todos los detalles
        private void Listar()
        {
            // Obtiene una lista de todos los detalles
            var lista = iRepositorio!.Listar();

            // Verifica que la lista tenga al menos un elemento
            Assert.IsTrue(lista.Count > 0);
        }

        // Método que prueba la funcionalidad de buscar un detalle por su ID
        public void Buscar()
        {
            // Busca un detalle por su ID utilizando una expresión lambda
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la lista de resultados no esté vacía
            Assert.IsTrue(lista.Count > 0);
        }

        // Método que prueba la funcionalidad de modificar un detalle
        private void Modificar()
        {
            // Modifica el ID de la persona asociada al detalle
            entidad!.Persona = 2;

            // Actualiza el detalle en la base de datos
            entidad = iRepositorio!.Modificar(entidad!);

            // Busca el detalle modificado por su ID
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que el detalle modificado aún exista en la base de datos
            Assert.IsTrue(lista.Count > 0);
        }

        // Método que prueba la funcionalidad de borrar un detalle
        private void Borrar()
        {
            // Elimina el detalle utilizando el repositorio
            entidad = iRepositorio!.Borrar(entidad!);

            // Intenta buscar el detalle que fue eliminado por su ID
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la lista de resultados esté vacía, indicando que el detalle fue eliminado
            Assert.IsTrue(lista.Count == 0);
        }
    }
}
