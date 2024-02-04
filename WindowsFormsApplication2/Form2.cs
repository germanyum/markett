using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        OleDbConnection con;
       
        OleDbCommand cmd;
        
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int barkod = Convert.ToInt32(textBox1.Text);
            int alis_fiyat = Convert.ToInt32(textBox3.Text);
            int satis_fiyat = Convert.ToInt32(textBox6.Text);
            int stok = Convert.ToInt32(textBox5.Text);
            string urun_adi = textBox4.Text;

            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=veri.accdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into tablo1 (barkod,alis_fiyat,satis_fiyat,urun_adi,stok) values ('" + barkod + "','" + alis_fiyat + "','" + satis_fiyat + "','" + urun_adi + "','" + stok + "')";
            cmd.ExecuteNonQuery();
            con.Close();


            Form1 fr = new Form1(); fr.Show();
            this.Hide();
        }
    }
}
