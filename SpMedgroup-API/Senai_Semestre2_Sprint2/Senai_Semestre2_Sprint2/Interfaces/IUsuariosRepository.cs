using Senai_Semestre2_Sprint2.Domains;
using Senai_Semestre2_Sprint2.DTOs.LoginDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Semestre2_Sprint2.Repositories
{
    public interface IUsuariosRepository
    {
        void Cadastrar(Usuarios usuario);
        List<Usuarios> Listar();
        Usuarios BuscarPorEmail(LoginDTO login);
        Usuarios VerificarSeExiste(string email);
        Usuarios pegandoID(string email);
    }
}
