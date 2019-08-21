<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@page import="com.sun.javafx.scene.layout.region.RepeatStruct"%>
<%@page import="com.sun.org.apache.xalan.internal.xsltc.dom.CurrentNodeListFilter"%>
<%@page import="org.apache.jasper.tagplugins.jstl.core.ForEach"%>
<%@page import="java.util.List"%>
<%@page import="org.apache.catalina.connector.Request"%>
<%@page language="java" contentType="text/html; charset=ISO-8859-1" pageEncoding="ISO-8859-1"%>
<%@ taglib prefix = "c" uri = "http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html>
<html>
<head>
<script src="//ajax.googleapis.com/ajax/libs/angularjs/1.7.0/angular.min.js"></script>
<meta charset="UTF-8">
<title>Confused Frogs</title>
	<link rel="stylesheet" href="<c:url value="/resources/theme1/css/stylesheet.css" />" />
</head>
<body class="body_home" data-ng-app>

	<div class="resppgcont">
		<div class="resppgtemp">
			<div class="header">
				<div class="topmenu">
					<div class="logo">
						<a href="homepg"> <img src="<c:url value="/resources/theme1/css/uprisen_frog.png" />" width="64" height="64"></a>
					</div>
					<div class="menuinidiv" data-tooltip-type="selector">
						<a class="menuini selectedpg" href="homepg"> HOME </a>
						<a class="menuini" href="tienda"> TIENDA </a>
						<a class="menuini" href="soporte"> SOPORTE</a>
						<a class="menuini" href="contacto"> CONTACTO</a>
					</div>
					<div class="loginstatus">
						<form:form action="loguearusuario" method="post">

							<span class="logged">Bienvenido, <%=session.getAttribute("nombre")%>
							</span>
							<button  class="newlogin">Cerrar Sesión</button>
						</form:form>

						<a href="editarusuario/<%=session.getAttribute("id")%>"><button class="newlogin" style="float: right; margin-left:50%;">Modificar usuario</button></a>
					</div>
				</div>
			</div>
			<div class="div_cont_horiz"></div>
				
			<div class="homepg_contenido">
					<table class="table_style" data-ng-show="<%=session.getAttribute("esAdmin")%>">
						<tr>
							<th>Nombre</th>
							<th>Email</th>
							<th>Clave</th>
							<th>Es administrador</th>
							<th style="width: 120px;">Desbloquear</th>
							<th style="width: 120px;">Bloquear</th>
							<th>Modificar</th>
						</tr>
						
						<c:forEach var="usr" items="${list}">
						<tr >				
							<td>${usr.nombre}</td>
							<td>${usr.email}</td>
							<td>${usr.clave}</td>
							<td>
								<c:if test="${usr.isAdmin == true}">Si</c:if>
								<c:if test="${usr.isAdmin == false}">No</c:if>
							</td>
							<td>
							<c:if test="${usr.isBloqueado == true}">
								<a href="desbloquearusuario/${usr.id}"><button class="btnverde" style="width:26px; height: 29px;" name="btnUnlcok" ></button></a>
							</c:if>
							</td>
							<td>
							<c:if test="${usr.isBloqueado != true}">
								<a href="bloquearusuario/${usr.id}"><button class="btnverde" style="width:26px; height: 29px;" name="btnUnlcok" ></button></a>
							</c:if>
							</td>

							<td>
								<a href="editarusuario/${usr.id}"><img src="<c:url value="/resources/theme1/css/icopencil.png" />"></a>
							</td>	
						</tr>
						</c:forEach>
						
					</table>
					<table class="table_style" data-ng-show="!<%=session.getAttribute("esAdmin")%>">
						<tr>
							<th>Nombre</th>
							<th>Email</th>
						<tr>				
							<td><%=session.getAttribute("nombre")%></td>
							<td><%=session.getAttribute("email")%></td>
						</tr>
					</table>
			</div>
			
			<div>
				
			</div>
	</div>
</div>
</body>
</html>