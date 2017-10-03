using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {


	public Text TheScore;
public static	int thecurrnetPoints=0;
	public Text Mytext;
	// Use this for initialization
	void Awake () {
	//	TheScore.text = thecurrnetPoints.ToString ();
		Mytext.text=GetComponent<Text>().text;
		Reset ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.R)) {
		
			Reset ();
		}

		// always updating the score
		//TheScore.text= Mytext.ToString ();


	}


public	 void AddScore (int points){

		thecurrnetPoints += points;
        
		//TheScore.text=thecurrnetPoints.ToString ();
		Mytext.text=thecurrnetPoints.ToString ();
	}


	public static void Reset () {
		int points = 0;

	
	

	}

}
