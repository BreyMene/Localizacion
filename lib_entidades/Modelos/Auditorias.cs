using System;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lib_entidades.Modelos
{
    public class Auditorias
    {
        [Key] public int Id { get; set; } //Id de Auditoria
        public string? Tabla { get; set; } //Nombre de la Tabla
        public string? Referencia { get; set; } //Nombre de la Tabla
        public string? Accion { get; set; } //Accion del metodo
        public DateTime? Fecha { get; set; } //Fecha de la Auditoria

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Tabla) ||
                string.IsNullOrEmpty(Referencia) ||
                string.IsNullOrEmpty(Accion) ||
                Fecha == null)
                return false;
            return true;
        }
    }
}