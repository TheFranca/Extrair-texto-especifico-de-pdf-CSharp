using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AbrirArquivoTXT.Entities
{
    class Worker
    {
        //Nome do trabalhador
        public string Nome { get; set; }

        //Número do PIS/PASEP/CI
        public string Npis { get; set; }

        //Data de Admissão
        public string DataAdmissao { get; set; }

        //CAT
        public string Cat { get; set; }

        //Código de Ocorrência
        public string Ocorrencia { get; set; }

        //Data de movimentação
        public string DataMov { get; set; }


        //Código de movimentação
        public string CodMov { get; set; }

        //CBO
        public string Cbo { get; set; }


        //Remuneração sem 13º salário
        public string RemSem13Sal { get; set; }

        //Remuneração do 13º salário
        public string Rem13Sal { get; set; }

        //Base de Cálculo do 13º salário da Previdência Social --> Valor que vai ser calculado os 30% 
        //É igual ao salário. Até o momento é calculado na mão
        public string Calculo13SalPrevSocial { get; set; }

        //Contribuição do trabalhador (8% do salário)
        public string Contribuicao { get; set; }

        //Depósito da contribuição (É o mesmo valor da contribuição)
        public string Deposito { get; set; }

        //Juros Mensal
        public string Jam { get; set; }

        public Worker()
        {
        }
       
        
        public override string ToString()
        {
            return
                Nome + ";" +
                Npis + ";" +
                DataAdmissao + ";" +
                Cat + ";" +
                Ocorrencia + ";" +
                DataMov + ";" +
                CodMov + ";" +
                Cbo + ";" +
                RemSem13Sal + ";" +
                Rem13Sal + ";" +
                Calculo13SalPrevSocial + ";" +
                Contribuicao + ";" +
                Deposito + ";" +
                Jam;
        }
    }

}
