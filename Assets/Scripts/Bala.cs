using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {

	public Vector2 velocity = new Vector2 (5, 0);
	public GameObject particulas;


	// Use this for initialization
	void OnCollisionEnter2D(Collision2D target){
				onDestroy ();
		}

	void onDestroy(){
				var clone = Instantiate (particulas, transform.position, Quaternion.identity)
			as GameObject;
				Destroy (clone, 1);
				Destroy (gameObject);
		}
}
