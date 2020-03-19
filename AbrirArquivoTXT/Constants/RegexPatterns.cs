using System;
using System.Collections.Generic;
using System.Text;

namespace AbrirArquivoTXT.Entities
{
    public static class RegexPatterns
    {
        public static readonly string NUMERO_PIS = @"\d{3}.\d{5}.\d{2}-\d{1}";
        public static readonly string DATA = @"\d{2}/\d{2}/\d{4}";
        public static readonly string CAT = @"\s\d{2}\s";
        public static readonly string CBO = @"\s\d{5}$";
        public static readonly string COD_MOV = @"\s[a-zA-Z]\s|\s[a-zA-Z][0-9]\s";
        public static readonly string NUMEROS = @"[0-9]*.[0-9]*,[0-9]{2}";
    }
}
