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

        public override string ToString()
        {
            if(Status == Status.Feito)
            {
                return $"\"[✅]\" {Status} {IdTarefa} - {TituloTarefa}";
            }
            else if (Status == Status.Fazendo)
            {
                return $"\"[⏳]\" {Status} {IdTarefa} - {TituloTarefa}";
            }
            else
            {
                return $"\"[ ]\" {Status} - {IdTarefa} - {TituloTarefa}";
            }
        }
    }
}
