using asp_servicios.Nucleo;
using lib_aplicaciones.Interfaces;
using lib_entidades.Modelos;
using lib_utilidades;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CoordenadasController : ControllerBase
    {
        private string Tabla = "Coordenadas";
        private ICoordenadasAplicacion? iAplicacion = null;
        private TokenController? tokenController = null;
        private IAuditoriasAplicacion? Auditoria = null;

        public CoordenadasController(ICoordenadasAplicacion? iAplicacion,
            TokenController tokenController, IAuditoriasAplicacion Auditoria)
        {
            this.iAplicacion = iAplicacion;
            this.tokenController = tokenController;
            this.Auditoria = Auditoria;
        }

        private Dictionary<string, object> ObtenerDatos()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = new StreamReader(Request.Body).ReadToEnd().ToString();
                if (string.IsNullOrEmpty(datos))
                    datos = "{}";
                return JsonConversor.ConvertirAObjeto(datos);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return respuesta;
            }
        }

        [HttpPost]
        public string Listar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("ConectionString"));
                respuesta["Entidades"] = this.iAplicacion!.Listar();

                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();

                this.Auditoria!.Guardar(new Auditorias() { Tabla = Tabla, Referencia = "Elementos listados", Accion = "Listar", Fecha = DateTime.Now });

                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Buscar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                var entidad = JsonConversor.ConvertirAObjeto<Coordenadas>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));
                var tipo = datos["Tipo"].ToString();

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("ConectionString"));
                respuesta["Entidades"] = this.iAplicacion!.Buscar(entidad, tipo);

                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();

                this.Auditoria!.Guardar(new Auditorias() { Tabla = Tabla, Referencia = entidad.Id.ToString(), Accion = "Buscar", Fecha = DateTime.Now });

                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Guardar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                var entidad = JsonConversor.ConvertirAObjeto<Coordenadas>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("ConectionString"));
                entidad = this.iAplicacion!.Guardar(entidad);

                respuesta["Entidad"] = entidad;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();

                this.Auditoria!.Guardar(new Auditorias() { Tabla = Tabla, Referencia = entidad.Id.ToString(), Accion = "Guardar", Fecha = DateTime.Now });

                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Modificar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                var entidad = JsonConversor.ConvertirAObjeto<Coordenadas>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("ConectionString"));
                entidad = this.iAplicacion!.Modificar(entidad);

                respuesta["Entidad"] = entidad;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();

                this.Auditoria!.Guardar(new Auditorias() { Tabla = Tabla, Referencia = entidad.Id.ToString(), Accion = "Modificar", Fecha = DateTime.Now });
                
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Borrar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                var entidad = JsonConversor.ConvertirAObjeto<Coordenadas>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("ConectionString"));
                entidad = this.iAplicacion!.Borrar(entidad);

                respuesta["Entidad"] = entidad;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();

                this.Auditoria!.Guardar(new Auditorias() { Tabla = Tabla, Referencia = entidad.Id.ToString(), Accion = "Borrar", Fecha = DateTime.Now });
                
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }
    }
}