using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace SayiTahminlemeOyunu.CustomControls
{
    /// <summary>
    /// Texbox class'ı Nummerik alan için özelleştirilip NumericTextBox class'ı oluşturuldu.
    /// </summary>
    public partial class NumericTextBox : TextBox
    {
        /// <summary>
        /// Textbox'da girilen sayının değeri
        /// </summary>
        public int? Deger 
        {
            get
            {
                return int.TryParse(this.Text, out _) ? int.Parse(this.Text) : null;
            }
            
            set
            {
                this.Text = value.ToString();
            }
        }
        public NumericTextBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Rakam haricinde diğer karakterlerin girilmesini engelemek için yazılıdı.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            // Girilmeye çalışılan veri rakam ise izin ver.
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
