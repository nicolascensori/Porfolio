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
    public partial class Tablero : Form
    {
        Config padre;
        int cantidadPiedras = 0;
        int chances = 2;
        public Tablero()
        {
            InitializeComponent();
        }

        private void Tablero_Load(object sender, EventArgs e)
        {
            padre = (Config)this.Owner;
            Random rnd = new Random();
            //int cantidadSinPiedras = (padre.trackBarConfig.Value * padre.trackBarConfig.Value) / 2;
            int cantidadSinPiedras = ((padre.trackBarConfig.Value * padre.trackBarConfig.Value) * 60) / 100;
            chances += ((padre.trackBarConfig.Value * padre.trackBarConfig.Value) * 10) / 100;

            for (int i = 0; i < padre.trackBarConfig.Value ; i++)
                for (int j = 0; j < padre.trackBarConfig.Value ; j++)
                {
                    Boton btn = new Boton();
                    btn.Width = this.Width / padre.trackBarConfig.Value;
                    btn.Height = this.Height / padre.trackBarConfig.Value;
                    btn.Location = new Point(j * btn.Width, i * btn.Height);
                    btn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
                    this.Controls.Add(btn);

                    int aleatorio = rnd.Next(2);
                    if (aleatorio == 1 && cantidadSinPiedras > 0)
                    {
                        btn.EsPiedra = true;
                        cantidadPiedras++;
                        cantidadSinPiedras--;
                    }
                }
            this.AutoSize = true;
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            Boton btn = (Boton)sender;
        
            if (btn.EsPiedra == true)
            {
                btn.BackColor = Color.Red;
                cantidadPiedras--;
            }
            else
            {
                btn.BackColor = Color.Black;
                chances--;
            }
            if (chances == 0)
            {
                MessageBox.Show("Perdiste");
                this.Close();
            }
            else if (cantidadPiedras < 1)
            {
                MessageBox.Show("Ganaste");  
                this.Close();
            }
        }

        private void Tablero_FormClosing(object sender, FormClosingEventArgs e)
        {
            padre.Show();
        }
    }
}
