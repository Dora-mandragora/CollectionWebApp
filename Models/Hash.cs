using System;
using System.Security.Cryptography;
using System.Text;

namespace CollectionWebApp.Models
{
    static public class Hash
    {
        static public string GetHashString(string sourceString)
        {
            if (sourceString == null) return null;
            byte[] bytes = Encoding.Unicode.GetBytes(sourceString);
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;            
        }
    }
}
