using AutoMapper;
using Machinewebapi.DTO;
using Machinewebapi.IDAO;
using SharedLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Machinewebapi.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Machinewebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {

        private readonly IHubContext<DataHub> hubContext;


        private readonly IMapper _mapper;  

        private readonly IDAOMachine _DAOMachine;
        private readonly IDAOLaverie _DAOLaverie;
        public MachineController(IDAOMachine movieRepo,IMapper mapper,IDAOLaverie dAOLaverie,IHubContext<DataHub> hub)
        {
            hubContext = hub;
            _DAOMachine = movieRepo; _mapper = mapper;
            _DAOLaverie = dAOLaverie;
        }

        /// <summary>
        /// Get list of all Laveries
        /// </summary>
        [HttpGet]

        public IQueryable Get()
        {
            return _DAOMachine.GetMachines();
        }

        [HttpGet("{idLaverie:int}")]
        public IQueryable Getbyid(int idLaverie)
        {
            return _DAOMachine.GetMachinesbyId(idLaverie);
        }

        /// <summary>
        /// Create a new laverie
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MachineDTO machineDTO)
        {  if (machineDTO == null)
                return BadRequest(ModelState);
            Machine machine = _mapper.Map<Machine>(machineDTO);
            if (!_DAOLaverie.LaverieExists(machineDTO.IdLaverie))
            {
                ModelState.AddModelError("", "laverie does not exist");
                return StatusCode(500, ModelState);
            }
            machine.Laverie = _DAOLaverie.GetLaverie(machineDTO.IdLaverie);
            
            if (machine == null)
                return BadRequest(ModelState);
            if (_DAOMachine.NumeroExists(machine.NumeroCode))
            {
                ModelState.AddModelError("", "Machine num code already Exist");
                return StatusCode(500, ModelState);
            }

            if (!_DAOMachine.CreateMachine(machine))
            {
                ModelState.AddModelError("", $"Something went wrong while saving machine  {machine.NumeroCode}");
                return StatusCode(500, ModelState);
            }
          await  hubContext.Clients.All.SendAsync("MachineAdded", machine);
            return Ok(machine);

        }

        /// <summary>
        /// Update a laverie
        /// </summary>
        /// <return></return>
        [HttpPut("{idmachine:int}")]
        public async Task<IActionResult> Update(int idmachine, [FromBody] MachineDTO1 machinedto)
        {
            Machine machine = _mapper.Map<Machine>(machinedto);
            machine.Laverie = _DAOLaverie.GetLaverie(machinedto.IdLaverie);
            if (machine == null || idmachine != machine.IdMachine)

            {
                ModelState.AddModelError("", $"Something went wrong while updating machine : {machine.NumeroCode}");
                return BadRequest(ModelState);
            }
           

            if (!_DAOMachine.UpdateMachine(machine))
            {
                ModelState.AddModelError("", $"Something went wrong while updating machine : {machine.NumeroCode}");
                return StatusCode(500, ModelState);
            }
            await hubContext.Clients.All.SendAsync("MachineAdded", machine);
            
            return Ok(machine); /*NoContent();*/
        }

        /// <summary>
        /// Update a laverie
        /// </summary>
        /// <return></return>

        [HttpDelete("{idmachine:int}")]
        public IActionResult Delete(int idmachine)
        {
            if (!_DAOMachine.MachineExists(idmachine))
            {
                return NotFound();
            }

            var machineobj = _DAOMachine.GetMachine(idmachine);

            if (!_DAOMachine.DeleteMachine(machineobj))
            {
                ModelState.AddModelError("", $"Something went wrong while deleting machine : {machineobj.NumeroCode}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}

