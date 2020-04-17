using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AbrirArquivoTXT.Entities
{
    class Enterprise
    {
        EnterpriseModel enterprise = new EnterpriseModel();

        public EnterpriseModel Getdata(string header)
        {

            MatchCnpj(ref enterprise, header);
            MatchSefip(ref enterprise, header);
            MatchCompetenceDate(ref enterprise, header);

            return enterprise;

        }


        private void MatchCnpj(ref EnterpriseModel e, string data)
        {
            Match cnpj = Regex.Match(data, RegexPatterns.CNPJ);
            if (cnpj.Success) enterprise.Cnpj = cnpj.ToString().Trim();
        }


        private void MatchSefip(ref EnterpriseModel e, string data)
        {
            Match sefip = Regex.Match(data, RegexPatterns.SEFIP_CODE);
            if (sefip.Success)
            {
                enterprise.SefipCode = sefip.ToString().Trim();
            }

        }


        private void MatchCompetenceDate(ref EnterpriseModel e, string data)
        {
            Match competence = Regex.Match(data, RegexPatterns.COMPETENCE_DATE);
            if (competence.Success)
            {

                string[] aux = competence.ToString().Trim().Split("/");
                enterprise.CompetenceMonth = int.Parse(aux[0]);
                enterprise.CompetenceYear = int.Parse(aux[1]);

            }


        }
    }
}
