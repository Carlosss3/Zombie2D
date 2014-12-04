﻿using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {
	public GameObject zombie;
	public float spamTime = 5f;
	public int maxZombies = 10;
	
	
	public float nextZombie;
	private float zcount = 0;
	// Use this for initialization
	void Start () {
		nextZombie = spamTime;
	}
	
	// Update is called once per frame
	void Update () {
		if( (Time.time > nextZombie) && (zcount < maxZombies)){
			nextZombie = Time.time + spamTime;
			var clone = Instantiate (zombie, transform.position, Quaternion.identity) as GameObject;
			
			zcount++;
		}
	}
}