using CFE_Requets.Material;
using CFE_Responses.Materials;
using CFE_Services.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APiCFE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        /// <summary>
        /// Repositorio de materiales
        /// </summary>
        private readonly IMaterialRepository materialRepository;
        /// <summary>
        /// Costructor de materiales
        /// </summary>
        /// <param name="material">repositorio de materiales</param>
        public MaterialController(IMaterialRepository material) 
        {
            materialRepository = material;
        }
        /// <summary>
        /// Obtiene una lista de materiales
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllMaterialRespose respose = await materialRepository.GetAll();
            return Ok(respose.materials);
        }

        /// <summary>
        /// obtiene materiales por id
        /// </summary>
        /// <param name="id">id del materal</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            GetMaterialByIDRequest request = new GetMaterialByIDRequest() { Id = id };
            GetMaterialByIDResponse response = await materialRepository.GetById(request);
            return Ok(response);
        }

        /// <summary>
        /// crea un material
        /// </summary>
        /// <param name="request">datos del material</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] CreateMaterialRequest request)
        {
            bool response = await materialRepository.Add(request);
            if (response) { return Ok("Se creo el material correctamete"); }
            else { return BadRequest("No se puedo crear el material"); }
        }
        /// <summary>
        /// Crea multiples materiales
        /// </summary>
        /// <param name="resquest">lista de materiales</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost("CreateMulti")]
        public async Task<IActionResult> multipost([FromBody] List<CreateMaterialRequest> list) 
        {
            CreateMultiMaterialrequest rquest = new CreateMultiMaterialrequest() { Materials = list };
             bool response = await materialRepository.CreateMulti(rquest);
            if (response) { return Ok("Se crearon exitonzamente todos los materiales"); }
            else { return BadRequest("No se puedo crear algunos el material"); }

        }
        /// <summary>
        /// Actualzia los materiales
        /// </summary>
        /// <param name="request">nuevos datos del material</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody] UpdateMaterialRequest request)
        {
            bool response = await materialRepository.Update(request);
            if (response) { return Ok("Se actulizado Correctamente"); }
            else { return BadRequest("No se pudo actualizar el material"); }
            
        }
        /// <summary>
        /// Elimina los materiales
        /// </summary>
        /// <param name="id">id de materiales</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteMaterialRequest request = new DeleteMaterialRequest() { Id = id };
            bool response = await materialRepository.Delete(request);
            if (response)  {  return Ok("Se elimino el material"); }
            else  { return BadRequest("No se puedo eliminar el material"); }
            
        }
    }
}
