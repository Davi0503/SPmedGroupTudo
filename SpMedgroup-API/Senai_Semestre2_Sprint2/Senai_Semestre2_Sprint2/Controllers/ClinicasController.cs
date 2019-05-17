using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_Semestre2_Sprint2.Domains;
using Senai_Semestre2_Sprint2.Interfaces;
using Senai_Semestre2_Sprint2.Repositories;

namespace Senai_Semestre2_Sprint2.Controllers
{   
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicasController : ControllerBase
    {

        private IClinicasRepository _ClinicasRepository { get; set; }

        public ClinicasController()
        {
            _ClinicasRepository = new ClinicasRepository();
        }


        [HttpGet]
        [Authorize(Roles = "administrador")]
        public IActionResult Listar()
        {

            

            return Ok(_ClinicasRepository.Listar());
        }

        [HttpPost]
        [Authorize(Roles = "administrador")]
        public IActionResult Cadastrar(Clinicas clinica)
        {

            _ClinicasRepository.Cadastrar(clinica);

            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "administrador")]
        public IActionResult Atualizar(Clinicas clinica)
        {

            _ClinicasRepository.Alterar(clinica);

            return Ok();
        }




        
    }
}