using System;
using System.Security.Cryptography.X509Certificates;

namespace Calculadora
{
    public class Calculator
    {

        private List<string> _historico;
        private int _quantidadeOperacoes;

        public Calculator()
        {
            _historico = new List<string>();
            _quantidadeOperacoes = 0;
        }

        public int QuantidadeOperacoes
        {
            get { return _quantidadeOperacoes; }
        }

        public static void Main()
        {

            Calculator calc = new Calculator();

            bool continuar = true;

            while (continuar)
            {

                int opcao = Helpers.OpcaoMenu();


                switch (opcao)
                {
                    case 1:
                        calc.Somar();
                        break;
                    case 2:
                        calc.Subtrair();
                        break;
                    case 3:
                        calc.Dividir();
                        break;
                    case 4:
                        calc.Multiplicar();
                        break;
                    case 5:
                        calc.CalcularPorcentagem();
                        break;
                    case 6:
                        calc.RaizQuadrada();
                        break;
                    case 7:
                        calc.VerHistórico();
                        break;
                    case 0:
                        continuar = false;
                        break;
                }
                if (continuar && opcao != 7)
                {
                    continuar = Helpers.PerguntarSeContinua();
                }

            }
            Console.WriteLine("obrigado por usar a calculadora,até mais");
        }





        public void Somar()
        {
            Console.Clear();
            Helpers.CorAmarelo("SOMA");
            Console.WriteLine(new string('=', 40));

            int num1 = LerNumeroValidado("digite o primeiro número");
            int num2 = LerNumeroValidado("digite o segundo número");
            int resultado = num1 + num2;


            string calculo = $"{num1} + {num2} = {resultado}";
            _historico.Add(calculo);
            _quantidadeOperacoes++;

            Helpers.CorVerde($"a soma dos dois números é: {resultado}");
        }
        public void Subtrair()
        {
            Console.Clear();
            Helpers.CorAmarelo("SUBTRAÇÃO");
            Console.WriteLine(new string('=', 40));
            int num1 = LerNumeroValidado("digite o primeiro número");
            int num2 = LerNumeroValidado("digite o segundo número");
            int resultado = num1 - num2;

            string calculo = $"{num1} - {num2} = {resultado}";
            _historico.Add(calculo);

            Helpers.CorVerde($"a subtração dos dois números é: {resultado}");
        }

        public void Dividir()
        {
            Console.Clear();
            Helpers.CorAmarelo("DIVISÃO");
            Console.WriteLine(new string('=', 40));
            int num1 = LerNumeroValidado("digite o primeiro número");
            int num2 = LerNumeroValidado("digite o segundo número");
            int resultado = num1 / num2;

            string calculo = $"{num1} / {num2} = {resultado}";
            _historico.Add(calculo);

            Helpers.CorVerde($"a divisão entre os dois números é: {resultado}");
        }

        public void Multiplicar()
        {
            Console.Clear();
            Helpers.CorAmarelo("MULTIPLICAÇÃO");
            Console.WriteLine(new string('=', 40));
            int num1 = LerNumeroValidado("digite o primeiro número");
            int num2 = LerNumeroValidado("digite o segundo número");
            int resultado = num1 * num2;

            string calculo = $"{num1} * {num2} = {resultado}";
            _historico.Add(calculo);

            Helpers.CorVerde($"a multiplicação dos dois números é: {resultado}");
        }



        private int LerNumeroValidado(string mensagem)
        {
            Helpers.CorAzul(mensagem);
            string input = Console.ReadLine()!;

            while (!Helpers.conferirSeForNumero(input))
            {
                Helpers.CorVermelho("Número inválido,digite novamente");
                input = Console.ReadLine()!;
            }

            return int.Parse(input);
        }

        public void CalcularPorcentagem()
        {
            Console.Clear();
            Helpers.CorAmarelo("PORCENTAGEM");
            Console.WriteLine(new string('=', 40));
            int num1 = LerNumeroValidado("digite a porcentagem primeiro");
            int num2 = LerNumeroValidado("digite o número");

            double resultado = (num1 * num2) / 100.0;


            string calculo = $"{num1}% de {num2} = {resultado}";
            _historico.Add(calculo);

            Helpers.CorVerde($"{num1}% de {num2} é {resultado}");
        }

