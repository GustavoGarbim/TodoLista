using TODOList.Entidades.Enum;

namespace TODOList.Entidades
{
    public class Tarefas
    {
        public int IdTarefa { get; set; }
        public string TituloTarefa { get; set; }
        public string Descricao { get; set; }
        public Status Status { get; set; }
        public DateTime DataAbertura { get; set; }
        public TimeOnly EstimativaHoras { get; set; }

        List<Tarefas> ListaDeTarefas = new();

        public Tarefas(){ }

        public Tarefas(int idTarefa, string tituloTarefa, string descricao, Status status, TimeOnly estimativaHoras)
        {
            IdTarefa = idTarefa;
            TituloTarefa = tituloTarefa;
            Descricao = descricao;
            Status = status;
            DataAbertura = DateTime.UtcNow.ToLocalTime();
            EstimativaHoras = estimativaHoras;
        }

        public void CriarTarefa(int idTarefa, string tituloTarefa, string descricao, Status status, TimeOnly estimativaHoras)
        {
            var tarefa = new Tarefas(idTarefa, tituloTarefa, descricao, status, estimativaHoras);
            ListaDeTarefas.Add(tarefa);
        }

        public Tarefas? BuscarTarefa(int idTarefa)
        {
            try
            {
                var tarefa = ListaDeTarefas.Find(c => c.IdTarefa == idTarefa);
                return tarefa;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public void EditarTarefa(int idTarefa, string? tituloTarefa, string? descricao)
        {
            var tarefa = BuscarTarefa(idTarefa);
            if(tarefa != null)
            {
                tarefa.TituloTarefa = tituloTarefa;
                tarefa.Descricao = descricao;
            }
        }

        public void EditarTarefa(int idTarefa, TimeOnly estimativaHoras)
        {
            var tarefa = BuscarTarefa(idTarefa);
            if (tarefa != null)
            {
                tarefa.EstimativaHoras = estimativaHoras;
            }
        }
    }
}
