using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class home : System.Web.UI.Page
{
    BLL dn = new BLL();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            nombreUsuario.InnerText = "Bienvenido, " + Session["nombre"].ToString();
            //ViewState["variable"] = RadioButtonList1.SelectedValue + " ASC";
            actualizarGridView();
        }
    }

    protected void BotonCerrarSesion_Click(object sender, EventArgs e)
    {
        eliminarCookies();
        Session.Abandon();

        Response.Redirect("login.aspx");
    }

    protected void GuardarBtn_Click(object sender, EventArgs e)
    {
        if (nombreBox.Text != "" && direccionBox.Text != "" && GridView1.SelectedRow == null)
        {
            String nombre = nombreBox.Text;
            String direccion = direccionBox.Text;

            dn.alta_persona(nombre, direccion);
            actualizarGridView();
            limpiarTextbox();
        }
        else if (nombreBox.Text != "" && direccionBox.Text != "" && GridView1.SelectedRow != null)
        {
            int id = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            String nombre = nombreBox.Text;
            String direccion = direccionBox.Text;

            dn.modificacion_persona(id, nombre, direccion);
            actualizarGridView();
            limpiarTextbox();
            GridView1.SelectedIndex = -1;
        }
        
    }

    protected void EditarBtn_Click(object sender, EventArgs e)
    {
        if (GridView1.SelectedRow != null)
        {
            nombreBox.Text = GridView1.SelectedRow.Cells[2].Text;
            direccionBox.Text = GridView1.SelectedRow.Cells[3].Text;
        }
    }

    protected void BorrarBtn_Click(object sender, EventArgs e)
    {
        if (GridView1.SelectedRow != null)
        {
            int id = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            dn.baja_persona(id);
            actualizarGridView();
            limpiarTextbox();
            GridView1.SelectedIndex = -1;
        }
    }

    protected void DeseleccionarBtn_Click(object sender, EventArgs e)
    {
        GridView1.SelectedIndex = -1;
        limpiarTextbox();
    }

    void eliminarCookies()
    {
        HttpCookie cookie = Request.Cookies["RememberCookie"];
        if (cookie != null)
        {
            cookie.Expires = DateTime.Now.AddSeconds(-10);
            Response.Cookies.Add(cookie);
        }
    }

    public void actualizarGridView()
    {
        DataView dataview = dn.GetPersonas().Tables[0].AsDataView();
        dataview.Sort = RadioButtonList1.SelectedValue + " " + RadioButtonList2.SelectedValue;
        GridView1.DataSource = null;
        GridView1.DataSource = dataview;
        GridView1.DataBind();
    }

    public void limpiarTextbox()
    {
        nombreBox.Text = "";
        direccionBox.Text = "";
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        actualizarGridView();
    }
}