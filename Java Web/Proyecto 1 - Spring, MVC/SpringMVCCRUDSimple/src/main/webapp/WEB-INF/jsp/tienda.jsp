<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="ISO-8859-1">
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
<link rel="stylesheet" href="<c:url value="/resources/theme1/css/stylesheet.css" />" />
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
<title>Tienda</title>
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
						<a href="tienda"> <img src="<c:url value="/resources/theme1/css/uprisen_frog.png" />" width="64" height="64">
						</a>
					</div>
					<div class="menuinidiv" data-tooltip-type="selector">
						<a class="menuini" href="homepg"> HOME </a> <a class="menuini selectedpg"
							href="tienda"> TIENDA </a> <a class="menuini"
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
			<div class="container col-sm-8 card-group">
			<div class="row">
				<c:forEach var="prod" items="${list}">
					<div class="card text-white bg-dark col-sm-3" style="width: 18rem;">
						<img src="${prod.foto}" class="card-img-top" alt="${prod.nombre}">
						<div class="card-body">
							<h5 class="card-title">${prod.nombre}</h5>
							<p class="card-text">${prod.descripcion}</p>
							<label class="label">$${prod.precio}</label>
						</div>
					</div>
				</c:forEach>
			</div>
			</div>
		</div>
	</div>
</body>
</html>