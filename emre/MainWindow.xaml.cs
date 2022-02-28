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
using System.Data.SqlClient;

namespace emre
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        static string constring = "Data Source=DESKTOP-FAQ3LIQ\\MSSQLSERVER1;Initial Catalog = Kisiler; Integrated Security = True";
        SqlConnection connect = new SqlConnection(constring);



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (connect.State == System.Data.ConnectionState.Closed)
                    connect.Open();
                String kayit = "insert into bilgi(kullanici_adi,ad_soyad,telefon) values (@kullanici_ad,@ad,@telefon)";
                SqlCommand komut = new SqlCommand(kayit, connect);
                komut.Parameters.AddWithValue("@kullanici_ad", txt_kad.Text);
                komut.Parameters.AddWithValue("@ad", txt_ad.Text);
                komut.Parameters.AddWithValue("@telefon", txt_tel.Text);
                komut.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Kayıt Eklendi");

            }
            catch(Exception hata)
            {
                MessageBox.Show("Hata Meydana Geldi"+ hata.Message);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
