using lib_entidades;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface IPaisesAplicacion
    {
        void Configurar(string string_conexion);
        List<Paises> Buscar(Paises entidad, string tipo);
        List<Paises> Listar();
        Paises Guardar(Paises entidad);
        Paises Modificar(Paises entidad);
        Paises Borrar(Paises entidad);
    }
}