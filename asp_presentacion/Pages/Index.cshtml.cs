using lib_entidades.Modelos;
using lib_presentaciones.Interfaces;
using lib_utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace asp_presentacion.Pages
{
    public class IndexModel : PageModel
    {
        private IUsuariosPresentacion? iUsuariosPresentacion = null;

        public IndexModel(IUsuariosPresentacion iUsuariosPresentacion)
        {
            try
            {
                this.iUsuariosPresentacion = iUsuariosPresentacion;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        [BindProperty] public List<Usuarios>? Usuarios { get; set; }

        public bool EstaLogueado = false;
        [BindProperty] public string? Email { get; set; }
        [BindProperty] public string? Contrase�a { get; set; }

        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");
            if (!String.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
                return;
            }
        }

        public void OnPostBtClean()
        {
            try
            {
                Email = string.Empty;
                Contrase�a = string.Empty;
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
        public string ConvertirUsuario(string Nombre)
        {
            try
            {
                CargarUsuarios();
                return Usuarios!.FirstOrDefault(x => x.Nombre == Nombre)!.Contrasena!;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return string.Empty;
            }
        }
        public void OnPostBtEnter()
        {
            try
            {
                if (string.IsNullOrEmpty(Email) &&
                    string.IsNullOrEmpty(Contrase�a))
                {
                    OnPostBtClean();
                    return;
                }
                CargarUsuarios();
                if (ConvertirUsuario(Email) != Contrase�a)
                {
                    OnPostBtClean();
                    return;
                }
                ViewData["Logged"] = true;
                HttpContext.Session.SetString("Usuario", Email!);
                EstaLogueado = true;
                OnPostBtClean();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}