#region KotikoBlog Header License

// // Solution: Curriculum
// // Project: Curriculum.CoreUtils
// //
// // This file is included in the Curriculum solution.
// //
// // File created on 16/01/2016   23:10
// //
// // File Modified on 16/01/2016/   23:10
// 
// // Permission is hereby granted, free of charge, to any person obtaining a copy
// // of this software and associated documentation files (the "Software"), to deal
// // in the Software without restriction, including without limitation the rights
// // to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// // copies of the Software, and to permit persons to whom the Software is
// // furnished to do so, subject to the following conditions:
// //
// // The above copyright notice and this permission notice shall be included in all
// // copies or substantial portions of the Software.
// //
// // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// // IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// // FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// // AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// // LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// // OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// // SOFTWARE.

#endregion

#region

using System.Text;
using SHA3;

#endregion

namespace Curriculum.CoreUtils.Security
{
    /// <summary>
    /// </summary>
    public static class CryptographyUtil
    {
        /// <summary>
        ///     take any string and encrypt it using SHA3 then
        ///     return the encrypted data
        /// </summary>
        /// <param name="data">input text you will enterd to encrypt it</param>
        /// <returns>return the encrypted text as hexadecimal string</returns>
        public static string Encrypted(string data)
        {
            var sha3 = new SHA3Managed(512);

            //convert the input text to array of bytes
            var hashData = sha3.ComputeHash(Encoding.Default.GetBytes(data));

            //create new instance of StringBuilder to save hashed data
            var returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (var i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            // return hexadecimal string
            return returnValue.ToString();
        }

        /// <summary>
        ///     encrypt input text using SHA3 and compare it with
        ///     the stored encrypted text
        /// </summary>
        /// <param name="inputData">input text you will enterd to encrypt it</param>
        /// <param name="storedHashData">
        ///     the encrypted text
        ///     stored on file or database ... etc
        /// </param>
        /// <returns>true or false depending on input validation</returns>
        public static bool ValidateHashData(string inputData, string storedHashData)
        {
            //hash input text and save it string variable
            var hashInputData = Encrypted(inputData);

            if (string.Compare(hashInputData, storedHashData) == 0)
            {
                return true;
            }
            return false;
        }
    }
}