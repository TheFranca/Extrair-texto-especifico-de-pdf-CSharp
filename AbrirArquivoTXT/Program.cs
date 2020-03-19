///   Site para auxiliar a construir os Regexs https://regex101.com/r/7bnJb7/1

using AbrirArquivoTXT.Entities;
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

            string[] dados_txt = File.ReadAllLines(path);

            int tam = dados_txt.Length;

            Empresa e = new Empresa();

            var file = new StreamWriter(@"C:\Users\T.I\Desktop\teste.csv");
            
            for (int i = 0; i < tam; i++)
            {
                Match np = Regex.Match(dados_txt[i], RegexPatterns.NUMERO_PIS);

                if (np.Success)
                {
                    Worker w = e.ExtractData(dados_txt[i], dados_txt[i + 2]);
                    //Console.WriteLine(w);
                    file.WriteLine(w);
                                       
                }

            }

            file.Close();

        }
    }
}
