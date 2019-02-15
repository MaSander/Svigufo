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
    //Define que o retorno sera um jason
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController] //Implementa funcionalidades no controller
    public class TiposEventosController : ControllerBase
    {
        List<TipoEventoDomain> tiposEventos = new List<TipoEventoDomain>()
        {
            new TipoEventoDomain{ Id = 1, Nome = " Tecnologia"},
            new TipoEventoDomain{ Id = 2, Nome = "Arquitetura"}
        };

        private ITipoEventoRepository TipoEventoRepository { get; set; }

        public TiposEventosController()
        {
            TipoEventoRepository = new TipoEventoRepository();
        }

        /// <summary>
        /// Retorna uma string atraves do metoso get
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //public string Get()
        //{
        //    return "Requisição recebida com sucesso";
        //}

        [HttpGet]
        //retorna uma lista de eventos
        public IEnumerable<TipoEventoDomain> Get()
        {
            return TipoEventoRepository.Listar();
        }

        /// <summary>
        /// Retorna um tipo de evento pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Busca um tipo de evento pelo seu id
            TipoEventoDomain tipoEventoSerProcurado = tiposEventos.Find(x => x.Id == id);
            if(tipoEventoSerProcurado == null)
            {
                return NotFound();
            }


            return Ok(tipoEventoSerProcurado);
        }

        /// <summary>
        /// Cadastra um novo tipo de evento
        /// </summary>
        /// <param name="tipoEvento"></param>
        /// <returns>Retorna um status code</returns>
        [HttpPost]
        public IActionResult Post(TipoEventoDomain tipoEvento)
        {
            return Ok();
        }

        /// <summary>
        /// Atualiza um tipo evento
        /// </summary>
        /// <param name="tipoEvento">tipo evento a ser atualizado</param>
        /// <returns>Retorna um status code</returns>
        [HttpPut]
        public IActionResult Put(TipoEventoDomain tipoEvento)
        {
            TipoEventoRepository.Alterar(tipoEvento);

            return Ok();
        }

        /// <summary>
        /// Altera tipo evento passando o id
        /// </summary>
        /// <param name="id">id do tipo evento</param>
        /// <param name="tipoEvento">TipoEventoDomain</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutById(int id, TipoEventoDomain tipoEvento)
        {
            return Ok();
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeletById(int id)
        {
            TipoEventoRepository.Deletar(id);
            
            return Ok();

        }
 
    }
}