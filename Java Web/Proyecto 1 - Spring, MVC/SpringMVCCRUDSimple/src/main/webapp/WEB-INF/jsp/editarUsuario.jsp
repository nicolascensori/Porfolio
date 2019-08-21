<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<!DOCTYPE html>
<html>
<head>
<script src="//ajax.googleapis.com/ajax/libs/angularjs/1.7.0/angular.min.js"></script>
<meta charset="ISO-8859-1">
	<link rel="stylesheet" href="<c:url value="/resources/theme1/css/stylesheet.css" />" />
<title>Insert title here</title>
</head>
<body class="body_login" data-ng-app>

	<div class="resppgcont">
		<div class="resppgtemp">
			<div class="header">
				<div class="topmenu">
					<div class="logo">
						<a>
							<img src="<c:url value="/resources/theme1/css/uprisen_frog.png" />" width="64" height="64">
						</a>
					</div>
					<div class="menuinidiv" data-tooltip-type="selector">
						<a class="menuini" > HOME </a>
						<a class="menuini" > TIENDA </a>
						<a class="menuini" > SOPORTE</a>
						<a class="menuini" > CONTACTO</a>
					</div>
					<div class="loginstatus">
				
					</div>
				</div>
			</div>
			<div class="div_cont_horiz"></div>
			<div class="columnas">
				<div class="colizq">
					<div class="submenu">
						<div class="login">
							<div class="logincol">
								<div class="logincontenido"> 
									<h2>EDITAR CUENTA</h2>
									<br>
									<form:form method="POST" action="/SpringMVCCRUDSimple/guardareditado">
											<form:hidden path="id"/>
											<div class="loginformlinea">												
												<label class="desc_text">Ingrese su nueva direccion de mail</label>
												<form:input class="text_input" path="email" type="email"/>
											</div>
											<div class="loginformlinea">
												<label class="desc_text">Ingrese su nuevo nomrbe de usuario</label>
												<form:input class="text_input" path="nombre" type="text"/>
											</div>
										<div class="loginformlinea">
											<label class="desc_text">Ingrese su nueva contraseña</label>
											<form:input class="text_input" path="clave" type="password"/>
										</div>
										<form:hidden path="isAdmin"/>
										<form:hidden path="isBloqueado"/>
										<button class="btnverde" type="submit">Modificar</button>
									</form:form>
								</div>
								<div></div>
								
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</body>
</html>