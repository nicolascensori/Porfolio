<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<h1>Employees List</h1>
<table border="2" width="70%" cellpadding="2">
	<tr>
		<th>Id</th>
		<th>Nombre</th>
		<th>Clave</th>
		<th>Email</th>
		<th>Bloqueado</th>
		<th>Admin</th>
		<th>Edit</th>
		<th>Delete</th>
	</tr>
	<c:forEach var="usr" items="${list}">
		<tr>
			<td>${usr.id}</td>
			<td>${usr.nombre}</td>
			<td>${usr.clave}</td>
			<td>${usr.email}</td>
			<td>${usr.isBloqueado}</td>
			<td>${usr.isAdmin}</td>
			<td><a href="editemp/${usr.id}">Edit</a></td>
			<td><a href="deleteemp/${usr.id}">Delete</a></td>
		</tr>
	</c:forEach>
</table>
<br />
<a href="empform">Add New Employee</a>