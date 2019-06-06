using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Censori___Recuperatorio
{
    public class Boton : System.Windows.Forms.Button
    {
        public Boton()
        {
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Location = new System.Drawing.Point(165, 200);
            this.Name = "boton";
            this.Size = new System.Drawing.Size(40, 40);
            this.TabIndex = 0;
            this.UseVisualStyleBackColor = true;
        }
    }
}
