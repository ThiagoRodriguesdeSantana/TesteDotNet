using System.Collections.Generic;
using TesteDotNet.Calculadora.Enuns;

namespace TesteDotNet.Calculadora.Interfaces
{
    public interface ICalculadora
    {
        decimal Calcular(OperacoesEnum operacoesEnum, List<decimal> numeros);

    }
}
