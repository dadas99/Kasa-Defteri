using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        

        public static string gelirstr = "0";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (comboBox1.Text.ToString()==""|| comboBox2.SelectedIndex.ToString() == "-1")
                {
                    MessageBox.Show("TÜM ALANLARI DOLDURDUĞUNUZDAN EMİN OLUNUZ!");

                }
                else
                {
                    SqlC.con.Open();
                    SqlC.com.CommandText = " use kasa insert into dbo.FİSLER (tarih, kullanıcı, gelir,değer ,Acıklama) values ('" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "','" + comboBox1.SelectedItem.ToString() + "','" + comboBox2.SelectedIndex.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox1.Text.ToString() + "')";
                    SqlC.com.Connection = SqlC.con;
                    SqlC.com.ExecuteNonQuery();
                }
                


                SqlC.con.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("TÜM ALANLARI DOLDURDUĞUNUZDAN EMİN OLUNUZ!");
            }
            
           


        }

        private void dBBağlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dbbaglan = new DB_Bağlan();
            dbbaglan.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SqlC.srvnameorip= Settings1.Default.srvnameorip.Trim();
            //SqlC.Password = Settings1.Default.Userd;
            //SqlC.Userd = Settings1.Default.Password;


            //if (SqlC.dbkont() == true)
            //{
            //    SqlC.con.Open();

            //    DataTable dt = new DataTable();

            //    SqlC.com.CommandText = " use kasa select * from FİSLER where tarih ='" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "'";

            //    SqlC.com.Connection = SqlC.con;

            //    SqlDataAdapter da = new SqlDataAdapter(SqlC.com);

            //    da.Fill(dt);

            //    dataGridView1.DataSource = dt;

            //    SqlC.con.Close();



            //}
            //else
            //{
            //    MessageBox.Show("LÜTFEN DB KURUNUZ");

            //}

           SetOlstr();
           


            //if (SqlC.setkont()==false)
            //{
                
            //    const string message =  "   LÜTFEN DB BAĞLANTI BİLGİLERİNİZİ GİRİNİZ";
            //    const string caption = "Form Closing";
            //    var result = MessageBox.Show(message, caption,
            //                                 MessageBoxButtons.OK,
            //                                 MessageBoxIcon.Question);

               
            //    if (result == DialogResult.OK)
            //    {
            //        var dbbaglan = new DB_Bağlan();
            //        dbbaglan.Show();

            //    }

            //}


            






            for (int i = 0; i < Settings1.Default.kullanıcı.Count; i++)
            {
                comboBox1.Items.Add(Settings1.Default.kullanıcı[i]);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SqlC.dbkont() == false)
            {
                try
                {
                    SqlC.con.Open();
                    SqlC.com.CommandText = "CREATE DATABASE KASA;";
                    SqlC.com.Connection = SqlC.con;
                    SqlC.com.ExecuteNonQuery();
                    
                    SqlC.com.CommandText = "use kasa CREATE TABLE FİSLER( FISno INT IDENTITY(1, 1),tarih date, kullanıcı nchar(255) , gelir bit, değer int,Acıklama varchar(255), CONSTRAINT FISno PRIMARY KEY(FISno) ); ";
                    SqlC.com.Connection = SqlC.con;
                    SqlC.com.ExecuteNonQuery();
                    SqlC.con.Close();
                    MessageBox.Show("DB BAŞIRI İLE OLUŞTURULDU");
                }
                catch (Exception ex)
                {

                    MessageBox.Show("hata    !" + ex);

                }

            }
            
        }

        private void kullanıcıEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlC.con.Open();

                DataTable dt = new DataTable();
                SqlC.dbname = "KASA";

                SqlC.com.CommandText = " use kasa select * from dbo.FİSLER where tarih ='" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "'";

                SqlC.com.Connection = SqlC.con;

                SqlDataAdapter da = new SqlDataAdapter(SqlC.com);

                da.Fill(dt);

                dataGridView1.DataSource = dt;

                SqlC.con.Close();
                SqlC.dbname = "master";

            }
            catch (Exception ex)
            {

                MessageBox.Show("hata " + ex);
            }





        }



        private void button4_Click(object sender, EventArgs e)
        {
            
            if (comboBox2.Text.ToString()== "GELİR ( + )".Trim())
                gelirstr = "1";
            else
                gelirstr = "0";
                
            
            try
            {
                SqlC.con.Open();
                SqlC.com.CommandText = (" use kasa update dbo.FİSLER set tarih = '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "',gelir ='" + gelirstr + "',kullanıcı='"+comboBox1.Text.ToString().Trim()+"',değer='"+textBox2.Text+"',Acıklama='"+textBox1.Text+"' where FISno='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'");
                SqlC.com.Connection = SqlC.con;
                SqlC.com.ExecuteNonQuery();
                SqlC.con.Close();
                //"',gelir='" + comboBox2.SelectedIndex + "',değer='" + textBox2.Text + "',Acıklama='" + textBox1.Text + "'
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen Satır seçiniz"+ ex);
                SqlC.con.Close();

            }
            string a = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();


            MessageBox.Show(a);

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            



        }
      

        private void button5_Click(object sender, EventArgs e)
        {
           

           


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = null;
            comboBox2.Text = null;
            textBox2.Text = null;
            textBox1.Text = null;
            comboBox1.SelectedText = dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Trim();
            if (dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Trim() == "True".Trim())
            {
                comboBox2.SelectedText = "Gelir (+)";
            }
            else
            {
                comboBox2.SelectedText = "Gider (-)";
            }

            textBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString().Trim();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString().Trim();

        }
        public static void SetOlstr()
        {
            if (!Directory.Exists(@"c:\yeniklasor"))
            {
                Directory.CreateDirectory(@"c:\yeniklasor");
                FileStream fss = File.Create(@"c:\yeniklasor\settings.txt");
                fss.Close();
                string dosya_yolu = @"c:\yeniklasor\settings.txt";

                FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);

                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(".");
                sw.WriteLine("AD");
                sw.WriteLine("sifre");

                sw.Flush();

                sw.Close();
                fs.Close();
            }


        }
    }
}
