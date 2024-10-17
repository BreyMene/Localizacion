using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Personas
    {
        [Key] public int Id { get; set; } // Id de la persona (Llave)
        public string? Cedula { get; set; } //Cedula de la persona
        public string? Nombre { get; set; }// Nombre de la persona
        public string? Contrasena { get; set; } //Contraseña de la persona (tipo password)

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Cedula) || 
                string.IsNullOrEmpty(Nombre) ||
                string.IsNullOrEmpty(Contrasena))
                return false;
            return true;
        }
    }
}
