using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	public string nombreNivel;

	public void salir(){
		Application.Quit ();
	}

	public void jugar(){
		Application.LoadLevel (nombreNivel);
	}
}
