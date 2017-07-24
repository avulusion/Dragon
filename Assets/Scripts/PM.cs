﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PM : MonoBehaviour {
	
	public GameObject aviso;
	public float sl;
	EarthLife shiel;
	public Text txt;
	int soma = 11;
	bool controle;
	public Score score;
	public float startYPosition;
	public RectTransform pl;

	void Start(){
		startYPosition = transform.position.y;
		shiel = FindObjectOfType<EarthLife> ();
		controle = false;
}
	void Update(){

		pl.sizeDelta = new Vector2 (sl, 30f);
		if (sl<=0) {
			Cursor.lockState = CursorLockMode.None;
			SceneManager.LoadScene (7);
		}
	}

	void OnTriggerEnter(Collider coll){
		controle = false;
		if (coll.gameObject.tag=="NaoSai") {
			aviso.SetActive (false);
			soma = 11;
			Debug.Log ("dentro");
		}
		if (coll.gameObject.tag=="ShotEM") {
			sl -= 41;
			Destroy (coll.gameObject);
		}
	}
	void OnTriggerExit(Collider coll){
		controle = true;
		if (coll.gameObject.tag == "NaoSai") {
			aviso.SetActive (true);
			StartCoroutine (cont ());
		}
	}

	void OnControllerColliderHit(ControllerColliderHit coll){
		if (coll.gameObject.tag=="Obstaculo") {
			sl -= 125;
		}

		if (coll.gameObject.tag=="Inimigo") {
			sl -= 41;
			Destroy (coll.gameObject);

		}

		if (coll.gameObject.tag=="Shield") {
			Destroy (coll.gameObject);
			shiel.sl += 21;
			}
		if (coll.gameObject.tag=="Boss") {
			sl -= 80;
		}

	}


	IEnumerator cont(){
		while (controle) {
			yield return new WaitForSeconds (1);
			soma-= 1;
			txt.text = "Você está se distanciando do seu objetivo, retorne em até: " + soma + " " + "segundos";
			Debug.Log (soma);
		if (soma <= 0f) {
				SceneManager.LoadScene (7);			
			}
		}
	}

	void LateUpdate() {
		Vector3 v = transform.position;
		v.y = startYPosition;
		transform.position = v;
	}
}

