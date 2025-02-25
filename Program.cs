﻿// Screen Sound - Sistema para registrar, avaliar e exibir bandas

// Mensagem de boas-vindas
string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";

// Dicionário para armazenar as bandas e suas respectivas avaliações
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Imagine Dragons", new List<int> {10, 8, 6});
bandasRegistradas.Add("The Beatles", new List<int>());

// Função para exibir o logotipo do sistema
void ExibirLogo() 
{
    Console.WriteLine(@"
    ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
    ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
    ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
    ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
    ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
    ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
    ");
    Console.WriteLine(mensagemDeBoasVindas);
};


// Função para exibir o menu principal
void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 0 para sair\n");

    Console.Write("Digite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    
    switch (opcaoEscolhidaNumerica)
    {
        case 1: 
            Console.WriteLine("\nVocê digitou a opção " + opcaoEscolhida);
            RegistrarBanda();
            break;
        case 2: 
            Console.WriteLine("\nVocê digitou a opção " + opcaoEscolhida);
            MostrarBandasRegistradas();
            break;
        case 3: 
            Console.WriteLine("\nVocê digitou a opção " + opcaoEscolhida);
            AvaliarBanda();
            break;
        case 4: 
            Console.WriteLine("\nVocê digitou a opção " + opcaoEscolhida);
            ExibirMedia();
            break;
        case 0:
            Console.WriteLine("\nSaindo do programa... Obrigado por usar o Screen Sound!");
            break;
        default:
             Console.WriteLine("\nOpção inválida! Tente novamente");
             break;
    }
}

// Função para registrar uma nova banda no sistema
void RegistrarBanda() {
    Console.Clear();
    ExibirTitulo("# Registrar nova banda #");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

// Função para mostrar as bandas registradas
void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTitulo("# Exibindo todas as bandas registradas #");
    if (bandasRegistradas?.Any() == true) {
        foreach (string banda in bandasRegistradas.Keys)
        {
            Console.WriteLine($"Banda: {banda}");
        }
    } else {
        Console.WriteLine("Não encontramos nenhuma banda registrada");
    }

    Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal\n");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

// Função para avaliar uma banda
void AvaliarBanda()
{
    Console.Clear();
    ExibirTitulo("# Avaliar bandas registradas #");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual nota a banda {nomeDaBanda} merece? ");
        int notaDaBanda = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(notaDaBanda);
        Console.WriteLine($"\nA nota {notaDaBanda} foi registrada com sucesso para a banda {nomeDaBanda}!");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    } else {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
        Thread.Sleep(2000);
        Console.Write($"\nDeseja registrar a banda {nomeDaBanda} como parte do sistema? (S/N): ");
        string adicionarNovaBanda = Console.ReadLine()!;
        if (adicionarNovaBanda == "S") {
            Thread.Sleep(2000);
            bandasRegistradas.Add(nomeDaBanda, new List<int>());
            Console.WriteLine($"\nA banda {nomeDaBanda} foi registrada com sucesso!");
            Thread.Sleep(4000);
            Console.Clear();
            AvaliarBanda();
        } else {
            Thread.Sleep(2000);
            Console.WriteLine("Digite qualquer tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesDoMenu();
        }
    }
}

// Função para exibir média de avaliações de uma banda
void ExibirMedia()
{
    Console.Clear();
    ExibirTitulo("# Exibindo média da banda #");
    Console.Write("\nDigite o nome da banda que deseja exibir a média: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda)) 
    {
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        Console.WriteLine($"\nA média da banda {nomeDaBanda} é {notasDaBanda.Average()}.");
        Console.WriteLine("Digite qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    
    } else {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
        Thread.Sleep(2000);
        Console.WriteLine("Digite qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

// Função auxiliar para exibir títulos formatados
void ExibirTitulo(string titulo)
{
    int qtdLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(qtdLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

// Iniciar o programa
ExibirOpcoesDoMenu();