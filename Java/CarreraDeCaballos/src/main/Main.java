package main;

import java.util.*;
import clases.Caballo;
import clases.CorrerRunnable;
import clases.Escritor;

public class Main {

	public static void main(String[] args) {
		
		List<Caballo> listaCaballos = new ArrayList<Caballo>();
		List<Caballo> listaLlegada = new ArrayList<Caballo>();
		Thread[] hilos = new Thread [5];
		Escritor escritor = new Escritor();
		
		listaCaballos.add(new Caballo("Centella", 11, 14));
		listaCaballos.add(new Caballo("Tornado", 6, 24));
		listaCaballos.add(new Caballo("Suspiro", 12, 13));
		listaCaballos.add(new Caballo("Relámpago", 10, 21));
		listaCaballos.add(new Caballo("Pegaso", 7, 22));
		
		listaCaballos.sort(null);
		System.out.println("Listado de caballos");
		System.out.println(listaCaballos);
		System.out.println();
		System.out.println("Orden de llegada: ");
		
		for (int i = 0 ; i < 5 ; i++)
		{
			hilos[i] = new Thread (new CorrerRunnable(listaCaballos.get(i), listaLlegada));
		}
		for (int i = 0 ; i < 5 ; i++)
		{
			hilos[i].start();
		}
		for (int i = 0 ; i < 5 ; i++)
		{
			try {
				hilos[i].join();
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
		}
			escritor.escribir(listaLlegada);
		
	}
}
