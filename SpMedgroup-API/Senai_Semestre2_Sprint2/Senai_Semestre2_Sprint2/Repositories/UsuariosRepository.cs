using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Senai_Semestre2_Sprint2.Domains;
using Senai_Semestre2_Sprint2.DTOs.LoginDTO;

namespace Senai_Semestre2_Sprint2.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        public Usuarios BuscarPorEmail(LoginDTO login)
        {
            using (SpMedGroup ctx = new SpMedGroup())
            {

                Usuarios usuario = ctx.Usuarios.ToList().Find(x => x.Email == login.Email);

                return usuario;
                
            }

        }

        public Usuarios VerificarSeExiste(string email)
        {

            using (SpMedGroup ctx = new SpMedGroup())
            {

                Usuarios usuario = ctx.Usuarios.ToList().Find(x => x.Email == email);

                return usuario;
                
            }            
        }

        public void Cadastrar(Usuarios usuario)
        {
            Usuarios usuarioCadastro = VerificarSeExiste(usuario.Email);

            if (usuarioCadastro == null)
            {

                using (SpMedGroup ctx = new SpMedGroup())
                {

                    ctx.Usuarios.Add(usuario);
                    ctx.SaveChanges();

                }
            }

        }

        public List<Usuarios> Listar()
        {
            using (SpMedGroup ctx = new SpMedGroup())
            {
                return ctx.Usuarios.ToList();
            }
        }
    }
}
