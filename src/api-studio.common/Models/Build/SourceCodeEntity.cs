// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Security.Cryptography;
using System.Text;

namespace ApiStudioIO.Common.Models.Build
{
    public class SourceCodeEntity
    {
        public SourceCodeEntity(string filename, string codeBase, bool alwaysOverwrite)
        {
            Filename = filename;
            CodeBase = codeBase;
            AlwaysOverwrite = alwaysOverwrite;
        }

        public SourceCodeEntity(string filename, string codeBase, bool alwaysOverwrite, string nestedFilename)
        {
            Filename = filename;
            CodeBase = codeBase;
            AlwaysOverwrite = alwaysOverwrite;
            NestedFilename = nestedFilename;
        }

        public string Filename { get; }
        public string CodeBase { get; }
        public bool AlwaysOverwrite { get; }
        public string NestedFilename { get; }

        public string Checksum => CreateMd5(CodeBase);

        private static string CreateMd5(string input)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                foreach (var t in hashBytes) sb.Append(t.ToString("X2"));
                return sb.ToString();
            }
        }
    }
}