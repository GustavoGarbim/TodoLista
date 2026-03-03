using TODOList.Entidades.Enum;

namespace TODOList.Entidades
{
    public class TarefasBase
    {
        public DateOnly DataAbertura { get; set; }
        public string Descricao { get; set; }
        public DateTime EstimativaHoras { get; set; }
        public int IdTarefa { get; set; }
        public Status Status { get; set; }
        public string TituloTarefa { get; set; }
    }
}