using CFE_Domain.Material;
using CFE_Requets.Material;
using CFE_Responses.Materials;
using CFE_Services.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Services.Implementacion
{
    /// <summary>
    /// Servio de materiales
    /// </summary>
    public class MaterialService : IMaterialRepository
    {
        /// <summary>
        /// Repositorio de materiales
        /// </summary>
        private readonly IRepository<Material> _materialRepository;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="materialRepository"></param>
        public MaterialService(IRepository<Material> materialRepository)
        {
            _materialRepository = materialRepository;
        }
        /// <summary>
        /// Crea un material
        /// </summary>
        /// <param name="material">Datos del material</param>
        /// <returns></returns>

        public async Task Add(CreateMaterialRequest request)
        {
            Material material = new Material() 
            {
                Id = Guid.NewGuid(),
                Code = request.Code,
                Name = request.Name,
                Unit = request.Unit,
                unirPrice = request.unirPrice,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
            };
            await _materialRepository.Add(material);
        }
        /// <summary>
        /// Elimina un material
        /// </summary>
        /// <param name="id">id del material</param>
        /// <returns></returns>

        public async Task Delete(DeleteMaterialRequest request)
        {
            await _materialRepository.Delete(request.Id);
        }

        /// <summary>
        /// obtiene una lista de materiales
        /// </summary>
        /// <returns></returns>
        public async Task<GetAllMaterialRespose> GetAll()
        {
            GetAllMaterialRespose respose = new GetAllMaterialRespose();
            respose.materials = await _materialRepository.AllGet();
            return respose;
        }
        /// <summary>
        /// Busxas por id del material
        /// </summary>
        /// <param name="id">id del material</param>
        /// <returns></returns>
        public async Task<GetMaterialByIDResponse> GetById(GetMaterialByIDRequest request)
        {
            GetMaterialByIDResponse response = new GetMaterialByIDResponse();
            response.materials = await _materialRepository.GetId(request.Id);
            return response;
        }

        /// <summary>
        /// Actuliza el material
        /// </summary>
        /// <param name="material">Material Actualizado</param>
        /// <returns></returns>

        public async Task Update(UpdateMaterialRequest request)
        {
            Material material = new Material() 
            {
                Id = request.Id,
                Code = request.Code,
                Name = request.Name,
                Unit = request.Unit,
                CreateDate = request.CreateDate,
                UpdateDate = DateTime.Now,
            };
            await _materialRepository.Update(material);
        }
        /// <summary>
        /// Crea multiples materiales
        /// </summary>
        /// <param name="resquest">Lista de materiales</param>
        /// <returns></returns>
        public async Task CreateMulti(CreateMultiMaterialrequest resquest) 
        {
            foreach (var material in resquest.Materials) 
            {
                Material newmaterial = new Material()
                {
                    Id = Guid.NewGuid(),
                    Code = material.Code,
                    Name = material.Name,
                    Unit = material.Unit,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                };
                await _materialRepository.Add(newmaterial);
            }
        }

    }
}
