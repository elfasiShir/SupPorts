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
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;

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
            Console.WriteLine("Analyzing ip: " + this.ip.ToString());
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
            port 0 assigns a random port, so is not worth checking by itself as it will never be assigned
            System or well-known ports : 1 - 1023
                
            User or registered ports : 1024 - 49151
               
            Dynamic, private ports : 49152 - 65535
            */
            try
            {
                
                PortFinder portWorker;
                ipThreadManager.WorkerReportsProgress = true;
                ipThreadManager.ReportProgress(1, "analyzing System or well-known ports : 1 - 1023, 14 threads");
                Thread thread;
                for (int portStart = 1; portStart <= 1023; portStart += 73)
                {
                    portWorker = new PortFinder(portStart, portStart + 73, this.ip);
                    thread = new Thread(new ThreadStart(portWorker.ThreadProc));
                    thread.Start();   
                }
                Thread.Sleep(20000);
                ipThreadManager.ReportProgress(2, "analyzing User or registered ports : 1024 - 49151, 19 threads");
                for (int portStart = 1024; portStart <= 49151; portStart += 2533)
                {
                    portWorker = new PortFinder(portStart, portStart + 2533, this.ip);
                    thread = new Thread(new ThreadStart(portWorker.ThreadProc));
                    thread.Start();
                }
                Thread.Sleep(500000);
                ipThreadManager.ReportProgress(2, "analyzing Dynamic, private ports : 49152 - 65535");
                for (int portStart = 49152; portStart <= 65535; portStart += 5461)
                {
                    portWorker = new PortFinder(portStart, portStart + 5461, this.ip);
                    thread = new Thread(new ThreadStart(portWorker.ThreadProc));
                    thread.Start();
                }


            }
            catch (Exception error)
            {

                Console.WriteLine(error.ToString());
            }

        }
        private void IpThreadManager_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            labelOutput.Text += (string)e.UserState + "\n";

        }
        public class PortFinder {
            public int portStart;
            public int portEnd;
            public IPAddress ip;
            public PortFinder(int start, int end, IPAddress ipAd )
            {
                portStart = start;
                portEnd = end;  
                ip = ipAd;
                 
            }
            public PortFinder()
            {
                ip = IPAddress.Parse("127.0.0.1");
                portStart = 1;
                portEnd = 15;    
            }
            public void ThreadProc()
            {
                for (int port = portStart; port <= portEnd; port++)
                {

                    IPEndPoint localEndPoint = new IPEndPoint(ip, port);
                    Socket sock = new Socket(ip.AddressFamily,
                                   SocketType.Stream, ProtocolType.Tcp);

                    try
                    {
                        sock.Connect(localEndPoint);
                        Console.WriteLine("port " + port.ToString() + " is open");
                        
                        sock.Close();
                    }
                    catch (Exception error) //closed port
                    {
                        //Console.WriteLine("port " + port.ToString() + " is CLOSE");
                    }
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

        private void labelOutput_Click(object sender, EventArgs e)
        {

        }
    }
}
