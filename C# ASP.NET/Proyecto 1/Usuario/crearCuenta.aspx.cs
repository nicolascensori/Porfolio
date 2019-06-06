using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class crearCuenta : System.Web.UI.Page
{
    BLL dn = new BLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["email"] != null)
        {
            Response.Redirect("home.aspx");
        }
    }

    protected void BotonSubmit_Click(object sender, EventArgs e)
    {
        if (usuarioExiste(email.Value) == false)
        {
            dn.alta_usuario(email.Value, nombre.Value, clave.Value);
            Response.Redirect("login.aspx");
        }
        else if (usuarioExiste(email.Value) == true)
        {
            labelAdvertencia.Visible = true;
        }
    }

    Boolean usuarioExiste(String email)
    {
        DataSet tabla = dn.get_usuario();
        

        foreach (DataRow row in tabla.Tables[0].Rows)
        {
            if (row.ItemArray.Contains(email))
            {
                return true;
            }
        }
        return false;
    }
}