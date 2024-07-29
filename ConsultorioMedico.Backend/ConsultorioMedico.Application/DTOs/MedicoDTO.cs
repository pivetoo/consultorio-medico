using ConsultorioMedico.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioMedico.Application.DTOs
{
    public class MedicoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Crm { get; set; }
        public EspecialidadeMedica Especialidade { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
