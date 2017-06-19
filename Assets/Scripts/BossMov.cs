﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BossMov : MonoBehaviour {

	public Vector3 pl;
	Rigidbody inimigo;
	public GameObject tiro;
	public float speed;
	bool test;
	float time;
	public float vidaBoss;
	PM life;
	public float danoNoPlayer;


	// Use this for initialization
	void Start () {
		life = FindObjectOfType<PM> ();
		inimigo = GetComponent<Rigidbody> ();
		pl = GameObject.FindGameObjectWithTag ("Earth").transform.position;
		test = false;		
	}
	
	// Update is called once per frame
	void Update () {
		

		transform.LookAt (pl);

		inimigo.MovePosition(inimigo.position + transform.forward * speed);
	          time += Time.deltaTime;
			if (time>=5) {
				GameObject g = Instantiate (tiro, transform.position, Quaternion.identity) as GameObject;
				g.transform.LookAt (pl);
				time = 0;


		}		
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag=="Player") {
			pl = GameObject.FindGameObjectWithTag ("Player").transform.position;



		}
	}

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag=="Shot") {
			Destroy (coll.gameObject);
			vidaBoss --;
		if (vidaBoss == 0) {
				Destroy (gameObject);
			}
		}
		if (coll.gameObject.tag=="Player") {
			life.sl.value -= danoNoPlayer;

		}
	}
	void OnTriggerExit(Collider coll){
		if (coll.gameObject.tag=="Player") {
			pl = GameObject.FindGameObjectWithTag ("Earth").transform.position;
		}
	}
}
