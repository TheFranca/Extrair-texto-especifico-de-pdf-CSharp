///   Site para auxiliar a construir os Regexs https://regex101.com/r/7bnJb7/1

using AbrirArquivoTXT.Entities;
using AbrirArquivoTXT.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace AbrirArquivoTXT
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\T.I\Desktop\tt.txt";

            ExtractData extractData = new ExtractData(path);

            Enterprise enterprise = new Enterprise();
            EnterpriseModel e = enterprise.Getdata(extractData.DataFromHeader());

            Console.WriteLine($"CNPJ: {e.Cnpj}");
            Console.WriteLine($"Código da SEFIP: {e.SefipCode}");
            Console.WriteLine($"Mês de Competência: {e.CompetenceMonth}");
            Console.WriteLine($"Ano de Competencia: {e.CompetenceYear}");

        }
    }
}
