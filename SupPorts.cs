using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupPorts_V2
{
    public partial class SupPorts : Form
    {
        //initialize ip with local host
        public IPAddress ip = IPAddress.Parse("127.0.0.1");
        public IPAddress[] workedOnIps = new IPAddress[5];

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
            //if ip is not in the workedOnIps array:
            //add it to worked on Ips 
            //call IpThread 
            ipThreadManager.RunWorkerAsync(); 
        }
        private void IpThreadManager_DoWork(object sender, DoWorkEventArgs e)
        {
            /*ThreadManager is responsible for disriputing threads to analyze open
            ports given an IP,
            worked on IPs are mentioned in this.workedOnIps
            and are maxed at 5.
            Port ranges:
            System or well-known ports : 0 - 1023
            User or registered ports : 1024 - 49151
            Dynamic, private ports : 49152 - 65535
            */


            //example to creating socket and finding port
            try
            {
                portFinderWorker.RunWorkerAsync(new portRange(1, 1023));
            }
            catch (Exception error)
            {

                Console.WriteLine(error.ToString());
            }

        }
        
        private void IpThreadManager_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void portFinderWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            portRange range = (portRange)e.Argument;
            for (int port = range.portStart; port <= range.portEnd; port++)
            {

                IPEndPoint localEndPoint = new IPEndPoint(ip, port);
                Socket sock = new Socket(this.ip.AddressFamily,
                               SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    sock.Connect(localEndPoint);
                    //labelOutput.Text += "port " + port.ToString() + "is open \n";
                    Console.WriteLine("port " + port.ToString() + "is open");

                    sock.Close();
                }
                catch (Exception error) //closed port
                {
                    //labelOutput.Text += "port " + port.ToString() + "is closed \n";
                    Console.WriteLine("port " + port.ToString() + "is CLOSE");
                }
            }
        }

        private void SupPorts_Load(object sender, EventArgs e)
        {

        }

        private void IpInputHeader_Click(object sender, EventArgs e)
        {

        }

        private class portRange
        {
            public int portStart;
            public int portEnd;

            public portRange(int portStart, int portEnd)
            {
                this.portStart = portStart;
                this.portEnd = portEnd;
            }
        }
    }
}
