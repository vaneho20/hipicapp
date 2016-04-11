using SHA3;
using System.Text;

namespace Hipica.Utils.Security
{
    public static class CryptographyUtil
    {
        /// <summary>
        /// take any string and encrypt it using SHA3 then
        /// return the encrypted data
        /// </summary>
        /// <param name="data">input text you will enterd to encrypt it</param>
        /// <returns>return the encrypted text as hexadecimal string</returns>
        public static string Encrypted(string data)
        {
            SHA3Managed sha3 = new SHA3Managed(512);

            //convert the input text to array of bytes
            byte[] hashData = sha3.ComputeHash(Encoding.Default.GetBytes(data));

            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            // return hexadecimal string
            return returnValue.ToString();
        }

        /// <summary>
        /// encrypt input text using SHA3 and compare it with
        /// the stored encrypted text
        /// </summary>
        /// <param name="inputData">input text you will enterd to encrypt it</param>
        /// <param name="storedHashData">the encrypted text
        ///         stored on file or database ... etc</param>
        /// <returns>true or false depending on input validation</returns>
        public static bool ValidateHashData(string inputData, string storedHashData)
        {
            //hash input text and save it string variable
            string hashInputData = Encrypted(inputData);

            if (string.Compare(hashInputData, storedHashData) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}