package clases;

public class Empleado {
	private String nombre;
	private String apellido;
	private int legajo;
	private int telefono;
	
	public Empleado() {
	}
	
	public Empleado(String nombre, String apellido, int legajo, int telefono) {

		this.nombre = nombre;
		this.apellido = apellido;
		this.legajo = legajo;
		this.telefono = telefono;
	}

	public String getNombre() {
		return nombre;
	}

	public void setNombre(String nombre) {
		this.nombre = nombre;
	}

	public String getApellido() {
		return apellido;
	}

	public void setApellido(String apellido) {
		this.apellido = apellido;
	}

	public int getLegajo() {
		return legajo;
	}

	public void setLegajo(int legajo) {
		this.legajo = legajo;
	}

	public int getTelefono() {
		return telefono;
	}

	public void setTelefono(int telefono) {
		this.telefono = telefono;
	}

	@Override
	public String toString() {
		
		return getNombre()+","+getApellido()+","+getLegajo()+","+getTelefono();
	}
}
