using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayiTahminlemeOyunu
{
    /// <summary>
    /// Yazılımda gerçekleşen sayısal işlemler ile ilgili metotların bulunduğu sınıftır.
    /// </summary>
    public class SayisalIslemler
    {

        private static Random _rnd = new Random();

        /// <summary>
        /// Belirtilen minimum ve maksimum değerler arasında rakamları farklı olacak şekilde rastgele 
        /// sayı üreterek sayı tahmin ediyor.
        /// </summary>
        /// <returns></returns>
        public static int TahminEt()
        {
            int tahminEdilenSayi = _rnd.Next(SabitDegerler.MINIMUM_DEGER, SabitDegerler.MAXIMUM_DEGER + 1);

            // Rakamları farklı üretene kadar while rastgele sayı üretmeye devam et
            while (!RakamlariFarklMi(tahminEdilenSayi))
            {
                tahminEdilenSayi = _rnd.Next(SabitDegerler.MINIMUM_DEGER, SabitDegerler.MAXIMUM_DEGER + 1);
            }

            return tahminEdilenSayi;
        }

        public static bool RakamlariFarklMi(int sayi)
        {
            // Bir rakam en fazla 9 değeri alabileceği için array'ın kapasitesi 10 olarak ayarlandı.
            int[] rakamAdetleri = new int[10];

            for (int n = sayi; n > 0; n /= 10)
            {
                int rakam = n % 10;
                
                if (rakamAdetleri[rakam] >= 1)
                {
                    return false;
                }

                rakamAdetleri[rakam]++;


            }

            return true;
        }

        /// <summary>
        /// Sayı istenen basamak sayısında mı onu kontrol ediyor. Ör: Sayının sayının 4 basamaklı  
        /// olduğu teyit edilebilmek istenir ise sayı 4 basamaklı ise sonuç true döner. Eğer sayı 4 basamaklı 
        /// değil ise sonuç false döner
        /// </summary>
        /// <param name="sayi">Gelen Sayı</param>
        /// <param name="basamakSayisi">Istenen basamak sayısı</param>
        /// <returns></returns>
        public static bool GecerliBasamakSayisiMi(int sayi,int basamakSayisi)
        {

            int rakamSayisi = 0;
            for (int n = sayi; n > 0; n /= 10)
            {
                rakamSayisi++;

                // Rakam sayısı istenen basamak sayısını aştı ise metot'dan çık
                if (rakamSayisi > basamakSayisi)
                {
                    return false;
                }
            }


            if (rakamSayisi == basamakSayisi)
            {
                return true;
            }

            else
            {
                return false;
            }

        }
    }
}
