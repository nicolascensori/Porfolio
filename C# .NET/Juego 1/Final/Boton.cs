using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCensori
{
    public class Boton : System.Windows.Forms.Button
    {
        bool esPiedra = false;
        public Boton()
        {
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Location = new System.Drawing.Point(81, 12);
            this.Name = "button1";
            this.Size = new System.Drawing.Size(30, 30);
            this.TabIndex = 0;
            this.UseVisualStyleBackColor = true;
            this.BackColor = System.Drawing.Color.Empty;
        }

        public bool EsPiedra
        {
            get
            {
                return esPiedra;
            }

            set
            {
                esPiedra = value;
            }
        }
    }
}
