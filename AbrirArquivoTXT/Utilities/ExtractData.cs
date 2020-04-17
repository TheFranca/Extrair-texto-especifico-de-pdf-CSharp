using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
/// Depois criar uma forma de passar um diretório e a partir dele ler todos os pdfs e fazer 
/// a extração de todos os dados e gravá-los no banco.
/// </summary>

namespace AbrirArquivoTXT.Utilities
{
    class ExtractData
    {
        string[] _dataFromTxt;

        public ExtractData(string path)
        {
            string[] readData = File.ReadAllLines(path);
            _dataFromTxt = ProcessingString.TextWithoutExtraWitheSpaces(readData).ToArray();

        }


        public string[] AllData()
        {
            //Retorna um array de dados normalizado, sem espaços em branco extras
            return _dataFromTxt;
        }


        public string DataFromHeader()
        {
            //Retorna um cabeçalho em linha única
            //Isso foi feito, pois facilitada a busca com Match do Regex
            //É mais fácil dar um match em uma linha só do que ficar rodando o arquivo todo
            return ProcessingString.ExtractHeader(_dataFromTxt, 0, 20);
        }
    }
}
