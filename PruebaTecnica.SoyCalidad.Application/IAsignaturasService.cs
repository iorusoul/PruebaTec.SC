using PruebaTecnica.SoyCalidad.Domain;

namespace PruebaTecnica.SoyCalidad.Application
{
    public interface IAsignaturasService
    {
        ValueTask<IEnumerable<Asignatura>?> ObtenerAsignaturasPorProgramaId(int _idPrograma);
        ValueTask<IEnumerable<Asignatura>?> ObtenerAsignaturasPorProgramaIdPaginado(int _idPrograma, int page = 1);
        ValueTask<int> ContarRegistrosDeAsignaturaPorIdPrograma(int _idPrograma);
    }
}