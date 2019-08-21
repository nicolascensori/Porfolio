package com.javatpoint.beans;  
  
public class Usuario {  
	int id;
	String nombre;
	String clave;
	String email;
	Boolean isBloqueado;
	Boolean isAdmin;
	
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public String getNombre() {
		return nombre;
	}
	public void setNombre(String nombre) {
		this.nombre = nombre;
	}
	public String getClave() {
		return clave;
	}
	public void setClave(String clave) {
		this.clave = clave;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public Boolean getIsBloqueado() {
		return isBloqueado;
	}
	public void setIsBloqueado(Boolean isBloqueado) {
		this.isBloqueado = isBloqueado;
	}
	public Boolean getIsAdmin() {
		return isAdmin;
	}
	public void setIsAdmin(Boolean isAdmin) {
		this.isAdmin = isAdmin;
	}
}  