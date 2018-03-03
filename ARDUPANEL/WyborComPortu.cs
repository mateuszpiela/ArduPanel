using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;

namespace ARDUPANEL
{
    public partial class WyborComPortu : Form
    {
        public WyborComPortu()
        {
            InitializeComponent();
            AutoUpdater.Start("https://raw.githubusercontent.com/mateuszpiela/ArduPanel/latest.xml");
            string[] ports = SerialPort.GetPortNames();
            foreach(string port in ports)
            {
                comboBox1.Items.Add(port);
            }

        }
        public string setcom;
        private void Button1_Click(object sender, EventArgs e)
        {
            setcom = comboBox1.SelectedItem.ToString();
            Informacje fr = new Informacje(setcom);
            fr.Show();
            this.Hide();

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //setcom = comboBox1.SelectedText.ToString();
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
