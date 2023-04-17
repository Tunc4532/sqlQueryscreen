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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=personel_veritabanii;Integrated Security=True");

        private void btnstart_Click(object sender, EventArgs e)
        {

            string sorgu = richTextBox1.Text;
           
            try
            {
                SqlDataAdapter da = new SqlDataAdapter( sorgu, baglantı);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch(Exception) 
            {
                MessageBox.Show("Kod bloğunu kontrol ediniz","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
          
        }
        
        private void btndml_Click(object sender, EventArgs e)
        {
           
            string sorgu = richTextBox1.Text;
           
            //DialogResult karar;
            //karar = MessageBox.Show("İşlemi Onaylıyomusunuz ", "Bilgi");
            //if (karar == DialogResult.OK)
            //{
            try
                {

                    baglantı.Open();
                    SqlCommand komut = new SqlCommand(sorgu , baglantı);
                    komut.ExecuteNonQuery();
                    baglantı.Close();

                    SqlDataAdapter dte = new SqlDataAdapter("Select * from tbl_personelıd ", baglantı);
                    DataTable dtr = new DataTable();
                    dte.Fill(dtr);
                    DataTable dt = new DataTable();

                }
                catch (Exception)
                {
                    MessageBox.Show("Kod bloğunu kontrol ediniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            //}
            //else { MessageBox.Show("İşlem iptal eedildi "); }


        }
    }
}
