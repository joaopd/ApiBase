using System.Security.Cryptography;
using System.Text;

namespace Dominio.Criptografar
{
    public interface ICriptografar
    {
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
