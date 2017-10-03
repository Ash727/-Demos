using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D col) {// on trigger must  be clicked 
		//Grabbing the collied object and destrying it 
		Destroy(col.gameObject);

	}


}
