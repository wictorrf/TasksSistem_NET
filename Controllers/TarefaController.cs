using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using listTask_Api.Models;
using listTask_Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace listTask_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> BuscarTodasTarefas()
        {
            List<TarefaModel> usuarios = await _tarefaRepository.BuscarTodasTarefas();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> BuscarUsuarioPorId(int id)
        {
            TarefaModel usuario = await _tarefaRepository.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<TarefaModel>> CadastrarUsuario([FromBody] TarefaModel usuarioModel)
        {
            TarefaModel usuario = await _tarefaRepository.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> AtualizarUsuario([FromBody] TarefaModel usuarioModel, int id)
        {
            TarefaModel usuario = await _tarefaRepository.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TarefaModel>> DeletarUsuario(int id)
        {
            bool response = await _tarefaRepository.Apagar(id);
            return Ok(response);
        }
    }
}