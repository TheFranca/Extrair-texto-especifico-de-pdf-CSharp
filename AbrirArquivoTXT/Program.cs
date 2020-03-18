///   Site para auxiliar a construir os Regexs https://regex101.com/r/7bnJb7/1

using System;
using System.Collections.Generic;
using System.IO;
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

            List<String> lista_geral = new List<string>();

            string num_pis = @"\d{3}.\d{5}.\d{2}-\d{1}";
            string data = @"\d{2}/\d{2}/\d{4}";
            string cod = @"\s\d{2}\s";
            string cbo = @"\s\d{5}$";
            string cat = @"\s[a-zA-Z]\s|\s[a-zA-Z][0-9]\s";
            string numbers = @"[0-9]*.[0-9]*,[0-9]{2}";

            for (int i = 0; i < tam; i++)
            {

                Match np = Regex.Match(dados_txt[i], num_pis);
                Match dt = Regex.Match(dados_txt[i], data);
                Match cd = Regex.Match(dados_txt[i], cod);
                Match cb = Regex.Match(dados_txt[i], cbo);
                Match ct = Regex.Match(dados_txt[i], cat);

                if (np.Success)
                {
                    string concat_nome = "";
                    for (int j = 0; j < dados_txt[i].Length; j++)
                    {
                        if (Char.IsLetter(dados_txt[i][j]))
                        {
                            if (dados_txt[i][j + 1] == ' ')
                            {
                                concat_nome += dados_txt[i][j] + " ";
                            }
                            else
                            {
                                concat_nome += dados_txt[i][j];
                            }
                        }
                    }
                    lista_geral.Add(concat_nome);
                    lista_geral.Add(np.ToString());

                    if (dt.Success) lista_geral.Add(dt.ToString());

                    if (cd.Success) lista_geral.Add(cd.ToString().Trim());

                    if (dt.NextMatch().Success)
                    {
                        lista_geral.Add(dt.NextMatch().ToString());
                    }
                    else
                    {
                        lista_geral.Add("-");
                    }

                    if (ct.Success) lista_geral.Add(ct.ToString().Trim()); else lista_geral.Add("*");

                    if (cb.Success) lista_geral.Add(cb.ToString().Trim());

                    if (i < dados_txt.Length - 2)
                    {
                        Match nb = Regex.Match(dados_txt[i + 2], numbers);
                        if (nb.Success)
                        {
                            while (nb.Success)
                            {
                                lista_geral.Add(nb.ToString().Trim());
                                nb = nb.NextMatch();
                            }
                        }
                    }
                }

            }

            foreach (String dado in lista_geral)
            {
                Console.WriteLine(dado);
            }

        }
    }
}
