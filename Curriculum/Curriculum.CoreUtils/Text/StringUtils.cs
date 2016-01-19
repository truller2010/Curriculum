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

using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

#endregion

namespace Curriculum.CoreUtils.Text
{
    /// <summary>
    /// </summary>
    public class StringUtils
    {
        /// <summary>
        /// </summary>
        private StringUtils()
        {
            // non instanceable
        }

        /// <summary>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string NormalizeString(string str)
        {
            var nfdNormalizedString = str.Normalize(NormalizationForm.FormD);
            return new string(nfdNormalizedString.Where(c => char.IsLetterOrDigit(c)).ToArray());
        }

        /// <summary>
        /// </summary>
        /// <param name="length"></param>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="str3"></param>
        /// <param name="str4"></param>
        /// <returns></returns>
        public static string ConcatByHyphen(int length, string str1, string str2, string str3, string str4)
        {
            return
                string.Concat(
                    string.IsNullOrWhiteSpace(str1)
                        ? string.Empty
                        : (str1.Length < length ? str1 : str1.Substring(0, length)),
                    string.IsNullOrWhiteSpace(str2)
                        ? string.Empty
                        : string.Concat("-", str2.Length < length ? str2 : str2.Substring(0, length)),
                    string.IsNullOrWhiteSpace(str3)
                        ? string.Empty
                        : string.Concat("-", str3.Length < length ? str3 : str3.Substring(0, length)),
                    string.IsNullOrWhiteSpace(str4)
                        ? string.Empty
                        : string.Concat("-", str4.Length < length ? str4 : str4.Substring(0, length)));
        }

        /// <summary>
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        /// <summary>
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Capitalize(string s)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
        }

        /// <summary>
        /// </summary>
        /// <param name="inputEmail"></param>
        /// <returns></returns>
        public static bool isValidEmail(string inputEmail)
        {
            var strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            var re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return true;
            return false;
        }
    }
}