using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SayiTahminlemeOyunu
{
    /// <summary>
    /// Uygulamanın ana başlangıç yeri app.xaml dosyasıdır.
    /// </summary>
    public partial class AnaPencere : Window
    {
        public AnaPencere()
        {
            InitializeComponent();
        }

        private bool GeçerlilikKontroluYap(int? gelenSayi)
        {
            if (gelenSayi == null)
            {
                PopupHelper.Goster(Mesajlar.LUTFEN_BIR_SAYI_GIRINIZ, MesajTuru.Hata);

                return false;
            }

            else if (!SayisalIslemler.GecerliBasamakSayisiMi(gelenSayi.Value,4))
            {
                PopupHelper.Goster(Mesajlar.SAYI_DORT_BASAMAKLI_OLMALI, MesajTuru.Hata);

                return false;
            }

            else if (!SayisalIslemler.RakamlariFarklMi(gelenSayi.Value))
            {
                PopupHelper.Goster(Mesajlar.RAKAMLAR_BIRBIRINDEN_FARKLI_OLMALI, MesajTuru.Hata);

                return false;
            }

            return true;
        }

        private string SayilariKarsilastir(int kullanicidanGelenSayi)
        {
            int randomTahminEdilenSayi = SayisalIslemler.TahminEt();
            int[] tahminEdilenSayiRakamlari = new int[SabitDegerler.BASAMAK_SAYISI];
            int basamakDogruSayisi = 0;
            int basamakYanlisSayisi = 0;
            string sonuc=string.Empty;

            int i = 0;
            for (int n = randomTahminEdilenSayi; n > 0; n /= 10)
            {
                int rakam = n % 10;
                tahminEdilenSayiRakamlari[i] = rakam;
                i++;
            }

            i = 0;
            for (int n = kullanicidanGelenSayi; n > 0; n /= 10)
            {
                int rakam = n % 10;

                for (int j = 0; j < tahminEdilenSayiRakamlari.Length; j++)
                {
                    // Basamak değerleri ve rakamlar birbirinine eşit ise
                    if (i == j && rakam == tahminEdilenSayiRakamlari[j])
                    {
                        basamakDogruSayisi++;
                        break;
                    }

                    // Sadece rakamlar eşit ise
                    else if(rakam == tahminEdilenSayiRakamlari[j])
                    {
                        basamakYanlisSayisi++;
                        break;
                    }

                    /* Yukarıdaki iki if bloğu için Önemli Not: Rakamların birbirinden farklı olması varsayıldığı için gereken 
                     * şart sağlandığı için döngüden çıkılıyor */
                }

                i++;
            }

            if (basamakDogruSayisi == 0 && basamakYanlisSayisi == 0)
            {
                PopupHelper.Goster(Mesajlar.BUTUN_RAKAMLAR_BIRINDEN_FARKLI, MesajTuru.Uyari);
            }

            else
            {
                // Basamak değerleri ve rakamlar birbirine eşit olan rakam adedin başına artı koy
                string dogruBasamakSayisiSonuc = basamakDogruSayisi > 0 ? "+"+ basamakDogruSayisi : string.Empty;

                // Basamak değerleri farklı ve rakamları birbirine eşit olan rakam adedin başına eksi koy
                string yanlisBasamakSayisiSonuc = basamakYanlisSayisi > 0 ? "-"+ basamakYanlisSayisi : string.Empty;

               sonuc = dogruBasamakSayisiSonuc + " " + yanlisBasamakSayisiSonuc;
            }

            return sonuc;
        }

        private void BtnTahminEt_Click(object sender, RoutedEventArgs e)
        {
            int? deger = txtSayi.Deger;
            if (!GeçerlilikKontroluYap(deger))
            {
                return;
            }

          txtBlckSayi.Text= SayilariKarsilastir(deger.Value);
        }

        private void BtnTemizle_Click(object sender, RoutedEventArgs e)
        {
            txtSayi.Deger = null;
            txtBlckSayi.Text = null;
        }
    }
}
