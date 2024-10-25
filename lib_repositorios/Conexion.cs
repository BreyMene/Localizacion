using lib_entidades.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace lib_repositorios
{
    // La clase Conexion hereda de DbContext, lo que permite gestionar la conexión a la base de datos
    public partial class Conexion : DbContext
    {
        // Define el número máximo de registros que se tomarán en las consultas
        private int tamaño = 20;

        // Propiedad para almacenar la cadena de conexión a la base de datos
        public string? StringConnection { get; set; }

        // Configuración del contexto de la base de datos (usando SQL Server y sin seguimiento de cambios)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configura el contexto para usar SQL Server con la cadena de conexión proporcionada
            optionsBuilder.UseSqlServer(this.StringConnection!, p => { });

            // Desactiva el seguimiento de cambios en las consultas para mejorar el rendimiento en lecturas
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        // Define los conjuntos de datos (tablas) del contexto, cada uno mapeado a una entidad
        protected DbSet<Barrios>? Barrios { get; set; }
        protected DbSet<Ciudades>? Ciudades { get; set; }
        protected DbSet<Departamentos>? Departamentos { get; set; }
        protected DbSet<Paises>? Paises { get; set; }
        protected DbSet<Coordenadas>? Coordenadas { get; set; }
        protected DbSet<Usuarios>? Usuarios { get; set; }
        protected DbSet<Ubicaciones>? Ubicaciones { get; set; }
        protected DbSet<Detalles>? Detalles { get; set; }

        // Método genérico para obtener un DbSet de cualquier entidad T (mapea la entidad con su tabla en la BD)
        public virtual DbSet<T> ObtenerSet<T>() where T : class, new()
        {
            return this.Set<T>();
        }

        // Método genérico para listar un máximo de "tamaño" registros de cualquier entidad T
        public virtual List<T> Listar<T>() where T : class, new()
        {
            return this.Set<T>()
                .Take(tamaño) // Limita el número de registros a "tamaño"
                .ToList();    // Convierte los resultados en una lista
        }

        // Método genérico para buscar registros de cualquier entidad T que cumplan con las condiciones especificadas
        public virtual List<T> Buscar<T>(Expression<Func<T, bool>> condiciones) where T : class, new()
        {
            return this.Set<T>()
                .Where(condiciones)  // Filtra según las condiciones
                .Take(tamaño)        // Limita el número de registros a "tamaño"
                .ToList();           // Convierte los resultados en una lista
        }

        // Método genérico para verificar si existe algún registro de la entidad T que cumpla con las condiciones especificadas
        public virtual bool Existe<T>(Expression<Func<T, bool>> condiciones) where T : class, new()
        {
            return this.Set<T>().Any(condiciones);  // Retorna true si existe al menos un registro que cumple las condiciones
        }

        // Método genérico para agregar una nueva entidad a la base de datos
        public virtual void Guardar<T>(T entidad) where T : class, new()
        {
            this.Set<T>().Add(entidad);  // Agrega la entidad al contexto para su inserción en la base de datos
        }

        // Método genérico para marcar una entidad existente como modificada
        public virtual void Modificar<T>(T entidad) where T : class
        {
            var entry = this.Entry(entidad);  // Obtiene la entrada (entry) de la entidad en el contexto
            entry.State = EntityState.Modified;  // Marca la entidad como modificada
        }

        // Método genérico para eliminar una entidad de la base de datos
        public virtual void Borrar<T>(T entidad) where T : class, new()
        {
            this.Set<T>().Remove(entidad);  // Elimina la entidad del contexto
        }

        // Método para separar o desvincular una entidad del contexto (deshacer seguimiento de cambios)
        public virtual void Separar<T>(T entidad) where T : class, new()
        {
            this.Entry(entidad).State = EntityState.Detached;  // Marca la entidad como no rastreada
        }

        // Método para guardar todos los cambios realizados en el contexto en la base de datos
        public virtual void GuardarCambios()
        {
            this.SaveChanges();  // Aplica todos los cambios pendientes en la base de datos
        }
    }
}
