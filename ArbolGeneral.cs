using System;
using System.Collections.Generic;

namespace TP1
{
	public class ArbolGeneral<T>
	{
		
		private NodoGeneral<T> raiz;

		public ArbolGeneral(T dato) {
			this.raiz = new NodoGeneral<T>(dato);
		}
	
		private ArbolGeneral(NodoGeneral<T> nodo) {
			this.raiz = nodo;
		}
	
		private NodoGeneral<T> getRaiz() {
			return raiz;
		}
	
		public T getDatoRaiz() {
			return this.getRaiz().getDato();
		}
	
		public List<ArbolGeneral<T>> getHijos() {
			List<ArbolGeneral<T>> temp= new List<ArbolGeneral<T>>();
			foreach (var element in this.raiz.getHijos()) {
				temp.Add(new ArbolGeneral<T>(element));
			}
			return temp;
		}
	
		public void agregarHijo(ArbolGeneral<T> hijo) {
			this.raiz.getHijos().Add(hijo.getRaiz());
		}
	
		public void eliminarHijo(ArbolGeneral<T> hijo) {
			this.raiz.getHijos().Remove(hijo.getRaiz());
		}
	
		public bool esVacio() {
			return this.raiz == null;
		}
	
		public bool esHoja() {
			return this.raiz != null && this.getHijos().Count == 0;
		}
		
		// Ejercicio 4- A)   >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		public int altura() {
			int altura = 0;
			if(this.esHoja()){
				return 0;
			}
			else{
				foreach(ArbolGeneral<T> arbol in this.getHijos()){
					int contador = arbol.altura();
					if(contador > altura)
						altura = contador;
				}
				altura++;
			}
			return altura;
		}
		
		//Ejercicio 4- B)      >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		public int nivel(T dato) {
			int nivel = 0;
			if(this.getDatoRaiz().ToString() == dato.ToString())
				return 0;
			else{
				foreach(ArbolGeneral<T> arbol in this.getHijos()){
					int encontrado = arbol.nivel(dato);
					if(encontrado < 0)
						continue;
					if(encontrado >= 0)
						nivel = 1 + encontrado;
				}
				if(nivel == 0)
					nivel--;
			}
			return nivel;
		}
		
		// Ejercicio 4- C)       >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		
		public int ancho(){
			int ancho = 0;
			if(this.esHoja())
				return 0;
			else{
				int contador = 0;
				foreach(ArbolGeneral<T> arbol in this.getHijos()){
					arbol.ancho();
					contador++;
					if(contador >= ancho)
						ancho = contador;
				}
			}
			return ancho;
		}
	
	}
}
