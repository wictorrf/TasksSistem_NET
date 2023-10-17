using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using listTask_Api.Enums;

namespace listTask_Api.Models
{
    public class TarefaModel
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public StatusTarefa status { get; set; }
        public int UsuarioId { get; set; }

        public virtual UsuarioModel Usuario { get; set; }
    }
}