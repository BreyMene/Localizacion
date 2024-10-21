using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using mst_pruebas.nucleo;

namespace mst_pruebas.Repositorios
{
    // Clase de prueba unitaria para la funcionalidad de la entidad Ubicaciones
    [TestClass]
    public class UbicacionesPruebaUnitaria
    {
        // Instancia de IUbicacionesRepositorio para interactuar con la base de datos a través del repositorio de ubicaciones
        private IUbicacionesRepositorio? iRepositorio = null;

        // Instancia de la entidad Ubicaciones que se utilizará durante las pruebas
        private Ubicaciones? entidad = null;

        // Constructor de la clase de prueba unitaria
        public UbicacionesPruebaUnitaria()
        {
            // Crea una nueva conexión a la base de datos
            var conexion = new Conexion();

            // Establece la cadena de conexión a la base de datos SQL Server
            conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");

            // Inicializa el repositorio de ubicaciones con la conexión creada
            iRepositorio = new UbicacionesRepositorio(conexion);
        }

        // Método que ejecuta todas las pruebas unitarias para la entidad Ubicaciones
        [TestMethod]
        public void Ejecutar()
        {
            Guardar();   // Prueba para guardar una nueva ubicación
            Listar();    // Prueba para listar ubicaciones
            Buscar();    // Prueba para buscar una ubicación
            Modificar(); // Prueba para modificar una ubicación
            Borrar();    // Prueba para borrar una ubicación
        }

        // Método que prueba la funcionalidad de guardar una nueva ubicación
        private void Guardar()
        {
            // Crea una nueva instancia de la entidad Ubicaciones con sus propiedades
            entidad = new Ubicaciones()
            {
                Descripcion = "pruebaaaa", // Descripción de la ubicación
                Imagen = "imagenPrueba",    // Nombre de la imagen asociada a la ubicación
                Nombre = "test",            // Nombre de la ubicación
                Barrio = 3,                 // ID del barrio al que pertenece
                Coordenada = 2              // ID de la coordenada asociada
            };

            // Guarda la entidad en la base de datos usando el repositorio
            entidad = iRepositorio!.Guardar(entidad);

            // Verifica que la ubicación haya sido guardada con un ID distinto de 0
            Assert.IsTrue(entidad.Id != 0);
        }

        // Método que prueba la funcionalidad de listar todas las ubicaciones
        private void Listar()
        {
            // Obtiene una lista de todas las ubicaciones
            var lista = iRepositorio!.Listar();

            // Verifica que la lista tenga al menos un elemento
            Assert.IsTrue(lista.Count > 0);
        }

        // Método que prueba la funcionalidad de buscar una ubicación por su ID
        public void Buscar()
        {
            // Busca una ubicación por su ID utilizando una expresión lambda
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la lista de resultados no esté vacía
            Assert.IsTrue(lista.Count > 0);
        }

        // Método que prueba la funcionalidad de modificar una ubicación
        private void Modificar()
        {
            // Modifica el nombre de la ubicación
            entidad!.Nombre = "Prueba";

            // Actualiza la ubicación en la base de datos
            entidad = iRepositorio!.Modificar(entidad!);

            // Busca la ubicación modificada por su ID
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la ubicación modificada aún exista en la base de datos
            Assert.IsTrue(lista.Count > 0);
        }

        // Método que prueba la funcionalidad de borrar una ubicación
        private void Borrar()
        {
            // Elimina la ubicación utilizando el repositorio
            entidad = iRepositorio!.Borrar(entidad!);

            // Intenta buscar la ubicación que fue eliminada por su ID
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la lista de resultados esté vacía, indicando que la ubicación fue eliminada
            Assert.IsTrue(lista.Count == 0);
        }
    }
}
