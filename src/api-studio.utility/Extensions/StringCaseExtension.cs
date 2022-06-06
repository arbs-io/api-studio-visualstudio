// The MIT License (MIT)
//
// Copyright (c) 2022 Andrew Butson
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Text.RegularExpressions;

namespace ApiStudioIO.Utility.Extensions
{
    public static class StringCaseExtension
    {
        public static string ToPascalCase(this string str, bool alphaNumericOnly = true)
        {
            if (alphaNumericOnly) str = ConvertToAlphaNumeric(str);

            var parts = str.Split(new char[] { },
                StringSplitOptions.RemoveEmptyEntries);
            var joinResult = string.Join(string.Empty, parts);
            return joinResult.Substring(0, 1).ToUpper() + str.Substring(1);
        }

        public static string ToCamelCase(this string str, bool alphaNumericOnly = true)
        {
            str = str.ToPascalCase(alphaNumericOnly);
            return str.Substring(0, 1).ToLower() + str.Substring(1);
        }

        public static string ToSnakeCase(this string str, bool alphaNumericOnly = true, bool convertToLower = true)
        {
            if (alphaNumericOnly) str = ConvertToAlphaNumeric(str);

            str = Regex.Replace(
                Regex.Replace(
                    Regex.Replace(str, @"([\p{Lu}]+)([\p{Lu}][\p{Ll}])", "$1_$2")
                    , @"([\p{Ll}\d])([\p{Lu}])", "$1_$2")
                , @"[-\s]", "_");

            if (convertToLower) return str.ToLower();

            return str;
        }

        public static string ToSpinalCase(this string str, bool alphaNumericOnly = true, bool convertToLower = true)
        {
            return str.ToSnakeCase(alphaNumericOnly, convertToLower).Replace("_", "-");
        }

        public static string ToAlphaNumeric(this string str, bool removeWhitespace = false)
        {
            if (removeWhitespace)
                return ConvertToAlphaNumeric(str).Replace(" ", "");
            return ConvertToAlphaNumeric(str);
        }

        private static string ConvertToAlphaNumeric(string str)
        {
            return Regex.Replace(str, @"[^0-9a-zA-Z\\s]+", " ");
        }
    }
}