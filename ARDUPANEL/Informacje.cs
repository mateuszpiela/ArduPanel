using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace ARDUPANEL
{
    public partial class Informacje : Form
    {
        public string COM;
        bool odsw = true;
        System.Windows.Forms.Timer tm = new System.Windows.Forms.Timer();

        public Informacje(string setcom)
        {
            InitializeComponent();

            COM = setcom;
            COMREAD();
            Timer();
        }
        public void Timer()
        {
            if (odsw)
            {
                tm.Interval = 10000;
                tm.Start();
                tm.Tick += Timer1_Tick;
            }
            else
            {
                tm.Stop();
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            COMREAD();
        }
            public void COMREAD()
        {
            string temp;
            string wilg;
            string version;
            string func1;
            SerialPort port = new SerialPort(COM, 9600);
            port.Open();
            port.WriteLine("/funkcje");
            func1 = port.ReadLine();
            //Wersja
            port.WriteLine("/wersja");
            version = port.ReadLine();
            //Temperatura i wilgotność
            func1 = func1.Replace("\r", "");
            if (func1 == "DHT")
            {
                port.WriteLine("/temp");
                temp = port.ReadLine();
                port.WriteLine("/wilg");
                wilg = port.ReadLine();
                temp = temp.Replace("\r", "");
                wilg = wilg.Replace("\r", "");

                label2.Text = temp + "°C";
                label4.Text = wilg + "%";
            }
            else
            {
                label2.Text = "Nie dostępne";
                label4.Text = "Nie dostępne";
            }
            label6.Text = version;
            port.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            COMREAD();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                odsw = true;
                Timer();
            }
            else
            {
                odsw = false;
                Timer();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            License lic = new License();
            lic.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/mateuszpiela/ArduPanel");
        }
    }
}
