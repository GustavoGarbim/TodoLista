using TODOList.Entidades;
using TODOList.Entidades.Enum;

namespace TODOList.Funcionalidades
{
    public class TarefasFuncionalidades
    {
        List<Tarefas> ListaDeTarefas = new();

        public void CriarTarefa()
        {
            Console.Clear();
            int idTarefa = Random.Shared.Next(1, 1000);

            Console.Write("\nDigite o Titulo da Tarefa: ");
            string tituloTarefa = Console.ReadLine();

            Console.Write("\nDigite a Descrição da Tarefa: ");
            string descricao = Console.ReadLine();

            Console.Write("\nDigite a Estimativa de Horas para a Tarefa (HH:mm): ");
            TimeOnly estimativaHoras = TimeOnly.Parse(Console.ReadLine());
            var tarefa = new Tarefas(idTarefa, tituloTarefa, descricao, Status.Fazer, estimativaHoras);
            ListaDeTarefas.Add(tarefa);
            Console.WriteLine($"\nTarefa: {tituloTarefa} criada com sucesso! ID: {idTarefa}");
        }

        public void MudarStatusTarefa(int idTarefa)
        {

            var tarefa = BuscarTarefa(idTarefa);

            Console.WriteLine($"\nDigite o novo Status para a tarefa ({tarefa.TituloTarefa}): ");
            foreach (var status in Enum.GetValues<Status>())
            {
                Console.WriteLine($"({(int)status}) - {status}");
            }
            Console.WriteLine("\nOpção: ");
            var novoStatus = Enum.Parse<Status>(Console.ReadLine(), true);
            if (tarefa != null)
            {
                tarefa.Status = novoStatus;
                Console.WriteLine($"Status da tarefa com ID {idTarefa} atualizado para {novoStatus}.");
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada para atualização de status.");
            }
        }

        public Tarefas? BuscarTarefa()
        {
            Console.Clear();
            Console.Write("Digite o Id da Tarefa que deseja buscar: ");
            var idBusca = int.Parse(Console.ReadLine());
            try
            {
                var tarefa = ListaDeTarefas.Find(c => c.IdTarefa == idBusca);
                return tarefa;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao buscar tarefa: " + ex.Message);
                return null;
            }
        }

        public Tarefas? BuscarTarefa(int idBusca)
        {
            try
            {
                var tarefa = ListaDeTarefas.Find(c => c.IdTarefa == idBusca);
                return tarefa;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao buscar tarefa: " + ex.Message);
                return null;
            }
        }

        public void ListarTarefas()
        {
            foreach(Tarefas tarefa in ListaDeTarefas)
            {
                Console.WriteLine(tarefa);
            }
        }

        public void EditarTarefa()
        {
            Console.Clear();

            Console.Write("Digite o ID da tarefa que deseja editar: ");
            var idBusca = int.Parse(Console.ReadLine());

            Console.WriteLine("\nDigite sua opção: ");
            Console.WriteLine("\n(1) - Editar Titulo/Descrição");
            Console.WriteLine("(2) - Editar Estimativa de Horas");
            Console.WriteLine("(3) - Mudar Status");

            Console.Write("Opção: ");
            var resposta = Console.ReadLine();

            if (resposta == "1")
            {
                var tarefa = BuscarTarefa(idBusca);
                Console.Write("Digite o novo Titulo da Tarefa (dê ENTER se não deseja alterar): ");
                var tituloTarefa = Console.ReadLine();
                if(tituloTarefa != "")
                {
                    tarefa.TituloTarefa = tituloTarefa;
                }
                Console.Write("Digite a nova descrição da Tarefa (dê ENTER se não deseja alterar): ");
                var novaDescricao = Console.ReadLine();
                if(novaDescricao != "")
                {
                    tarefa.Descricao = novaDescricao;
                }
            }
            else if (resposta == "2")
            {
                Console.Write("Digite a nova Estimativa de Horas para a Tarefa (HH:mm): ");
                TimeOnly novaEstimativaHoras = TimeOnly.Parse(Console.ReadLine());
                EditarTarefa(idBusca, novaEstimativaHoras);
            }
            else if(resposta == "3")
            {
                MudarStatusTarefa(idBusca);
            }
             else
            {
                Console.WriteLine("Opção Inválida.");
            }
        }

        private void EditarTarefa(int idTarefa, TimeOnly estimativaHoras)
        {
            var tarefa = BuscarTarefa(idTarefa);
            if (tarefa != null)
            {
                tarefa.EstimativaHoras = estimativaHoras;
            }
        }

        public void ExcluirTarefa()
        {
            Console.Clear();
            Console.Write("Digite o Id da Tarefa que deseja excluir: ");
            var idTarefa = int.Parse(Console.ReadLine());
            var tarefa = BuscarTarefa(idTarefa);
            if (tarefa != null)
            {
                Console.Clear();
                Console.WriteLine($"Tem certeza que deseja excluir a tarefa: {tarefa.TituloTarefa}?");
                Console.Write("\nS/N: ");
                var respostaExclusao = Console.ReadLine();
                if (respostaExclusao == "S" || respostaExclusao == "s" || respostaExclusao == "sim" || respostaExclusao == "Sim")
                {
                    var tarefaExcluida = ListaDeTarefas.Remove(tarefa);
                    if (tarefaExcluida)
                    {
                        Console.WriteLine($"Tarefa com ID {idTarefa} excluída com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Tarefa não encontrada para exclusão.");
                    }
                }
                else if (respostaExclusao == "N" || respostaExclusao == "n" || respostaExclusao == "não" || respostaExclusao == "nao")
                {
                    Console.WriteLine("Exclusão cancelada.");
                }
                else
                {
                    Console.WriteLine("Resposta Inválida.");
                }
            }
        }
    }
}
