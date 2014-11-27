using UnityEngine;
using System.Collections;

public class teleport : MonoBehaviour {
	
	public Transform punto1;
	public float tiempoEspera = 0.0f; // Tiempo que el Player tiene que estar para cargar
	bool cargando = false; // Controla si el player esta dentro del trigger
	
	
	
	void OnDrawGizmosSelected() {
		if (punto1 != null) {
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(transform.position,  punto1.position);
		}
	}
	
	
	void OnTriggerStay2D(Collider2D target){
		
		if (target.transform.tag == "Player") {
			Debug.Log("Entrando");
			if(!cargando) // Si no esta cargando empezamos la cuenta atras
				StartCoroutine(cargaSalto(target));
			
		}
	}
	
	//Si salimos del trigger cortamos la carga
	void OnTriggerExit2D(Collider2D target){
		cargando = false;
	}
	
	// Ejecutamos esto cuando entramos en el trigger
	IEnumerator cargaSalto(Collider2D target) {
		cargando = true;
		Debug.Log("Before Waiting 2 seconds");
		yield return new WaitForSeconds(tiempoEspera); // Esperamos el tiempo definido
		if(cargando) // Si sigue en el trigger cargamos la escena
			target.transform.position = punto1.position;
	}
}