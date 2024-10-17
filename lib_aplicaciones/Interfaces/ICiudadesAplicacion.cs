using lib_entidades;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface ICiudadesAplicacion
    {
        void Configurar(string string_conexion);
        List<Ciudades> Buscar(Ciudades entidad, string tipo);
        List<Ciudades> Listar();
        Ciudades Guardar(Ciudades entidad);
        Ciudades Modificar(Ciudades entidad);
        Ciudades Borrar(Ciudades entidad);
    }
}