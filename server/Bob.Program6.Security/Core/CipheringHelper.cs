using System;
using System.Security.Cryptography;
using System.Text;

namespace Bob.Program6.Security.Core
{
    public static class CipheringHelper
    {
        public static string ToSha256Hash(string content)
        {
            using (var sha2 = SHA256.Create())
            {
                var bytesContent = Encoding.UTF8.GetBytes(content);
                var hash = sha2.ComputeHash(bytesContent);
                var base64Hash = Convert.ToBase64String(hash);
                return base64Hash;
            }
        }
    }
}
