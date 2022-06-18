// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

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