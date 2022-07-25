using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contador_Regressivo
{
    public partial class Form1 : Form
    {
        private int totalDeSegundos;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.label1.Text = "00:00";
            this.button2.Enabled = false;
            for(int i = 0; i < 60; i++)
            {
                this.comboBox1.Items.Add(i.ToString());
                this.comboBox2.Items.Add(i.ToString());

            }
            this.comboBox1.SelectedIndex = 59;
            this.comboBox2.SelectedIndex = 59;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.button2.Enabled = true;

            int minutos = int.Parse(comboBox1.SelectedIndex.ToString());
            int segundos = int.Parse(comboBox2.SelectedIndex.ToString());

            totalDeSegundos = (minutos * 60) + segundos;

            this.timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
            this.button2.Enabled = false;

            this.timer1.Enabled = false;
            totalDeSegundos = 0;
            this.label1.Text = "00:00";


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(totalDeSegundos > 0 )
            {
                int minutos = (totalDeSegundos / 60);
                int segundos = totalDeSegundos - (minutos * 60);
                this.label3.Text = minutos.ToString() + ":" + segundos.ToString();

                totalDeSegundos--;
            }
            else
            {
                this.timer1.Enabled = false;
                MessageBox.Show("Contador acabou!");

            }
        }
    }
}
