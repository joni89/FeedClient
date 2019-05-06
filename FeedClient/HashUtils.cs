using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FeedClient
{
    public class HashUtils
    {
        public static string ComputeHash(string input)
        {
            SHA1 sha1 = SHA1CryptoServiceProvider.Create();

            byte[] inputBytes = ASCIIEncoding.Default.GetBytes(input);
            byte[] outputBytes = sha1.ComputeHash(inputBytes);

            StringBuilder hashBuilder = new StringBuilder();
            foreach (byte b in outputBytes)
            {
                hashBuilder.AppendFormat("{0:x2}", b);
            }

            return hashBuilder.ToString();
        }
    }
}
