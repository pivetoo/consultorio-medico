using ConsultorioMedico.Application.DTOs;
using ConsultorioMedico.Dominio.Entities;
using ConsultorioMedico.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioMedico.Application.Services
{
    public class PacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public IEnumerable<PacienteDTO> GetAll(int page, int size, string search, out int totalPacientes)
        {
            var pacientes = _pacienteRepository.GetAll(page, size, search, out totalPacientes);

            return pacientes.Select(p => new PacienteDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Cpf = p.Cpf,
                DataNascimento = p.DataNascimento,
                Telefone = p.Telefone,
                Email = p.Email,
                Endereco = p.Endereco,
            });
        }

        public PacienteDTO GetById(int id)
        {
            var paciente = _pacienteRepository.GetById(id);

            if (paciente == null)
            {
                return null;
            }

            return new PacienteDTO
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                Cpf = paciente.Cpf,
                DataNascimento = paciente.DataNascimento,
                Telefone = paciente.Telefone,
                Email = paciente.Email,
                Endereco = paciente.Endereco
            };
        }

        public bool Create(PacienteDTO pacienteDto, out List<ValidationResult> errors)
        {
            errors = new List<ValidationResult>();

            var paciente = new Paciente
            {
                Nome = pacienteDto.Nome,
                Cpf = pacienteDto.Cpf,
                DataNascimento = pacienteDto.DataNascimento,
                Telefone = pacienteDto.Telefone,
                Email = pacienteDto.Email,
                Endereco = pacienteDto.Endereco,
            };

            return _pacienteRepository.Create(paciente, out errors);
        }

        public bool Update(PacienteDTO pacienteDto, out List<ValidationResult> errors)
        {
            errors = new List<ValidationResult>();

            var paciente = _pacienteRepository.GetById(pacienteDto.Id);

            if (paciente == null)
            {
                errors.Add(new ValidationResult("Paciente não encontrado."));
                return false;
            }
            
            paciente.Nome = pacienteDto.Nome;
            paciente.Cpf = pacienteDto.Cpf;
            paciente.DataNascimento = pacienteDto.DataNascimento;
            paciente.Telefone = pacienteDto.Telefone;
            paciente.Email = pacienteDto.Email;
            paciente.Endereco = pacienteDto.Endereco;

            return _pacienteRepository.Update(paciente, out errors);
        }

        public bool Delete(int id, out List<ValidationResult> errors)
        {
            errors = new List<ValidationResult>();

            var paciente = _pacienteRepository.GetById(id);
            if (paciente == null)
            {
                errors.Add(new ValidationResult("Paciente não encontrado."));
                return false;
            }

            return _pacienteRepository.Delete(paciente, out errors);
        }

        public IEnumerable<PacienteDTO> GetByCpf(string cpf)
        {
            var paciente = _pacienteRepository.GetByCpf(cpf);
            return paciente.Select(p => new PacienteDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Cpf = p.Cpf,
                DataNascimento = p.DataNascimento,
                Telefone = p.Telefone,
                Email = p.Email,
                Endereco = p.Endereco,
            });
        }
    }
}