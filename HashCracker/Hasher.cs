using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Threading;

namespace HashCracker
{
    public class Hasher
    {
        public static string Md5Hash(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            MD5CryptoServiceProvider MD5Provider = new MD5CryptoServiceProvider();
            byte[] bytes = MD5Provider.ComputeHash(new UTF8Encoding().GetBytes(inputString));

            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public Hasher() { }
    }
}
