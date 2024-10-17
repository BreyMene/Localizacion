using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;

namespace mst_pruebas.Repositorios
{
    // Clase de prueba unitaria para la funcionalidad de la entidad Ciudades
    [TestClass]
    public class CiudadesPruebaUnitaria
    {
        // Instancia de ICiudadesRepositorio para interactuar con la base de datos a través del repositorio de ciudades
        private ICiudadesRepositorio? iRepositorio = null;

        // Instancia de la entidad Ciudades que se utilizará durante las pruebas
        private Ciudades? entidad = null;

        // Constructor de la clase de prueba unitaria
        public CiudadesPruebaUnitaria()
        {
            // Crea una nueva conexión a la base de datos
            var conexion = new Conexion();

            // Establece la cadena de conexión a la base de datos SQL Server
            conexion.StringConnection = "server=localhost;database=db_Localizacion;Integrated Security=True;TrustServerCertificate=true;";

            // Inicializa el repositorio de ciudades con la conexión creada
            iRepositorio = new CiudadesRepositorio(conexion);
        }

        // Método que ejecuta todas las pruebas unitarias para la entidad Ciudades
        [TestMethod]
        public void Ejecutar()
        {
            Guardar();   // Prueba para guardar una ciudad
            Listar();    // Prueba para listar ciudades
            Buscar();    // Prueba para buscar una ciudad
            Modificar(); // Prueba para modificar una ciudad
            Borrar();    // Prueba para borrar una ciudad
        }

        // Método que prueba la funcionalidad de guardar una nueva ciudad
        private void Guardar()
        {
            // Crea una nueva instancia de la entidad Ciudades con nombre y departamento
            entidad = new Ciudades()
            {
                Nombre = "bolee",    // Nombre de la ciudad
                Departamento = 1     // ID del departamento al que pertenece
            };

            // Guarda la entidad en la base de datos usando el repositorio
            entidad = iRepositorio!.Guardar(entidad);

            // Verifica que la ciudad haya sido guardada con un ID distinto de 0
            Assert.IsTrue(entidad.Id != 0);
        }

        // Método que prueba la funcionalidad de listar todas las ciudades
        private void Listar()
        {
            // Obtiene una lista de todas las ciudades
            var lista = iRepositorio!.Listar();

            // Verifica que la lista tenga al menos un elemento
            Assert.IsTrue(lista.Count > 0);
        }

        // Método que prueba la funcionalidad de buscar una ciudad por su ID
        public void Buscar()
        {
            // Busca una ciudad por su ID utilizando una expresión lambda
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la lista de resultados no esté vacía
            Assert.IsTrue(lista.Count > 0);
        }

        // Método que prueba la funcionalidad de modificar una ciudad
        private void Modificar()
        {
            // Modifica el nombre de la ciudad de "bolee" a "Bello"
            entidad!.Nombre = "Bello";

            // Actualiza la ciudad en la base de datos
            entidad = iRepositorio!.Modificar(entidad!);

            // Busca la ciudad modificada por su ID
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la ciudad modificada aún exista en la base de datos
            Assert.IsTrue(lista.Count > 0);
        }

        // Método que prueba la funcionalidad de borrar una ciudad
        private void Borrar()
        {
            // Elimina la ciudad utilizando el repositorio
            entidad = iRepositorio!.Borrar(entidad!);

            // Intenta buscar la ciudad que fue eliminada por su ID
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la lista de resultados esté vacía, indicando que la ciudad fue eliminada
            Assert.IsTrue(lista.Count == 0);
        }
    }
}
