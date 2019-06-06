package clases;

import java.util.Random;

public class Caballo implements Comparable<Caballo>{
	private String nombre;
	private int velMin;
	private int velMax;
	private int velReal;
	
	public Caballo() {
		
	}
	public Caballo(String nombre, int velMin, int velMax) {
		this.nombre = nombre;
		this.velMin = velMin;
		this.velMax = velMax;
		this.velReal = new Random().nextInt((velMax - velMin)+1)+velMin;
	}
	public String getNombre() {
		return nombre;
	}
	public void setNombre(String nombre) {
		this.nombre = nombre;
	}
	public int getVelMin() {
		return velMin;
	}
	public void setVelMin(int velMin) {
		this.velMin = velMin;
	}
	public int getVelMax() {
		return velMax;
	}
	public void setVelMax(int velMax) {
		this.velMax = velMax;
	}
	public int getVelReal() {
		this.setVelReal(new Random().nextInt((velMax - velMin)+1)+velMin);
		return velReal;
	}
	public void setVelReal(int velReal) {
		this.velReal = velReal;
	}
	@Override
	public String toString() {
		
		return getNombre(); 
	}
	@Override
	public int compareTo(Caballo otroCaballo) {
		
		return nombre.compareTo(otroCaballo.getNombre());
	}
}
