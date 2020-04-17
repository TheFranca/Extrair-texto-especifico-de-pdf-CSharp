using System;
using System.IO;
using System.Text.RegularExpressions;

namespace testinRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\T.I\Desktop\tt.txt";

            string[] dados_txt = File.ReadAllLines(path);

            ExtractHeader extracHeader = new ExtractHeader();

            string[] normalizedText = ProcessingString.BreakText(dados_txt).ToArray();

            //Limitei a 20 linhas por o cabeçalho não tem mais que isso e roda só uma vez
            for (int i = 0; i < 20; i++)
            {
                EmpresaModel e = extracHeader.ExtractDatasFromHeader(normalizedText[i]);  
            }
        }
    }
}
