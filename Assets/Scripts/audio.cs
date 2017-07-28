﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class audio : MonoBehaviour {
	public AudioSource som; 
	public GameObject canva,slider;
	public Slider sl;
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (canva);
		som= GetComponent<AudioSource> ();
		if (SceneManager.GetActiveScene ().name == "pregame") {
			Score.pontos = 0;
			SceneManager.LoadScene ("Play");	
		}

	}
	
	// Update is called once per frame
	void Update () {
		AudioListener.volume = sl.value;
		switch (SceneManager.GetActiveScene ().name) {
		case"Over":
			som.UnPause ();
			break;
		case"Game":
			som.Pause ();
			break;
		case"Terra":
			som.Pause ();
			break;
		case"Mercurio":
			som.Pause ();
			break;
		case"Venus":
			som.Pause ();
			break;
		case"Urano":
			som.Pause ();
			break;
		case"Marte":
			som.Pause ();
			break;
		case"Júpiter":
			som.Pause ();
			break;
		case"Plutão":
			som.Pause ();
			break;
		case"Saturno":
			som.Pause ();
			break;
		case"Netuno":
			som.Pause ();
			break;
		case"Twin":
			som.UnPause ();
			break;
		case"PLay":
			som.UnPause ();
			break;
		}



		if (SceneManager.GetActiveScene().name=="Opçoes") {
			slider.SetActive (true);
		} else {
			slider.SetActive (false);
		}


	

	}
	public void onClick()
	{
		
		if (som.isPlaying) {
			som.Pause ();
		} else
		{
			som.Play ();
		}
	}
	}


