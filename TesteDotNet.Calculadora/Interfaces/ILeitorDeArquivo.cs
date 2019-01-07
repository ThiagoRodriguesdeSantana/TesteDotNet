using System.Collections.Generic;
using System.IO;
using TesteDotNet.Calculadora.EntidadesServicos;

namespace TesteDotNet.Calculadora.Interfaces
{
    public interface ILeitorDeArquivo
    {
        List<Arquivo> Ler(StreamReader arquivo);
    }
}
