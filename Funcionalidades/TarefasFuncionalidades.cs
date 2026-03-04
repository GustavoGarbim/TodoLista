using TODOList.Entidades;
using TODOList.Entidades.Enum;

namespace TODOList.Funcionalidades
{
    public class TarefasFuncionalidades
    {
        List<Tarefas> ListaDeTarefas = new();

        public void TesteAdicionar3Tarefas()
        {
            var tarefa1 = new Tarefas(Random.Shared.Next(1000, 2000), "Tarefa 1", "Descrição da Tarefa 1", Status.Fazer, TimeOnly.Parse("02:00"));
            var tarefa2 = new Tarefas(Random.Shared.Next(1000, 2000), "Tarefa 2", "Descrição da Tarefa 2", Status.Fazendo, TimeOnly.Parse("01:30"));
            var tarefa3 = new Tarefas(Random.Shared.Next(1000, 2000), "Tarefa 3", "Descrição da Tarefa 3", Status.Feito, TimeOnly.Parse("00:45"));
            ListaDeTarefas.Add(tarefa1);
            ListaDeTarefas.Add(tarefa2);
            ListaDeTarefas.Add(tarefa3);
        }

        public void CriarTarefa()
        {
            try
            {
                Console.Clear();
                int idTarefa = Random.Shared.Next(1, 1000);

                while(ListaDeTarefas.Any(t => t.IdTarefa == idTarefa))
                {
                    idTarefa = Random.Shared.Next(1, 1000);
                }

                Console.Write("\nDigite o Titulo da Tarefa: ");
                string tituloTarefa = Console.ReadLine();

                if (tituloTarefa == "" || tituloTarefa == null)
                {
                    Console.WriteLine("Titulo da tarefa não pode ser vazio. Tarefa não criada.");
                    return;
                }

                Console.Write("\nDigite a Descrição da Tarefa: ");
                string descricao = Console.ReadLine();

                Console.Write("\nDigite a Estimativa de Horas para a Tarefa (HH:mm): ");
                TimeOnly estimativaHoras = TimeOnly.Parse(Console.ReadLine());

                var tarefa = new Tarefas(idTarefa, tituloTarefa, descricao, Status.Fazer, estimativaHoras);
                ListaDeTarefas.Add(tarefa);

                Console.WriteLine($"\nTarefa: {tituloTarefa} criada com sucesso! ID: {idTarefa}");
            }
            catch (Exception ex) {
                Console.WriteLine("Não foi possivel criar a tarefa. Revise os campos e tente novamente.");
            }
        }

        public void MudarStatusTarefa(int idTarefa)
        {

            var tarefa = BuscarTarefa(idTarefa);

            if(tarefa == null)
            {
                Console.WriteLine("Tarefa não encontrada para mudança de status.");
                return;
            }

            Console.WriteLine($"\nDigite o novo Status para a tarefa ({tarefa.TituloTarefa}): ");
            foreach (var status in Enum.GetValues<Status>())
            {
                Console.WriteLine($"({(int)status}) - {status}");
            }
            Console.WriteLine("\nOpção: ");
            var novoStatus = Enum.Parse<Status>(Console.ReadLine(), true);

            if (tarefa != null)
            {
                if(novoStatus == Status.Fazer || novoStatus == Status.Fazendo || novoStatus == Status.Feito)
                {
                    tarefa.Status = novoStatus;
                    Console.WriteLine($"Status da tarefa com ID {idTarefa} atualizado para {novoStatus}.");
                }
                else
                {
                    Console.WriteLine($"Status '{novoStatus}' inválido.");
                }
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
            try
            {
                int idBusca = int.Parse(Console.ReadLine());
                var tarefa = ListaDeTarefas.Find(c => c.IdTarefa == idBusca);
                if(tarefa != null)
                {
                    return tarefa;
                }
                else
                {
                    Console.WriteLine("Tarefa não encontrada");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao buscar tarefa. Revise os campos e tente novamente");
                return null;
            }
        }

        public Tarefas? BuscarTarefa(int idBusca)
        {
            try
            {
                var tarefa = ListaDeTarefas.Find(c => c.IdTarefa == idBusca);
                if(tarefa != null)
                {
                    return tarefa;
                }
                else
                {
                    Console.WriteLine("Tarefa com ID " + idBusca + " não encontrada.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao buscar tarefa: " + ex.Message);
                return null;
            }
        }

        public void ListarTarefas()
        {
            if (ListaDeTarefas == null || ListaDeTarefas.Count == 0)
            {
                Console.WriteLine("\nNenhuma tarefa encontrada.");
                return;
            }
            else
            {
                foreach (Tarefas tarefa in ListaDeTarefas)
                {
                    if(tarefa.Status == Status.Fazer)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(tarefa);
                    }
                    else if(tarefa.Status == Status.Fazendo)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(tarefa);
                    }
                    else if(tarefa.Status == Status.Feito)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(tarefa);
                    }
                }
            }
        }

        public void EditarTarefa()
        {
            Console.Clear();

            try
            {
                Console.Write("Digite o ID da tarefa que deseja editar: ");
                var idBusca = int.Parse(Console.ReadLine());
                var tarefa = BuscarTarefa(idBusca);
                if(tarefa == null)
                {
                    return;
                }

                Console.WriteLine("\nDigite sua opção: ");
                Console.WriteLine("\n(1) - Editar Titulo/Descrição");
                Console.WriteLine("(2) - Editar Estimativa de Horas");
                Console.WriteLine("(3) - Mudar Status");

                Console.Write("Opção: ");
                var resposta = Console.ReadLine();

                if (resposta == "1")
                {
                    Console.Write("Digite o novo Titulo da Tarefa (dê ENTER se não deseja alterar): ");
                    var tituloTarefa = Console.ReadLine();
                    if (tituloTarefa != "")
                    {
                        tarefa.TituloTarefa = tituloTarefa;
                    }
                    Console.Write("Digite a nova descrição da Tarefa (dê ENTER se não deseja alterar): ");
                    var novaDescricao = Console.ReadLine();
                    if (novaDescricao != "")
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
                else if (resposta == "3")
                {
                    MudarStatusTarefa(idBusca);
                }
                else
                {
                    Console.WriteLine("Opção Inválida.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao editar tarefa. Revise os campos e tente novamente.");
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
            try
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
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao excluir tarefa. Revise os campos e tente novamente.");
            }
        }
    }
}