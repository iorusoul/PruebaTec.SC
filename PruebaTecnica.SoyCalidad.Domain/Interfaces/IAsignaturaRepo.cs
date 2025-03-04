namespace PruebaTecnica.SoyCalidad.Domain.Interfaces
{
    public interface IAsignaturaRepo
    {
        public ValueTask<IEnumerable<Asignatura>?> ObtenerAsignaturasPorIdPrograma(int _id);
        public ValueTask<IEnumerable<Asignatura>?> ObtenerAsignaturasPorIdProgramaPaginado(int _id, int size = 5, int pageN = 1);
        public ValueTask<int> ContarRegistrosAsignaturaPorProgramaId(int _id);
    }
}