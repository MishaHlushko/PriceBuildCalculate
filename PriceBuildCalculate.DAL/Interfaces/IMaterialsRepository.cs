using PriceBuildCalculate.Domain.Entity;

namespace PriceBuildCalculate.DAL.Interfaces
{
    public interface IMaterialsRepository : IBaseRepository<Material>
    {
        Task<Material> GetByName(string name);
    }
}
