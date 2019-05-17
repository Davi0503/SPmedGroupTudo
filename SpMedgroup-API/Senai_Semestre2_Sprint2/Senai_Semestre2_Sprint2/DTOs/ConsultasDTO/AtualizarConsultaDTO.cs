using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Semestre2_Sprint2.DTOs.ConsultasDTO
{
    public class AtualizarConsultaDTO
    {
        public int Id { get; set; }
        public string Permicao { get; set; }
        public int idStatus { get; set; }
        public string Descricao { get; set; }
    }
}
