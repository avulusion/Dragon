﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class audio : MonoBehaviour {
	public AudioSource som; 
	public GameObject canva,show,slider;
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
		if (SceneManager.GetActiveScene().name=="Opçoes") {
			slider.SetActive (true);
		} else {
			slider.SetActive (false);
		}
		if (SceneManager.GetActiveScene().name=="Game") {
			som.Pause ();
			show.SetActive (false);
		}
		if (SceneManager.GetActiveScene().name=="Arcade") {
			som.Pause ();
			show.SetActive (false);
		}
		if (SceneManager.GetActiveScene().name=="Over") {
			Debug.Log ("pqqq");
			show.SetActive (true);
			som.Play ();
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


