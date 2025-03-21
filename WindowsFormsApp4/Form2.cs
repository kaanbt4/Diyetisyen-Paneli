using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    public partial class Form2: Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP-NINNCP6\\SQLEXPRESS; Initial Catalog = RumeysaOzen; Integrated Security=True;Encrypt=False");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand giris = new SqlCommand("Select * From Table_Yonetici where KullaniciAd=@p1 and Sifre =@p2" ,baglanti);
            giris.Parameters.AddWithValue("@p1", textBox1.Text);
            giris.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader dr = giris.ExecuteReader();

            if (dr.Read())
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();

                MessageBox.Show("Giriş Başarılı!");
            }

            else
            {

                MessageBox.Show("Hatalı Kullanıcı Adı Ya da Şifre!");
            }

                baglanti.Close();
        }
    }
}
