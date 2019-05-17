using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai_Semestre2_Sprint2.Domains
{
    public partial class Clinicas
    {
        public Clinicas()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Nome inválido")]
        [MinLength(3)]
        public string NomeFantasia { get; set; }
        [Required(ErrorMessage = "Nome inválido")]
        [MinLength(3)]
        public string RasaoSocial { get; set; }
        [Required(ErrorMessage = "Nome inválido")]
        [MinLength(3)]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "Nome inválido")]
        [MinLength(3)]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Nome inválido")]
        [MinLength(3)]
        public string Cnpj { get; set; }

        public ICollection<Medicos> Medicos { get; set; }
    }
}
