using lib_entidades.Modelos;
using lib_presentaciones.Interfaces;
using lib_utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages.Ventanas
{
    public class UbicacionesModel : PageModel
    {
        private IUbicacionesPresentacion? iPresentacion = null;
        private IBarriosPresentacion? iBarriosPresentacion = null;
        private ICoordenadasPresentacion? iCoordenadasPresentacion = null;

        public UbicacionesModel(IUbicacionesPresentacion iPresentacion,
            IBarriosPresentacion iBarriosPresentacion,
            ICoordenadasPresentacion? iCoordenadasPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                this.iBarriosPresentacion = iBarriosPresentacion;
                this.iCoordenadasPresentacion = iCoordenadasPresentacion;
                Filtro = new Ubicaciones();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }

        }

        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Ubicaciones? Actual { get; set; }
        [BindProperty] public Ubicaciones? Filtro { get; set; }
        [BindProperty] public List<Ubicaciones>? Lista { get; set; }
        [BindProperty] public List<Barrios>? Barrios { get; set; }
        [BindProperty] public List<Coordenadas>? Coordenadas { get; set; }

        public virtual void OnGet() { OnPostBtRefrescar(); }

        public void OnPostBtRefrescar()
        {
            try
            {
                var variable_session = HttpContext.Session.GetString("key");
                if (String.IsNullOrEmpty(variable_session))
                    HttpContext.Session.SetString("key", "Pruebas");

                Filtro!.Nombre = Filtro!.Nombre ?? "";

                Accion = Enumerables.Ventanas.Listas;
                var task = this.iPresentacion!.Buscar(Filtro!, "NOMBRE");
                task.Wait();
                Lista = task.Result;
                CargarBarrios();
                CargarCoordenadas();
                Actual = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtNuevo()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;
                CargarBarrios();
                CargarCoordenadas();
                Actual = new Ubicaciones();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void CargarBarrios()
        {
            try
            {
                if (!(Barrios == null || Barrios!.Count <= 0))
                    return;

                var task = this.iBarriosPresentacion!.Listar();
                task.Wait();
                Barrios = task.Result;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public string ConvertirBarrio(int id)
        {
            try
            {
                CargarBarrios();
                return Barrios!.FirstOrDefault(x => x.Id == id)!.Nombre!;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return string.Empty;
            }
        }
        public void CargarCoordenadas()
        {
            try
            {
                if (!(Coordenadas == null || Coordenadas!.Count <= 0))
                    return;

                var task = this.iCoordenadasPresentacion!.Listar();
                task.Wait();
                Coordenadas = task.Result;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public string ConvertirCoordenada(int id)
        {
            try
            {
                CargarCoordenadas();
                var coordenada = Coordenadas!.FirstOrDefault(x => x.Id == id);
                return coordenada != null ? $"{coordenada.Latitud}, {coordenada.Longitud}" : string.Empty;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return string.Empty;
            }
        }

        public virtual void OnPostBtModificar(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Editar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtGuardar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;
                if (FormFile != null)
                {
                    var memoryStream = new MemoryStream();
                    FormFile.CopyToAsync(memoryStream).Wait();
                    Actual!.Imagen = EncodingHelper.ToString(memoryStream.ToArray());
                    memoryStream.Dispose();
                }
                Task<Ubicaciones>? task = null;
                if (Actual!.Id == 0)
                    task = this.iPresentacion!.Guardar(Actual!);
                else
                    task = this.iPresentacion!.Modificar(Actual!);
                task.Wait();
                Actual = task.Result;
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrarVal(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Borrar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrar()
        {
            try
            {
                var task = this.iPresentacion!.Borrar(Actual!);
                Actual = task.Result;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCancelar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCerrar()
        {
            try
            {
                if (Accion == Enumerables.Ventanas.Listas)
                    OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

    }
}