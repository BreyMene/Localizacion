using lib_comunicaciones.Interfaces;
using lib_entidades.Modelos;
using lib_presentaciones.Interfaces;
using lib_utilidades;

namespace lib_presentaciones.Implementaciones
{
    public class BarriosPresentacion : IBarriosPresentacion
    {
        private IBarriosComunicacion? iComunicacion = null;

        public BarriosPresentacion(IBarriosComunicacion iComunicacion)
        {
            this.iComunicacion = iComunicacion;
        }

        public async Task<List<Barrios>> Listar()
        {
            var lista = new List<Barrios>();
            var datos = new Dictionary<string, object>();

            var respuesta = await iComunicacion!.Listar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Barrios>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<List<Barrios>> Buscar(Barrios entidad, string tipo)
        {
            var lista = new List<Barrios>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;
            datos["Tipo"] = tipo;

            var respuesta = await iComunicacion!.Buscar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Barrios>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<Barrios> Guardar(Barrios entidad)
        {
            if (entidad.Id != 0 || !entidad.Validar())
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            var respuesta = await iComunicacion!.Guardar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Barrios>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<Barrios> Modificar(Barrios entidad)
        {
            if (entidad.Id == 0 || !entidad.Validar())
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            var respuesta = await iComunicacion!.Modificar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Barrios>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<Barrios> Borrar(Barrios entidad)
        {
            if (entidad.Id == 0 || !entidad.Validar())
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            var respuesta = await iComunicacion!.Borrar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Barrios>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}