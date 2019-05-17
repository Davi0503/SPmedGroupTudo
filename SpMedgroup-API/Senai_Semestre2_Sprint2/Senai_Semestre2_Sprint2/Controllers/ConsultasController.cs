using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_Semestre2_Sprint2.Domains;
using Senai_Semestre2_Sprint2.DTOs.ConsultasDTO;
using Senai_Semestre2_Sprint2.Repositories;

namespace Senai_Semestre2_Sprint2.Controllers
{
    [Authorize(Roles = "administrador")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {

        private IConsultasRepository _consultasRepository { get; set; }


        public ConsultasController()
        {
            _consultasRepository = new ConsultasRepository();
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Listar() {

            string role = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Role).Value;
            int Id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            return Ok(_consultasRepository.Listar(role, Id));
        }

        [HttpPost]
        [Authorize(Roles = "administrador")]
        public IActionResult Cadastrar(Consultas consulta)
        {
            _consultasRepository.Cadastrar(consulta);

            return Ok();
        }


        [HttpPut]
        [Authorize(Roles = "administrador")]
        //mudar
        public IActionResult Atualizar(AtualizarConsultaDTO consulta)
        {
            string role = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Role).Value;

            _consultasRepository.Atualizar(consulta);


            return Ok();

        }

        






    }
}