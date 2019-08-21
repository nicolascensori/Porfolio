<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="ISO-8859-1">
<link rel="stylesheet" href="<c:url value="/resources/theme1/css/stylesheet.css" />" />
<title>Soporte</title>
</head>
<body class="body_home">

<%
	if(session.getAttribute("nombre") == null){
		response.sendRedirect(request.getContextPath() + "/login.jsp");
	}
%>

	<div class="resppgcont">
		<div class="resppgtemp">
			<div class="header">
				<div class="topmenu">
					<div class="logo">
						<a href="soporte"> <img src="<c:url value="/resources/theme1/css/uprisen_frog.png" />" width="64" height="64">
						</a>
					</div>
					<div class="menuinidiv" data-tooltip-type="selector">
						<a class="menuini" href="homepg"> HOME </a> <a class="menuini"
							href="tienda"> TIENDA </a> <a class="menuini selectedpg"
							href="soporte"> SOPORTE</a> <a class="menuini"
							href="contacto"> CONTACTO</a>
					</div>
					<div class="loginstatus">
						<form action="loguearusuario" method="post">

							<span class="logged">Bienvenido, <%=session.getAttribute("nombre")%>
							</span>
							<button type="submit" class="newlogin">Cerrar Sesión</button>
						</form>

						<a href="editarUsuario.jsp"><button class="newlogin" style="float: right; margin-left:50%;">Modificar usuario</button></a>
					</div>
				</div>
			</div>
		</div>
	</div>
</body>
</html>