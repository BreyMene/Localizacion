using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Paises
    {
        [Key] public int Id { get; set; } //Id del Pais (Llave)
        public string? Nombre { get; set; } // Nombre del Pais

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
                return false;
            return true;
        }
    }
}


