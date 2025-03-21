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
using System.Data.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace WindowsFormsApp4
{
    public partial class Form1: Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP-NINNCP6\\SQLEXPRESS; Initial Catalog = RumeysaOzen; Integrated Security=True;Encrypt=False");
        public Form1()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            double vki = Convert.ToDouble(label4.Text);  // label4.Text'teki değeri double'a çevir
            SqlCommand komut = new SqlCommand("insert into Table_5 (Ad_Soyad, Boy, Kilo, VKI_Degeri, Cinsiyet, Tc_Kimlik) values (@p1, @p2, @p3, @p4, @p5, @p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", textBox3.Text);
            komut.Parameters.AddWithValue("@p4", vki);
            komut.Parameters.AddWithValue("@p5", label6.Text);
            komut.Parameters.AddWithValue("@p6", textBox4.Text);


            komut.ExecuteNonQuery();
            this.table_5TableAdapter.Fill(this.rumeysaOzenDataSet.Table_5);

            baglanti.Close();

            MessageBox.Show("Kaydedildi! Lütfen Listele komutunu Kullanın!");

            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rumeysaOzenDataSet5.Table_5' table. You can move, or remove it, as needed.
            this.table_5TableAdapter5.Fill(this.rumeysaOzenDataSet5.Table_5);
            // TODO: This line of code loads data into the 'rumeysaOzenDataSet4.Table_5' table. You can move, or remove it, as needed.
            this.table_5TableAdapter4.Fill(this.rumeysaOzenDataSet4.Table_5);
            // TODO: This line of code loads data into the 'rumeysaOzenDataSet3.Table_5' table. You can move, or remove it, as needed.
            this.table_5TableAdapter3.Fill(this.rumeysaOzenDataSet3.Table_5);
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Table_5 ORDER BY Eklenme_Tarihi ASC", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double vki;
            double boy;
            double kilo;

            boy = Convert.ToDouble(textBox2.Text);
            kilo = Convert.ToDouble(textBox3.Text);

            vki = kilo / (boy/100 * boy/100);

            label4.Text = vki.ToString("0.000");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutsil = new SqlCommand("Delete From Table_5 Where Ad_Soyad=@k1", baglanti);

            komutsil.Parameters.AddWithValue("@k1", textBox1.Text);

            komutsil.ExecuteNonQuery();
            MessageBox.Show("Kayıt Silindi!");


            baglanti.Close();
        }

        

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label6.Text = "Kadın";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label6.Text = "Erkek";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            textBox4.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            label6.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
        }
    }
}
