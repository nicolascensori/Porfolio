using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Censori___Recuperatorio
{
    public partial class Form1 : Form
    {
        public static int indice;
        private int index = indice;
        Button btn;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int numero = 0;
            Random rnd = new Random();

            for (int i = 0 ; i < indice ; i++)
                for(int j = 0 ; j < indice; j++)
                {
                    numero++;
                    btn = new Boton();
                    btn.Location = new Point(btn.Width * i, btn.Height * j);
                    btn.Text = numero.ToString();
                    btn.BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                    btn.MouseEnter += new System.EventHandler(this.Boton_MouseEnter);
                    this.Controls.Add(btn);   
                }
        }
        private void Boton_MouseEnter(object sender, EventArgs e)
        {
            Form2 frm = (Form2)this.Owner;
            Button btn = sender as Button;

            frm.pictureBox1.BackColor = btn.BackColor;
            frm.label1.Text = index + "x" + index + ": " + btn.Text;
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();

            foreach (Button btn in this.Controls)
            {
                btn.BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            }
        }
    }
}
