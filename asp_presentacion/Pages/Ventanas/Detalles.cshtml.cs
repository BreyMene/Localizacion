using lib_entidades.Modelos;
using lib_presentaciones.Interfaces;
using lib_utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages.Ventanas
{
    public class DetallesModel : PageModel
    {
        private IDetallesPresentacion? iPresentacion = null;
        private IUsuariosPresentacion? iUsuariosPresentacion = null;
        private IUbicacionesPresentacion? iUbicacionesPresentacion = null;

        public DetallesModel(IDetallesPresentacion iPresentacion,
            IUsuariosPresentacion iUsuariosPresentacion,
            IUbicacionesPresentacion? iUbicacionesPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                this.iUsuariosPresentacion = iUsuariosPresentacion;
                this.iUbicacionesPresentacion = iUbicacionesPresentacion;
                Filtro = new Detalles();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }

        }

        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Detalles? Actual { get; set; }
        [BindProperty] public Detalles? Filtro { get; set; }
        [BindProperty] public List<Detalles>? Lista { get; set; }
        [BindProperty] public List<Usuarios>? Usuarios { get; set; }
        [BindProperty] public List<Ubicaciones>? Ubicaciones { get; set; }

        public virtual void OnGet() { OnPostBtRefrescar(); }

        public void OnPostBtRefrescar()
        {
            try
            {
                var variable_session = HttpContext.Session.GetString("key");
                if (String.IsNullOrEmpty(variable_session))
                    HttpContext.Session.SetString("key", "Pruebas");

                Filtro!.Fecha = Filtro!.Fecha ?? null;

                Accion = Enumerables.Ventanas.Listas;
                var task = this.iPresentacion!.Buscar(Filtro!, "FECHA");
                task.Wait();
                Lista = task.Result;

                CargarUsuarios();
                CargarUbicaciones();
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
                CargarUsuarios();
                CargarUbicaciones();
                Actual = new Detalles();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void CargarUsuarios()
        {
            try
            {
                if (!(Usuarios == null || Usuarios!.Count <= 0))
                    return;

                var task = this.iUsuariosPresentacion!.Listar();
                task.Wait();
                Usuarios = task.Result;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public string ConvertirUsuario(int id)
        {
            try
            {
                CargarUsuarios();
                return Usuarios!.FirstOrDefault(x => x.Id == id)!.Nombre!;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return string.Empty;
            }
        }
        public void CargarUbicaciones()
        {
            try
            {
                if (!(Ubicaciones == null || Ubicaciones!.Count <= 0))
                    return;

                var task = this.iUbicacionesPresentacion!.Listar();
                task.Wait();
                Ubicaciones = task.Result;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public string ConvertirUbicacion(int id)
        {
            try
            {
                CargarUsuarios();
                return Ubicaciones!.FirstOrDefault(x => x.Id == id)!.Nombre!;
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
                Task<Detalles>? task = null;
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