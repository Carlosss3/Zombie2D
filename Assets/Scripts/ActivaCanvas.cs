using UnityEngine;
using System.Collections;

public class ActivaCanvas : MonoBehaviour {

	public GameObject canvas;
	public bool estacerca = false;
	public bool muestratexto = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
				if (estacerca) {
						canvas.SetActive (true);
				}else {
						canvas.SetActive (false);

				}
		}

	void OnTriggerEnter2D(Collider2D col){
		if(col.transform.tag == "Player")
		estacerca = true;

	}

	void OnTriggerExit2D(Collider2D col){
		if(col.transform.tag == "Player")
		estacerca = false;

	}
}
