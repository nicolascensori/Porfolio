package main;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import clases.Empleado;
import clases.EscritorEmpleado;

public class Main {

	public static void main(String[] args) {
		List<Empleado> listaEmpleados = new ArrayList<Empleado>();
		List<Empleado> empleadoLeido = new ArrayList<Empleado>();

		listaEmpleados.add(new Empleado("Pedro", "Gomez", 424234, 43324567));
		listaEmpleados.add(new Empleado("Juan", "Gutierrez", 678678, 87679998));
		listaEmpleados.add(new Empleado("Florencio", "Roldan", 222323, 33233233));
		
		EscritorEmpleado escritor = new EscritorEmpleado(listaEmpleados);
		
		try {
			empleadoLeido = escritor.leerEmpleado("empleados.csv");
			System.out.println(empleadoLeido);
			
		} catch (IOException e) {
			
			e.printStackTrace();
		}
		
	}
}
