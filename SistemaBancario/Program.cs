using SistemaBancario;
using System;
using System.ComponentModel.Design;

namespace SistemaBancario
{
    class Program
    {
        //TEXTO TEMÁTICO.
        static void ExibirCabecalho()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@" ██████╗  █████╗ ███╗   ██╗███████╗███╗   ███╗    ██████╗  █████╗ ███╗   ██╗██╗  ██╗");
            Console.WriteLine(@" ██╔══██╗██╔══██╗████╗  ██║██╔════╝████╗ ████║    ██╔══██╗██╔══██╗████╗  ██║██║ ██╔╝");
            Console.WriteLine(@" ██████╔╝███████║██╔██╗ ██║█████╗  ██╔████╔██║    ██████╦╝███████║██╔██╗ ██║█████═╝ ");
            Console.WriteLine(@" ██╔═══╝ ██╔══██║██║╚██╗██║██╔══╝  ██║╚██╔╝██║    ██╔══██╗██╔══██║██║╚██╗██║██╔═██╗ ");
            Console.WriteLine(@" ██║     ██║  ██║██║ ╚████║███████╗██║ ╚═╝ ██║    ██████╦╝██║  ██║██║ ╚████║██║  ██╗");
            Console.WriteLine(@" ╚═╝     ╚═╝  ╚═╝╚═╝  ╚═══╝╚══════╝╚═╝     ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n╠══════════════════════════════════════════════════════════════════════════╣");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    \"GARANTINDO A SOBERANIA FINANCEIRA EM TODOS OS 12 DISTRITOS.\"    ");
            Console.WriteLine("             \"QUE OS SALDOS ESTEJAM SEMPRE A SEU FAVOR!\"             ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════╣");
            Console.ResetColor();
        } //---------------

        static void Main(string[] args)
        {
            List<ContaBancaria> contas = new List<ContaBancaria>();
            ContaBancaria contaAtual = null;
            int contador = 1234;
            int opcao = -1;

            do
            {
                try
                {
                    Console.Clear();
                    ExibirCabecalho();
                    if (contas.Count == 0)
                    {

                        Console.WriteLine("\nAinda não indentificamos nenhuma conta cadastrada. Continue com as opções abaixo:");
                        Console.WriteLine("\n1 - Criar conta Corrente");
                        Console.WriteLine("2 - Criar conta Poupança");
                        Console.WriteLine("3 - Criar conta Empresarial");
                        Console.WriteLine("0 - Sair");
                        Console.WriteLine("\nEscolha e digite uma opção:");
                        opcao = int.Parse(Console.ReadLine());

                        if (opcao > 3)
                        {
                            Console.WriteLine("Adicione uma opção válida.");
                            Console.ReadKey();
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\n[Conta Ativa: {contaAtual.Titular} - {contaAtual.GetType().Name}]");
                        Console.WriteLine("\n1 - Criar conta Corrente");
                        Console.WriteLine("2 - Criar conta Poupança");
                        Console.WriteLine("3 - Criar conta Empresarial");
                        Console.WriteLine("4 - Depositar");
                        Console.WriteLine("5 - Sacar");
                        Console.WriteLine("6 - Extrato");

                        if (contaAtual is ContaPoupanca)
                        {
                            Console.WriteLine("7 - Visualizar rendimento da conta");
                        }
                        if (contaAtual is ContaEmpresarial)
                        {
                            Console.WriteLine("7 - Solicitar empréstimo");
                        }
                        Console.WriteLine("0 - Sair");
                        Console.WriteLine("\nEscolha e digite uma opção:");
                        opcao = int.Parse(Console.ReadLine());
                    }




                    switch (opcao)
                    {

                        case 1:
                            string t1;
                            do
                            {
                                Console.WriteLine("Digite o nome do titular da conta corrente:");
                                t1 = Console.ReadLine();

                                if (string.IsNullOrWhiteSpace(t1) || !t1.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                                {
                                    Console.WriteLine("Nome inválido! Digite apenas letras.\n");
                                }
                                else
                                {
                                    break;
                                }
                            } while (true);

                            decimal s1;
                            do
                            {
                                Console.Write("Digite o saldo inicial: R$ ");
                                if (!decimal.TryParse(Console.ReadLine(), out s1) || s1 < 0)
                                {
                                    Console.WriteLine("Valor inválido! Digite um saldo positivo ou zero.\n");
                                }
                                else
                                {
                                    break;
                                }
                            } while (true);

                            contaAtual = new ContaCorrente(t1, contador++, s1);
                            contas.Add(contaAtual);

                            Console.WriteLine($"\nConta Corrente criada com sucesso! Número da conta: {contador - 1}");
                            Console.WriteLine("\nPressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            break;


                        case 2:
                            string t2;
                            do
                            {
                                Console.WriteLine("Digite o nome do titular da conta poupança:");
                                t2 = Console.ReadLine();

                                if (string.IsNullOrWhiteSpace(t2) || !t2.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                                {
                                    Console.WriteLine("Nome inválido! Digite apenas letras.\n");
                                }
                                else
                                {
                                    break;
                                }
                            } while (true);

                            decimal s2;
                            do
                            {
                                Console.Write("Digite o saldo inicial: R$ ");
                                if (!decimal.TryParse(Console.ReadLine(), out s2) || s2 < 0)
                                {
                                    Console.WriteLine("Valor inválido! Digite um saldo positivo ou zero.\n");
                                }
                                else
                                {
                                    break;
                                }
                            } while (true);

                            contaAtual = new ContaPoupanca(t2, contador++, s2);
                            contas.Add(contaAtual);
                            Console.WriteLine($"\nConta Poupança criada com sucesso! Número da conta: {contador - 1}");
                            Console.WriteLine("\nPressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            break;



                        case 3:

                            string t3;
                            do
                            {
                                Console.WriteLine("Digite o nome do titular da conta empresarial:");
                                t3 = Console.ReadLine();

                                if (string.IsNullOrWhiteSpace(t3) || !t3.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                                {
                                    Console.WriteLine("Nome inválido! Digite apenas letras.\n");
                                }
                                else
                                {
                                    break;
                                }
                            } while (true);

                            decimal s3;
                            do
                            {
                                Console.Write("Digite o saldo inicial: R$ ");
                                if (!decimal.TryParse(Console.ReadLine(), out s3) || s3 < 0)
                                {
                                    Console.WriteLine("Valor inválido! Digite um saldo positivo ou zero.\n");
                                }
                                else
                                {
                                    break;
                                }
                            } while (true);

                            contaAtual = new ContaEmpresarial(t3, contador++, s3);
                            contas.Add(contaAtual);
                            Console.WriteLine($"\nConta Empresarial criada com sucesso! Número da conta: {contador - 1}");
                            Console.WriteLine("\nPressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            break;



                        case 4:
                            if (contaAtual != null)
                            {
                                Console.WriteLine("Digite o valor a ser depositado: R$ ");
                                decimal valorDeposito = decimal.Parse(Console.ReadLine());
                                contaAtual.Depositar(valorDeposito);
                            }
                            Console.WriteLine("\nPressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            break;

                        case 5:
                            if (contaAtual != null)
                            {
                                if (contaAtual.Saldo <= 0) { 
                                    Console.WriteLine("Não é possível realizar o saque. Sua conta está sem saldo. Faça um deposito:");
                                }
                                else { Console.WriteLine("Digite o valor a ser sacado: R$ ");
                                    decimal valorSaque = decimal.Parse(Console.ReadLine());
                                    contaAtual.Sacar(valorSaque);
                                }
                                }
                            Console.WriteLine("\nPressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            break;

                        case 6:
                            if (contaAtual != null)
                            {
                                if (contaAtual.Saldo <= 0)
                                {
                                    Console.WriteLine("\nVocê ainda não possue movimentações nessa conta.");
                                }
                                else {
                                    Console.WriteLine("\n--- EXTRATO ---");
                                    contaAtual.ExtratoAtual(); } 
                            }
                            Console.WriteLine("\nPressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            break;

                        case 7:
                            if (contaAtual is ContaPoupanca poupanca)
                            {
                                if (poupanca.Saldo <= 0)
                                {
                                    Console.WriteLine("\nNão é possível calcular o rendimento. Sua conta está sem saldo. Faça um deposito:");
                                }
                                else
                                {
                                    decimal taxa = 0.7m;
                                    poupanca.Rendimento(taxa);
                                }
                            }
                            else if (contaAtual is ContaEmpresarial emprest)
                            {
                                Console.WriteLine("Seu limite é de: R$10.000");
                                Console.WriteLine("Digite o valor do empréstimo: R$ ");
                                decimal valorEmprestimo = decimal.Parse(Console.ReadLine());
                                emprest.SolicitarEmprestimo(valorEmprestimo);
                            }
                            else if (contaAtual != null)
                            {
                                Console.WriteLine("\nOpção inválida.");
                            }
                            Console.WriteLine("\nPressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            break;

                        case 0:
                            Console.WriteLine("Saindo do sistema. Obrigada!");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            Console.ReadKey();
                            break;

                    }




                }

                catch (FormatException)
                {
                    Console.WriteLine("\n ERRO:Por favor, digite um número válido.");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                    Console.ReadKey();
                }
            } while (opcao != 0);

        }

    }
}