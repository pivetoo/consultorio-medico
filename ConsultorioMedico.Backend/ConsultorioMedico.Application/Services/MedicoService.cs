using ConsultorioMedico.Application.DTOs;
using ConsultorioMedico.Dominio.Entities;
using ConsultorioMedico.Dominio.Repositories;
using ConsultorioMedico.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioMedico.Application.Services
{
    public class MedicoService
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoService(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public IEnumerable<MedicoDTO> GetAll(int page, int size, string search, out int totalMedicos)
        {
            var medicos = _medicoRepository.GetAll(page, size, search, out totalMedicos);

            return medicos.Select(m => new MedicoDTO
            {
                Id = m.Id,
                Nome = m.Nome,
                Crm = m.Crm,
                Especialidade = m.Especialidade,
                Telefone = m.Telefone,
                Email = m.Email,
            });
        }

        public MedicoDTO GetById(int id)
        {
            var medicos = _medicoRepository.GetById(id);

            if (medicos == null)
            {
                return null;
            }

            return new MedicoDTO
            {
                Id = id,
                Nome = medicos.Nome,
                Crm = medicos.Crm,
                Especialidade = medicos.Especialidade,
                Telefone = medicos.Telefone,
                Email = medicos.Email,
            };
        }

        public bool Create(MedicoDTO medicoDto, out List<ValidationResult> errors)
        {
            errors = new List<ValidationResult>();

            var medicos = new Medico
            {
                Nome = medicoDto.Nome,
                Crm = medicoDto.Crm,
                Especialidade = medicoDto.Especialidade,
                Telefone = medicoDto.Telefone,
                Email = medicoDto.Email
            };

            return _medicoRepository.Create(medicos, out errors);
        }

        public bool Update(MedicoDTO medicoDto, out List<ValidationResult> errors)
        {
            errors = new List<ValidationResult>();

            var medico = _medicoRepository.GetById(medicoDto.Id);
            if (medico == null)
            {
                errors.Add(new ValidationResult("Medico não encontrado."));
                return false;
            }

            medico.Nome = medicoDto.Nome;
            medico.Crm = medicoDto.Crm;
            medico.Especialidade = medicoDto.Especialidade;
            medico.Telefone = medicoDto.Telefone;
            medico.Email = medicoDto.Email;

            return _medicoRepository.Update(medico, out errors);
        }

        public bool Delete(int id, out List<ValidationResult> errors)
        {
            errors = new List<ValidationResult>();

            var medico = _medicoRepository.GetById(id);
            if (medico == null)
            {
                errors.Add(new ValidationResult("Medico não encontrado."));
                return false;
            }

            return _medicoRepository.Delete(medico, out errors);
        }

        public IEnumerable<MedicoDTO> GetBySpecialty(EspecialidadeMedica especialidadeMedica)
        {
            var medicos = _medicoRepository.GetBySpecialty(especialidadeMedica);
            return medicos.Select(m => new MedicoDTO
            {
                Id = m.Id,
                Nome = m.Nome,
                Crm = m.Crm,
                Especialidade = m.Especialidade,
                Telefone = m.Telefone,
                Email = m.Email,
            });
        }
    }
}