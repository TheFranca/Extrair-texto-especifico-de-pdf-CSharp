using System;
using System.Collections.Generic;
using System.Text;

namespace testinRegex
{
    class RegexPatterns
    {
        public static readonly string SEFIP_CODE = @"(\d{12}\s+){3}\d{12}";
        public static readonly string CNPJ = @"\d{2}([.]\d{3}){2}\/\d{4}[-]\d{2}";
        public static readonly string DATE_COMPETENCE = @"COMP: \d{2}\/\d{4}";
    }
}
