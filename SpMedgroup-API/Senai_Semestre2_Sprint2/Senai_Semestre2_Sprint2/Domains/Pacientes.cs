using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai_Semestre2_Sprint2.Domains
{
    public partial class Pacientes
    {
        public Pacientes()
        {
            Consultas = new HashSet<Consultas>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Nome inválido")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "CPF inválido")]
        [MinLength(8)]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Telefone inválido")]
        [MinLength(8)]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Usuario inválido")]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "data inválido")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "RG inválido")]
        public string Rg { get; set; }

        public Usuarios IdUsuarioNavigation { get; set; }
        public ICollection<Consultas> Consultas { get; set; }
    }
}
