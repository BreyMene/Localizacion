
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Implementaciones
{
    public class CoordenadasAplicacion : ICoordenadasAplicacion
    {
        private ICoordenadasRepositorio? iRepositorio = null;

        public CoordenadasAplicacion(ICoordenadasRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Coordenadas Borrar(Coordenadas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Coordenadas Guardar(Coordenadas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Coordenadas> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Coordenadas> Buscar(Coordenadas entidad, string tipo)
        {
            Expression<Func<Coordenadas, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "LATITUD": condiciones = x => x.Latitud!.Contains(entidad.Latitud!); break;
                case "LONGITUD": condiciones = x => x.Longitud!.Contains(entidad.Longitud!); break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Coordenadas Modificar(Coordenadas entidad)
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