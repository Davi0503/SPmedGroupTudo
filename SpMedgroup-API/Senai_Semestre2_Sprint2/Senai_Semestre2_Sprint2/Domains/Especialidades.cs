using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai_Semestre2_Sprint2.Domains
{
    public partial class Especialidades
    {
        public Especialidades()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Nome inválido")]
        public string Nome { get; set; }

        public ICollection<Medicos> Medicos { get; set; }
    }
}
