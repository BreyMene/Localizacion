using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;

namespace mst_pruebas.Repositorios
{
    // Clase de prueba unitaria para la funcionalidad de la entidad Departamentos
    [TestClass]
    public class DepartamentosPruebaUnitaria
    {
        // Instancia de IDepartamentosRepositorio para interactuar con la base de datos a trav�s del repositorio de departamentos
        private IDepartamentosRepositorio? iRepositorio = null;

        // Instancia de la entidad Departamentos que se utilizar� durante las pruebas
        private Departamentos? entidad = null;

        // Constructor de la clase de prueba unitaria
        public DepartamentosPruebaUnitaria()
        {
            // Crea una nueva conexi�n a la base de datos
            var conexion = new Conexion();

            // Establece la cadena de conexi�n a la base de datos SQL Server
            conexion.StringConnection = "server=localhost;database=db_Localizacion;Integrated Security=True;TrustServerCertificate=true;";

            // Inicializa el repositorio de departamentos con la conexi�n creada
            iRepositorio = new DepartamentosRepositorio(conexion);
        }

        // M�todo que ejecuta todas las pruebas unitarias para la entidad Departamentos
        [TestMethod]
        public void Ejecutar()
        {
            Guardar();   // Prueba para guardar un nuevo departamento
            Listar();    // Prueba para listar departamentos
            Buscar();    // Prueba para buscar un departamento 
            Modificar(); // Prueba para modificar un departamento
            Borrar();    // Prueba para borrar un departamento
        }

        // M�todo que prueba la funcionalidad de guardar un nuevo departamento
        private void Guardar()
        {
            // Crea una nueva instancia de la entidad Departamentos con nombre y pa�s
            entidad = new Departamentos()
            {
                Nombre = "bocaya",  // Nombre del departamento
                Pais = 1             // ID del pa�s al que pertenece
            };

            // Guarda la entidad en la base de datos usando el repositorio
            entidad = iRepositorio!.Guardar(entidad);

            // Verifica que el departamento haya sido guardado con un ID distinto de 0
            Assert.IsTrue(entidad.Id != 0);
        }

        // M�todo que prueba la funcionalidad de listar todos los departamentos
        private void Listar()
        {
            // Obtiene una lista de todos los departamentos
            var lista = iRepositorio!.Listar();

            // Verifica que la lista tenga al menos un elemento
            Assert.IsTrue(lista.Count > 0);
        }

        // M�todo que prueba la funcionalidad de buscar un departamento por su ID
        public void Buscar()
        {
            // Busca un departamento por su ID utilizando una expresi�n lambda
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la lista de resultados no est� vac�a
            Assert.IsTrue(lista.Count > 0);
        }

        // M�todo que prueba la funcionalidad de modificar un departamento
        private void Modificar()
        {
            // Modifica el nombre del departamento de "bocaya" a "Boyaca"
            entidad!.Nombre = "Boyaca";

            // Actualiza el departamento en la base de datos
            entidad = iRepositorio!.Modificar(entidad!);

            // Busca el departamento modificado por su ID
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que el departamento modificado a�n exista en la base de datos
            Assert.IsTrue(lista.Count > 0);
        }

        // M�todo que prueba la funcionalidad de borrar un departamento
        private void Borrar()
        {
            // Elimina el departamento utilizando el repositorio
            entidad = iRepositorio!.Borrar(entidad!);

            // Intenta buscar el departamento que fue eliminado por su ID
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);

            // Verifica que la lista de resultados est� vac�a, indicando que el departamento fue eliminado
            Assert.IsTrue(lista.Count == 0);
        }
    }
}
