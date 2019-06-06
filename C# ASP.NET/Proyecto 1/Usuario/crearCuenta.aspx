<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="crearCuenta.aspx.cs" Inherits="crearCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    <div class="container"  style="margin-top: 10%; width: 40%" data-ng-app>
		<form runat="server">
			<div class="form-group, text-center">
				<h1 class="h3 mb-3 font-weight-normal text-left">Formulario de registro</h1>
			</div>
			<div class="form-group">
				<label for="nombre" class="">Nombre para mostrar</label>
				<input type="text" id="nombre" class="form-control" data-ng-model="nombre" runat="server" required autofocus>
			</div>
			<div class="form-group">
				<label for="email" class="">Dirección de email</label>
				<input type="email" id="email" class="form-control" data-ng-model="email" runat="server" required>
                <asp:Label id="labelAdvertencia" runat="server" class="alert-danger rounded small" Visible="False">Ya hay un usuario registrado con ese email. Seleccione otro por favor</asp:Label>
			</div>
			<div class="form-group">
				<label for="clave" class="">Contraseña (debe tener 8 caracteres o más)</label>
				<input type="password" id="clave" class="form-control" pattern=".{8,}" runat="server" data-ng-model="clave" required>
			</div>
			<div class="form-group">
				<label for="clave2" class="">Repita la contraseña</label>
				<input type="password" id="clave2" class="form-control" data-ng-model="clave2" data-ng-pattern="clave" required>
			</div>
			<div class="">
                <asp:button class="btn btn-lg btn-block" data-ng-disabled="!(nombre && email && clave && clave2)" style="background-color: #CA7920; color: white; width: 40%;" type="submit" runat="server" text="Registrarse" id="BotonSubmit" OnClick="BotonSubmit_Click"/>
			</div>
		</form>
	</div>

</asp:Content>

