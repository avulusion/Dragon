﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
public class Loading : MonoBehaviour {
	 string proximacena;
	public float time = 5;
	public enum carregando {Carregamento,TempoFixo};
	public carregando load;
	public Text txt;
	int progresso;
	public RectTransform barraDois;
	string texto;
	// Use this for initialization
	void Start () {

		if (PlayerPrefs.GetInt ("Survival") == 1) {
			proximacena = "Game";
			Debug.Log ("ue2");
		} else {
			Debug.Log ("ue");
			proximacena = EscolhaPL.scene;
		}
		switch (load) {
		case carregando.Carregamento:
			StartCoroutine (cena (proximacena));
			break;
		case carregando.TempoFixo:
			StartCoroutine (tempofixo (proximacena));
			break;
		}

	}
	IEnumerator cena(string cena){
		AsyncOperation carregar = SceneManager.LoadSceneAsync (cena);

		while (!carregar.isDone) {
			progresso =(int) (carregar.progress * 100.0f);
			yield return null;
		}
	}
	IEnumerator tempofixo(string cena){
		yield return new WaitForSeconds (time);
		SceneManager.LoadScene (cena);
	}
	// Update is called once per frame
	void Update () {
		//barraDois.right = progresso * 100.0f;
		switch (load) {
		case carregando.Carregamento:
			break;
		case carregando.TempoFixo:
			progresso = (int)(Mathf.Clamp((Time.time / time),0.0f,1.0f) * 100.0f);
			break;
		}
		txt.text = texto + "" + progresso + "%";
		print (progresso);
		barraDois.offsetMin = new Vector2 (progresso,barraDois.offsetMin.y);
	}
}
