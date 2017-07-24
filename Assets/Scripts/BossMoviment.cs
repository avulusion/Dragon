﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BossMoviment : MonoBehaviour {

	public Transform segue;
	Rigidbody inimigo;
	public GameObject tiro;
	public float speed;
	float time;
	public float vidaBoss;
	PM life;
	public float danoNoPlayer;
	public static bool go;


	// Use this for initialization
	void Start () {
		go = false;
		life = FindObjectOfType<PM> ();
		inimigo = GetComponent<Rigidbody> ();
		segue = GameObject.FindGameObjectWithTag ("Earth").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.timeScale==1) {
			transform.LookAt (segue.position);
			inimigo.MovePosition (inimigo.position + transform.forward * speed);
			time += Time.deltaTime;
			if (time >= 3) {
				Instantiate (tiro, transform.position, transform.rotation);
				time = 0;
			}
		}
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag=="Player") {
			segue = GameObject.FindGameObjectWithTag ("Player").transform;
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

	}

	void OnTriggerExit(Collider coll){
		if (coll.gameObject.tag=="Player") {
			segue = GameObject.FindGameObjectWithTag ("Earth").transform;
		}
	}


	void OnDestroy(){
		go = true;
	}
}
