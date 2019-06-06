package clases;

import java.util.List;

public class CorrerRunnable implements Runnable{

	private int distancia = 1000;
	private Caballo caballo = null;
	private List<Caballo> listaLlegada = null;
	
	public CorrerRunnable(Caballo caballo, List<Caballo> listaLlegada) {
		this.caballo = caballo;
		this.listaLlegada = listaLlegada;
	}

	@Override
	public void run() {
		
		int distCorrida = 0;
		
		while (distCorrida < distancia)
		{
			distCorrida += caballo.getVelReal();
			try {
				Thread.sleep(50);
			}catch(InterruptedException e){
				e.printStackTrace();
			}
		}
		System.out.println(caballo.getNombre()+" llegó");
		
		synchronized (this) {
			listaLlegada.add(caballo);
		}
		
	}

}
