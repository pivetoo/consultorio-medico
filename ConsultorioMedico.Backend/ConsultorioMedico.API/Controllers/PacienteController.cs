using ConsultorioMedico.Application.DTOs;
using ConsultorioMedico.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioMedico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteService _pacienteService;

        public PacienteController(PacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]
        public IActionResult GetAll(int page = 1, int size = 10, string search = "")
        {
            var paciente = _pacienteService.GetAll(page, size, search, out var totalPacientes);
            var result = new
            {
                Paciente = paciente,
                TotalPacientes = totalPacientes
            };
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var paciente = _pacienteService.GetById(id);
            return Ok(paciente);
        }

        [HttpGet("cpf")]
        public IActionResult GetByCpf(string cpf)
        {
            var paciente = _pacienteService.GetByCpf(cpf);
            return Ok(paciente);
        }

        [HttpPost]
        public IActionResult Create(PacienteDTO pacienteDto)
        {
            var paciente = _pacienteService.Create(pacienteDto, out var errors);
            return paciente ? Ok(paciente) : BadRequest(errors);
        }

        [HttpPut]
        public IActionResult Update(PacienteDTO pacienteDto)
        {
            var paciente = _pacienteService.Update(pacienteDto, out var errors);
            return paciente ? Ok(paciente) : BadRequest(errors);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var paciente = _pacienteService.Delete(id, out var errors);
            return paciente ? Ok(paciente) : BadRequest(errors);
        }
    }
}