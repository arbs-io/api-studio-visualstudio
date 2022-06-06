﻿// The MIT License (MIT)
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

using System.Security.Cryptography;
using System.Text;

namespace ApiStudioIO.CodeGeneration.VisualStudio
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