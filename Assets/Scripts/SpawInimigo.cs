using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawInimigo : MonoBehaviour {
	
	public GameObject obj,bonus;
    public Transform um,um1,dois,dois2,tres,tres3,quatro,quatro4;
	public static float minTime , maxTime ;
	public bool status;
	 int PosiX,sorte,x ;

	 Vector3[] position=new Vector3[4];
	// Use this for initialization
	void Start () {
	    x = PlayerPrefs.GetInt ("Sorte");
		status = true;
		StartCoroutine (Spawn ());
		minTime = 2;
		maxTime = 8;
	}
	void Update(){
	}
	// Update is called once per frame
	IEnumerator Spawn() {
		while (true) 
		{
			position [0] = new Vector3 (Random.Range (um.position.x, um1.position.x), -3.5f, um.position.z);
			position [1] = new Vector3 (Random.Range (dois.position.x, dois2.position.x), -3.5f,dois.position.z);
			position [2] = new Vector3 ( tres.position.x, -3.5f,(Random.Range (tres.position.z, tres3.position.z)));
			position [3] = new Vector3 ( quatro.position.x, -3.5f,(Random.Range (tres.position.z, tres3.position.z)));

			yield return new WaitForSeconds (Random.Range (minTime, maxTime));
			if (status) {
				PosiX= Random.Range (0, 4);
				Debug.Log (PosiX);
				Instantiate (obj, position [PosiX], Quaternion.identity);

				if (Score.pontos > 0 && Score.pontos < 30) {
					sorte = Random.Range (0, 20 - x);
					if (sorte == 7) {
						Instantiate (bonus, position [PosiX], Quaternion.identity);
					}
				}
				if (Score.pontos > 200 && Score.pontos < 250) {
					sorte = Random.Range (0, 18 - x);
					if (sorte == 7) {
						Instantiate (bonus, position [PosiX], Quaternion.identity);
					}
				}
				if (Score.pontos > 500 && Score.pontos < 520) {
					sorte = Random.Range (0, 16 - x);
					if (sorte == 7) {
						Instantiate (bonus, position [PosiX], Quaternion.identity);
					}
				}
				if (Score.pontos > 700 && Score.pontos < 1000) {
					sorte = Random.Range (0, 10 - x);
					if (sorte == 7) {
						Instantiate (bonus, position [PosiX], Quaternion.identity);
					}
				}

				}
			}
		}
	


	public void MudarEstadoDoSpawn()
	{
		status = !status;
	}
}
