using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai_Semestre2_Sprint2.Domains
{
    public partial class Consultas
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Data inválido")]
        public DateTime DataAgendamento { get; set; }
        [Required(ErrorMessage = "Data inválido")]
        public DateTime DataConsulta { get; set; }

        public string Descricao { get; set; }
        [Required(ErrorMessage = "Paciente inválido")]
        public int IdPaciente { get; set; }
        [Required(ErrorMessage = "Paciente medico")]
        public int IdMedicos { get; set; }
        [Required(ErrorMessage = "Paciente status")]
        public int IdStatus { get; set; }

    //    public Medicos IdMedicosNavigation { get; set; }
    //    public Pacientes IdPacienteNavigation { get; set; }
    //    public StatusConsulta IdStatusNavigation { get; set; }
    }
}
