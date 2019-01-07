using System;
using TesteDotNet.Consoles;
using TesteDotNet.Calculadora.EntidadesServicos;

namespace TesteDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            BoasVindas();
            var calculadora = new CalculadoraConsole(CalculadoraImplementacao.ObterInstancia(), 
                LeitorDeArquivo.ObterInstancia());
            calculadora.Exibir();

            Despedida();
            
            

        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Despedida();
        }

        private static void Despedida()
        {
            
            for (int i = 0; i < 2; i++)
            {
                Console.Clear();
                Console.WriteLine("Obrigado por utilizar nossa calculadora");
                System.Threading.Thread.Sleep(2000);
            }
          
        }

        private static void BoasVindas()
        {
            for (int i = 0; i < 2; i++)
            {
                Console.Clear();
                
                Console.WriteLine("\n\n                                  Seja bem vindo !!!");
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
