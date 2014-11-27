using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {
	
	public Vector2 velocity = new Vector2(5,0);
	public GameObject particulas;
	//public GameObject blood;
	//public int damage = 5;
	// Use this for initialization
	void Start () {
		//rigidbody2D.velocity = velocity * transform.localScale.x;
		rigidbody2D.AddForce (velocity* transform.localScale.x, ForceMode2D.Impulse);
		Invoke ("onDestroy", 1f);
	}
	
	
	
	
	
	
	void onDestroy(){				
		var clone = Instantiate(particulas,transform.position,Quaternion.identity) as GameObject;
		clone.transform.parent = null;
		clone.particleSystem.startColor = Color.grey;
		//clone.particleSystem.startColor = color ?? Color.grey;
		Destroy(clone,1);
		Destroy(gameObject);
	}
	
}