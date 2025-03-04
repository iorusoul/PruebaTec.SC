using Dapper;
using Microsoft.Data.SqlClient;
using PruebaTecnica.SoyCalidad.Domain;
using PruebaTecnica.SoyCalidad.Domain.Interfaces;

namespace PruebaTecnica.SoyCalidad.Infrastructure
{
    public class AsignaturaRepo : IAsignaturaRepo
    {
        private readonly IContainerCadenaConexion _cadenaConexion;

        public AsignaturaRepo(IContainerCadenaConexion containerCadenaCon)
        {
            _cadenaConexion = containerCadenaCon;
        }

        /// <summary>
        /// cuenta los registros del id de programa consultado...
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public async ValueTask<int> ContarRegistrosAsignaturaPorProgramaId(int _id)
        {
            string query =
            @"SELECT 
            COUNT(A.IdAsignatura) AS CantidadRegistros
            FROM 
                dbo.TAsignaturas A
            INNER JOIN 
                dbo.TProgramasAsignaturas PA ON A.IdAsignatura = PA.IdAsignatura
            WHERE 
                PA.IdPrograma = @IdPrograma;";

            // Parámetros para la consulta
            var parametros = new
            {
                IdPrograma = _id,
            };

            var conteo = default(int);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion.ConnString))
                {
                    conteo = await connection.QueryFirstOrDefaultAsync<int>(query, parametros); //usamos dapper
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return conteo;
        }

        public async ValueTask<IEnumerable<Asignatura>?> ObtenerAsignaturasPorIdPrograma(int _id)
        {
            string query =
                @"
                SELECT 
                    A.IdAsignatura,
                    A.CodAsignatura,
                    A.Asignatura AS AsignaturaNombre,
                    A.ECTS,
                    A.EsPersonalizable,
                    A.Horas,
                    A.IdModalidad,
                    A.PublicarWeb,
                    A.FechaAlta,
                    A.FechaModificacion,
                    A.IdUsuarioModificacion
                FROM 
                    dbo.TAsignaturas A
                INNER JOIN 
                    dbo.TProgramasAsignaturas PA ON A.IdAsignatura = PA.IdAsignatura
                WHERE 
                    PA.IdPrograma = @IdPrograma
                ORDER BY 
                    A.IdAsignatura";

            // Parámetros para la consulta
            var parametros = new
            {
                IdPrograma = _id,
            };

            var listaAsignaturas = default(IEnumerable<Asignatura>);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion.ConnString))
                {
                    listaAsignaturas = await connection.QueryAsync<Asignatura>(query, parametros); //usamos dapper
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return listaAsignaturas;
        }

        public async ValueTask<IEnumerable<Asignatura>?> ObtenerAsignaturasPorIdProgramaPaginado(int _id,int size = 5 , int pageN = 1)
        {
            string query =
                @"
                SELECT 
                    A.IdAsignatura,
                    A.CodAsignatura,
                    A.Asignatura AS AsignaturaNombre,
                    A.ECTS,
                    A.EsPersonalizable,
                    A.Horas,
                    A.IdModalidad,
                    A.PublicarWeb,
                    A.FechaAlta,
                    A.FechaModificacion,
                    A.IdUsuarioModificacion
                FROM 
                    dbo.TAsignaturas A
                INNER JOIN 
                    dbo.TProgramasAsignaturas PA ON A.IdAsignatura = PA.IdAsignatura
                WHERE 
                    PA.IdPrograma = @IdPrograma
                ORDER BY 
                    A.IdAsignatura
                OFFSET (@PageNumber - 1) * @PageSize ROWS
                FETCH NEXT @PageSize ROWS ONLY;";

            // Parametros para la consulta
            var parametros = new
            {
                IdPrograma = _id,
                PageNumber = pageN,
                PageSize = size
            };

            var listaAsignaturas = default(IEnumerable<Asignatura>);
            try
            {
                using (var connection = new SqlConnection(_cadenaConexion.ConnString))
                {
                    listaAsignaturas = await connection.QueryAsync<Asignatura>(query, parametros); //usamos dapper
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return listaAsignaturas;
        }
    }
}