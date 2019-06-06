using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalCensori
{
    public partial class Config : Form
    {
        Tablero tablero;
        public Config()
        {
            InitializeComponent();
        }

        private void iniciarBtn_Click(object sender, EventArgs e)
        {
            if (tablero == null)
            {
                tablero = new Tablero();
                tablero.Owner = this;
                tablero.Show();
                this.Hide();
            }
            else
            {
                tablero.Close();
                tablero = null;
                tablero = new Tablero();
                tablero.Owner = this;
                tablero.Show();
                this.Hide();
            }
        }
    }
}
