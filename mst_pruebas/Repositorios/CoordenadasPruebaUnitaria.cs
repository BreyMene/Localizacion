using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using mst_pruebas.nucleo;

namespace mst_pruebas.Repositorios
{
    // Clase de prueba unitaria para la funcionalidad de la entidad Coordenadas
    [TestClass]
    public class CoordenadasPruebaUnitaria
    {
        // Instancia de ICoordenadasRepositorio para interactuar con la base de datos a través del repositorio de coordenadas
        private ICoordenadasRepositorio? iRepositorio = null;

        // Instancia de la entidad Coordenadas que se utilizará durante las pruebas
        private Coordenadas? entidad = null;

        // Constructor de la clase de prueba unitaria
        public CoordenadasPruebaUnitaria()
        {
            // Crea una nueva conexión a la base de datos
            var conexion = new Conexion();

            // Establece la cadena de conexión a la base de datos SQL Server
            conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");

            // Inicializa el repositorio de coordenadas con la conexión creada
            iRepositorio = new CoordenadasRepositorio(conexion);
        }

        // Método que ejecuta todas las pruebas unitarias para la entidad Coordenadas
        [TestMethod]
        public void Ejecutar()
        {
            Guardar();   // Prueba para guardar una coordenada
            Listar();    // Prueba para listar coordenadas
            Buscar();    // Prueba para buscar una coordenada
            Modificar(); // Prueba para modificar una coordenada
            Borrar();    // Prueba para borrar una coordenada
        }

        // Método que prueba la funcionalidad de guardar una nueva coordenada
        private void Guardar()
        {
            // Crea una nueva instancia de la entidad Coordenadas con latitud y longitud
            entidad = new Coordenadas()
            {
                Latitud = "000.001",    // Latitud de la coordenada
                Longitud = "1111.22"    // Longitud de la coordenada
            };

            // Guarda la entidad en la base de datos usando el repositorio
            entidad = iRepositorio!.Guardar(entidad);

            // Verifica que la coordenada haya sido guardada con un ID distinto de 0
            Assert.IsTrue(entidad.Id != 0);
        }

        // Método que prueba la funcionalidad de listar todas las coordenadas
        private void Listar()
        {
            // Obtiene una lista de todas las coordenadas
            var lista = iRepositorio!.Listar();

            // Verifica que la lista tenga al menos un elemento
            Assert.IsTrue(lista.Count > 0);
        }

        // Método que prueba la funcionalidad de buscar una coordenada por su ID
        public void Buscar()
        {
            // Busca una coordenada por su ID utilizando una expresión lambda
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la lista de resultados no esté vacía
            Assert.IsTrue(lista.Count > 0);
        }

        // Método que prueba la funcionalidad de modificar una coordenada
        private void Modificar()
        {
            // Modifica la latitud de la coordenada
            entidad!.Latitud = "333333";

            // Actualiza la coordenada en la base de datos
            entidad = iRepositorio!.Modificar(entidad!);

            // Busca la coordenada modificada por su ID
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la coordenada modificada aún exista en la base de datos
            Assert.IsTrue(lista.Count > 0);
        }

        // Método que prueba la funcionalidad de borrar una coordenada
        private void Borrar()
        {
            // Elimina la coordenada utilizando el repositorio
            entidad = iRepositorio!.Borrar(entidad!);

            // Intenta buscar la coordenada que fue eliminada por su ID
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la lista de resultados esté vacía, indicando que la coordenada fue eliminada
            Assert.IsTrue(lista.Count == 0);
        }
    }
}
