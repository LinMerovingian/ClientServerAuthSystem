using System;
using System.Text;

using System.Security.Cryptography;
namespace Winform_Client
{
    class Encryption
    {
        private static int saltLengthLimit = 32;
        private static byte[] GetSalt()
        {
            return GetSalt(saltLengthLimit);
        }
        private static byte[] GetSalt(int maximumSaltLength)
        {
            var salt = new byte[maximumSaltLength];
            using (rng)
            {
                rng.GetNonZeroBytes(salt);
            }

            return salt;
        }

        static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        
        public static String encryptPasswordWithSalt(String password, out String saltString)
        {
            var salt = GetSalt();
            rng.GetBytes(salt);
            var hash = GenerateSaltedHash(Encoding.UTF8.GetBytes(password), salt);

            saltString = Convert.ToBase64String(salt);

            return Convert.ToBase64String(hash);
        }
        
        public static String encryptPasswordWithSalt(String password, Byte[] salt)
        {
            var hash = GenerateSaltedHash(Encoding.UTF8.GetBytes(password), salt);

            return Convert.ToBase64String(hash);
        }

        static byte[] GenerateSaltedHash(byte[] passwordByteArray, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes = new byte[passwordByteArray.Length + salt.Length];

            for (int i = 0; i < passwordByteArray.Length; i++)
            {
                plainTextWithSaltBytes[i] = passwordByteArray[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[passwordByteArray.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
    }
}
