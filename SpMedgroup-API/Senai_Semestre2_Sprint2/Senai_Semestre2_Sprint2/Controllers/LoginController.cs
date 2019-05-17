using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai_Semestre2_Sprint2.Domains;
using Senai_Semestre2_Sprint2.DTOs.LoginDTO;
using Senai_Semestre2_Sprint2.Repositories;

namespace Senai_Semestre2_Sprint2.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private IUsuariosRepository _usuarioRepositorio;

        public LoginController()
        {
            _usuarioRepositorio = new UsuariosRepository();
        }


        [HttpPost]
        public IActionResult Login(LoginDTO login)
        {

            try
            {
                Usuarios usuario = _usuarioRepositorio.BuscarPorEmail(login);

                if (usuario == null)
                {
                    return NotFound();

                }

                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                new Claim(ClaimTypes.Role, usuario.Permicao.ToString())
            };

                // Chave de acesso do token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("SPmedgroup-chave-autenticacao"));


                //Credenciais do Token - Header
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


                //Gera o token
                var token = new JwtSecurityToken(
                    issuer: "Senai_Semestre_Sprint2",
                    audience: "Senai_Semestre_Sprint2",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)

                });
            }
            catch(SystemException ex)
            {
                return BadRequest();
            }
        }
    }
}