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
        public virtual int Id { get; set; }
        [Required]
        [StringLength(100)]
        public virtual string Nome { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public virtual string Cpf { get; set; }
        [Required]
        public virtual DateTime DataNascimento { get; set; }
        [StringLength(15)]
        public virtual string Telefone { get; set; }
        [StringLength(100)]
        public virtual string Email { get; set; }
        [StringLength(200)]
        public virtual string Cep { get; set; }
        [StringLength(200)]
        public virtual string Rua { get; set; }
        [StringLength(200)]
        public virtual string Cidade { get; set; }
        [StringLength(200)]
        public virtual string Bairro { get; set; }        
        [StringLength(200)]
        public virtual string Numero { get; set; }
    }
}