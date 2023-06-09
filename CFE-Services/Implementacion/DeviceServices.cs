using CFE_Domain.Devices;
using CFE_Domain.Material;
using CFE_Requets.AmountMaterial;
using CFE_Requets.Devices;
using CFE_Services.Repositorios;
using CFEDatabase.Migrations;

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
                    devices.materials.Add(amountMaterial);
                }
                else 
                {
                    return false;
                }
            }
            return await _DevicesRepository.Add(devices);
        }

        public async Task<List<Devices>> GetAll()
        {
            List<Devices> response = new List<Devices>();
            response = await _DevicesRepository.AllGet();
            return response;
        }

        public async Task<Devices> GetById(DeviceGetByID resquest)
        {
            Devices? device = await _DevicesRepository.GetId(resquest.Id);
            if (device != null) 
            {
                return device;
            }
            else 
            {
                return new Devices();
            }
        }
    }
}
