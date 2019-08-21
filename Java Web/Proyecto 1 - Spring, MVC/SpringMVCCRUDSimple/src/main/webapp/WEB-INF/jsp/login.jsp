<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<!DOCTYPE html>
<html>
<head>
<script src="//ajax.googleapis.com/ajax/libs/angularjs/1.7.0/angular.min.js"></script>
<meta charset="UTF-8">
<title>Nueva sesión</title>
	<link rel="stylesheet" href="<c:url value="/resources/theme1/css/stylesheet.css" />" />
</head>
<body class="body_login" data-ng-app>

<% if(session.getAttribute("nombre") != null) {
		response.sendRedirect(request.getContextPath() + "/homepg.jsp");
	}

%>

	<div class="resppgcont">
		<div class="resppgtemp">
			<div class="header">
				<div class="topmenu">
					<div class="logo">
						<a href="login" >
							<img src="<c:url value="/resources/theme1/css/uprisen_frog.png" />" width="64" height="64">
						</a>
					</div>
					<div class="menuinidiv" data-tooltip-type="selector">
						<a class="menuini" href="login"> HOME </a>
						<a class="menuini" href="login"> TIENDA </a>
						<a class="menuini" href="login"> SOPORTE</a>
						<a class="menuini" href="login"> CONTACTO</a>
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
									<h2>INICIAR SESIÓN</h2>
									<p>en una cuenta existente</p>
									<br>
									<form:form class="loginform" action="loguearusuario" method="post">
										<div class="loginformlinea">
											<div>Nombre de usuario</div>
											<form:input class="text_input" type="text" path="nombre" autofocus=""/>
											<br>
											<span class="desc_text_err" data-ng-show="<%=session.getAttribute("usuarioNoExiste")%>"> El nombre de usuario no existe</span>
										</div>
										<div class="loginformlinea">
											<div class="">Contraseña</div>
											<form:input class="text_input" type="password" path="clave"/>
											<br>
											<span class="desc_text_err" data-ng-show="<%=session.getAttribute("usuarioClave")%>"> La clave es incorrecta</span>
											<span class="desc_text_err" data-ng-show="<%=session.getAttribute("usuarioBloqueado")%>"> El usuario esta bloqueado</span>
										</div>
										</div>
									<div>
										<button type="submit" class="btnverde"> Iniciar sesión </button>
									</div>	
									</form:form>


							</div>
							<div class="loginseparador" ></div>
								<div class="logincol" data-ng-show="<%=request.getAttribute("existeUsuario")%>">
									<div class="logincontenido">
										<div>
											<h2>TU CUENTA FUE CREADA</h2>
											<p>Bienvenido!</p>
											<br>
											<p>Antes de continuar, proba iniciar sesion con el formulario a la izquierda. Tene en cuenta que sera necesario confirmar tu mail.</p>					
										</div>
									</div>
									<div>
									<a href="crearcuenta">
										<button type="button" class="btnverde"> Crear cuenta </button>
									</a>
									</div>	
								</div>
								<div class="logincol" data-ng-show="<%=request.getAttribute("sesionCerrada")%>">
									<div class="logincontenido">
										<div>
											<h2>SESION CERRADA</h2>
											<p>Nos vemos pronto!</p>
											<br>
											<p></p>					
										</div>
									</div>
									<div>
									<a href="crearcuenta">
										<button type="button" class="btnverde"> Crear cuenta </button>
									</a>
									</div>	
								</div>
								<div class="logincol" data-ng-show="!<%=request.getAttribute("existeUsuario")%> && !<%=request.getAttribute("sesionCerrada")%>">
									<div class="logincontenido">
										<div>
											<h2>CREAR</h2>
											<p>una cuenta nueva</p>
											<br>
											<p>Solo requerimos tu email y fecha de nacimiento y tendras acceso a todas las herramientas de la pagina</p>					
										</div>
									</div>
									<div>
									<a href="crearcuenta">
										<button type="button" class="btnverde"> Crear cuenta </button>
									</a>
									</div>	
								</div>
							</div>
						</div>
					</div>
				<div class="colder">
			<div class="block">

				<div class="block_contenido">
					<h3>MOTIVOS PARA UNIRSE</h3>
					<ul class="lista_bullet">
						<li>Compra y descarga software licenciado</li>
						<li>Únete a la Comunidad de evaluación</li>
						<li>Chatea con tus amigos</li>
						<li>Asegúrate de la compatibilidad con tu sistema</li>
						<li>Ten tu propio software evaluado</li>
						<li>Recibe actualizaciones automáticas</li>
					</ul>
				</div>
			</div>
		</div>
			</div>
		</div>
	</div>		
</body>
</html>