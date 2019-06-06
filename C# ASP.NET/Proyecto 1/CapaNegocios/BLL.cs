using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class BLL
    {
        DAL ad = new DAL();

        public DataSet GetPersonas()
        {
            return ad.GetPersonas();
        }

        public DataSet get_usuario()
        {
            return ad.get_usuario();
        }

        public void alta_usuario(String email, String nombre, String clave)
        {
            ad.alta_usuario(email, nombre, clave);
        }
        public void alta_persona(String nombre, String direccion)
        {
            ad.alta_persona(nombre, direccion);
        }
        public void baja_persona(int id)
        {
            ad.baja_persona(id);
        }
        public void modificacion_persona(int id, String nombreNuevo, String direccionNueva)
        {
            ad.modificacion_persona(id, nombreNuevo, direccionNueva);
        }

    }
}
