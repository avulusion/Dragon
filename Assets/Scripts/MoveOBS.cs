﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveOBS : MonoBehaviour {
	public Rigidbody obs;
	public float speed;
	public int vidas = 3;
	public int random,randon;	
	public GameObject shield;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		
	}
	void Update(){
		obs.MovePosition (obs.position + transform.forward * speed);	
	}
	void OnCollisionEnter (Collision coll){

		if (coll.gameObject.tag=="Shot") {
			perdervida (1);
			Destroy(coll.gameObject);
		}
		if (coll.gameObject.tag=="Obstaculo") {
			perdervida (3);
			Destroy (coll.gameObject);
		}
	}
	public void perdervida(int dano){
		vidas = vidas - dano; 
		if (vidas<=0) {
			int x = Random.Range (random, randon);
			if (x==1) {
				Instantiate (shield, transform.position, transform.rotation);
			}
			Instantiate(explosion, transform.position, transform.rotation);

			Destroy (gameObject);
		}
	}

}
