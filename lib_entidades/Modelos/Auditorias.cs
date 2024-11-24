using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    internal class Auditorias
    {
        [Key] public int Id { get; set; } //Id de Auditoria
        public string? Tabla { get; set; } //Nombre de la Tabla
        public string? Referencia { get; set; } //Nombre de la Tabla
        public string? Accion { get; set; } //Accion del metodo
        public DateTime? Fecha { get; set; } //Fecha de la Auditoria
    }
}
