using lib_entidades;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface IAuditoriasAplicacion
    {
        void Configurar(string string_conexion);
        List<Auditorias> Buscar(Auditorias entidad, string tipo);
        List<Auditorias> Listar();
        Auditorias Guardar(Auditorias entidad);
    }
}