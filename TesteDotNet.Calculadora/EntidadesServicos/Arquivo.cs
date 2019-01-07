using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDotNet.Calculadora.Enuns;

namespace TesteDotNet.Calculadora.EntidadesServicos
{
    public class Arquivo
    {
        public string Nome { get; set; }
        public OperacoesEnum Operacao { get; set; }
        public List<decimal> Numeros { get; set; }

        public Arquivo()
        {
            this.Numeros = new List<decimal>();
        }
        
    }
}
