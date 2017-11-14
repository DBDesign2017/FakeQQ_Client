using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakeQQ_Client
{
    public partial class Form2 : Form
    {
        private ClientOperation c;
        public Form2(ClientOperation c)
        {
            this.c = c;
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("退出程序");
            Application.Exit();
        }
    }
}