        public void VerHistórico()
        {
            Console.Clear();
            Helpers.CorAzul("HISTÓRICO DE CÁLCULOS");
            Console.WriteLine(new string('=', 40));

            if (_historico.Count == 0)
            {
                Helpers.CorAmarelo("Nenhum cálculo adicionado ainda");
            }

            else
            {
                for (int i = _historico.Count - 1; i >= 0; i--)
                {
                    Console.WriteLine($"{_historico.Count - i}. {_historico[i]}");
                }
            }

            Console.WriteLine(new string('=', 40));
            Helpers.CorAmarelo("Pressione qualquer tecla para voltar");
            Console.ReadKey();
        }

        public List<string> GetHistorico()
        {
            return new List<string>(_historico);
        }



        public void RaizQuadrada()
        {
            Console.Clear();
            Helpers.CorAmarelo("RAIZ QUADRADA");
            Console.WriteLine(new string('=', 40));

            int num1 = LerNumeroValidado("Digite o número para descobrir a raiz quadrada");
            double resultado = Math.Sqrt(num1);

            Helpers.CorAzul($"A raiz quadrada de {num1} é {resultado}");

            string calculo = $"√{num1} = {resultado}";
            _historico.Add(calculo);
        }

        public static class Helpers
        {
            public static int OpcaoMenu()
            {
                while (true)
                {
                    Console.Clear();
                    Helpers.CorAzul("BEM VINDO À CALCULADORA");

                    Helpers.CorAmarelo(new string('═', 40));
                    Helpers.CorAmarelo("1 - Soma");
                    Helpers.CorAmarelo("2 - Subtração");
                    Helpers.CorAmarelo("3 - Divisão");
                    Helpers.CorAmarelo("4 - Multiplicação");
                    Helpers.CorAmarelo("5 - Porcentagem");
                    Helpers.CorAmarelo("6 - Raiz Quadrada");
                    Helpers.CorAmarelo("7 - Ver Histórico");

                    Helpers.CorVermelho("0 - SAIR");
                    Console.WriteLine(new string('═', 40));
                    Console.Write("Escolha uma opção: ");

                    string tentativa = Console.ReadLine()!;

                    if (Helpers.conferirSeForNumero(tentativa))
                    {
                        int opcao = int.Parse(tentativa);

                        if (opcao >= 0 && opcao <= 7)
                        {
                            return opcao;
                        }
                        else
                        {
                            Helpers.CorVermelho("Digite um número entre 0 e 7!");
                        }
                    }
                    else
                    {
                        Helpers.CorVermelho("Valor inválido! Digite um número.");
                    }
                    Console.WriteLine();
                }
            }

            public static bool PerguntarSeContinua()
            {
                Console.WriteLine("\n" + new string('═', 40));
                Console.WriteLine("Deseja voltar para o menu?");
                Console.WriteLine("Digite [S] para SIM ou [N] para NÃO");

                while (true)
                {
                    string resposta = Console.ReadLine()!.ToUpper();

                    if (resposta == "S" || resposta == "SIM")
                    {
                        Helpers.CorVerde("Continuando...");
                        return true;
                    }

                    else if (resposta == "N" || resposta == "NAO" || resposta == "NÃO")
                    {
                        Helpers.CorAmarelo("Saindo...");
                        return false;
                    }

                    Helpers.CorVermelho("Digite S ou N");

                }
            }


            public static bool conferirSeForNumero(string input)
            {
                return int.TryParse(input, out _);
            }

            public static void CorVerde(string texto)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(texto);
                Console.ResetColor();
            }

            public static void CorAzul(string texto)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(texto);
                Console.ResetColor();
            }

            public static void CorVermelho(string texto)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(texto);
                Console.ResetColor();
            }

            public static void CorAmarelo(string texto)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(texto);
                Console.ResetColor();
            }
        }
    }
}