using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Ubicaciones
    {
        [Key] public int Id { get; set; }// Id de la ubicación (Llave)
        public string? Descripcion { get; set; } //Descripcion de la ubicacion
        public string? Imagen { get; set; } // Imagen de la ubicacion (Aún no definido tipo)
        public string? Nombre { get; set; } // Nombre de la Ubicación
        public int Barrio { get; set; } //Id del Barrio al que pertenece
        public int Coordenada { get; set; } // Id de la coordenada a la que pertenece

        [ForeignKey("Barrio")] public Barrios? _Barrio{ get; set; }
        [ForeignKey("Coordenada")] public Barrios? _Coordenada { get; set; }// Instancia a Coordenadas, no mapeada a la base de datos.

        [NotMapped] public virtual ICollection<Detalles>? Detalles { get; set; }
        public bool Validar()
        {
            if (string.IsNullOrEmpty(Descripcion) ||
                string.IsNullOrEmpty(Imagen) ||
                string.IsNullOrEmpty(Nombre))
                return false;
            if(Barrio == 0 || Coordenada == 0)
                return false;
            return true;
        }
        /*-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|*
         *                                    *
         * Metodos funcionales de Ubicaciones *
         *                                    *
         *-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|*/


        //1. Metodo "ToString", retorna un string con las caracteristicas de la ubicacion
        public override string ToString()
        {
            return $"Id: {Id} \nDetalle: {Nombre} \nDescripción: {Descripcion} \nBarrio ID: {Barrio} \nCoordenada ID: {Coordenada}";
        }

        /*2. Metodo "UbicacionesBarrio" genera una lista 
         la cual contiene las ubicaciones que se encuentran en un barrio definido*/
        public List<Ubicaciones> UbicacionesBarrio(List<Ubicaciones> lista, int barrio)
        {
            //Se crea una lista para almacenar las Ubicaciones
            List<Ubicaciones> list = new List<Ubicaciones>();

            //se recorre la lista de Ubicaciones
            foreach (Ubicaciones item in lista)
            {
                //Si la Ubicación tiene el mismo id de Barrio que el necesitado se añade a la lista
                if (item.Barrio == barrio)
                    list.Add(item);
            }
            //Se retorna la lista
            return list;
        }
    }

}