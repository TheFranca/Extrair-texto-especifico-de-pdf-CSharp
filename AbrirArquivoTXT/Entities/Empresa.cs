using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AbrirArquivoTXT.Entities
{
    class Empresa
    {
        Worker worker = new Worker();


        public Worker ExtractData(string row, string row2)
        {
            Worker w = new Worker();

            MatchNome(ref w, row);
            MatchData(ref w, row);
            MatchNpis(ref w, row);
            MatchCat(ref w, row);
            MatchCodMov(ref w, row);
            MatchCbo(ref w, row);

            MatchNumbers(ref w, row2);

            return w;
        }

        private void MatchNome(ref Worker w, string s)
        {
            string concat_nome = "";

            for (int j = 0; j < s.Length; j++)
            {
                if (Char.IsLetter(s[j]))
                {
                    if (s[j + 1] == ' ')
                    {
                        concat_nome += s[j] + " ";
                    }
                    else
                    {
                        concat_nome += s[j];
                    }
                }
            }
            w.Nome = concat_nome;
        }


        private void MatchNpis(ref Worker w, string s)
        {
            Match np = Regex.Match(s, RegexPatterns.NUMERO_PIS);
            if (np.Success)
            {
                w.Npis = np.ToString().Trim();
            }
        }


        private void MatchData(ref Worker w, string s)
        {
            string data = "";
            Match dt = Regex.Match(s, RegexPatterns.DATA);

            if (dt.Success)
            {
                w.DataAdmissao = dt.ToString();

                if (dt.NextMatch().Success)
                {
                    w.DataMov = dt.NextMatch().ToString();
                }
                else
                {
                    w.DataMov = "-";
                }

            }

        }


        private void MatchCat(ref Worker w, string s)
        {
            Match ct = Regex.Match(s, RegexPatterns.CAT);

            if (ct.Success)
            {
                w.Cat = ct.ToString().Trim();

                if (ct.NextMatch().Success)
                {
                    w.Ocorrencia = ct.NextMatch().ToString().Trim();
                }
                else
                {
                    w.Ocorrencia = "-";
                }
            }
        }


        private void MatchCodMov(ref Worker w, string s)
        {
            Match cdm = Regex.Match(s, RegexPatterns.COD_MOV);

            if (cdm.Success) w.CodMov = cdm.ToString().Trim();
            else w.CodMov = "-";
        }


        private void MatchCbo(ref Worker w, string s)
        {
            Match cb = Regex.Match(s, RegexPatterns.CBO);

            if (cb.Success) w.Cbo = cb.ToString().Trim();
        }


        private void MatchNumbers(ref Worker w, string s)
        {
            Match numbers = Regex.Match(s, RegexPatterns.NUMEROS);

            if (numbers.Success)
            {

                List<string> aux = new List<string>();
                w.RemSem13Sal = numbers.ToString().Trim();

                while (numbers.Success)
                {

                    aux.Add(numbers.NextMatch().ToString().Trim());
                    numbers = numbers.NextMatch();
                }
                w.Rem13Sal = aux[0];
                w.Calculo13SalPrevSocial = aux[1];
                w.Contribuicao = aux[2];
                w.Deposito = aux[3];
                w.Jam = aux[4];
            }


        }

    }
}
