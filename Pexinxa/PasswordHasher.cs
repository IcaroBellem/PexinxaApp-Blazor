using System;
using System.Security.Cryptography;
using System.Text;

namespace Pexinxa
{
	public class PasswordHasher
	{
		public static string HashPassword(string senha)
		{
			//Gerando um salt aleatorio 
			byte[] salt = new byte[16];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(salt);
			}

			//Combinando senha com salt 
			string saltedPassword = string.Concat(salt, senha);

			//Gerando o Hash da senha com salt 
			using (var sha256 = SHA256.Create())
			{
				byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
				return Convert.ToBase64String(hashBytes);
			}
		}

		public static bool VerifyPassword(string Senha, string storedHash)
		{
			//Dividindo o hash armazenando em salt e hash 
			byte[] hashBytes = Convert.FromBase64String(storedHash);
			byte[] salt = new byte[16];
			Array.Copy(hashBytes, 0, salt, 0, 16);
			byte[] storedHashBytes = new byte[hashBytes.Length - 16];
			Array.Copy(hashBytes, 16, storedHashBytes, 0, storedHashBytes.Length);

			//Criando um novo hash com o salt e a senha
			string hashedPassword = HashPassword(Senha, salt);

            //Comparando os hashes
            return storedHashBytes.SequenceEqual(Convert.FromBase64String(hashedPassword));
        }

		//Funcao auxiliar para combinar salt com a senha
		private static string HashPassword(string Senha, byte[] salt)
		{
            string saltedPassword = string.Concat(salt, Senha);
			using (var sha256 = SHA256.Create())
			{
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                return Convert.ToBase64String(hashBytes);
            }

        }

		public PasswordHasher()
		{
		}
	}
}

