using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace MSSA_Extensions
{
    public enum StringFormat
    {
        Base64,
        Hex
    }
    public static class MssaExtensions
    {
        public static string GetSHAString(this FileInfo _file, StringFormat format=StringFormat.Hex)
        {
            using (var sha1 = SHA1.Create())
            {
                byte[] fileHash = sha1.ComputeHash(_file.OpenRead());
                return format switch
                {
                    StringFormat.Base64 => Convert.ToBase64String(fileHash),
                    StringFormat.Hex => Convert.ToHexString(fileHash),
                    _ => Convert.ToBase64String(fileHash)
                };
            }
        }
    }
}