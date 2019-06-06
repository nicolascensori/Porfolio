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
    public partial class Form2 : Form
    {
        public static Color colorHijo = new Color();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10 ; i++)
            {
                Form1.indice = i + 1;
                Form1 frm = new Form1();
                frm.Owner = this;
                //this.AddOwnedForm(frm);
                frm.Show();
            }
        }

        private void colorsButton_Click(object sender, EventArgs e)
        {
            foreach (Form1 frm in this.OwnedForms)
            {
                frm.timer1.Start();
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            foreach (Form1 frm in this.OwnedForms)
            {
                frm.timer1.Stop();
            }
        }
    }
}
