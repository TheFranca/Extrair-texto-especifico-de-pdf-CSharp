using System;
using System.Collections.Generic;
using System.Text;

namespace AbrirArquivoTXT.Entities
{
    public static class RegexPatterns
    {
        public static readonly string NUMERO_PIS = @"\d{3}.\d{5}.\d{2}-\d{1}";
        public static readonly string NAME = @"([a-zA-Z]+\s{1})+[a-zA-Z]*";
        public static readonly string DATA = @"\d{2}/\d{2}/\d{4}";
        public static readonly string CAT = @"\s\d{2}\s";
        public static readonly string CBO = @"\s\d{5}$";
        public static readonly string COD_MOV = @"\s[a-zA-Z]\d{0,1}\s";
        public static readonly string NUMEROS = @"(\d{3}[.])*\d{3},\d{2}";


        public static readonly string SEFIP_CODE = @"(\d{12}\s+){3}\d{12}";
        public static readonly string CNPJ = @"\d{2}([.]\d{3}){2}\/\d{4}[-]\d{2}";
        public static readonly string COMPETENCE_DATE = @"\s\d{2}\/\d{4}";

        
    }
}
