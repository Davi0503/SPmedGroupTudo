using Senai_Semestre2_Sprint2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Semestre2_Sprint2.Interfaces
{
    interface IClinicasRepository
    {
        List<Clinicas> Listar();
        void Cadastrar(Clinicas clinica);
        void Alterar(Clinicas clinica);
    }
}
