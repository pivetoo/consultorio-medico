using ConsultorioMedico.Application.DTOs;
using ConsultorioMedico.Application.Services;
using ConsultorioMedico.Dominio.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioMedico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly MedicoService _medicoService;

        public MedicoController(MedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        [HttpGet]
        public IActionResult GetAll(int page = 1, int size = 10, string search = "")
        {
            var medicos = _medicoService.GetAll(page, size, search, out var totalMedicos);
            var result = new
            {
                Medicos = medicos,
                TotalMedicos = totalMedicos
            };
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var medico = _medicoService.GetById(id);
            return Ok(medico);
        }

        [HttpGet("specialty")]
        public IActionResult GetBySpecialty(EspecialidadeMedica especialidadeMedica)
        {
            var medicos = _medicoService.GetBySpecialty(especialidadeMedica);
            if (medicos == null)
            {
                return NotFound("Não foi encontrado nenhum médico.");
            }
            return Ok(medicos);
        }

        [HttpPost]
        public IActionResult Create(MedicoDTO medicoDto)
        {
            var create = _medicoService.Create(medicoDto, out var errors);
            return create ? Ok(create) : BadRequest(errors);
        }

        [HttpPut]
        public IActionResult Update(MedicoDTO medicoDto)
        {
            var update = _medicoService.Update(medicoDto, out var errors);
            return update ? Ok(update) : BadRequest(errors);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var delete = _medicoService.Delete(id, out var errors);
            return delete ? Ok(delete) : BadRequest(errors);
        }
    }
}
