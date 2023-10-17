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
    public class TarefaRepository : ITarefaRepository
    {
        private readonly SistemaTarefasDBContext _dbcontext;
        public TarefaRepository(SistemaTarefasDBContext sistemaTarefasDBContext)
        {
            _dbcontext = sistemaTarefasDBContext;
        }
        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _dbcontext.Tarefas.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _dbcontext.Tarefas.ToListAsync();

        }
        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            await _dbcontext.Tarefas.AddAsync(tarefa);
            await _dbcontext.SaveChangesAsync();
            return tarefa;
        }

        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);
            if (tarefaPorId == null) throw new Exception($"A tarefa com o id: {id} não foi encontrado!");
            tarefaPorId.Nome = tarefa.Nome;
            tarefaPorId.Descricao = tarefa.Descricao;
            _dbcontext.Tarefas.Update(tarefaPorId);
            await _dbcontext.SaveChangesAsync();
            return tarefaPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);
            if (tarefaPorId == null) throw new Exception($"A tarefa com o id: {id} não foi encontrado!");
            _dbcontext.Tarefas.Remove(tarefaPorId);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}