using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChatSystem
{
    public partial class Form1 : Form
    {
        public string name;

        public Form1()
        {
            InitializeComponent();
        }

        public delegate void ControlStringConsumer(Control control, string text);
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private const int ListenPort = 11000;
        bool sent;
        UdpClient listener;
        public byte click;
     

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread ListenThread = new Thread(Listener);
            ListenThread.Start();
        }

        void Listener()
        {
            listener = new UdpClient(ListenPort);
            try
            {
                while (true)
                {
                    IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, ListenPort);
                    byte[] bytes = listener.Receive(ref groupEP);
                    string message = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                    if (sent)
                    {
                        AddText(richTextBox1, DateTime.Now + " " + message);
                        sent = false;
                    }
                    else
                    {
                        AddText(richTextBox1, DateTime.Now + ": " + message);
                    }

                }
            }
            catch (SocketException e)
            {
                //AddText(Console, e.ToString());
            }
            finally
            {
                listener.Close();
            }
        }

        void AddText(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new ControlStringConsumer(AddText), new object[] { control, text });
            }
            else
            {
                control.Text += text + "\n";
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("images/exitbutton.png");
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("images/exitbuttonred.png");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            listener.Close();
        }

        public void Send(string msg)
        {
            sent = true;
            socket.EnableBroadcast = true;
            IPEndPoint ep = new IPEndPoint(IPAddress.Broadcast, 11000);

            byte[] sendbuf = Encoding.UTF8.GetBytes(msg);
            socket.SendTo(sendbuf, ep);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Send("[" + name + "]: " + textBox1.Text);
                textBox1.Text = string.Empty;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        FormEmoji form = new FormEmoji();

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            click++;

            if (click == 1)
            {
                form.Show();
                form.form1_instance = this;
            }
            else
            {
                form.Close();
                click = 0;
                form = new FormEmoji();
            }
        }
    }
}
