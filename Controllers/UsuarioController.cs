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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioReporitory _usuarioReporitory;
        public UsuarioController(IUsuarioReporitory usuarioReporitory)
        {
            _usuarioReporitory = usuarioReporitory;
        }
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosOsUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioReporitory.BuscarTodosusuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarUsuarioPorId(int id)
        {
            UsuarioModel usuario = await _usuarioReporitory.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> CadastrarUsuario([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioReporitory.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> AtualizarUsuario([FromBody] UsuarioModel usuarioModel, int id)
        {
            UsuarioModel usuario = await _usuarioReporitory.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> DeletarUsuario(int id)
        {
            bool response = await _usuarioReporitory.Apagar(id);
            return Ok(response);
        }
    }
}