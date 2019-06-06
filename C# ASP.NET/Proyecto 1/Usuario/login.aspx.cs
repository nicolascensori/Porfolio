using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    BLL dn = new BLL();
    public bool usuarioIncorrecto = false;
    String nombreUsuario;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            HttpCookie cookie = null;
            cookie = Request.Cookies["RememberCookie"];
            if (cookie != null)
            {
                if (usuarioCorrecto(cookie["email"], cookie["clave"]) == true)
                {
                    clave.Value = cookie["clave"];
                    email.Value = cookie["email"];
                    guardarSesion();
                    Response.Redirect("home.aspx");
                }
            }
        }
    }

    protected void BotonIngresar_Click(object sender, EventArgs e)
    {

        if (usuarioCorrecto(email.Value, clave.Value) == true)
        {
            guardarSesion();
            
            if (CheckBoxRecordar.Checked)
                guardarCookie();

            Response.Redirect("home.aspx");
        }
        else if (usuarioCorrecto(email.Value, clave.Value) == false)
        {
            
            labelAdvertencia.Visible = true;
        }
    }

    void guardarCookie()
    {
        HttpCookie cookie = new HttpCookie("RememberCookie");
        cookie["nombre"] = nombreUsuario;
        cookie["email"] = email.Value;
        cookie["clave"] = clave.Value;
        cookie.Expires = DateTime.Now.AddYears(1);
        Response.Cookies.Add(cookie);
    }
    void guardarSesion()
    {
        Session["nombre"] = nombreUsuario;
        Session["email"] = Server.HtmlEncode(email.Value);
        Session["clave"] = Server.HtmlEncode(clave.Value);
        Session.Timeout = 5;
    }

    public bool usuarioCorrecto(String email, String clave)
    {
        DataSet tabla = dn.get_usuario();       

        foreach (DataRow row in tabla.Tables[0].Rows)
        {
            if (row.ItemArray.Contains(email) && row.ItemArray.Contains(clave))
            {
                nombreUsuario = row.ItemArray[1].ToString();

                return true;
            }
        }
        return false;
    }
}