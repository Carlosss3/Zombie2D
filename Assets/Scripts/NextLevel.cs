using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	// Use this for initialization

		public string nombreNivel;
	public float tiempoEspera = 3.0f;
		bool cargando = false;

		void OnTriggerStay2D(Collider2D AvatarTarget){
			if(AvatarTarget.transform.tag == "Player"){
				//Application.LoadLevel(nombreNivel);
			if(!cargando)
				StartCoroutine(cargaNivel());
		}

	
	}
	
	void OnTriggerExit2D(Collider2D target){
				cargando = false;
		}

	IEnumerator cargaNivel(){			//Para parar la funcion a la que voy a llamar.
				cargando = true;
				yield return new WaitForSeconds (tiempoEspera);
				if (cargando)
						Application.LoadLevel (nombreNivel);
		}
}
