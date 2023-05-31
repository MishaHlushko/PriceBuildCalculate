using PriceBuildCalculate.DAL.Interfaces;
using PriceBuildCalculate.Domain.Entity;
using PriceBuildCalculate.Domain.Response;
using PriceBuildCalculate.Service.Interfaces;
using PriceBuildCalculate.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceBuildCalculate.Domain.Enum;

namespace PriceBuildCalculate.Service.Implementations
{
    public class MaterialService : IMaterialInterface
    {
        private readonly IMaterialsRepository _materialsRepository;
        public MaterialService(IMaterialsRepository materialsRepository)
        {
            _materialsRepository = materialsRepository;
        }


        public async Task<IBaseResponse<IEnumerable<Material>>> GetMaterials() 
        {
            var baseResponse = new BaseResponse<IEnumerable<Material>>();
            try
            {
                var material = await _materialsRepository.Select();
                if (material.Count == 0)
                {
                    baseResponse.Description = "Знайдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = material;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Material>>()
                {
                    Description = $"[GetMaterial] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Material>> GetMaterial(int id) 
        {
            var baseResponse = new BaseResponse<Material>();
            try
            {
                var material = await _materialsRepository.Get(id);
                if (material == null) 
                {
                    baseResponse.Description = "Material not found";
                    baseResponse.StatusCode = StatusCode.MaterialNotFound;
                    return baseResponse;               
                }
                baseResponse.Data = material;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Material>()
                {
                    Description = $"[GetMaterial] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<Material>> GetMaterialByName(string name)
        {
            var baseResponse = new BaseResponse<Material>();
            try
            {
                var material = await _materialsRepository.GetByName(name);
                if (material == null)
                {
                    baseResponse.Description = "User not found";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return baseResponse;
                }

                baseResponse.Data = material;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Material>()
                {
                    Description = $"[GetMaterialByName] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<bool>> DeleteMaterial(int id)
        {
            var baseResponse = new BaseResponse<bool>()
            {
                Data = true
            };
            try
            {
                var material = await _materialsRepository.Get(id);
                if (material == null)
                {
                    baseResponse.Description = "User not found";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    baseResponse.Data = false;

                    return baseResponse;
                }

                await _materialsRepository.Delete(material);

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteMaterial] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }


    }
}
