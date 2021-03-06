﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentidoAranha : MonoBehaviour {
	public GameObject text;


	// Use this for initialization
	void Start () {
		text.SetActive (false);
		StartCoroutine (time ());

	}
	
	// campo para identificar inimigos ou asteroides se aproximando do planeta
	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag=="Inimigo") {
			text.SetActive (true);
		}
		if (coll.gameObject.tag=="Obstaculo") {
			text.SetActive (true);
		}
	}
	IEnumerator time(){
		while(text){
			yield return new WaitForSeconds (3);
			text.SetActive (false);

		}
	}
}
