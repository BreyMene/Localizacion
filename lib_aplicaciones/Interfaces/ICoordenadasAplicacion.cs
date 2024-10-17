using lib_entidades;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface ICoordenadasAplicacion
    {
        void Configurar(string string_conexion);
        List<Coordenadas> Buscar(Coordenadas entidad, string tipo);
        List<Coordenadas> Listar();
        Coordenadas Guardar(Coordenadas entidad);
        Coordenadas Modificar(Coordenadas entidad);
        Coordenadas Borrar(Coordenadas entidad);
    }
}