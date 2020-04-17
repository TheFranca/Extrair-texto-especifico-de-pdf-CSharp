using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AbrirArquivoTXT.Entities
{
    class Worker
    {
        WorkerModel worker = new WorkerModel();
        

        public Worker()
        {

        }


        public WorkerModel ExtractData(string row, string row2)
        {
            WorkerModel w = new WorkerModel();

            MatchNome(ref w, row);
            MatchData(ref w, row);
            MatchNpis(ref w, row);
            MatchCat(ref w, row);
            MatchCodMov(ref w, row);
            MatchCbo(ref w, row);

            MatchNumbers(ref w, row2);

            return w;
        }

        private void MatchNome(ref WorkerModel w, string s)
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


        private void MatchNpis(ref WorkerModel w, string s)
        {
            Match np = Regex.Match(s, RegexPatterns.NUMERO_PIS);
            if (np.Success)
            {
                w.Npis = np.ToString().Trim();
            }
        }


        private void MatchData(ref WorkerModel w, string s)
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


        private void MatchCat(ref WorkerModel w, string s)
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


        private void MatchCodMov(ref WorkerModel w, string s)
        {
            Match cdm = Regex.Match(s, RegexPatterns.COD_MOV);

            if (cdm.Success) w.CodMov = cdm.ToString().Trim();
            else w.CodMov = "-";
        }


        private void MatchCbo(ref WorkerModel w, string s)
        {
            Match cb = Regex.Match(s, RegexPatterns.CBO);

            if (cb.Success) w.Cbo = cb.ToString().Trim();
        }


        private void MatchNumbers(ref WorkerModel w, string s)
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

        public override string ToString()
        {
            //Só construir o modelo com os dados do trabalhador
            return "";
        }

    }
}
