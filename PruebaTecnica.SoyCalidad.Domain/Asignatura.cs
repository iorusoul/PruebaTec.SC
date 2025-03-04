
namespace PruebaTecnica.SoyCalidad.Domain
{
    public class Asignatura
    {
        public int IdAsignatura { get; set; }
        public string? CodAsignatura { get; set; }
        public string? AsignaturaNombre { get; set; }
        public decimal ECTS { get; set; }
        public bool EsPersonalizable { get; set; }
        public decimal? Horas { get; set; }
        public int? IdModalidad { get; set; }
        public bool PublicarWeb { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int IdUsuarioModificacion { get; set; }
    }
}
