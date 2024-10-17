using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;

namespace mst_pruebas.Repositorios
{
    // Clase de prueba unitaria para la funcionalidad de la entidad Personas
    [TestClass]
    public class PersonasPruebaUnitaria
    {
        // Instancia de IPersonasRepositorio para interactuar con la base de datos a través del repositorio de personas
        private IPersonasRepositorio? iRepositorio = null;

        // Instancia de la entidad Personas que se utilizará durante las pruebas
        private Personas? entidad = null;

        // Constructor de la clase de prueba unitaria
        public PersonasPruebaUnitaria()
        {
            // Crea una nueva conexión a la base de datos
            var conexion = new Conexion();

            // Establece la cadena de conexión a la base de datos SQL Server
            conexion.StringConnection = "server=localhost;database=db_Localizacion;Integrated Security=True;TrustServerCertificate=true;";

            // Inicializa el repositorio de personas con la conexión creada
            iRepositorio = new PersonasRepositorio(conexion);
        }

        // Método que ejecuta todas las pruebas unitarias para la entidad Personas
        [TestMethod]
        public void Ejecutar()
        {
            Guardar();   // Prueba para guardar una nueva persona
            Listar();    // Prueba para listar todas las personas
            Buscar();    // Prueba para buscar una persona
            Modificar(); // Prueba para modificar los datos de una persona
            Borrar();    // Prueba para borrar una persona
        }

        // Método que prueba la funcionalidad de guardar una nueva persona
        private void Guardar()
        {
            // Crea una nueva instancia de la entidad Personas con la cédula, nombre y contraseña
            entidad = new Personas()
            {
                Cedula = "1111000",  // Cédula de la persona
                Nombre = "PRUEBA",    // Nombre de la persona
                Contrasena = "*****"  // Contraseña de la persona 
            };

            // Guarda la entidad en la base de datos usando el repositorio
            entidad = iRepositorio!.Guardar(entidad);

            // Verifica que la persona haya sido guardada con un ID distinto de 0
            Assert.IsTrue(entidad.Id != 0);
        }

        // Método que prueba la funcionalidad de listar todas las personas
        private void Listar()
        {
            // Obtiene una lista de todas las personas
            var lista = iRepositorio!.Listar();

            // Verifica que la lista tenga al menos un elemento
            Assert.IsTrue(lista.Count > 0);
        }

        // Método que prueba la funcionalidad de buscar una persona por su ID
        public void Buscar()
        {
            // Busca una persona por su ID utilizando una expresión lambda
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la lista de resultados no esté vacía
            Assert.IsTrue(lista.Count > 0);
        }

        // Método que prueba la funcionalidad de modificar los datos de una persona
        private void Modificar()
        {
            // Cambia el nombre de la persona de "PRUEBA" a "pepito"
            entidad!.Nombre = "pepito";

            // Actualiza la persona en la base de datos
            entidad = iRepositorio!.Modificar(entidad!);

            // Busca la persona modificada por su ID
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la persona modificada aún exista en la base de datos
            Assert.IsTrue(lista.Count > 0);
        }

        // Método que prueba la funcionalidad de borrar una persona
        private void Borrar()
        {
            // Elimina la persona utilizando el repositorio
            entidad = iRepositorio!.Borrar(entidad!);

            // Intenta buscar la persona que fue eliminada por su ID
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la lista de resultados esté vacía, indicando que la persona fue eliminada
            Assert.IsTrue(lista.Count == 0);
        }
    }
}
