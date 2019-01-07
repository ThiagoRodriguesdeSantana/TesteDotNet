using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TesteDotNet.Calculadora.Extensoes
{
    public static class Extensoes 
    {
        public static string ObterDescricaoDoEnum(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static string RemoverCaracteresEspeciaisEAcentos(this string valor)
        {
            return valor.ToUpper().Replace("Ã", "A")
                .Replace("É", "E").Replace("Ê", "E").Replace("È", "E")
                .Replace("Í", "I").Replace("Õ", "O").Replace("Ô", "O")
                .Replace("Ú", "U").Replace("Ç", "C");
        }

        public static bool SeNumerico(this string valor)
        {
            var numerosArray = valor.ToCharArray();

            foreach (var item in numerosArray)
            {
                if (!char.IsDigit(item) && item != '-')
                    return false;
                continue;
            }
            return true;
        }
    }
}
