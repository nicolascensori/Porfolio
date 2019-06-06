<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form runat="server">
        <div class="container-fluid col-md-12">
            <div class="float-right">
                <span class="" id="nombreUsuario" runat="server"></span>
                <asp:button id="BotonCerrarSesion" cssclass="btn btn-danger btn-sm" runat="server" onclick="BotonCerrarSesion_Click" text="Cerrar Sesion" />
            </div>
        </div>
        <div class="container col-md-6 float-left">
            <div class="form-group">
                <asp:gridview id="GridView1" runat="server" autogeneratecolumns="False" allowsorting="True" backcolor="White" bordercolor="#CCCCCC" borderstyle="None" borderwidth="1px" cellpadding="4" forecolor="Black" gridlines="Horizontal" width="539px" autogenerateselectbutton="True">
		<Columns>
			<asp:BoundField HeaderText="Id" DataField="Id" ReadOnly="True"  />
			<asp:BoundField HeaderText="Nombre" DataField="Nombre" />
			<asp:BoundField HeaderText="Dirección" DataField="Direccion" />
		</Columns>
		<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
		<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
		<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
		<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
		<SortedAscendingCellStyle BackColor="#F7F7F7" />
		<SortedAscendingHeaderStyle BackColor="#4B4B4B" />
		<SortedDescendingCellStyle BackColor="#E5E5E5" />
		<SortedDescendingHeaderStyle BackColor="#242121" />
	</asp:gridview>
            </div>
        </div>
        <div class="container col-md-6 float-right">
            <h4>Panel de control</h4>
            <div class="btn-group col-md-4">
                <asp:button id="EditarBtn" runat="server" cssclass="btn-secondary btn btn-sm btn-block" text="Editar" onclick="EditarBtn_Click" />
                <asp:button id="BorrarBtn" runat="server" cssclass="btn-danger btn btn-sm btn-block" text="Borrar" onclick="BorrarBtn_Click" />
                <asp:button id="DeseleccionarBtn" runat="server" text="Deseleccionar" cssclass="btn-info btn btn-sm btn-block" onclick="DeseleccionarBtn_Click" />
            </div>
            <div class="radio col-md-8" style="margin: auto">
                <asp:radiobuttonlist id="RadioButtonList1" runat="server" autopostback="True" onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                    <asp:ListItem Text="Ordenar por id" Value="Id"></asp:ListItem>
                    <asp:ListItem Text="Ordenar por nombre" Value="Nombre" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Ordenar por direccion" Value="Direccion"></asp:ListItem>
                </asp:radiobuttonlist>
                <asp:radiobuttonlist id="RadioButtonList2" runat="server" autopostback="True" onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                    <asp:ListItem Text="Orden ascendente" Value="ASC" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Orden descendente" Value="DESC"></asp:ListItem>
                </asp:radiobuttonlist>
            </div>
        </div>
        <div class="container col-md-6 float-right" style="margin-top: 40px;clear:both">
            <div class="text-left">
                <div class="form-group">
                    <h4>Formulario de inserción/modificación</h4>
                </div>
                <div class="col-md-2 text-right">
                    <label class="d-block">Nombre</label>
                    <label class="d-block">Dirección</label>
                </div>
                <div class="col-md-10">
                    <div class="d-block">
                         <asp:textbox id="nombreBox" runat="server" width="125px"></asp:textbox>
                    </div>
                    <div class="d-block" style="margin-top:3px">
                         <asp:textbox id="direccionBox" runat="server" height="22px" width="125px"></asp:textbox>
                    </div>
                    <div class="btn-group" style="margin-top: 10px">
                        <asp:button id="Button1" runat="server" cssclass="btn-primary btn btn-sm" text="Guardar" onclick="GuardarBtn_Click" />
                    </div>
                </div>
            </div>
            
        </div>
    </form>
</asp:Content>

