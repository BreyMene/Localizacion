using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Barrios
    {
        [Key] public int Id { get; set; } //Id de Barrio
        public string? Nombre { get; set; } //Nombre del Barrio
        public int Ciudad { get; set; } //ID de la ciudad a la que pertenece

        [ForeignKey("Ciudad")] public Ciudades? _Ciudad { get; set; } // Instancia a ciudad, no mapeada a la base de datos.
        [NotMapped] public virtual ICollection<Ubicaciones>? Ubicaciones { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre) || Ciudad == 0 )
                return false;
            return true;
        }
    }
}
