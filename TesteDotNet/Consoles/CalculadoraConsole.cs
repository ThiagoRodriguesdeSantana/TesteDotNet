using System;
using System.Collections.Generic;
using System.IO;
using TesteDotNet.Calculadora.Enuns;
using TesteDotNet.Calculadora.Extensoes;
using TesteDotNet.Calculadora.Interfaces;

namespace TesteDotNet.Consoles
{
    public class CalculadoraConsole
    {
        private ICalculadora _ICalculadora;
        private readonly ILeitorDeArquivo _LeitorDeArquivo;
        private readonly ConsoleColor _corPadrao;
        private Dictionary<string, decimal> _resultadoArquivo;


        public CalculadoraConsole(ICalculadora calculadora, ILeitorDeArquivo leitorDeArquivo)
        {
            _ICalculadora = calculadora;
            _LeitorDeArquivo = leitorDeArquivo;
            _corPadrao = Console.ForegroundColor;
        }


        public void Exibir()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = _corPadrao;
                _resultadoArquivo = new Dictionary<string, decimal>();
                var parametros = ObterParamtros();

                if ((OperacoesEnum)parametros.Item1 != OperacoesEnum.LerArquivo)
                {
                    var resultado = _ICalculadora.Calcular((OperacoesEnum)parametros.Item1, parametros.Item2);
                    _resultadoArquivo.Add("Resultado", resultado);
                    ExibirResultado();
                }
                else
                {
                    LerArquivo();
                    ExibirResultado();

                }

                ValidarTeclaPressionada();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Exibir();
            }
        }

        private void LerArquivo()
        {
            var streamReader = new StreamReader("../../Arquivo/Arquivo.txt");
            var arquivos = _LeitorDeArquivo.Ler(streamReader);


            foreach (var arquivo in arquivos)
            {
                var resultado = _ICalculadora.Calcular(arquivo.Operacao, arquivo.Numeros);
                _resultadoArquivo.Add(arquivo.Nome, resultado);
            }
        }

        private void ValidarTeclaPressionada()
        {
            if (Console.ReadKey().Key != ConsoleKey.Escape)
                Exibir();
        }

        private void ExibirResultado()
        {
            SaltarLinha();
            SaltarLinha();
            Console.WriteLine("-------------------------------------------Resultado-------------------------------- \n");

            foreach (var item in _resultadoArquivo)
            {
                Console.WriteLine($"                          {item.Key}: {item.Value}");
            }

            SaltarLinha();
            SaltarLinha();
            Console.WriteLine($"           <Pressione qualquer tecla para continuar ou ESC para sair>       ");

            SaltarLinha();
            SaltarLinha();

        }

        private static void SaltarLinha() => Console.WriteLine("\n");

        private Tuple<int, List<decimal>> ObterParamtros()
        {
            Console.WriteLine("------Informe a operação e os numeros a serem calculados separados com \";\"(Ponto e virgula)----");
            SaltarLinha();

            var opercacoes = string.Empty;
            foreach (OperacoesEnum item in Enum.GetValues(typeof(OperacoesEnum)))
            {
                opercacoes = string.Concat(opercacoes, $"        {Convert.ToInt32(item)} - {item.ObterDescricaoDoEnum()} \n");
            }

            Console.WriteLine(opercacoes);
            SaltarLinha();
            SaltarLinha();

            var parametros = Console.ReadLine();

            var parametrosArray = parametros.Split(';');
            var operacaoSelecioanda = ValidarOperacao(parametrosArray[0]);
            List<decimal> listaNumeros = ObterNumeros(parametrosArray);
            return Tuple.Create(operacaoSelecioanda, listaNumeros);

        }

        private List<decimal> ObterNumeros(string[] parametrosArray)
        {
            var listaNumeros = new List<decimal>();
            for (int i = 1; i < parametrosArray.Length; i++)
            {
                var numeroNaPosicao = parametrosArray[i];
                VerificarSeNumerico(numeroNaPosicao);
                listaNumeros.Add(Convert.ToDecimal(numeroNaPosicao));

            }

            return listaNumeros;
        }

        private int ValidarOperacao(string operacao)
        {
            VerificarSeNumerico(operacao);
            return Convert.ToInt32(operacao);
        }

        private void VerificarSeNumerico(string operacao)
        {

            if (!operacao.SeNumerico())
                throw new Exception($"O valor {operacao} não é um número./n" +
                                    $"Deve ser informado apenas números!");

        }
    }
}
