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
    public partial class Form1 : Form
    {
        DataTable tablo = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
        }
        public void guncel() {
            object sumObject;
            sumObject = tablo.Compute("Sum(toplam)", string.Empty);
            label1.Text = sumObject.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DataColumn workColumn = tablo.Columns.Add("id", typeof(Int32));
            workColumn.AutoIncrement = true;
            tablo.Columns.Add("barkod", typeof(int));
            tablo.Columns.Add("urun adi", typeof(string));
            tablo.Columns.Add("brim fiyat", typeof(int));
            tablo.Columns.Add("miktar", typeof(int));
            tablo.Columns.Add("toplam", typeof(int));
            tablo.PrimaryKey = new DataColumn[] { tablo.Columns["id"] }; ;
             
            dataGridView1.DataSource = tablo;

           
        }
        int ilkdeger = 0;
        private void button5_Click(object sender, EventArgs e)
        {
         /*   tablo.Rows.Add(null,44,"dee",333,10,22);
            DataRow[] result = tablo.Select("id = 3 ");
            foreach (DataRow row in result)
            {
                DataRow[] bark = tablo.Select("barkod = 44");
                if (bark.Length>1)
                {
                     
                  
                }
               
            }*/
           
            foreach (DataRow dtRow in tablo.Rows)
            {
                if (Convert.ToInt32(dtRow["barkod"]) == ilkdeger)
                {
                    MessageBox.Show("ıkrı");
                }
                ilkdeger = Convert.ToInt32(dtRow["barkod"]);   
            }
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tablo.Rows.Add(null,11, "dee", 333, 10, 22);
            guncel();
        }
        public void data_ekle_grid(int barkod) {
            OleDbConnection con;
            OleDbDataAdapter da;
            DataSet ds2;
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=veri.accdb");
            da = new OleDbDataAdapter("SELECT * from tablo1 where barkod = " + barkod.ToString() , con);
            ds2 = new DataSet();
            con.Open();
            da.Fill(ds2, "tablo1");
            DataRow satir = ds2.Tables["tablo1"].Rows[0];
            tablo.Rows.Add(null, satir["barkod"], satir["urun_adi"].ToString(), satir["satis_fiyat"], 1, satir["satis_fiyat"]);
            con.Close();
        }
        public string  data_al_tek(int barkod,string sutun)
        {
            OleDbConnection con;
            OleDbDataAdapter da;
            DataSet ds2;
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=veri.accdb");
            da = new OleDbDataAdapter("SELECT * from tablo1 where barkod = " + barkod.ToString(), con);
            ds2 = new DataSet();
            con.Open();
            da.Fill(ds2, "tablo1");
            DataRow satir = ds2.Tables["tablo1"].Rows[0];
            con.Close();
            return  satir[sutun].ToString();

        }
        private void button14_Click(object sender, EventArgs e)
        {
            data_ekle_grid(110);
            button14.Text = data_al_tek(110, "urun_adi");
            guncel();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

            Form2 fr = new Form2(); fr.Show();
            this.Hide();
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            hizliurun fr = new hizliurun(); fr.Show();
            this.Hide();
            data_ekle_grid(115);
            
        }

        private void button19_Click(object sender, EventArgs e)
        {
             
        }

        private void button15_Click(object sender, EventArgs e)
        {
            data_ekle_grid(115);
            button15.Text = data_al_tek(115, "urun_adi");
            guncel();
        }

    }
}
