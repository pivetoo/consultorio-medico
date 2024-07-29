using ConsultorioMedico.Dominio.Entities;
using ConsultorioMedico.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioMedico.Dominio.Repositories
{
    public interface IPacienteRepository
    {
        Paciente GetById(int id);
        IEnumerable<Paciente> GetByCpf(string cpf);
        IEnumerable<Paciente> GetAll(int page, int size, string search, out int totalPacientes);
        bool Create(Paciente paciente, out List<ValidationResult> errors);
        bool Update(Paciente paciente, out List<ValidationResult> errors);
        bool Delete(Paciente paciente, out List<ValidationResult> errors);
    }
}
