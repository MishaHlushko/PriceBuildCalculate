using PriceBuildCalculate.Domain.Entity;
using PriceBuildCalculate.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceBuildCalculate.Service.Interfaces
{
    public interface IMaterialInterface
    {
        Task<IBaseResponse<IEnumerable<Material>>> GetMaterials();


        Task<IBaseResponse<bool>> DeleteMaterial(int id);

        Task<IBaseResponse<Material>> GetMaterialByName(string name);
        Task<IBaseResponse<Material>> GetMaterial(int id);
    }
}
