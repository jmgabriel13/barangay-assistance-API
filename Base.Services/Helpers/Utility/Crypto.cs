using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Base.Services.Helpers.Utility
{
    public class Crypto
    {
        public static string MD5Encryption(string input)
        {
            string result = string.Empty;
            using (MD5 hash = MD5.Create())
            {
                byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sb.Append(data[i].ToString("x2"));

                    result = sb.ToString();
                }
                return result;
            }
        }

        public static string Encrypt(string forencrpyt)
        {
            MD5 md5 = MD5.Create();

            byte[] inputBytes = Encoding.UTF8.GetBytes(forencrpyt);

            string key = "$d$53cR3t1234567@p!c@550";

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            byte[] keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
            //Always release the resources and flush data
            // of the Cryptographic service provide. Best Practice

            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(inputBytes, 0,
              inputBytes.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();

            //// byte[] hash = md5.ComputeHash(resultArray);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < resultArray.Length; i++)
            {
                sb.Append(resultArray[i].ToString("X2"));
            }


            return sb.ToString();
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static string Decrypt(string fordecrypt)
        {
            //\u0016Y[i�\u000fl�
            byte[] toEncryptArray = StringToByteArray(fordecrypt);
            string x = UTF8Encoding.UTF8.GetString(toEncryptArray);

            string key = "$d$53cR3t1234567@p!c@550";

            //if hashing was used get the hash code with regards to your key
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            byte[] keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
            //release any resource held by the MD5CryptoServiceProvider

            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return Encoding.UTF8.GetString(resultArray);
        }
    }
}
