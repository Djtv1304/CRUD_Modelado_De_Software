using Ejemplo1.Models;

namespace Ejemplo1.API
{
    public interface IAPIService
    {

        Task<List<CentroCostos>> GetCentroCostos();

        Task<CentroCostos> InsertCentroCostos(CentroCostos newCentroCostos);

        Task UpdateCentroCostos(CentroCostos CentroCostosToUpdate);

        Task<CentroCostos> DeleteCentroCostos(CentroCostos CentroCostosToDelete);

    }
}
