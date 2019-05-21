using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai_Semestre2_Sprint2.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Medicos = new HashSet<Medicos>();
            Pacientes = new HashSet<Pacientes>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha inválida")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Permicao inválida")]
        public string Permicao { get; set; }

        public ICollection<Medicos> Medicos { get; set; }
        public ICollection<Pacientes> Pacientes { get; set; }
    }
}
