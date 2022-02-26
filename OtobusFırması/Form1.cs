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
namespace OtobusFırması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mskKoltukNo.Text = "4";
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox9_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-0UHEVM7\SQLEXPRESS;Initial Catalog=OtobusSirketi;Integrated Security=True");
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLYOLCU (AD,SOYAD,TELEFON,TC,CINSIYET,MAIL) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", mskAd.Text);
            komut.Parameters.AddWithValue("@p2", mskSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTel.Text);
            komut.Parameters.AddWithValue("p4", mskTc.Text);
            komut.Parameters.AddWithValue("p5", cmbcinsiyet.Text);
            komut.Parameters.AddWithValue("@p6", mskMail.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yolcu Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnButonKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBKAPTANLAR (KAPTANNO,ADSOYAD,TELEFON) values (@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("p1", mskKaptanNo.Text);
            komut.Parameters.AddWithValue("p2", mskKaptanAdSoyad.Text);
            komut.Parameters.AddWithValue("p3", mskKaptanTel.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kaptan Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnSeferKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLSEFERBILGI (KALKIS,VARIS,TARIH,SAAT,KAPTAN,FIYAT)values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("p1", mskKalkıs.Text);
            komut.Parameters.AddWithValue("p2", mskVarıs.Text);
            komut.Parameters.AddWithValue("p3", mskTarih.Text);
            komut.Parameters.AddWithValue("p4", mskSaat.Text);
            komut.Parameters.AddWithValue("p5", mksKaptan.Text);
            komut.Parameters.AddWithValue("@p6", mskFiyat.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Sefer Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            seferlistesi();
        }
        void seferlistesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBLSEFERBILGI", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            seferlistesi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            mskSeferNo.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            mskKoltukNo.Text = "1";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            mskKoltukNo.Text = "3";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            mskKoltukNo.Text = "5";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            mskKoltukNo.Text = "7";
        }

        private void butonsefer_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into seferdetay (seferno,yoltutc,koltuk) values(@p1,@p2,@p3");
        }
    }
}
