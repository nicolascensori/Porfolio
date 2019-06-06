<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    
    <div class="container"  style="margin-top: 10%; width: 40%" data-ng-app>	
		<form runat="server"> 
			<div class="form-group, text-center">
				<img class="mb-4" src="img/mueblelogo.jpg" alt="" width="110" height="72" >
				<h1 class="h3 mb-3 font-weight-normal">Bienvenido</h1>	
			</div>
			<div class="form-group">
				<label for="email" class="">Dirección de email</label>
				<input type="email" id="email" class="form-control" runat="server" required autofocus>
                
                <asp:Label id="labelAdvertencia" runat="server" class="alert-danger small rounded" Visible="False">El usuario y/o la clave son incorrectos</asp:Label>
			</div>
			<div class="form-group">
				<label for="clave" class="">Contraseña</label>
				<input type="password" id="clave" class="form-control" runat="server"  required="">
			</div>
			<div class="checkbox mb-3">
				<label>
					<asp:CheckBox ID="CheckBoxRecordar" runat="server" />  Recordar mi cuenta
				</label>
			</div>
			<div class="">
                <asp:Button ID="BotonIngresar" class="btn btn-lg" style="background-color: #CA7920; color: white; width: 40%;" type="submit" runat="server" Text="Ingresar" OnClick="BotonIngresar_Click" />
				<span class="float-right ">Si no tiene cuenta, por favor <a href="crearCuenta.aspx">regístrese</a>.</span>
			</div>
		</form>
	</div>

</asp:Content>

