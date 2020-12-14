using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Com_Server_Project
{
    public partial class Form1 : Form
    {
        String resualt = "";
        public static Form1 instance;
        public Form1()
        {

            InitializeComponent();
            if(instance==null)  instance = this;
        }

        private void setDisableItems(Boolean value)
        {
            groupBox1.Enabled = value;
            defualt.Enabled = value;
           // menuStrip1.Enabled = value;
        }


        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            resualt = serialPort1.ReadLine();
            richTextBox1.Text = resualt.ToString();
            //    MessageBox.Show(" " + resualt);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            String[] port;
            port = System.IO.Ports.SerialPort.GetPortNames();
            comboBox1.Items.Clear();

            for (int i = 0; i < port.Length ; i++)
                comboBox1.Items.Add(port[i]);
            comboBox1.SelectedIndex = 0;

            // dataBits Value 
            comboBox2.SelectedIndex = 3;

            //Buad rate value
            comboBox3.SelectedIndex = 0;

            // stop bit Value
            comboBox4.SelectedIndex = 0;

            // parity  Value
            comboBox5.SelectedIndex = 0;

        }

        private void startCall_Click_1(object sender, EventArgs e)
        {
            string str;
            if (serialPort1.IsOpen == false)
            {
                // set port name Value
                serialPort1.PortName = (comboBox1.SelectedItem).ToString();

                // set dataBits Value 
                int temp = Convert.ToInt32(comboBox2.SelectedItem);
                serialPort1.DataBits = temp;

                //set Buad rate value
                temp = Convert.ToInt32(comboBox3.SelectedItem);
                serialPort1.BaudRate = temp;

                // set stop bit Value
                str = "";
                str = comboBox4.SelectedItem.ToString().ToLower();
                if (str == "one")
                    serialPort1.StopBits = System.IO.Ports.StopBits.One;
                else
                    if (str == "two")
                    serialPort1.StopBits = System.IO.Ports.StopBits.Two;
                else
                        if (str == "onefivepoint")
                    serialPort1.StopBits = System.IO.Ports.StopBits.OnePointFive;

                // set parity  Value
                str = comboBox5.SelectedItem.ToString().ToLower();
                if (str == "none")
                    serialPort1.Parity = System.IO.Ports.Parity.None;
                else
                    if (str == "even")
                    serialPort1.Parity = System.IO.Ports.Parity.Even;
                else
                        if (str == "odd")
                    serialPort1.Parity = System.IO.Ports.Parity.Odd;
                else
                            if (str == "mark")
                    serialPort1.Parity = System.IO.Ports.Parity.Mark;
                else
                                if (str == "space")
                    serialPort1.Parity = System.IO.Ports.Parity.Space;

                try
                {
                    serialPort1.Open();
                    status.Text = "متصل ";
                    status.ForeColor = System.Drawing.Color.Green;
                    startCall.Enabled = false;
                    stopCall.Enabled = true;
                    setDisableItems(false);
                }
                catch
                {
                    status.Text = "فشل في الإتصال";
                    status.ForeColor = System.Drawing.Color.Red;
                    startCall.Enabled = true;
                    stopCall.Enabled = false;
                    setDisableItems(true);

                }
            }
        }

        private void defualt_Click_1(object sender, EventArgs e)
        {
            serialPort1.PortName = "COM1";
            serialPort1.DataBits = 8;
            serialPort1.BaudRate = 9600;
            serialPort1.StopBits = System.IO.Ports.StopBits.One;
            serialPort1.Parity = System.IO.Ports.Parity.None;
            comboBox1.Text = "COM1";
            comboBox2.Text = "8";
            comboBox3.Text = "9600";
            comboBox4.Text = "One";
            comboBox5.Text = "None";
        }

        private void send_Click_1(object sender, EventArgs e)
        {
            if (selectedActions.SelectedIndex == 1)
            {
                serialPort1.WriteLine("1");

                serialPort1.WriteLine(@"D:/aaa");

            }

            else serialPort1.WriteLine(selectedActions.SelectedIndex.ToString());
      
        }

        private void stopCall_Click_1(object sender, EventArgs e)
        {
            serialPort1.Close();
            status.Text = "غير متصل";
            status.ForeColor = System.Drawing.Color.Red;
            startCall.Enabled = true;
            stopCall.Enabled = false;
            setDisableItems(true);

        }

        private void selectedActions_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (selectedActions.SelectedIndex == 1)
            {
                //  label9.Enabled = true;
                textBox1.Enabled = true;

            }
            else
            {

                //  label9.Visible = false;
                textBox1.Enabled = false;
            }
        }

        private void iNRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            serialPort1.WriteLine(richTextBox1.Text);

        }
        private void tipStartConnect_Click(object sender, EventArgs e)
        {
            startCall_Click_1(sender, e);

        }

        private void tipStopConnection_Click(object sender, EventArgs e)
        {
            stopCall_Click_1(sender, e);

        }
    }
}
