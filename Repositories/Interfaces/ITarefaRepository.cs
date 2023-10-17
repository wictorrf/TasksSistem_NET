using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using listTask_Api.Models;

namespace listTask_Api.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        Task<List<TarefaModel>> BuscarTodasTarefas();
        Task<TarefaModel> BuscarPorId(int id);
        Task<TarefaModel> Adicionar(TarefaModel tarefa);
        Task<TarefaModel> Atualizar(TarefaModel tarefa, int id);
        Task<bool> Apagar(int id);
    }
}