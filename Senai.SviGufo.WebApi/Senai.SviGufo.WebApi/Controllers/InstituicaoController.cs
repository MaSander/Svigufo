using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Domais;
using Senai.SviGufo.WebApi.Interfaces;
using Senai.SviGufo.WebApi.Repositores;

namespace Senai.SviGufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        private IInstituicaoRepository InstituicaoRepository { get; set; }

        public InstituicaoController()
        {
            InstituicaoRepository = new InstituicaoRepository();
        }

        [HttpGet]
        public IEnumerable<InstituicaoDomain> Get()
        {
            return InstituicaoRepository.Listar();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            InstituicaoRepository.Deletar(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult PutById(int id, InstituicaoDomain instituicao)
        {
            InstituicaoRepository.Alterar(instituicao);

            return Ok();
        }

        [HttpPost]
        public IActionResult Post(InstituicaoDomain instituicao)
        {
            InstituicaoRepository.Cadastrar(instituicao);

            return Ok();
        }
    }
}