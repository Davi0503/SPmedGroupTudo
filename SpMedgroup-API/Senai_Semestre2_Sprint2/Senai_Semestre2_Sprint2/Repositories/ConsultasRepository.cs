using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai_Semestre2_Sprint2.Domains;
using Senai_Semestre2_Sprint2.DTOs.ConsultasDTO;

namespace Senai_Semestre2_Sprint2.Repositories
{
    public class ConsultasRepository : IConsultasRepository
    {
        public void Atualizar(AtualizarConsultaDTO consulta)
        {
            using (SpMedGroup ctx = new SpMedGroup())
            {

                if(consulta.Permicao == "administrador") {


                    Consultas consultaUpdate = ctx.Consultas.Find(consulta.Id);
                    consultaUpdate.IdStatus = consulta.idStatus;
                    ctx.Consultas.Update(consultaUpdate);
                    ctx.SaveChanges();

                }else if(consulta.Permicao == "medico")

                {
                    Consultas consultaUpdate = ctx.Consultas.Find(consulta.Id);
                    consultaUpdate.Descricao = consulta.Descricao;
                    ctx.Consultas.Update(consultaUpdate);
                    ctx.SaveChanges();
                }              
            }
        }

        public void Cadastrar(Consultas consulta)
        {
            using (SpMedGroup ctx = new SpMedGroup())
            {

                ctx.Consultas.Add(consulta);
                ctx.SaveChanges();

            }
        }

        public List<Consultas> Listar(string tipoUsuario, int Id)
        {

            using (SpMedGroup ctx = new SpMedGroup())
            {
                if (tipoUsuario == "administrador")
                {
                    return ctx.Consultas.ToList();
                }
                else if (tipoUsuario == "medico")
                {
                                       
                    return ctx.Consultas.Where(x => x.IdMedicos == Id).ToList();

                }else if(tipoUsuario == "paciente")
                {
                    return ctx.Consultas.Where(x => x.IdPaciente == Id).ToList();


                }
                else
                {
                    return null;
                }
            }
          
        }
    }
}
