
using lib_entidades.Modelos;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace asp_presentacion.Pages.Ventanas
{
    public class MapaModel : PageModel
    {
        private readonly ICoordenadasPresentacion _iCoordenadasPresentacion;

        // Lista de coordenadas obtenidas de la base de datos
        public List<Coordenadas>? ListaCoordenadas { get; private set; }

        public MapaModel(ICoordenadasPresentacion iCoordenadasPresentacion)
        {
            _iCoordenadasPresentacion = iCoordenadasPresentacion;
        }

        public void OnGet()
        {
            try
            {
                // Inicializamos el filtro para buscar todas las coordenadas
                var filtro = new Coordenadas { Latitud = string.Empty };

                // Ejecuta la b�squeda de coordenadas en la base de datos
                var task = _iCoordenadasPresentacion.Buscar(filtro, "LATITUD");
                task.Wait();
                ListaCoordenadas = task.Result;

                // Verificaci�n para depuraci�n (para asegurar que los datos no son null o vac�os)
                if (ListaCoordenadas == null || ListaCoordenadas.Count == 0)
                {
                    Console.WriteLine("No se encontraron coordenadas.");
                }
            }
            catch (Exception ex)
            {
                // Si hay un error, se maneja y se establece una lista vac�a
                ListaCoordenadas = new List<Coordenadas>();
                Console.WriteLine($"Error al obtener coordenadas: {ex.Message}");
            }
        }

    }
}
