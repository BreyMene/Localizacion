using lib_entidades;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface IBarriosAplicacion
    {
        void Configurar(string string_conexion);
        List<Barrios> Buscar(Barrios entidad, string tipo);
        List<Barrios> Listar();
        Barrios Guardar(Barrios entidad);
        Barrios Modificar(Barrios entidad);
        Barrios Borrar(Barrios entidad);
    }
}