using System;
using System.Collections.Generic;
using System.IO;
using TesteDotNet.Calculadora.Enuns;
using TesteDotNet.Calculadora.Extensoes;
using TesteDotNet.Calculadora.Interfaces;

namespace TesteDotNet.Calculadora.EntidadesServicos
{
    public class LeitorDeArquivo : ILeitorDeArquivo
    {
        private static LeitorDeArquivo _Leitor;

        private LeitorDeArquivo()
        {
        }

        public static LeitorDeArquivo ObterInstancia()
        {
            if (_Leitor == null)
                _Leitor = new LeitorDeArquivo();
            return _Leitor;
        }


        public List<Arquivo> Ler(StreamReader stream)
        {
            var texto = string.Empty;
            var listaArquivo = new List<Arquivo>();



            while ((texto = stream.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(texto))
                    continue;

                var linha = texto.Split(';');

                var arquivo = new Arquivo();

                arquivo.Nome = linha[0];
                arquivo.Operacao = ObterOperacao(linha[1]);

                for (int i = 2; i < linha.Length; i++)
                {
                    if (linha[i].Replace(" ", "").SeNumerico())
                        arquivo.Numeros.Add(Convert.ToDecimal(linha[i]));
                }

                listaArquivo.Add(arquivo);
            }
            return listaArquivo;
        }

        private OperacoesEnum ObterOperacao(string descricao)
        {
            var desc = descricao.RemoverCaracteresEspeciaisEAcentos();

            OperacoesEnum opracao = OperacoesEnum.Somar;

            switch (desc)
            {
                case "SUBTRACAO":
                    opracao = OperacoesEnum.Subtrair;
                    break;
                case "DIVISAO":
                    opracao = OperacoesEnum.Dividir;
                    break;
                case "MULTIPLICACAO":
                    opracao = OperacoesEnum.Multiplicar;
                    break;

            }

            return opracao;
        }
    }
}
