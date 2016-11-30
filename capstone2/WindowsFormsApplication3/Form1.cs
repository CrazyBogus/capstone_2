using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        private SerialPort arduSerialport = new SerialPort();

        public Form1()
        {
            InitializeComponent();
        }

        void arduSerialport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int recvSize = arduSerialport.BytesToRead;
            string str;

            if (recvSize != 0)
            {
                str = "";
                byte[] buff = new byte[recvSize];
                arduSerialport.Read(buff, 0, recvSize);
                for(int i=0; i<recvSize; i++)
                {
                    str += Convert.ToChar(buff[i]);
                }
                textBox1.Text += str;
                textBox1.Select(textBox1.Text.Length, 0);
                textBox1.ScrollToCaret();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (true == arduSerialport.IsOpen)
            {
                arduSerialport.Close();
                textBox2.Text = "Connect Close";
            }
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            arduSerialport.PortName = "COM9";
            arduSerialport.BaudRate = 9600;
            arduSerialport.DataReceived += new SerialDataReceivedEventHandler(arduSerialport_DataReceived);
            arduSerialport.Open();

            if (true == arduSerialport.IsOpen)
                textBox2.Text = "Connect Succes\n";
            else
                textBox2.Text = "Connect fail";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
