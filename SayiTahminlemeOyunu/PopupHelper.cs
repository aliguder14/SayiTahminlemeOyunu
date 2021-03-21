using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SayiTahminlemeOyunu
{
    /// <summary>
    /// MessgaeBox.Show metodunu daha basit hale getirmek için yazıldı.
    /// </summary>
    public class PopupHelper
    {
        public static void Goster(string mesaj,MesajTuru mesajTuru)
        {
            if (mesajTuru == MesajTuru.Bilgi)
            {
                MessageBox.Show(mesaj, "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information); 
            }

            else if(mesajTuru == MesajTuru.Hata)
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            else if (mesajTuru == MesajTuru.Uyari)
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
    }
}
