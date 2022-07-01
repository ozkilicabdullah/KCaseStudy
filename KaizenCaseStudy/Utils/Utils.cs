using System;
using System.Collections.Generic;
using System.Text;

namespace KaizenCaseStudy
{
    public static class Utils
    {
        private static Random random = new Random();

        private const string keys = "ACDEFGHKLMNPRTXYZ234579";

        // Kod oluşturulurken kullanılacak karaterler 1'den başlayarak  numaralandırılır.(soldan) Örn: A=1,C=2,D=3,E=4 ....
        // Bu numaralandırma sonucunda tek sayı değeri alanlar 'OddNumberIndexes', çift sayı değeri alanlar 'EvenNumberIndexes' isimli değişkenlere atanmıştır.
        // Kod oluşturulurken 1'den başlayarak basamaklar sayılır ve basamak değeri tek çift olmasına göre 'OddNumberIndexes' veya 'EvenNumberIndexes' isimli değişkenlerden rastgele bir karakter alır.
        // Eğer basamak değeri çift ise  'OddNumberIndexes' değişkeninden,
        // eğer basamak değeri tek ise 'EvenNumberIndexes' değişkeninden
        // rastgele bir karakter alınarak yeni oluşturulan kodun ilgili basamağına eklenir.  (Ters -> çift ise tek listesinden , tek ise çift listesinden)
        // Örneğin =>
        // 8 basamaklı => CAEDGFKH  => 1. Basamak ('1' tek sayıdır) 'EvenNumberIndexes' değişkeninde 'C' harfini almıştır
        // 2. Basamak ('2' çift saydır) 'OddNumberIndexes'değişkeninden  'A' harfi alınmıştır.
        // 3. , 4. ... diğer basamaklarda aynı şekilde devam etmektedir.

        // Tek sayı değerini alanlar
        private const string OddNumberIndexes = "ADFHLNRXZ359";
        // Çift sayı değerini alanlar
        private const string EvenNumberIndexes = "CEGKMPTY247";


        /// <summary>
        /// Kampanya kodu oluşturan fonksiyon
        /// </summary>
        /// <param name="count">Kaç adet kupon oluşturulmak isteniyor</param>
        /// <param name="codeLength">Kampanya kodunun karakter uzunluğu</param>
        /// <returns></returns> 
        public static List<string> GenerateCampaignCode(int count = 10, int codeLength = 8)
        {
            List<string> codes = new List<string>();

            for (int i = 0; i < count; i++)
            {
                string newCode = string.Empty;

                // 0. basamktan başlamamısı için 1'den başlatıldı
                for (int x = 1; x < codeLength + 1; x++)
                {
                    // x' oluşturulan yeni kod'un basamak değerinide ifade etmektedir.
                    // Eğer çif ise indexdeğerinin basamak değeri 'tek' olan listeden random bir değer eklenir
                    if (x % 2 == 0)
                    {
                        int rand = random.Next(OddNumberIndexes.Length);
                        newCode = string.Concat(newCode, OddNumberIndexes[rand]);
                    }
                    else
                    {
                        int rand = random.Next(EvenNumberIndexes.Length);
                        newCode = string.Concat(newCode, EvenNumberIndexes[rand]);
                    }
                }
                codes.Add(newCode);
            }

            return codes;
        }
       
        /// <summary>
        /// Girilen kodun geçerliliğini kontrol eder.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool CheckValidCode(string code)
        {
            // ilk basamğı 1 kabul ettiğimiz için i değişkeni '1' den başlatıldı
            for (int i = 1; i < code.Length + 1; i++)
            {
                char[] charArray = code.ToCharArray();
                string currentValue = charArray[i - 1].ToString();
                if (i % 2 == 0)
                {
                    if (!OddNumberIndexes.Contains(currentValue))

                        return false;
                }
                else
                {
                    if (!EvenNumberIndexes.Contains(currentValue))
                        return false;

                }
            }
            return true;
        }
    }
}
