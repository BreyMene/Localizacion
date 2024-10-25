
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Implementaciones
{
    public class UbicacionesAplicacion : IUbicacionesAplicacion
    {
        private IUbicacionesRepositorio? iRepositorio = null;

        public UbicacionesAplicacion(IUbicacionesRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Ubicaciones Borrar(Ubicaciones entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Ubicaciones Guardar(Ubicaciones entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Ubicaciones> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Ubicaciones> Buscar(Ubicaciones entidad, string tipo)
        {
            Expression<Func<Ubicaciones, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "NOMBRE": condiciones = x => x.Nombre!.Contains(entidad.Nombre!); break;
                case "DESCRIPCION": condiciones = x => x.Descripcion!.Contains(entidad.Descripcion!); break;
                case "BARRIO": condiciones = x => x.Barrio == entidad.Barrio; break;
                case "COORDENADA": condiciones = x => x.Coordenada== entidad.Coordenada; break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Ubicaciones Modificar(Ubicaciones entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }

    }
}