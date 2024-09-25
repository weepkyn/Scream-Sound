
using static System.Net.Mime.MediaTypeNames;

string mensagemDeBoasVindas = "Boas vindas ao Screen Sound!";

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Blink-182", new List<int> {10, 8, 6});
bandasRegistradas.Add("Linkin Park", new List<int>());

void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░ " );

    Console.WriteLine(mensagemDeBoasVindas);
}


void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a media de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\n Digite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse( opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBanda();
            break;
        case 2: MostrarBandasRegistradas();
            break;
       case 3: AvaliarBanda();
            break;
        case 4: ExibirMedia();
            break;
        case -1: Console.WriteLine("Tchau! :)");
            break;
        default: Console.WriteLine("Opção Invalida");
            break;
    }
}

void RegistrarBanda()
{
    ExibirTitulodaOpcao("Registro das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(1000);
    Console.Clear() ;
    ExibirOpcoesDoMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTitulodaOpcao("Exibindo todas as bandas registradas");

    //for (int i = 0; i < listaDeBandas.Count; i++)
    //{
    //  Console.WriteLine($"Banda: {listaDeBandas[i]}");
    //}

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Bandas: {banda}");
    }

    Console.WriteLine(" \n Digite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTitulodaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos +"\n");
}

void AvaliarBanda()
{

    Console.Clear();
    ExibirTitulodaOpcao("Avaliar Banda");

    Console.WriteLine("Bandas Registradas:");
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine(banda);
    }

    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que banda {nomeDaBanda} merece? ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($" \n A nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}.");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.Write($" \n A banda {nomeDaBanda} não existe, deseja cadastrá-la? Digite 'S' para sim e 'N' para não ");
        string opcao = Console.ReadLine()!;

        if (opcao == "S" || opcao == "s")
        {
            RegistrarBanda();
        }
        else if (opcao == "N" || opcao == "n")
        {
            Console.WriteLine("Digite uma telca para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesDoMenu();
        }
        else
        {
            Console.WriteLine("Opção Inválida :(");
            Thread.Sleep(5000);
            ExibirOpcoesDoMenu();
        }

    }
}
void ExibirMedia(){
    Console.Clear();
    ExibirTitulodaOpcao("Exibindo Médias");
    Console.Write("Digite a banda que deseja consultar as média ");
    string nomeDaBanda = Console.ReadLine()!;


    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        Console.WriteLine($" \nA média da banda {nomeDaBanda} é {notasDaBanda.Average()}");
        Console.Write("Digite uma tecla para voltar ao menu principal: ");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($" \n Não foi possível consultar a média da banda {nomeDaBanda}, pois ela não existe");
        Console.WriteLine("Voltando para o menu principal...");
        Console.Clear();
        Thread.Sleep(5000);
        ExibirOpcoesDoMenu();
    }
}

void FecharAplicacao()
{
    Console.WriteLine("Tchau! :)");
}
ExibirOpcoesDoMenu();