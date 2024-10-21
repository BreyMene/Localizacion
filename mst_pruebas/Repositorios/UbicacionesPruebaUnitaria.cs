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
        // Instancia de IUbicacionesRepositorio para interactuar con la base de datos a trav�s del repositorio de ubicaciones
        private IUbicacionesRepositorio? iRepositorio = null;

        // Instancia de la entidad Ubicaciones que se utilizar� durante las pruebas
        private Ubicaciones? entidad = null;

        // Constructor de la clase de prueba unitaria
        public UbicacionesPruebaUnitaria()
        {
            // Crea una nueva conexi�n a la base de datos
            var conexion = new Conexion();

            // Establece la cadena de conexi�n a la base de datos SQL Server
            conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");

            // Inicializa el repositorio de ubicaciones con la conexi�n creada
            iRepositorio = new UbicacionesRepositorio(conexion);
        }

        // M�todo que ejecuta todas las pruebas unitarias para la entidad Ubicaciones
        [TestMethod]
        public void Ejecutar()
        {
            Guardar();   // Prueba para guardar una nueva ubicaci�n
            Listar();    // Prueba para listar ubicaciones
            Buscar();    // Prueba para buscar una ubicaci�n
            Modificar(); // Prueba para modificar una ubicaci�n
            Borrar();    // Prueba para borrar una ubicaci�n
        }

        // M�todo que prueba la funcionalidad de guardar una nueva ubicaci�n
        private void Guardar()
        {
            // Crea una nueva instancia de la entidad Ubicaciones con sus propiedades
            entidad = new Ubicaciones()
            {
                Descripcion = "pruebaaaa", // Descripci�n de la ubicaci�n
                Imagen = "imagenPrueba",    // Nombre de la imagen asociada a la ubicaci�n
                Nombre = "test",            // Nombre de la ubicaci�n
                Barrio = 3,                 // ID del barrio al que pertenece
                Coordenada = 2              // ID de la coordenada asociada
            };

            // Guarda la entidad en la base de datos usando el repositorio
            entidad = iRepositorio!.Guardar(entidad);

            // Verifica que la ubicaci�n haya sido guardada con un ID distinto de 0
            Assert.IsTrue(entidad.Id != 0);
        }

        // M�todo que prueba la funcionalidad de listar todas las ubicaciones
        private void Listar()
        {
            // Obtiene una lista de todas las ubicaciones
            var lista = iRepositorio!.Listar();

            // Verifica que la lista tenga al menos un elemento
            Assert.IsTrue(lista.Count > 0);
        }

        // M�todo que prueba la funcionalidad de buscar una ubicaci�n por su ID
        public void Buscar()
        {
            // Busca una ubicaci�n por su ID utilizando una expresi�n lambda
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la lista de resultados no est� vac�a
            Assert.IsTrue(lista.Count > 0);
        }

        // M�todo que prueba la funcionalidad de modificar una ubicaci�n
        private void Modificar()
        {
            // Modifica el nombre de la ubicaci�n
            entidad!.Nombre = "Prueba";

            // Actualiza la ubicaci�n en la base de datos
            entidad = iRepositorio!.Modificar(entidad!);

            // Busca la ubicaci�n modificada por su ID
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la ubicaci�n modificada a�n exista en la base de datos
            Assert.IsTrue(lista.Count > 0);
        }

        // M�todo que prueba la funcionalidad de borrar una ubicaci�n
        private void Borrar()
        {
            // Elimina la ubicaci�n utilizando el repositorio
            entidad = iRepositorio!.Borrar(entidad!);

            // Intenta buscar la ubicaci�n que fue eliminada por su ID
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la lista de resultados est� vac�a, indicando que la ubicaci�n fue eliminada
            Assert.IsTrue(lista.Count == 0);
        }
    }
}
