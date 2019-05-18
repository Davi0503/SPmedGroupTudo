using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai_Semestre2_Sprint2.Domains
{
    public partial class Medicos
    {
        public Medicos()
        {
            Consultas = new HashSet<Consultas>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Nome inválido")]
        [MinLength(5)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Data inválida")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "Telefone inválido")]
        [MinLength(8)]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Crm inválido")]
        [MinLength(5)]
        public string Crm { get; set; }
        [Required(ErrorMessage = "Especialidade inválida")]
        public int IdEspecialidade { get; set; }
        [Required(ErrorMessage = "Clinica inválida")]
        public int IdClinica { get; set; }
        [Required(ErrorMessage = "Usuario inválido")]
        public int IdUsuario { get; set; }

        //public Clinicas IdClinicaNavigation { get; set; }
        //public Especialidades IdEspecialidadeNavigation { get; set; }
        //public Usuarios IdUsuarioNavigation { get; set; }
        //public ICollection<Consultas> Consultas { get; set; }
    }
}
