using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupPorts_V2
{
    public partial class SupPorts : Form
    {
        //initialize ip with local host
        public IPAddress ip = IPAddress.Parse("127.0.0.1");

        public SupPorts()
        {
            InitializeComponent();
            labelOutput.Text += "\n";
        }

        private void IpInput_TextChanged(object sender, EventArgs e)
        {
            if (IPAddress.TryParse(IpInput.Text, out this.ip)) {
                IpInputHeader.Text = "Enter ip: valid " + this.ip.ToString();
            } else {
                IpInputHeader.Text = "Enter ip: not an ip";
            }
        }
        private void FindPorts_Click(object sender, EventArgs e)
        {
            labelOutput.Text += "Analyzing ip: " + this.ip.ToString() + "\n";

        }

        private void SupPorts_Load(object sender, EventArgs e)
        {

        }

        private void IpInputHeader_Click(object sender, EventArgs e)
        {

        }

        private void IpThreadManager_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
