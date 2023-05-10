using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
// AZAT DİLCE
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace web_browser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);
            String site = textBox1.Text;

            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send(site, 100);
                if (reply != null)
                {
                    richTextBox3.Text = ("Status :  " + reply.Status + " \n Time : " + reply.RoundtripTime.ToString() + " \n Address : " + reply.Address);
                    richTextBox3.BackColor = Color.Green;
                }
            }
            catch
            {
                richTextBox3.BackColor = Color.Red;
                richTextBox3.Text = "HATA:ÜZGÜNÜM BAĞLANMADIM";
            }

            IPHostEntry host;
            string LocalIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach(IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    LocalIP = ip.ToString();
                    richTextBox4.Text = "Local İp'in: "+LocalIP;
                }
            }

            var endPoint = "https://api.ipify.org";
            var request = (HttpWebRequest)WebRequest.Create(endPoint);
            var response = (HttpWebResponse)request.GetResponse();
            var resStream = response.GetResponseStream();
            var streamReader = new StreamReader(resStream);
            richTextBox4.Text+="\r\n";
            richTextBox4.Text += ("İnternet İp'iniz: " + streamReader.ReadToEnd());

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
            richTextBox2.Text += webBrowser1.Url.ToString()+"\r\n";
            richTextBox2.Text += "\r\n";



            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += webBrowser1.Url.ToString() + "\r\n";
            richTextBox1.Text += "\r\n";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
        }
    }


    }

