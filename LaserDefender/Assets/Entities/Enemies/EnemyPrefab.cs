using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefab : MonoBehaviour {

	public float Health=150f; 
	public GameObject EnemeyLaster;
	public float ProjectileSpeed = 10;
	public float shotsPerSeconds=0.5f;
	public Score theScore;
	public int ScoreValue = 100;
	private Score scorekeeper;
	public AudioClip EnemyFire;
	public AudioClip Enemey_death_sound;
	void Start(){
		//Getting hold of somthing dynamically
		//Returns a object with the score script
		scorekeeper=GameObject.Find ("Score").GetComponent<Score>();

	}


	void Update() {

		float probiability = Time.deltaTime * shotsPerSeconds;
		// When we fare at a random tie
		if (Random.value < probiability) {
			Fire ();
		}

	
	}



	void Fire(){


		Vector3 startPosiion = transform.position + new Vector3 (0f,-1,0f );
		GameObject enemeyLaster = Instantiate (EnemeyLaster,startPosiion,Quaternion.identity) as GameObject;

		enemeyLaster.GetComponent<Rigidbody2D> ().velocity += new Vector2 (0, -ProjectileSpeed);

		AudioSource.PlayClipAtPoint (EnemyFire, this.transform.position);
	}

	void OnCollisionEnter2D (Collision2D collision){

		print ("Enemy hit");

		//Destroy (collision.gameObject);

		// Prjectile a class that we made 
		Projectile missle = collision.gameObject.GetComponent<Projectile> ();// Get the projectil 

		if (missle) {
		
			Debug.Log ("Hit By a projectile");
			Health -= missle.GetDamage ();
			missle.Hit ();
			if (Health <= 0) {
				Die ();
			}

		}


	}



	void Die(){
		Destroy (gameObject);
		AudioSource.PlayClipAtPoint (Enemey_death_sound, transform.position);
		//EnemySpawner.numberofenimes--;
		//	theScore.AddScore (5);
		scorekeeper.AddScore (ScoreValue);

	}

}
