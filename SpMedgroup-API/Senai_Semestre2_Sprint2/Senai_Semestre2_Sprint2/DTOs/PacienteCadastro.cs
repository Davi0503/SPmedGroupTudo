using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Semestre2_Sprint2.DTOs
{
    public class PacienteCadastro
    {
        public string email { get; set; }

        public string senha { get; set; }

        public string permicao { get; set; }

        public string nome { get; set; }

        public string cpf { get; set; }

        public string telefone { get; set; }

        public int idUsuario { get; set; }

        public DateTime dataNascimento { get; set; }

        public string Rg { get; set; }
    }
}
