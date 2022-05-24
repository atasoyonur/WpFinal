using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        ObservableCollection<SeferBilgileri> col=new ObservableCollection<SeferBilgileri>();
        /*Verileri tutmak için bir liste oluşturduk. Diğer List Collectionlarına göre avantajı veri listelediğimiz herhangi bir sayfada 
          veri kaynağında değişme olduğunda bir refresh ihtiyacı olmadan bu değişiklikleri
        ListBox, LongListSelector gibi kontrollere bildirir ve değişiklikler gerçekleşir.*/
        public MainWindow()
        {
            InitializeComponent();
            
            col.Add(new SeferBilgileri() { HatNumarasi = 156, HatAdi = "Erdemli", HatSofor = "Ali Yılmaz" ,HatUzunluk=46});//örnek kayıt
            col.Add(new SeferBilgileri() { HatNumarasi = 141, HatAdi = "Tarsus", HatSofor = "Fuat Uçar", HatUzunluk = 51 });
            col.Add(new SeferBilgileri() { HatNumarasi = 26, HatAdi = "Tece", HatSofor = "Emir Kaplan", HatUzunluk = 44 });
            col.Add(new SeferBilgileri() { HatNumarasi = 44, HatAdi = "Üniversite", HatSofor = "Ece Yıldız", HatUzunluk = 16 });



            dg1.ItemsSource = col;//datagrid'in item kaynağı yukarıda belirtmiş olduğumuz liste diyoruz.
            //Form tarafındaki DataSource wpf tarafında yoktur. ItemSource kullandım.
        }
        
        private void btnAdd(object sender, RoutedEventArgs e)
        {
            int No = 0;
            int km = 0;
            try
            {
                No = int.Parse(HatNo.Text.Trim());
                km = int.Parse(hatUzunluk.Text.Trim());
                /*nesne oluşturup property değerini textBox içinde yazılan değerlere eşitliyoruz ve bunu listemizde referans ediyoruz. Oluşturmuş olduğum textClear metodu ile
                 textBox içlerini null hale getiriyorum. MessageBox ile bilgilendirme yapıyorum.
                 */
                col.Add(new SeferBilgileri() { HatNumarasi = No, HatAdi = hatAdi.Text.Trim(), HatSofor = hatSofor.Text.Trim(),HatUzunluk=km });
                textClear();
                MessageBox.Show("Ekleme işlemi başarılı", "Bilgilendirme", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Hat numarası ve uzunluğu tam sayı olmalıdır.", "Geçersiz İşlem", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }
        //private yazmama gerek yok default değeri zaten private
        void textClear()
        {
            HatNo.Text = null;
            hatAdi.Text = null; 
            hatSofor.Text = null;
            hatUzunluk.Text = null;
        }


        

        

        private void btnDelete(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedIndex >= 0)
            {
                //Seçilen Item türü SeferBilgileri türünden ise bunu referans edip remove metodu ile listemizden siliyoruz.
                SeferBilgileri hatInfo = dg1.SelectedItem as SeferBilgileri;
                col.Remove(hatInfo);
                MessageBox.Show("Silme işlemi başarılı", "Bilgilendirme", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void btnUpdate(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedIndex >= 0)
            {
                
                // SeferBilgileri class'ından yeni bir nesne oluşturulur ve değerler referansın işaretiyle RAM'in heap bölgesinde nesnenin içinde tutulur.
                SeferBilgileri updateSefer = new SeferBilgileri();
                updateSefer.HatNumarasi = int.Parse(HatNoS.Text);
                updateSefer.HatAdi = hatAdiS.Text.Trim();
                updateSefer.HatSofor = hatSoforS.Text.Trim();
                updateSefer.HatUzunluk = int.Parse(hatUzunlukS.Text);

                // Seçilen değer silinir
                SeferBilgileri oldSefer = dg1.SelectedItem as SeferBilgileri;
                col.Remove(oldSefer);

                //oluşturduğumuz nesnemizle yeni tablo oluşturduk böylece güncellemiş olduk
                col.Add(updateSefer);
                MessageBox.Show("Güncelleme işlemi başarılı", "Bilgilendirme", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else { MessageBox.Show("İşlem yapabilmek için sefer seçiniz","Geçersiz İşlem",MessageBoxButton.OK,MessageBoxImage.Error); }

        }
        //textBox için olay sonucunda stil işlemleri. Mouse'un üzerine gelmesi ile bir değer veriyoruz. Mouse textBox üzerinden gittiğinde eski haline dönmesi için de tanımlama yaptım
        private void HatNo_MouseEnter(object sender, MouseEventArgs e)
        {
            HatNo.Background = Brushes.LightGray;
            HatNo.Foreground = Brushes.White;
        }

        private void HatNo_MouseLeave(object sender, MouseEventArgs e)
        {
            HatNo.Background = Brushes.White;
            HatNo.Foreground = Brushes.Black;
        }

        private void hatAdi_MouseEnter(object sender, MouseEventArgs e)
        {
            hatAdi.Background = Brushes.LightGray;
            hatAdi.Foreground = Brushes.White;
        }

        private void hatAdi_MouseLeave(object sender, MouseEventArgs e)
        {
            hatAdi.Background = Brushes.White;
            hatAdi.Foreground = Brushes.Black;
        }

        private void hatSofor_MouseEnter(object sender, MouseEventArgs e)
        {
            hatSofor.Background = Brushes.LightGray;
            hatSofor.Foreground = Brushes.White;
        }

        private void hatSofor_MouseLeave(object sender, MouseEventArgs e)
        {
            hatSofor.Background = Brushes.White;
            hatSofor.Foreground = Brushes.Black;
        }

        private void hatUzunluk_MouseEnter(object sender, MouseEventArgs e)
        {
            hatUzunluk.Background = Brushes.LightGray;
            hatUzunluk.Foreground = Brushes.White;
        }

        private void hatUzunluk_MouseLeave(object sender, MouseEventArgs e)
        {
            hatUzunluk.Background = Brushes.White;
            hatUzunluk.Foreground = Brushes.Black;
        }

        private void HatNoS_MouseEnter(object sender, MouseEventArgs e)
        {
            HatNoS.Background = Brushes.LightGray;
            HatNoS.Foreground = Brushes.White;
        }

        private void HatNoS_MouseLeave(object sender, MouseEventArgs e)
        {
            HatNoS.Background = Brushes.White;
            HatNoS.Foreground = Brushes.Black;
        }

        private void hatAdiS_MouseEnter(object sender, MouseEventArgs e)
        {
            hatAdiS.Background = Brushes.LightGray;
            hatAdiS.Foreground = Brushes.White;
        }

        private void hatAdiS_MouseLeave(object sender, MouseEventArgs e)
        {
            hatAdiS.Background = Brushes.White;
            hatAdiS.Foreground = Brushes.Black;
        }

        private void hatSoforS_MouseEnter(object sender, MouseEventArgs e)
        {
            hatSoforS.Background = Brushes.LightGray;
            hatSoforS.Foreground = Brushes.White;
        }

        private void hatSoforS_MouseLeave(object sender, MouseEventArgs e)
        {
            hatSoforS.Background = Brushes.White;
            hatSoforS.Foreground = Brushes.Black;
        }

        private void hatUzunlukS_MouseEnter(object sender, MouseEventArgs e)
        {
            hatUzunlukS.Background = Brushes.LightGray;
            hatUzunlukS.Foreground = Brushes.White;
        }

        private void hatUzunlukS_MouseLeave(object sender, MouseEventArgs e)
        {
            hatUzunlukS.Background = Brushes.White;
            hatUzunlukS.Foreground = Brushes.Black;
        }
    }
    //Class
    public class SeferBilgileri
    {
        public int HatNumarasi { get; set; }
        public string HatAdi { get; set; }
        public string HatSofor { get; set; }
        public int HatUzunluk { get; set; }
    }
}
