using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {

	public Vector2 velocity = new Vector2 (5,0);

	// Use this for initialization
	void Start () {

		rigidbody2D.velocity = velocity * transform.localScale.x
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
