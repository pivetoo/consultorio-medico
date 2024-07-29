using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioMedico.Dominio.Entities
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string Cpf { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [StringLength(15)]
        public string Telefone { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(200)]
        public string Endereco { get; set; }
    }
}