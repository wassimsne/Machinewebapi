using Machinewebapi.IDAO;
using SharedLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Machinewebapi.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Machinewebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaverieController : ControllerBase
    {
        private readonly JwtAuthenticationManager _jwtAuthenticationManager;

        private readonly IMapper _mapper;     

        private readonly IDAOLaverie _LaverieRepo;
        public LaverieController(IDAOLaverie laverieRepo,IMapper mapper, JwtAuthenticationManager JwtAuthenticationManager)
        {
            _LaverieRepo = laverieRepo;
            
            _mapper = mapper;

            _jwtAuthenticationManager= JwtAuthenticationManager; 

        }

        /// <summary>
        /// Get list of all Laveries
        /// </summary>
        /*[Authorize]*/
        [HttpGet]

        public IQueryable Get()
        {
            return _LaverieRepo.GetLaveries();
        }

       /* [HttpGet("{username:string}")]
        public IQueryable Getlogin(string username,string password)
        {
            return _LaverieRepo.GetLogin(username,password);
        }*/

        /// <summary>
        /// Create a new laverie
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LaverieDTO laveriedto)
        {
            Laverie laverie = _mapper.Map<Laverie>(laveriedto);
            if (laveriedto == null)
                return BadRequest(ModelState);
            if (_LaverieRepo.NomExists(laverie.Nom))
            {
                ModelState.AddModelError("", "Laverie name already Exist");
                return StatusCode(500, ModelState);
            }

            if (!_LaverieRepo.CreateLaverie(laverie))
            {
                ModelState.AddModelError("", $"Something went wrong while saving laverie {laverie.Nom}");
                return StatusCode(500, ModelState);
            }

            return Ok(laveriedto);

        }

        /// <summary>
        /// Update a laverie
        /// </summary>
        /// <return></return>
        [HttpPut("{idLav:int}")]
        public IActionResult Update( int idLav, [FromBody] Laverie laverie)
        {


            /*Laverie laverie = _mapper.Map<Laverie>(laveriedto);*/
            if (laverie == null || idLav != laverie.IdLav)
            {
                ModelState.AddModelError("", $"IdLav doit etre inchangé car idLav != laverie.IdLav");
                return BadRequest(ModelState);
            }

                if (!_LaverieRepo.UpdateLaverie(laverie))
                {
                    
                    ModelState.AddModelError("", $"Something went wrong while updating laverie : {laverie.Nom}");
                    return StatusCode(500, ModelState);
                }

                return NoContent();
            
        }

        [AllowAnonymous]
        [HttpPost("Authorize")]
        public IActionResult AuthUser([FromBody] User usr)
        {
            var token = _jwtAuthenticationManager.Authenticate(usr.Username, usr.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        /// <summary>
        /// Update a laverie
        /// </summary>
        /// <return></return>

        [HttpDelete("{idLav:int}")]
        public IActionResult Delete(int idLav)
        {
            if (!_LaverieRepo.LaverieExists(idLav))
            {
                return NotFound();
            }

            var laverieobj = _LaverieRepo.GetLaverie(idLav);

            if (!_LaverieRepo.DeleteLaverie(laverieobj))
            {
                ModelState.AddModelError("", $"Something went wrong while deleting Laverie : {laverieobj.Nom}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}