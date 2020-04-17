using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace testinRegex
{
    class ExtractHeader
    {
        EmpresaModel empresa = new EmpresaModel();
        private bool status = true;

        public EmpresaModel ExtractDatasFromHeader(string data)
        {
            EmpresaModel e = new EmpresaModel();

            MatchCnpj(ref e, data);
            MatchSefip(ref e, data);
            MatchCompetenceDate(ref e, data);

            return e;

        }

        private void MatchCnpj(ref EmpresaModel e, string data)
        {
            Match cnpj = Regex.Match(data, RegexPatterns.CNPJ);
            if (cnpj.Success) e.Cnpj = cnpj.ToString().Trim();
        }

        private void MatchSefip(ref EmpresaModel e, string data)
        {
            Match sefip = Regex.Match(data, RegexPatterns.SEFIP_CODE);
            if (sefip.Success && status)
            {
                e.SefipCode = sefip.ToString().Trim();
                status = false;
            }

        }

        //No CompetenceDate tu pode usar o teu Regex de data mm/AAAA
        private void MatchCompetenceDate(ref EmpresaModel e, string data)
        {
            Match competence = Regex.Match(data, RegexPatterns.DATE_COMPETENCE);
            if (competence.Success) e.CompetenceDate = competence.ToString().Trim();

        }
    }
}
