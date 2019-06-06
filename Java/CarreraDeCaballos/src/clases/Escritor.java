package clases;

import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.List;

public class Escritor {

	public void escribir (List<Caballo> listaLlegada) {
		PrintWriter out = null;		
		
		try {
			out = new PrintWriter (new FileWriter ("llegada.txt"));
			
			for (Caballo caballo : listaLlegada) {
				out.println(caballo);
			}
		}catch(IOException e){
			e.printStackTrace();
		}finally {
			if(out != null)
				out.close();
		}
	}
}
