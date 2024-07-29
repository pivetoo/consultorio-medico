using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioMedico.Dominio.Entities
{
    public class Consulta
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataHoraConsulta { get; set; } = DateTime.Now;
        [StringLength(100)]
        public string Observacoes { get; set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
    }
}