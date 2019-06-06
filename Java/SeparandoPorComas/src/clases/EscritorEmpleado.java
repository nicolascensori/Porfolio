package clases;
import java.io.*;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.*;

public class EscritorEmpleado {

	public EscritorEmpleado(List<Empleado> listaEmpleado) {
		try {
			escribirEmpleado("empleados.csv", listaEmpleado);
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	public void escribirEmpleado (String path, List<Empleado> listaEmpleado) throws IOException
	{
		PrintWriter out = new PrintWriter (new FileWriter(path));
		
		try {
			for (Empleado empleado : listaEmpleado) {
				out.println(empleado);
								
			}
		}finally {
			if(out != null)
				out.close();
		}
	}
	public List<Empleado> leerEmpleado (String path) throws IOException
	{
		List<Empleado> listaEmpleados = new ArrayList<Empleado>();
		BufferedReader in = new BufferedReader (new FileReader(path));
		String linea;
	
		
		try {
			while((linea = in.readLine()) != null) {
				
				listaEmpleados.add(crearEmpleado(linea));
			}
		}finally {
			if (in != null)
				in.close();
		}
		return listaEmpleados;
		
	}
	
	public Empleado crearEmpleado(String linea)
	{
		String[] arregloCrear;
		arregloCrear = linea.split(",");
		Empleado emp = new Empleado(arregloCrear[0], arregloCrear[1], Integer.parseInt(arregloCrear[2]), Integer.parseInt(arregloCrear[3]));
		return emp;
	}	
}
