using Senai_Semestre2_Sprint2.Domains;
using Senai_Semestre2_Sprint2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Semestre2_Sprint2.Repositories
{
    public class ClinicasRepository : IClinicasRepository
    {
        public void Alterar(Clinicas clinica)
        {
            using (SpMedGroup ctx = new SpMedGroup())
            {

                ctx.Clinicas.Update(clinica);
                ctx.SaveChanges();
                

            }
            
        }

        public void Cadastrar(Clinicas clinica)
        {
            using (SpMedGroup ctx = new SpMedGroup())
            {
                
                ctx.Clinicas.Add(clinica);
                ctx.SaveChanges();

            }
        }

        public List<Clinicas> Listar()
        {
            using (SpMedGroup ctx = new SpMedGroup())
            {



                return ctx.Clinicas.ToList();

            }
        }
    }
}
