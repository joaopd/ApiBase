using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Dominio.Entidades.Base
{
    public class ValidadorDeSenha : ValidationAttribute
    {
        public ValidadorDeSenha() : base("Senha Fraca:  Por favor, digite uma senha segura...A senha deve ter pelomenos 8 caracteres. Para torná-la mais forte, use letras maiúsculas e minúsculas, números e seimbolos como !?#$& ") { }
        public override bool IsValid(object value)
        {
            int tamanhoMinimo = 8;
            int tamanhoMinusculo = 1;
            int tamanhoMaiusculo = 1;
            int tamanhoNumeros = 1;
            int tamanhoCaracteresEspeciais = 1;
            string password = value.ToString();

            // Definição de letras minusculas
            Regex regTamanhoMinusculo = new Regex("[a - z]");

            // Definição de letras minusculas
            Regex regTamanhoMaiusculo = new Regex("[A - Z]");

            // Definição de letras minusculas
            Regex regTamanhoNumeros = new Regex("[0 - 9]");

            // Definição de letras minusculas
            Regex regCaracteresEspeciais = new Regex("[^a - zA - Z0 - 9]");

            // Verificando tamanho minimo
            if (password.Length < tamanhoMinimo)
            {
                return false;
            }

            // Verificando caracteres minusculos
            if (regTamanhoMinusculo.Matches(password).Count < tamanhoMinusculo)
            {
                return false;
            }

            // Verificando caracteres maiusculos
            if (regTamanhoMaiusculo.Matches(password).Count < tamanhoMaiusculo)
            {
                return false;
            }

            // Verificando numeros
            if (regTamanhoNumeros.Matches(password).Count < tamanhoNumeros)
            {
                return false;
            }

            // Verificando os diferentes
            if (regCaracteresEspeciais.Matches(password).Count < tamanhoCaracteresEspeciais)
            {
                return false;
            }

            return true;
        }
    }
}
