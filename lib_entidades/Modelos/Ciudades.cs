using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Ciudades
    {
        [Key] public int Id { get; set; } //Id de la Ciudad (Llave)
        public string? Nombre { get; set; }// Nombre de la Ciudad
        public int Departamento { get; set; }// Id del departamento al que pertenece 

        [NotMapped] public Departamentos? _Departamento { get; set; } // Instancia a Departamentos, no mapeada a la base de datos.

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre) || Departamento == 0)
                return false;
            return true;
        }
    }
}
