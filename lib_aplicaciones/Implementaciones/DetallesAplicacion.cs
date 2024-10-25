
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Implementaciones
{
    public class DetallesAplicacion : IDetallesAplicacion
    {
        private IDetallesRepositorio? iRepositorio = null;

        public DetallesAplicacion(IDetallesRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Detalles Borrar(Detalles entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Detalles Guardar(Detalles entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Detalles> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Detalles> Buscar(Detalles entidad, string tipo)
        {
            Expression<Func<Detalles, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "USUARIO": condiciones = x => x.Usuario == entidad.Usuario; break;
                case "FECHA": condiciones = x => x.Fecha == entidad.Fecha; break;
                case "UBICACION": condiciones = x => x.Ubicacion == entidad.Ubicacion; break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Detalles Modificar(Detalles entidad)
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