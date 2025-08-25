using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                  "Digite o preço inicial:");
precoInicial = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Agora digite o preço por hora:");
precoPorHora = Convert.ToDecimal(Console.ReadLine());

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            CadastrarVeiculo(estacionamento);
            break;

        case "2":
            RemoverVeiculo(estacionamento);
            break;

        case "3":
            ListarVeiculos(estacionamento);            
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
    Console.Clear();
}

Console.WriteLine("O programa se encerrou");

static void CadastrarVeiculo(Estacionamento estacionamento)
{
    Console.Clear();
    while (true)
    {
        string placa = "";
        Console.WriteLine("Digite a placa do veículo para estacionar:");
        placa = Console.ReadLine();

        if (estacionamento.AdicionarVeiculo(placa))
        {
            Console.WriteLine("Veículo cadastrado com sucesso!");
            break;
        }
        else
        {
            Console.WriteLine("Placa inválida. Tente novamente no formato ABC-1234.");
        }
    }
}

static void RemoverVeiculo(Estacionamento estacionamento)
{
    while (true)
    {
        Console.WriteLine("Digite a placa do veículo para remover:");
        string placa = Console.ReadLine();
        bool veiculoExiste = estacionamento.VeiculoExiste(placa);

        if (estacionamento.ValidarPlaca(placa) && veiculoExiste)
        {
            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

            int horasEstacionado = 0;

            while (true)
            {
                try
                {
                    horasEstacionado = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Entrada inválida. Por favor, insira um número inteiro para as horas.");
                    continue;
                }
            }

            decimal valorTotal = estacionamento.CalcularValorTotal(horasEstacionado);

            estacionamento.RemoverVeiculo(placa);

            Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            break;
        }
        else
        {
            Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
        }
    }
}

static void ListarVeiculos(Estacionamento estacionamento)
{
    List<string> veiculos = estacionamento.ListarVeiculos();
    if (veiculos.Any())
    {
        Console.WriteLine("Os veículos estacionados são:");
        foreach (string veiculo in veiculos)
        {
            Console.WriteLine($"Placa: {veiculo}");
        }
    }
    else
    {
        Console.WriteLine("Não há veículos estacionados.");
    }
}
