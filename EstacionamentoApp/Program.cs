using EstacionamentoApp.Enums;
using EstacionamentoApp.Models;
using EstacionamentoApp.Services;

namespace EstacionamentoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EstacionamentoService service = new EstacionamentoService();
            bool sair = false;
            while (sair == false)
            {

                Console.WriteLine(" ");
                Console.WriteLine("Escolha o que deseja fazer: " +
                                 "\n1 - Cadastrar veículo " +
                                 "\n2 - Registrar entrada " +
                                 "\n3 - Registrar saída" +
                                 "\n4 - Listar veículos estacionados" +
                                 "\n5 - Listar histórico" +
                                 "\n6 - Listar vagas disponíveis" +
                                 "\n7 - Listar vagas ocupadas" +
                                 "\n0 - Sair");

                string? opcao = Console.ReadLine();
                if (string.IsNullOrEmpty(opcao)) { Console.WriteLine("Tente Novamente"); }
                switch (opcao)
                {

                    case "0":
                        Console.WriteLine("Você escolheu sair");
                        sair = true;
                        break;

                    case "1":
                        bool cadastro = false;
                        Console.WriteLine("Informe a placa do veículo:");
                        string placa = Console.ReadLine();

                        Console.WriteLine("Informe a marca do veículo:");
                        string marca = Console.ReadLine();

                        Console.WriteLine("Informe o modelo do veículo:");
                        string modelo = Console.ReadLine();

                        Console.WriteLine("Informe a cor do veículo:");
                        string cor = Console.ReadLine();

                        Console.WriteLine("Informe o tipo do veículo: \n- Carro \n- Moto \n- Caminhao");
                        TipoVeiculo tipoVeiculo = (TipoVeiculo)Enum.Parse(typeof(TipoVeiculo), Console.ReadLine(), true);

                        switch (tipoVeiculo)
                        {
                            case TipoVeiculo.Carro:
                                Console.WriteLine("Informe quantas portas há no carro:");
                                int quantidadePorta = int.Parse(Console.ReadLine());
                                cadastro = service.CadastrarVeiculo(new Carro(placa, marca, modelo, cor, quantidadePorta));
                                break;

                            case TipoVeiculo.Moto:
                                Console.WriteLine("Informe quantas cilindradas a moto possui:");
                                int cilindradas = int.Parse(Console.ReadLine());
                                cadastro = service.CadastrarVeiculo(new Moto(placa, marca, modelo, cor, cilindradas));
                                break;

                            case TipoVeiculo.Caminhao:
                                Console.WriteLine("Informe quantos eixos o caminhão possui:");
                                int quantidadeEixo = int.Parse(Console.ReadLine());
                                cadastro = service.CadastrarVeiculo(new Caminhao(placa, marca, modelo, cor, quantidadeEixo));
                                break;
                        }
                        if (cadastro) { Console.WriteLine("Veículo cadastrado com sucesso"); }
                        else { Console.WriteLine("Veículo já cadastrado no sistema"); }
                        break;

                    case "2":
                        Console.WriteLine("Informe a placa do veículo");
                        string placaDoVeiculoEntrada = Console.ReadLine();

                        bool sucessoEntrada = service.RegistrarEntrada(placaDoVeiculoEntrada);
                        Console.WriteLine(sucessoEntrada ? "Entrada registrada com sucesso" : "Não foi possível registrar a entrada");

                        break;

                    case "3":
                        Console.WriteLine("Informe a placa do veículo");
                        string placaDoVeiculoSaida = Console.ReadLine();

                        bool sucessoSaida = service.RegistrarSaida(placaDoVeiculoSaida);
                        Console.WriteLine(sucessoSaida ? "Saida registrada com sucesso" : "Não foi possível registrar a saida");
                        break;

                    case "4":
                        if (service.ExisteVeiculosEstacionamento())
                        {
                            Console.WriteLine("VEÍCULOS ESTACIONADOS \n-------------------------------------------------------");
                            foreach (Veiculo veiculo in service.VeiculosNoEstacionamento())
                            {
                                Console.WriteLine(veiculo.ToString());
                            }

                        }
                        else
                        {
                            Console.WriteLine("Não há veículos no estacionamento");
                        }
                        break;

                    case "5":
                        var historico = service.Historico();
                        if (historico.Any())
                        {
                            Console.WriteLine("HISTÓRICO DE ESTADIA \n-------------------------------------------------------");
                            foreach (Estadia estadia in historico)
                            {
                                Console.WriteLine(estadia.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Não há histórico de estadias");
                        }
                        break;

                    case "6":
                        var vagasDisponiveis = service.VagasDisponiveis();
                        if (vagasDisponiveis.Any())
                        {
                            Console.WriteLine("VAGAS DISPONÍVEIS \n-------------------------------------------------------");
                            foreach (Vaga vaga in vagasDisponiveis)
                            {
                                Console.WriteLine(vaga.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Não há vagas disponíveis");
                        }
                        break;

                    case "7":
                        var vagasOcupadas = service.VagasOcupadas();
                        if (vagasOcupadas.Any())
                        {
                            Console.WriteLine("VAGAS OCUPADAS \n-------------------------------------------------------");
                            foreach (Vaga vaga in vagasOcupadas)
                            {
                                Console.WriteLine(vaga.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Não há vagas ocupadas");
                        }
                        break;
                }
            }
                
        }
    }
}
