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
    public interface IMedicoRepository
    {
        Medico GetById(int id);
        IEnumerable<Medico> GetBySpecialty(EspecialidadeMedica especialidadeMedica);
        IEnumerable<Medico> GetAll(int page, int size, string search, out int totalMedicos);
        bool Create(Medico medico, out List<ValidationResult> errors);
        bool Update(Medico medico, out List<ValidationResult> errors);
        bool Delete(Medico medico, out List<ValidationResult> errors);
    }
}
