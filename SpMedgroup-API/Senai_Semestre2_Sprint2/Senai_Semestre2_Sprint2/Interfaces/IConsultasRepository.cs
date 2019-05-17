using Senai_Semestre2_Sprint2.Domains;
using Senai_Semestre2_Sprint2.DTOs.ConsultasDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Semestre2_Sprint2.Repositories
{
    public interface IConsultasRepository
    {
        List<Consultas> Listar(string tipoUsuario, int Id);
        void Cadastrar(Consultas consulta);
        void Atualizar(AtualizarConsultaDTO consulta);
    }
}
