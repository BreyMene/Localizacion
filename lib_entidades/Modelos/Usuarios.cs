using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Usuarios
    {
        [Key] public int Id { get; set; } // Id del Usuario (Llave)
        public string? Cedula { get; set; } //Cedula delUsuario
        public string? Nombre { get; set; }// Nombre del Usuario
        public string? Contrasena { get; set; } //Contraseña del Usuario (tipo password)
        public string? Rol { get; set; } // Rol del usuario (administrador, comun)

        public bool Validar() // metodo que valida si alguno de los campos de la entidad es nulo o vacio
        {
            if (string.IsNullOrEmpty(Cedula) || 
                string.IsNullOrEmpty(Nombre) ||
                string.IsNullOrEmpty(Contrasena))
                return false;
            return true;
        }
    }
}
