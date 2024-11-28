﻿using lib_comunicaciones.Interfaces;

namespace lib_comunicaciones.Implementaciones
{
    public class AuditoriasComunicacion : IAuditoriasComunicacion
    {
        private Comunicaciones? comunicaciones = null;
        private string? Nombre = "Auditorias";

        public AuditoriasComunicacion()
        {
            comunicaciones = new Comunicaciones(Nombre);
        }

        public async Task<Dictionary<string, object>> Buscar(Dictionary<string, object> datos)
        {
            datos = comunicaciones!.BuildUrl(datos, "Buscar");
            return await comunicaciones!.Execute(datos);
        }

        public async Task<Dictionary<string, object>> Listar(Dictionary<string, object> datos)
        {
            datos = comunicaciones!.BuildUrl(datos, "Listar");
            return await comunicaciones!.Execute(datos);
        }
    }
}