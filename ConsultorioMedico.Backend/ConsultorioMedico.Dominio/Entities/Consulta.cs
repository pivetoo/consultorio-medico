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
        public virtual int Id { get; set; }
        public virtual DateTime DataHoraConsulta { get; set; } = DateTime.Now;
        [StringLength(100)]
        public virtual string Observacoes { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual Medico Medico { get; set; }
    }
}