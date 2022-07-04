﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiStudioIO.Common.Models.Linting
{
    public class LintingError
    {
        public LintingError(string fileName)
        {
            FileName = fileName;
        }

        public string Provider { get; set; } = "Api Studio";
        public string FileName { get; set; }
        public string Message { get; set; }
        public int LineNumber { get; set; }
        public int ColumnNumber { get; set; }
        public bool IsError { get; set; } = true;
        public string ErrorCode { get; set; }
        public string HelpLink { get; set; }

        public override string ToString()
        {
            return Message;
        }
    }
}
