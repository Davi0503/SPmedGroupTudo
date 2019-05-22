using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public List<ConsultaListDTO> Listar(string tipoUsuario, int Id)
        {
            
            using (SpMedGroup ctx = new SpMedGroup())
            {
                List<ConsultaListDTO> consultasRetorno = new List<ConsultaListDTO>();

                if (tipoUsuario == "administrador")
                {
                    List<Consultas> lista =
                       ctx.Consultas.Where(x => x.IdPaciente == Id)
                       .Include(x => x.IdPacienteNavigation)
                       .Include(x => x.IdMedicosNavigation)
                       .Include(x => x.IdStatusNavigation)
                       .Include(x => x.Descricao)
                       .Include(x => x.DataConsulta)
                       .ToList();

                    foreach (var x in lista)
                    {
                        ConsultaListDTO consulta = new ConsultaListDTO()
                        {
                            paciente = x.IdPacienteNavigation.Nome,
                            Medico = x.IdMedicosNavigation.Nome,
                            status = x.IdStatusNavigation.Nome,
                            descricao = x.Descricao,
                            data = x.DataConsulta
                        };

                        consultasRetorno.Add(consulta);
                    }

                    return consultasRetorno;
                }
                else if (tipoUsuario == "medico")
                {
                    List<Consultas> lista =
                         ctx.Consultas.Where(x => x.IdMedicos == Id)
                         .Include(x => x.IdPacienteNavigation)
                        .Include(x => x.IdPacienteNavigation)
                        .Include(x => x.IdStatusNavigation)
                        .Include(x => x.Descricao)
                        .Include(x => x.DataConsulta)
                        .ToList();

                    foreach(var x  in lista)
                    {
                        ConsultaListDTO consulta = new ConsultaListDTO()
                        {
                            paciente = x.IdMedicosNavigation.Nome,
                            Medico = x.IdMedicosNavigation.Nome,
                            status = x.IdStatusNavigation.Nome,
                            descricao = x.Descricao,
                            data = x.DataConsulta
                        };

                        consultasRetorno.Add(consulta);
                    }

                    return consultasRetorno;



                } else if (tipoUsuario == "paciente" || tipoUsuario == "1")
                {
                    List<Consultas> lista = ctx.Consultas
                        .Where(x => x.IdPaciente == Id)
                        .Include(x => x.IdPacienteNavigation)
                        .Include(x => x.IdMedicosNavigation)
                        .Include(x => x.IdStatusNavigation)                        
                        .ToList();

                    foreach(var x  in lista)
                    {
                        ConsultaListDTO consulta = new ConsultaListDTO()
                        {
                            paciente = x.IdPacienteNavigation.Nome,
                            Medico = x.IdMedicosNavigation.Nome,
                            status = x.IdStatusNavigation.Nome,
                            descricao = x.Descricao,
                            data = x.DataConsulta
                        };

                        consultasRetorno.Add(consulta);
                    }

                    return consultasRetorno;

                    
                }
                else
                {
                    return null;
                }
            }
          
        }
    }
}
