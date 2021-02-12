using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        private static List<Conta> _listaContas = new List<Conta>();

        static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("DIO Bank ao seu dispor");
            System.Console.WriteLine("Escolha a opção desejada");

            System.Console.WriteLine("1 - Listar Contas");
            System.Console.WriteLine("2 - Inserir nova Conta");
            System.Console.WriteLine("3 - Transferir");
            System.Console.WriteLine("4 - Sacar");
            System.Console.WriteLine("5 - Depositar");
            System.Console.WriteLine("C - Limpar Tela");
            System.Console.WriteLine("X - Sair");
            System.Console.WriteLine();

            return Console.ReadLine().ToUpper();
        }

        static void InserirConta()
        {
            System.Console.WriteLine("Inserir Nova Conta");

            System.Console.Write("Digite 1 para Conta do Física e 2 para Conta Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            System.Console.Write("Digite o Saldo Inicial da Conta: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            System.Console.Write("Digite o Crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            var conta = new Conta(
                tipoConta: (TipoConta)entradaTipoConta,
                saldo: entradaSaldo,
                credito: entradaCredito,
                nome: entradaNome
            );

            _listaContas.Add(conta);
        }

        static void ListarContas()
        {
            System.Console.WriteLine("Lista Contas");

            if (_listaContas.Count == 0)
            {
                System.Console.WriteLine("Nenhuma conta cadastrada!");
                return;
            }

            for (int i = 0; i < _listaContas.Count; i++)
            {
                var conta = _listaContas[i];
                System.Console.WriteLine($"#{i} - {conta}");
            }

        }

        static void Main(string[] args)
        {
            var opcao = ObterOpcaoUsuario();

            while (opcao != "X")
            {
                switch (opcao)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentException("opão inválida");
                }

                opcao = ObterOpcaoUsuario();
            }

            System.Console.WriteLine("Obrigado por utilizar o DIO Bank!");
            System.Console.ReadKey();
        }

        private static void Transferir()
        {
            System.Console.WriteLine("Transferência!");

            System.Console.Write("Digite o número da conta de origem: ");
            int.TryParse(Console.ReadLine(), out var indiceContaOrigem);

            System.Console.Write("Digite o número da conta de destino: ");
            int.TryParse(Console.ReadLine(), out var indiceContaDestino);

            System.Console.Write("Digite o valor para a ser transferido: ");
            double.TryParse(Console.ReadLine(), out var valorTransferido);

            _listaContas[indiceContaOrigem].Transferir(valorTransferido, _listaContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            System.Console.WriteLine("Depositar!");

            System.Console.Write("Digite o número da conta para o depósito: ");
            int.TryParse(Console.ReadLine(), out var indiceConta);

            System.Console.Write("Digite o valor a ser depositado: ");
            double.TryParse(Console.ReadLine(), out var valorDeposito);

            _listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            System.Console.WriteLine("Sacar!");

            System.Console.Write("Digite o número da conta para o saque: ");
            int.TryParse(Console.ReadLine(), out var indiceConta);

            System.Console.Write("Digite o valor para o saque: ");
            double.TryParse(Console.ReadLine(), out var valorSaque);

            _listaContas[indiceConta].Sacar(valorSaque);
        }
    }
}
