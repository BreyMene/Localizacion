using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Departamentos
    {
        [Key] public int Id { get; set; } //Id del departamento (Llave)
        public string? Nombre { get; set; }// Nombre del departamento
        public int Pais { get; set; }// Id del pais al que pertenece

        [NotMapped] public virtual ICollection<Ciudades>? Ciudades { get; set; }
        [ForeignKey("Pais")] public Paises? _Pais { get; set; } // Instancia a Paises

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre) || Pais == 0)
                return false;
            return true;
        }
    }
}
