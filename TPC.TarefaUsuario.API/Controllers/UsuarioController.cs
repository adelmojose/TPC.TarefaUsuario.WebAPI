using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TPC.TarefaUsuario.API.Core.Data.Entity;
using TPC.TarefaUsuario.API.Core.Services.Interface;
using TPC.TarefaUsuario.API.Enum;

namespace TPC.TarefaUsuario.API.Controllers
{

    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly ITarefaService _tarefaService;

        public UsuarioController(IUsuarioService usuarioService, ITarefaService tarefaService)
        {
            this._service = usuarioService;
            this._tarefaService = tarefaService;
        }


        [HttpGet("id")]
        [Authorize]
        public ActionResult Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id inválido.");
            }

            try
            {
                var usuario = this._service.FindById(id);

                return Ok(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Get()
        {
            try
            {
                var usuario = this._service.ListAll();

                return Ok(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Add(Usuario usuario)
        {
            if (usuario == null)
                return NoContent();

            try
            {
                var usuarioAdd = _service.Add(usuario);

                return Ok(usuario);

            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost("{id}/tarefa")]
        [Authorize]
        public ActionResult Add(int id, Tarefa tarefa)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id inválido.");
            }

            try
            {
                tarefa.UsuarioId = id;
                tarefa.StatusId = ((int)StatusTarefaEnum.EmAndamento);

                var usuarioAdd = _tarefaService.Add(tarefa);

                return Ok(tarefa);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}/tarefa")]
        [Authorize]
        public ActionResult GetForUsuario(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id inválido.");
            }

            try
            {
                var tarefa = this._tarefaService.ListForUsuario(id);

                return Ok(tarefa);
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
