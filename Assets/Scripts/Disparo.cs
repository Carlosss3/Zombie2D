﻿using UnityEngine;
using System.Collections;

public class Disparo : MonoBehaviour {

	public GameObject bala;
	public Transform puntoDisparo;

	public void Fire(){
		if(bala != null){
			var clone = Instantiate(bala,puntoDisparo.position, Quaternion.identity) as GameObject;
			clone.transform.localScale = transform.localScale;
} else {
			Debug.Log ("El jugador no tiene balas");
	}
}
}
