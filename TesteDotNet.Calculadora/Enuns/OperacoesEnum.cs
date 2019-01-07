using System.ComponentModel;

namespace TesteDotNet.Calculadora.Enuns
{
    public enum OperacoesEnum
    {
        [Description("Somar")]
        Somar = 1,
        [Description("Subtrair")]
        Subtrair = 2,
        [Description("Multiplicar")]
        Multiplicar = 3,
        [Description("Dividir")]
        Dividir = 4,
        [Description("Calcular Média")]
        Media = 5,
        [Description("Somar Somente Números Pares")]
        SomarSomentePares = 6,
        [Description("Ler Arquivo")]
        LerArquivo = 7

    }
}
