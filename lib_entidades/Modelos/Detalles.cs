using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace lib_entidades.Modelos
{

    public class Detalles
    {
        List<Detalles> detallesUsuario = new List<Detalles>();

        [Key] public int Id { get; set; } // Id del Detalle (Llave)
        public DateTime? Fecha { get; set; }// Fecha del detalle
        public int Ubicacion { get; set; }//Id de la ubicacion a la que pertenece
        public int Usuario { get; set; }// Id del Usuario a la que pertenece

        [NotMapped] public Ubicaciones? _Ubicacion { get; set; }// Instancia a Ubicaciones, no mapeada a la base de datos.
        [NotMapped] public Usuarios? _Usuario { get; set; }// Instancia a Usuarios, no mapeada a la base de datos.

        public bool Validar()
        {
            if (Fecha == null || Ubicacion == 0
                || Usuario == 0)
                return false;
            return true;
        }

        /*-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-*
         *                                 *
         * Metodos funcionales de Detalles *
         *                                 *
         *-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-*/

        /*
         * 1. Metodo "DetallesUsuario", recibe la lista de detalles y el id de una Usuario,
         * retorna string con los detalles que tiene el Usuario
         */
        public string DetallesUsuario(List<Detalles> lista, int id)
        {
            //Se crea una variable string para almacenar los detalles
            string text = "";
            
            //se recorre la lista de detalles
            foreach (Detalles item in lista) 
            {
                //Si el detalle tiene el mismo id de Usuario que el necesitado se añade al texto
                if (item.Usuario == id) 
                    text += $"Id: {item.Id} \nFecha {item.Fecha} \nUbicacion {item.Ubicacion} \n\n";
            }

            /*Validacion de datos, si la variable text esta vacia, se da el mensaje de no tener detalles,
             de lo contrario, se envia el texto*/
            if (text.Equals(""))
                return ($"El Usuario con Id {id} no tiene detalles");
            else
                return ($"El Usuario con Id {id}, tiene los siguientes detalles:\n" + text);
        }

        /*
         * 2. Metodo "CalcularAntiguedad" recibe una Fecha 
         * y compara los dias que hay entre esta y el dia actual
         */
        public int CalcularAntiguedad(DateTime FechaCreacion)
        {
            //se toma la fecha actual y se compara con la fecha de creacion, se retornan los dias entre estos
            return (DateTime.Now - FechaCreacion).Days;
        }

    }
}
