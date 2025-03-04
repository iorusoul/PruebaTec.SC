namespace PruebaTecnica.SoyCalidad.Infrastructure
{
    public interface IContainerCadenaConexion
    {
        string ConnString { get; }
    }

    public class ContainerCadenaConexion : IContainerCadenaConexion
    {
        public string ConnString { get; }
        public ContainerCadenaConexion(string cadena)
        {
            ConnString = cadena;
        }
    }
}
