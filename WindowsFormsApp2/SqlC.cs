using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp2
{
    class SqlC
    {
       

        public static string srvnameorip = Settingss()[0].ToString().Trim();
        public static string dbname = "master";
        public static string Userd = Settingss()[1].ToString().Trim();
        public static string Password= Settingss()[2].ToString().Trim();
        public static string tarih = null;
        




        public static SqlConnection con = new SqlConnection(@"server = "+ Settingss()[0].ToString().Trim() + "; Database = "+dbname+";User ID = "+ Settingss()[1].ToString().Trim() + "; Password="+ Settingss()[2].ToString().Trim() + "Connection Timeout=30");
        public static SqlCommand com = new SqlCommand();
        public static SqlDataAdapter daa = new SqlDataAdapter(com);
        
        
        public static string[] Settingss()
        {
            string dosya_yolu = @"c:\yeniklasor\settings.txt";

            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);

            StreamReader sw = new StreamReader(fs);

            string yazi = sw.ReadLine();
            string[] settings = new string[3];
             int i = 0;
            while (yazi != null)
            {
                settings[i] = yazi;
                i = i + 1;
                if (i>2)
                    break;
                yazi = sw.ReadLine();
            }
            i = 0;
            
          
            sw.Close();
            fs.Close();
          
            return settings;




        }
         

        public static bool dbkont() 
        {
            bool kontrol = false;
            DataSet dataset = new DataSet();
            con.Open();
            com.CommandText= "SELECT name FROM master.dbo.sysdatabases";
            com.Connection = SqlC.con;
            daa.SelectCommand = com;

            daa.Fill(dataset);
            //MessageBox.Show(dataset.Tables[0].Rows[1].ItemArray[0].ToString());
            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {

                if (dataset.Tables[0].Rows[i].ItemArray[0].ToString()=="KASA")
                {
                    
                    kontrol = true;
                    Settings1.Default.dbkont = true;
                }
            }

            con.Close();

            return kontrol;
            



        }
        
       
        
      

    }
}
