using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Semestre2_Sprint2.DTOs.ConsultasDTO
{
    public class ConsultaListDTO
    {
        public string paciente { get; set; }

        public string Medico { get; set; }

        public DateTime data { get; set; }

        public string descricao { get; set; }

        public string status { get; set; }

        public string especialidade { get; set; }
    }
}
