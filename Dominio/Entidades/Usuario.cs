using Dominio.Entidades.Base;
using System.Security.Cryptography;
using System.Text;

namespace Dominio.Entidades
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public string Role { get; private set; }
        public Usuario(string nome, string senha, string role)
        {
            Nome = nome;
            Senha = CriarHash(senha);
            Role = role;
        }

        public string CriarHash(string texto)
        {
            MD5 md5 = MD5.Create();

            byte[] bytes = Encoding.ASCII.GetBytes(texto);
            byte[] hash = md5.ComputeHash(bytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
