using TODOList.Funcionalidades;

TarefasFuncionalidades Servico = new TarefasFuncionalidades();

while (true)
{
    Console.Clear();

    // Define a cor do texto para Amarelo
    Console.ForegroundColor = ConsoleColor.Yellow;

    Console.WriteLine(@" 

$$$$$$$$\  $$$$$$\  $$$$$$$\   $$$$$$\  $$\       $$\             $$\     
\__$$  __|$$  __$$\ $$  __$$\ $$  __$$\ $$ |      \__|            $$ |    
   $$ |   $$ /  $$ |$$ |  $$ |$$ /  $$ |$$ |      $$\  $$$$$$$\ $$$$$$\   
   $$ |   $$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |      $$ |$$  _____|\_$$  _|  
   $$ |   $$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |      $$ |\$$$$$$\    $$ |    
   $$ |   $$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |      $$ | \____$$\   $$ |$$\ 
   $$ |    $$$$$$  |$$$$$$$  | $$$$$$  |$$$$$$$$\ $$ |$$$$$$$  |  \$$$$  |
   \__|    \______/ \_______/  \______/ \________|\__|\_______/    \____/ 
                                                                   
    ");

    Console.WriteLine("Selecione sua opção");
    Console.WriteLine("1 - Criar Tarefa");
    Console.WriteLine("2 - Buscar Tarefa Pelo Id");
    Console.WriteLine("3 - Editar Tarefa");
    Console.WriteLine("4 - Listar Tarefas");
    Console.WriteLine("5 - Deletar Tarefa");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("\n10 - Adicionar 3 tarefas para testes");

    Console.Write("\nSua opção: ");

    var resposta = Console.ReadLine();

    if(resposta != null)
        if(resposta == "0" || resposta == "1" || resposta == "2" || resposta == "3" || resposta == "4" || resposta == "5" || resposta == "10")
            Console.WriteLine("Opção selecionada: " + resposta);
        else
        {
            Console.WriteLine("Opção inválida. Pressione qualquer tecla para tentar novamente...");
            Console.ReadKey();
            continue;
        }
    switch (resposta)
    {
        case "1":
            Servico.CriarTarefa();
            break;

        case "2":
            var tarefaBuscada = Servico.BuscarTarefa();
            if (tarefaBuscada != null)
            {
                Console.Clear();
                Console.WriteLine("Sua tarefa buscada: ");
                Console.WriteLine($"\nId: {tarefaBuscada.IdTarefa}");
                Console.WriteLine($"Título: {tarefaBuscada.TituloTarefa}");
                Console.WriteLine($"Descrição: {tarefaBuscada.Descricao}");
                Console.WriteLine($"Status: {tarefaBuscada.Status}");
                Console.WriteLine($"Data de Abertura: {tarefaBuscada.DataAbertura}");
                Console.WriteLine($"Estimativa de Horas: {tarefaBuscada.EstimativaHoras}");
            }
            else
            {
                break;
            }
            break;

        case "3":
            Servico.EditarTarefa();
            break;

        case "4":
            Console.Clear();
            Console.WriteLine("Sua lista de Tarefas: ");
            Servico.ListarTarefas();
            break;

        case "5":
            Servico.ExcluirTarefa();
            break;

        case "10":
            Servico.TesteAdicionar3Tarefas();
            Console.WriteLine("Adicionando Tarefas...");
            break;

        case "0":
            Console.WriteLine("Saindo...");
            return;
    }
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadKey();
}