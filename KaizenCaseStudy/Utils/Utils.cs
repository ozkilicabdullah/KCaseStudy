using System;
using System.Collections.Generic;
using System.Text;

namespace KaizenCaseStudy
{
    public static class Utils
    {
        private static Random random = new Random();

        private const string keys = "ACDEFGHKLMNPRTXYZ234579";

        //İndex değerlerinin basamak değeri  'tek' olanlar
        private const string OddIndexes = "ADFHLNRXZ359";
        //İndex değerlerinin basamak değeri  'ÇİFT' olanlar
        private const string EventIndexes = "CEGKMPTY247";
        public static List<string> GenerateCampaignCode(int count = 10, int codeLength = 8)
        {
            List<string> codes = new List<string>();

            for (int i = 0; i < count; i++)
            {
                string newCode = string.Empty;

                for (int x = 1; x < codeLength + 1; x++)
                {
                    // x' oluşturulan yeni kod'un basamak değerinide ifade etmektedir.
                    // Eğer çif ise indexdeğerinin basamak değeri 'tek' olan listeden random bir değer eklenir
                    if (x % 2 == 0)
                    {
                        int rand = random.Next(OddIndexes.Length);
                        newCode = string.Concat(newCode, OddIndexes[rand]);
                    }
                    else
                    {
                        int rand = random.Next(EventIndexes.Length);
                        newCode = string.Concat(newCode, EventIndexes[rand]);
                    }
                }
                codes.Add(newCode);
            }

            return codes;
        }

        public static bool CheckValidCode(string code)
        {
            for (int i = 0; i < code.Length; i++)
            {
                char[] charArray = code.ToCharArray();
                string currentValue = charArray[i].ToString();
                if (i % 2 == 0)
                {
                    if (!EventIndexes.Contains(currentValue))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!OddIndexes.Contains(currentValue))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
