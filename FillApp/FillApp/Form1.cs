using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FillApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {
          int i;
            string UserID;
            Random randno = new Random();
            int quant;
            string quantity;
            string date;
            string final = "";
            //FileStream fs = File.Open("C:/Hackathon", FileMode.Open, FileAccess.Write, FileShare.None);
            
            for (i = 1; i <= 120; i++)
            {
                UserID = i.ToString().PadLeft(7,'0');
              
              for (int j = 0; j < 2400; j=j+100)
              {
                  date = maskedTextBox1.Text.Remove(4,1).Remove(6,1) + j.ToString().PadLeft(4, '0');
                  quant = randno.Next(100000000, 100000500);
                  quantity = quant.ToString().PadLeft(11, '0');

                  if (i == 120 && j == 2300)
                  {
                      final = final + UserID + date + quantity ;
                  }
                  else
                  {
                      final = final + UserID + date + quantity + ',';
                  }
                           
              }
                //Byte[] info = new UTF8Encoding(true).GetBytes(final);
            
               // fs.Write(info,0,info.Length);

            }
            System.IO.File.WriteAllText(@"C:\Hackathon\sensor_Raw"+maskedTextBox1.Text.Remove(4,1).Remove(6,1)+".txt", final);

        }
   
      }
}
