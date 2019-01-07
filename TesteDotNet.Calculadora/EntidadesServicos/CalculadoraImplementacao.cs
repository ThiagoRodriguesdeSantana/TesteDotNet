using System;
using System.Collections.Generic;
using System.Linq;
using TesteDotNet.Calculadora.Enuns;
using TesteDotNet.Calculadora.Extensoes;
using TesteDotNet.Calculadora.Interfaces;

namespace TesteDotNet.Calculadora.EntidadesServicos
{
    public class CalculadoraImplementacao : ICalculadora
    {

        private static CalculadoraImplementacao _Calculadora;

        private CalculadoraImplementacao()
        {
        }

        public static CalculadoraImplementacao ObterInstancia()
        {
            if (_Calculadora == null)
                _Calculadora = new CalculadoraImplementacao();
            return _Calculadora;
        }

        public decimal Calcular(OperacoesEnum operacoesEnum, List<decimal> numeros)
        {
            var numerosArray = SomenteDoisNumeros(operacoesEnum, numeros);

            switch (operacoesEnum)
            {
                case OperacoesEnum.Somar:
                    return Soma(numeros);
                case OperacoesEnum.Subtrair:
                    return Subtrair(numerosArray[0], numerosArray[1]);
                case OperacoesEnum.Multiplicar:
                    return Multiplicar(numerosArray[0], numerosArray[1]);
                case OperacoesEnum.Dividir:
                    return Dividir(numerosArray[0], numerosArray[1]);
                case OperacoesEnum.Media:
                    return Media(numeros);
                case OperacoesEnum.SomarSomentePares:
                    return SomarSomentePares(numeros);
            }

            throw new Exception($"A opreção {operacoesEnum} é inválida!");
        }

        private decimal SomarSomentePares(List<decimal> numeros)
        {
            var numerosPares = numeros.Where(c => SePar(c)).ToList();
            return Soma(numerosPares);
        }

        private bool SePar(decimal c)
        {
            return c % 2 == decimal.Zero;
        }

        private decimal Media(List<decimal> numeros)
        {
            var soma = Soma(numeros);
            return Dividir(soma, numeros.Count());
        }

        private decimal Dividir(decimal primeiroNumro, decimal segundoNumero)
        {
            if (segundoNumero <= 0)
                throw new Exception($"Divião: {primeiroNumro} / {segundoNumero}./n" +
                    $"Não é permitida divisão por zero");

            return primeiroNumro / segundoNumero;

        }

        private decimal[] SomenteDoisNumeros(OperacoesEnum operacao, List<decimal> numeros)
        {
            var numerosArray = numeros.ToArray();
            var descricao = operacao.ObterDescricaoDoEnum();

            if (numerosArray.Length > 2 
                && (operacao == OperacoesEnum.Subtrair
                || operacao == OperacoesEnum.Multiplicar
                || operacao == OperacoesEnum.Dividir))
                throw new Exception($"{descricao} Devem haver apenas 2 números para essa operação!");
            return numerosArray;
        }

        private decimal Multiplicar(decimal primeiroNumero, decimal segundoNumero) 
            => primeiroNumero * segundoNumero;

        private decimal Subtrair(decimal primeiroNumero, decimal segundoNumero) 
            => primeiroNumero - segundoNumero;

        private decimal Soma(List<decimal> numeros)
        {
            var resultado = decimal.Zero;
            numeros.ForEach(c => resultado += c);
            return resultado;
        }
    }
}