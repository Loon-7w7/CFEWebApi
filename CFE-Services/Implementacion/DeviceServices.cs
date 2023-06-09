using CFE_Domain.Devices;
using CFE_Domain.Material;
using CFE_Requets.AmountMaterial;
using CFE_Requets.Devices;
using CFE_Responses.Devicess;
using CFE_Services.Repositorios;
using CFEDatabase.Migrations;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CFE_Services.Implementacion
{
    /// <summary>
    /// Servicio de dispositivos
    /// </summary>
    public class DeviceServices : IDevicesRepository
    {
        /// <summary>
        /// Repositorio de Dispositivos
        /// </summary>
        private readonly IRepository<Devices> _DevicesRepository;
        /// <summary>
        /// Repositorio de materiales
        /// </summary>
        private readonly IRepository<Material> _materialRepository;
        /// <summary>
        /// contrctor
        /// </summary>
        /// <param name="devicesRepository">Repositorio de dispositivos</param>
        /// <param name="materalRepository">Repositorio de materiales</param>
        public DeviceServices(IRepository<Devices> devicesRepository, IRepository<Material> materalRepository) 
        {
            _DevicesRepository = devicesRepository;
            _materialRepository = materalRepository;
        }
        public async Task<bool> Add(CreateDevicesRequest request)
        {
            Devices devices = new Devices()
            {
                Id = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                name = request.name,
                isHeavy = request.isHeavy,
                isSemiInsulated = request.isSemiInsulated,
            };
            List<AmountMaterial> materials = new List<AmountMaterial>();
            foreach(var mat in request.materials) 
            {
                Material? material = await _materialRepository.GetId(mat.Id);
                if(material != null) 
                {
                    AmountMaterial amountMaterial = new AmountMaterial()
                    {
                        Id = Guid.NewGuid(),
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                        amount = mat.Amount,
                        material = material
                    };
                    materials.Add(amountMaterial);
                }
                else 
                {
                    return false;
                }
            }
            devices.materials = materials;
            return await _DevicesRepository.Add(devices);
        }

        public async Task<getDeviceAll> GetAll()
        {
            getDeviceAll response = new getDeviceAll();
            response.devices = await _DevicesRepository.AllGet(Entity => Entity.materials);
            return response;
        }

        public async Task<GetDeviceByidResponse> GetById(DeviceGetByID resquest)
        {
            GetDeviceByidResponse response = new GetDeviceByidResponse();
            Devices? device = await _DevicesRepository.GetId(resquest.Id);
            if (device != null) 
            {
                response.device = device;
            }
            else 
            {
                response.device = new Devices();
            }
            return response;
        }
    }
}
