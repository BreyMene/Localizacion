using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lib_entidades.Modelos
{
    public class Coordenadas
    {
        [Key] public int Id { get; set; } // Id de la coordenada (Llave)
        public string? Latitud { get; set; } // Latitud de la coordenada (de norte a sur)
        public string? Longitud { get; set; }//Longitud horizontal (De este a oeste)

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Latitud) || string.IsNullOrEmpty(Longitud))
                return false;
            return true;
        }
    }
}

