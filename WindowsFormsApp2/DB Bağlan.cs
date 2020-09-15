using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp2
{
    public partial class DB_Bağlan : Form
    {
        public DB_Bağlan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {




            try
            {

                SqlC.srvnameorip = SqlC.Settingss()[0].ToString().Trim();
                SqlC.Userd = SqlC.Settingss()[1].ToString().Trim();
                SqlC.Password = SqlC.Settingss()[2].ToString().Trim();
                SqlC.con.Open();
                MessageBox.Show("bağlantı başarılı");
                SqlC.con.Close();




            }
            catch (SqlException ex)
            {
                MessageBox.Show("hata   !" + ex);
                SqlC.con.Close();

            }
            SqlC.con.Close();

        }

        private void DB_Bağlan_Load(object sender, EventArgs e)
        {
            textBox1.Text = SqlC.Settingss()[0].ToString().Trim();
            textBox2.Text = SqlC.Settingss()[1].ToString().Trim();
            textBox3.Text = SqlC.Settingss()[2].ToString().Trim();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Settings1.Default.srvnameorip = textBox1.Text;
            //Settings1.Default.Userd = textBox2.Text;
            //Settings1.Default.Password = textBox3.Text;

            //Settings1.Default.Save();
            string dosya_yolu = @"c:\yeniklasor\settings.txt";
            
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
           
            StreamWriter sw = new StreamWriter(fs);
            
            sw.WriteLine(textBox1.Text.ToString().Trim());
            sw.WriteLine(textBox2.Text.ToString().Trim());
            sw.WriteLine(textBox3.Text.ToString().Trim());
            
            sw.Flush();
            
            sw.Close();
            fs.Close();


        }
    }
}
