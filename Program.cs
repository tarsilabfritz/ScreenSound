// Screen Sound - Sistema interativo para registrar, avaliar e exibir bandas cadastradas

// Mensagem exibida ao iniciar o programa
string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";

// Estrutura de dados que armazena o nome da banda como chave e uma lista de notas como valor
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Imagine Dragons", new List<int> {10, 8, 6});
bandasRegistradas.Add("The Beatles", new List<int>());

// Função que imprime o logotipo e a mensagem de boas-vindas na tela
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
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 0 para sair\n");

    Console.Write("Digite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    // Garante que o usuário insira um número válido antes de processar a opção
    if (int.TryParse(opcaoEscolhida, out int opcaoEscolhidaNumerica))
    {
        switch (opcaoEscolhidaNumerica)
        {
            case 1: 
                RegistrarBanda();
                break;
            case 2: 
                MostrarBandasRegistradas();
                break;
            case 3: 
                AvaliarBanda();
                break;
            case 4: 
                ExibirMedia();
                break;
            case 0:
                Console.WriteLine("\nSaindo do programa... Obrigado por usar o Screen Sound!");
                break;
            default:
                Console.WriteLine("\nOpção inválida! Tente novamente");
                break;
        }
    } else {
        Console.WriteLine("\nEntrada inválida! Por favor, digite um número.");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }    
}

// Função para registrar uma nova banda no sistema
void RegistrarBanda() {
    Console.Clear();
    ExibirTitulo("# Registrar nova banda #");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!.Trim();
    // Verifica se a banda já está registrada antes de adicioná-la
    if (!bandasRegistradas.ContainsKey(nomeDaBanda)) 
    {
        bandasRegistradas.Add(nomeDaBanda, new List<int>());
        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    } else {
        Console.WriteLine($"A banda {nomeDaBanda} já está registrada.");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
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
        Console.WriteLine("Ainda não há bandas registradas. Use a opção 1 para adicionar.");
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
    string nomeDaBanda = Console.ReadLine()!.Trim();
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual nota a banda {nomeDaBanda} merece? ");
        // Garante que o usuário insira um número válido antes de processar a opção
        if (int.TryParse(Console.ReadLine(), out int notaDaBanda) && notaDaBanda >= 0) {
            bandasRegistradas[nomeDaBanda].Add(notaDaBanda);
            Console.WriteLine($"\nA nota {notaDaBanda} foi registrada com sucesso para a banda {nomeDaBanda}!");
            Thread.Sleep(2000);
            Console.Clear();
            ExibirOpcoesDoMenu();
        } else {
            Console.WriteLine("\nNúmero inválido! Tente novamente");
            Thread.Sleep(2000);
            Console.Clear();
            AvaliarBanda();
        }
    } else {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
        Thread.Sleep(2000);
        Console.Write($"\nDeseja registrar a banda {nomeDaBanda} como parte do sistema? (S/N): ");
        string adicionarNovaBanda = Console.ReadLine()!;
        if (adicionarNovaBanda.Trim().ToUpper() == "S") {
            Thread.Sleep(2000);
            bandasRegistradas.Add(nomeDaBanda, new List<int>());
            Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
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
    Console.Write("Digite o nome da banda que deseja exibir a média: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda)) 
    {
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        Console.WriteLine($"\nA média da banda {nomeDaBanda} é {notasDaBanda.Average():F2}.");
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

// Exibe um título formatado com a mesma quantidade de asteriscos que o texto possui
void ExibirTitulo(string titulo)
{
    int qtdLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(qtdLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

// Inicialização do programa
ExibirOpcoesDoMenu();