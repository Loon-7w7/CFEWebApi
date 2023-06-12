using CFE_Requets.Devices;
using CFE_Responses;
using CFE_Responses.Devicess;
using CFE_Services.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APiCFE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {

        /// <summary>
        /// servicios de dispositivos
        /// </summary>
        private readonly IDevicesRepository devicesRepository;
        /// <summary>
        /// contrctor
        /// </summary>
        /// <param name="DevicesRepository">servicios de dispositivos</param>
        public DevicesController(IDevicesRepository DevicesRepository) 
        {
            devicesRepository = DevicesRepository;
        }
        /// <summary>
        /// obtine todos los dispositivos
        /// </summary>
        /// <returns>Lista de dispositivos</returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            getDeviceAll response = await devicesRepository.GetAll();
            return Ok(response.devices);
        }
        /// <summary>
        /// obtien un dispositivo por id
        /// </summary>
        /// <param name="id">id del dispositivo</param>
        /// <returns>dispositivo</returns>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            DeviceGetByID request = new DeviceGetByID() { Id = id};
            GetDeviceByidResponse response = await devicesRepository.GetById(request);
            return Ok(response);
        }
        /// <summary>
        /// crea un dispositivo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] CreateDevicesRequestbody requestBody)
        {

            CreateDevicesRequest request = new CreateDevicesRequest()
            {
                name = requestBody.name,
                voltage = requestBody.voltage,
                isHeavy = bool.Parse(requestBody.isHeavy),
                isSemiInsulated = bool.Parse(requestBody.isSemiInsulated),
                materials = requestBody.materials,
            };
            GeneralResponse response = new GeneralResponse();
            response.success = await devicesRepository.Add(request);
            if(response.success) 
            {
                response.Message = "Se creo correctamente el dispositivo";
                return Ok(response);
            }
            else 
            {
                response.Message = "No se puedo crear correctamenete el dispositivo";
                return BadRequest(response);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Update/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
        }
    }
}
