using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using listTask_Api.Data;
using listTask_Api.Models;
using listTask_Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace listTask_Api.Repositories
{
    public class UsuarioRepository : IUsuarioReporitory
    {
        private readonly SistemaTarefasDBContext _dbcontext;
        public UsuarioRepository(SistemaTarefasDBContext sistemaTarefasDBContext)
        {
            _dbcontext = sistemaTarefasDBContext;
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbcontext.Usuarios.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosusuarios()
        {
            return await _dbcontext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbcontext.Usuarios.AddAsync(usuario);
            await _dbcontext.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null) throw new Exception($"O Usuario com o id: {id} não foi encontrado!");
            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;
            _dbcontext.Usuarios.Update(usuarioPorId);
            await _dbcontext.SaveChangesAsync();
            return usuarioPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null) throw new Exception($"O Usuario com o id: {id} não foi encontrado!");
            _dbcontext.Usuarios.Remove(usuarioPorId);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}