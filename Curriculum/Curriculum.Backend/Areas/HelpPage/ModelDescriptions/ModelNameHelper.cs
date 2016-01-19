#region KotikoBlog Header License

// // Solution: Curriculum
// // Project: Curriculum.Backend
// //
// // This file is included in the Curriculum solution.
// //
// // File created on 18/01/2016   11:23
// //
// // File Modified on 18/01/2016/   11:23
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

using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

#endregion

namespace Curriculum.Backend.Areas.HelpPage.ModelDescriptions
{
    internal static class ModelNameHelper
    {
        // Modify this to provide custom model name mapping.
        public static string GetModelName(Type type)
        {
            var modelNameAttribute = type.GetCustomAttribute<ModelNameAttribute>();
            if (modelNameAttribute != null && !string.IsNullOrEmpty(modelNameAttribute.Name))
            {
                return modelNameAttribute.Name;
            }

            var modelName = type.Name;
            if (type.IsGenericType)
            {
                // Format the generic type name to something like: GenericOfAgurment1AndArgument2
                var genericType = type.GetGenericTypeDefinition();
                var genericArguments = type.GetGenericArguments();
                var genericTypeName = genericType.Name;

                // Trim the generic parameter counts from the name
                genericTypeName = genericTypeName.Substring(0, genericTypeName.IndexOf('`'));
                var argumentTypeNames = genericArguments.Select(t => GetModelName(t)).ToArray();
                modelName = string.Format(CultureInfo.InvariantCulture, "{0}Of{1}", genericTypeName,
                    string.Join("And", argumentTypeNames));
            }

            return modelName;
        }
    }
}