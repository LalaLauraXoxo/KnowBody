using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ASI.Basecode.Services.Manager
{
    /// <summary>
    /// Password Manager
    /// </summary>
    public class PasswordManager
    {
        /// <summary>
        /// Gets or sets the secret key.
        /// </summary>
        public static string secretKey { get; set; }

        /// <summary>
        /// Sets up.
        /// </summary>
        /// <param name="tokenAuthConfig">Token authentication configuration</param>
        public static void SetUp(IConfigurationSection tokenAuthConfig)
        {
            secretKey = tokenAuthConfig.GetValue<string>("SecretKey");
        }

        /// <summary>
        /// Encrypts the password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static string EncryptPassword(string password)
        {
            byte[] iv = new byte[16];
            byte[] aesKey = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                var keyBytes = Encoding.UTF8.GetBytes(secretKey);
                Array.Copy(keyBytes, aesKey, Math.Min(keyBytes.Length, aesKey.Length));
                aes.Key = aesKey;
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(password);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        /// <summary>
        /// Decrypts the password.
        /// </summary>
        /// <param name="encryptedPassword">The encrypted password.</param>
        /// <returns></returns>
        public static string DecryptPassword(string encryptedPassword)
        {
            byte[] iv = new byte[16];
            byte[] aesKey = new byte[16];
            byte[] buffer = Convert.FromBase64String(encryptedPassword);

            using (Aes aes = Aes.Create())
            {
                var keyBytes = Encoding.UTF8.GetBytes(secretKey);
                Array.Copy(keyBytes, aesKey, Math.Min(keyBytes.Length, aesKey.Length));
                aes.Key = aesKey;
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

    }
}
