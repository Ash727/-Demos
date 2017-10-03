using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour {

	public PlayerController player;
	public Image thehealthbar;
	float thex;
	float thez;
	float ratio;
	public Text Life;
	// Use this for initialization
	void Start () {
		
		 thex =	thehealthbar.rectTransform.localScale.x;
		 ratio= thehealthbar.rectTransform.localScale.y;
		thez = thehealthbar.rectTransform.localScale.z;
	}
	
	// Update is called once per frame
	void Update () {
		//updtehealth ();

	}

	public void updtehealth (){



		 ratio =player.Health/250f;
	//	int life
		thehealthbar.rectTransform.localScale=new Vector3(thex,ratio,thez); // updating the health bar 

		if (ratio < 0.5) {
			Life.color = Color.red;
		
		}

	}




}
