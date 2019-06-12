using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Senai_Semestre2_Sprint2.Domains;
using Senai_Semestre2_Sprint2.DTOs;
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
       

        Usuarios IUsuariosRepository.pegandoID(string email)
        {
            using (SpMedGroup ctx = new SpMedGroup())
            {

                Usuarios usuario = ctx.Usuarios.ToList().Find(x => x.Email == email);

                return usuario;

            }
        }

        public List<MedicoListagem> listarmedicos()
        {
            List<MedicoListagem> listademedicos = new List<MedicoListagem>();

            using (SpMedGroup ctx = new SpMedGroup())
            {

                List<Medicos> medicoslist = ctx.Medicos.ToList();

                foreach(Medicos medico in medicoslist)
                {
                    MedicoListagem mediconovo = new MedicoListagem()
                    {
                        Id = medico.Id,
                        Nome = medico.Nome                        
                    };
                    listademedicos.Add(mediconovo);
                }
            }
            return listademedicos;

        }

        public List<PacientesListagem> listarpaciente()
        {
            List<PacientesListagem> listadepacientes = new List<PacientesListagem>();

            using (SpMedGroup ctx = new SpMedGroup())
            {
                List<Usuarios> listapacientes = ctx.Usuarios.ToList();

                List<Pacientes> pacientelist = ctx.Pacientes.ToList();

                foreach (Pacientes medico in pacientelist)
                {
                    PacientesListagem pacientenovo = new PacientesListagem()
                    {
                        Id = medico.Id,
                        Nome = medico.Nome
                    };
                    listadepacientes.Add(pacientenovo);
                }
            }
            return listadepacientes;

        }
    }
}
