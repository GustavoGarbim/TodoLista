using TODOList.Entidades;

Tarefas tarefa = new Tarefas();

tarefa.CriarTarefa(890, "Primeira Tarefa", "Tarefa muito legal", 0, new TimeOnly(12, 10, 10));
var buscar = tarefa.BuscarTarefa(890);

Console.WriteLine(buscar.TituloTarefa);


while (true)
{
    Console.WriteLine("BEM-VINDO(A) AO TODO LIST");
    Console.WriteLine("Selecione sua opção");
    Console.WriteLine("1 - Criar Tarefa");
    Console.WriteLine("2 - Buscar Tarefa Pelo Id");
    Console.WriteLine("3 - Listar Tarefas");
    Console.WriteLine("4 - Deletar Tarefa");

    var resposta = Console.ReadLine();
    if(resposta != null)
    {
        if(resposta == "1")
        {
            
        }
    }

}