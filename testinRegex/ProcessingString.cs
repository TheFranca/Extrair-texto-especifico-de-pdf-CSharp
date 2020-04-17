using System;
using System.Collections.Generic;
using System.Text;

namespace testinRegex
{
    class ProcessingString
    {
        private static String ReplaceBlankSpaceBetweenWords(string word)
        {
            string[] aux = word.Trim().Split(" "); //Trim retira espaços em branco do inicio e do fim. O Split quebra nos espaços em branco

            string wordWithoutExtraWhiteSpace = "";

            foreach (string dado in aux)
            {
                if (!String.IsNullOrWhiteSpace(dado)) wordWithoutExtraWhiteSpace += dado + " ";

            }

            return wordWithoutExtraWhiteSpace.Trim();
        }

        public static List<string> BreakText(string[] allDataFromText)
        {
            List<string> allTextWithoutExtraWhiteSpace = new List<string>();

            for (int i = 0; i < allDataFromText.Length; i++)
            {
                allTextWithoutExtraWhiteSpace.Add(ReplaceBlankSpaceBetweenWords(allDataFromText[i]));
            }

            return allTextWithoutExtraWhiteSpace;

        }
    }
}
