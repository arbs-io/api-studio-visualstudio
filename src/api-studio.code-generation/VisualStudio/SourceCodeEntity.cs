namespace ApiStudioIO.CodeGeneration.VisualStudio
{
    using System.Text;

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
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                foreach (var t in hashBytes)
                {
                    sb.Append(t.ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}