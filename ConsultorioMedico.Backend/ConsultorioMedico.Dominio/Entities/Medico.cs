using ConsultorioMedico.Dominio.ValueObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsultorioMedico.Dominio.Entities
{
    public class Medico
    {
        [Key]
        public virtual int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100)]
        public virtual string Nome { get; set; }
        [Required(ErrorMessage = "O CRM é obrigatório.")]
        [StringLength(20)]
        public virtual string Crm { get; set; }
        [Required]
        public virtual EspecialidadeMedica Especialidade { get; set; }
        [StringLength(15)]
        public virtual string Telefone { get; set; }
        [StringLength(100)]
        public virtual string Email { get; set; }
    }
}
