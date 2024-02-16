using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Kütüphane_Otomasyonu
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        static string baglantiYolu = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=KütüphaneBilgileri.mdb";
        static OleDbConnection baglanti = new OleDbConnection(baglantiYolu);

        private void çIKIŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mENÜToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 kapat = new Form5();
            kapat.Close();
            Form2 ac = new Form2();
            ac.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
        public void üyeleriListele()
        {
            string veri = "select*from Üyeler";
            OleDbDataAdapter adaptor = new OleDbDataAdapter(veri, baglanti);
            DataSet ds = new DataSet();
            adaptor.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
        private void tÜMÜYELERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            üyeleriListele();
        }

        private void üYEEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Visible = true;

            guna2TextBox3.Visible = true;
            guna2TextBox4.Visible = true;
            guna2Button1.Enabled = true;

            guna2TextBox3.Enabled = true;
            guna2TextBox4.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ÜyeAdSoyad = guna2TextBox1.Text;
            string Meslek = guna2TextBox3.Text;
            int TelNo =Convert.ToInt32(guna2TextBox4.Text);

            B10.üyeEkle(ÜyeAdSoyad, Meslek, TelNo);
            guna2MessageDialog1.Show("Üye Başarıyla Eklendi");
            guna2Button1.Enabled = false;
            üyeleriListele();
            guna2TextBox1.Clear();
            guna2TextBox3.Clear();
            guna2TextBox4.Clear();

        }

        private void üYESİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guna2Button2.Enabled = true;

            guna2TextBox3.Visible = false;
            guna2TextBox4.Visible = false;
            guna2MessageDialog1.Show("Silmek İsteğin Üyenin İsmini Gir");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ÜyeAdı = guna2TextBox1.Text;
            B10.üyeSil(ÜyeAdı);
            guna2MessageDialog1.Show("İstenilen Üye Başarıyla Silindi");
            guna2TextBox1.Clear();
            üyeleriListele();
            guna2Button2.Enabled = false;
  

            guna2TextBox3.Visible = true;
            guna2TextBox4.Visible = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = guna2DataGridView1.SelectedCells[0].RowIndex;
            string ÜyeAdSoyad = guna2DataGridView1.Rows[secilen].Cells[1].Value.ToString();
            string Meslek = guna2DataGridView1.Rows[secilen].Cells[3].Value.ToString();
            int TelNo = Convert.ToInt32(guna2DataGridView1.Rows[secilen].Cells[4].Value);

            guna2TextBox1.Text = ÜyeAdSoyad;
            guna2TextBox3.Text = Meslek;
            guna2TextBox4.Text = TelNo.ToString();
            üyeleriListele();
        }

        private void üYEGÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string ÜyeAdSoyad = guna2TextBox1.Text;
                string Meslek = guna2TextBox3.Text;
                int TelNo = Convert.ToInt32(guna2TextBox4.Text);
                B10.üyeGuncelle(ÜyeAdSoyad, Meslek, TelNo);
                guna2MessageDialog1.Show("Seçilen Kişi Başarıyla Güncellendi.");
                guna2TextBox1.Clear();

                guna2TextBox3.Clear();
                guna2TextBox4.Clear();
                üyeleriListele();
            }
            catch (Exception)
            {

                guna2MessageDialog1.Show("Lütfen Satırları Boş Bıkramayınız.");
            }
            
        }

        private void üYEARAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guna2Button1.Enabled = false;
            guna2Button2.Enabled = false;
            guna2Button3.Enabled = true;
            guna2TextBox3.Visible = false;
            guna2TextBox4.Visible = false;
            guna2MessageDialog1.Show("Aramak İsteğiniz Üyenin İsmini Ve Soyad'nı  Girin");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string veri = "select * from Üyeler where ÜyeAdı like '%" + guna2TextBox1.Text + "%'";
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            OleDbDataAdapter adaptor = new OleDbDataAdapter(komut);
            DataSet DS = new DataSet();
            adaptor.Fill(DS);
            guna2DataGridView1.DataSource = DS.Tables[0];
            baglanti.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string ÜyeAdSoyad = guna2TextBox1.Text;
            string Sınıf = guna2TextBox3.Text;
            int OkulNo = Convert.ToInt32(guna2TextBox4.Text);

            B10.üyeEkle(ÜyeAdSoyad, Sınıf, OkulNo);
            guna2MessageDialog1.Show("Üye Başarıyla Kaydedildi");
            guna2Button1.Enabled = false;
            üyeleriListele();
            guna2TextBox1.Clear();
            guna2TextBox3.Clear();
            guna2TextBox4.Clear();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string veri = "select * from Üyeler where ÜyeAdSoyad like '%" + guna2TextBox1.Text + "%'";
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            OleDbDataAdapter adaptor = new OleDbDataAdapter(komut);
            DataSet DS = new DataSet();
            adaptor.Fill(DS);
            guna2DataGridView1.DataSource = DS.Tables[0];
            baglanti.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DialogResult silinsinmi = guna2MessageDialog3.Show("Silmek İstediginden Eminmisin");
            if (silinsinmi == DialogResult.Yes)
            {
                string ÜyeAdı = guna2TextBox1.Text;
                B10.üyeSil(ÜyeAdı);
                guna2TextBox1.Clear();
            }
                
            üyeleriListele();
            guna2Button2.Enabled = false;
            guna2TextBox3.Visible = true;
            guna2TextBox4.Visible = true;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Form2 ana = new Form2();
            ana.ShowDialog();
            this.Close();
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text = guna2DataGridView1.CurrentRow.Cells["ÜyeAdSoyad"].Value.ToString();
            guna2TextBox3.Text = guna2DataGridView1.CurrentRow.Cells["Sınıf"].Value.ToString();
            guna2TextBox4.Text = guna2DataGridView1.CurrentRow.Cells["OkulNo"].Value.ToString();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void yazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text = guna2DataGridView1.CurrentRow.Cells["ÜyeAdSoyad"].Value.ToString();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
