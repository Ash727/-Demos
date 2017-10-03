using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Vector3 ShipPoistion;
	public float Speed=15.0f;
	public float padding = 1f;
	float fireposition=0f;
	public GameObject Projectile;
	public float projectileSpeed;
	public float FiringRate=0.2f;
	float xmin;
	float xmax;
	public float Health =250f;
	public AudioClip fireSound;
	public AudioClip playerDeath;
	private	LevelManager levelMove ;
	public Health Healthbar;
	// Use this for initialization
	void Start () {

		float distance_ofship_tocamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint ( new Vector3 (0,0,distance_ofship_tocamera)); 
		Vector3 RighttMost = Camera.main.ViewportToWorldPoint ( new Vector3 (1,0,distance_ofship_tocamera)); 

		xmin = leftMost.x+padding;
		xmax = RighttMost.x-padding;

		levelMove =GameObject.Find("LevelManager").GetComponent<LevelManager>();

	}

	void Fire(){

		Vector3 offset = new Vector3 (0, 1, 0);

		//Instantiate the prefab
		GameObject LasterBeam =Instantiate (Projectile, transform.position+offset, Quaternion.identity) as GameObject;
		// Move the projectile forward
		LasterBeam.GetComponent<Rigidbody2D>().velocity = new Vector2 (0f,projectileSpeed);
		//Play the sound at the position 
		AudioSource.PlayClipAtPoint (fireSound, transform.position);

		//gameObject.GetComponent<AudioSource> ().PlayOneShot (fireSound);
	}


	// Update is called once per frame
	void Update () {

		//=============================================Player========================================================
		// Moving Left
		if (Input.GetKey (KeyCode.LeftArrow)) {

			gameObject.transform.position+= new Vector3 (-Speed*Time.deltaTime,0.0f,0.0f);
			//gameObject.transform.Translate (-Speed,0.0f,0.0f);

			// or
			//			gameObject.transform.Translate (-0.4f,0.0f,0.0f);
		}
		else
		if (Input.GetKey (KeyCode.RightArrow)){

		//	gameObject.transform.Translate (new Vector3 (0.4f,0.0f,0.0f));

				gameObject.transform.Translate (Speed*Time.deltaTime,0.0f,0.0f);


		}

//Restric the player to the game space 
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax); // will clamp the value to a certain point

		//Fixing the value to that clamp position either min or max at extreeme 
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);



		//=================================================Player Movement==============================



		//==================================================Player Fireing=================================

		if (Input.GetKeyDown (KeyCode.Space)) {
		//	Fire ();
			InvokeRepeating ("Fire", 0.00010f, FiringRate);
	//				Invoke
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
		
			CancelInvoke ("Fire");
		}

	

		
	}

	//==================================================Player Fireing=================================

	void OnCollisionEnter2D (Collision2D collision){

		print ("Enemy hit");

		//Destroy (collision.gameObject);

		// Prjectile a class that we made 
		Projectile missle = collision.gameObject.GetComponent<Projectile> ();// Get the projectil 

		if (missle) {

			Debug.Log (" Player Hit By a missle");
			Health -= missle.GetDamage ();

			missle.Hit ();
			Healthbar.updtehealth ();
			if (Health <= 0) {


				Die ();


			}

		}


	}

	void Die (){

		AudioSource.PlayClipAtPoint (playerDeath, transform.position);
		Destroy (gameObject);
		levelMove.LoadLevel ("Win Screen");


	}




}
