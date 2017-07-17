﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PM : MonoBehaviour {
	
	public GameObject aviso;
	public Slider sl,shield;
	EarthLife shiel;
	public Text txt;
	int soma=11;
	bool controle;
	public Score score;

	void Start(){
		shiel = FindObjectOfType<EarthLife> ();
		controle = false;
}
	// Update is called once per frame
	void OnTriggerEnter(Collider coll){
		controle = false;
		if (coll.gameObject.tag=="NaoSai") {
			aviso.SetActive (false);
			soma = 11;
			Debug.Log ("dentro");
		}
	}
	void OnTriggerExit(Collider coll){
		controle = true;
		if (coll.gameObject.tag == "NaoSai") {
			print ("fora");
			aviso.SetActive (true);
			StartCoroutine (cont ());
		}
	}

	void OnControllerColliderHit(ControllerColliderHit coll){
		if (coll.gameObject.tag=="Obstaculo") {
			sl.value -= 0.5f;
		}


		if (coll.gameObject.tag=="Inimigo") {
			sl.value -= 0.2f;
			Destroy (coll.gameObject);

		}
		if (coll.gameObject.tag=="ShotEM") {
			sl.value -= 0.2f;
			Destroy (coll.gameObject);


		}
		if (coll.gameObject.tag=="Shield") {
			Destroy (coll.gameObject);
			shiel.sl.value += 0.5f;
			}
		if (coll.gameObject.tag=="Boss") {
			sl.value -= 0.5f;
		}
		if (sl.value==0) {
			Cursor.lockState = CursorLockMode.None;
			SceneManager.LoadScene (7);
		}
	}


	IEnumerator cont(){
		while (controle) {
			yield return new WaitForSeconds (1);
			soma-= 1;
			txt.text = "Você está se distanciando do seu objetivo, retorne em até: " + soma + "s";
			Debug.Log (soma);
		
			if (soma <= 0f) {
				SceneManager.LoadScene (7);			}
		}
	}

}

