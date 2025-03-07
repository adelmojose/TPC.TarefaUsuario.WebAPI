using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPC.TarefaUsuario.API.Core.Data.Entity;
using TPC.TarefaUsuario.API.Core.Services.Interface;
using TPC.TarefaUsuario.API.Enum;

namespace TPC.TarefaUsuario.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        
        private readonly ITarefaService _service;
        public TarefaController(ITarefaService tarefaService)
        {
            this._service = tarefaService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Get()
        {
            try
            {
                var tarefa = this._service.ListAll();

                return Ok(tarefa);
            }
            catch (Exception)
            {
                throw;
            }
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
                var tarefa = this._service.FindById(id);

                return Ok(tarefa);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("usuarios/{id}/tarefa")]
        [Authorize]
        public ActionResult GetForUsuario(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id inválido.");
            }

            try
            {
                var tarefa = this._service.ListForUsuario(id);

                return Ok(tarefa);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost("usuarios/{id}/tarefa")]
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

                var usuarioAdd = _service.Add(tarefa);

                return Ok(tarefa);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //[HttpGet]
        //public ActionResult GetAll()
        //{
        //    try
        //    {
        //        return Ok("");
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

    }
}
