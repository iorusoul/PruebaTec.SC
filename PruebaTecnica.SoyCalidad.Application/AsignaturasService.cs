using PruebaTecnica.SoyCalidad.Domain.Interfaces;
using PruebaTecnica.SoyCalidad.Domain;

namespace PruebaTecnica.SoyCalidad.Application
{
    public class AsignaturasService : IAsignaturasService
    {
        private readonly IAsignaturaRepo _asignaturaRepo;
        public AsignaturasService(IAsignaturaRepo signaturaRepo)
        {
            _asignaturaRepo = signaturaRepo;
        }
        public async ValueTask<IEnumerable<Asignatura>?> ObtenerAsignaturasPorProgramaId(int _idPrograma)
        {
            var lista = await _asignaturaRepo.ObtenerAsignaturasPorIdPrograma(_idPrograma);
            return lista;
        }

        public async ValueTask<IEnumerable<Asignatura>?> ObtenerAsignaturasPorProgramaIdPaginado(int _idPrograma,int page =1)
        {
            var lista = await _asignaturaRepo.ObtenerAsignaturasPorIdProgramaPaginado(_idPrograma,5,page);
            return lista;
        }

        public async ValueTask<int> ContarRegistrosDeAsignaturaPorIdPrograma(int _idPrograma)
        {
            var conteo = await _asignaturaRepo.ContarRegistrosAsignaturaPorProgramaId(_idPrograma);
            return conteo;
        }
    }
}