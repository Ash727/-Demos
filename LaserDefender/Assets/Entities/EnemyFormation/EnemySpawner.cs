using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width =10f;
	public float height=4f;
	private bool movingRight=true;
	public float speed=5f;
	private float xmax;
	private float xmin;
	public float spawnDeley=0.5f;// number of seconds in the delay
	public static int numberofenimes=0;
	// Use this for initialization
	void Start () {
		// So we can automatically pearnt an enemy in the formation/spawner we make it a game object
		// Instantiate the game object pearent the transform
		//GameObject enemy = Instantiate (enemyPrefab, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
		//enemy.transform.parent = transform;
		float distance_tocamera = transform.position.z - Camera.main.transform.position.z;

		Vector3 leftboundary=	Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance_tocamera));
		Vector3 rightBoundary=	Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance_tocamera));
		xmax = rightBoundary.x;
		xmin = leftboundary.x;


		/*(/
		//for each transform child(initiating in the stament) in this object transform
		foreach( Transform child in this.transform){// loop over every child this object has have
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;// after creating an enmy ie instantiating it we parent it to that currnet child of this class

		}/*/

		SpawnUntilFull ();

	}

	public void OnDrawGizmos(){

		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height, 0));

	}

	// Update is called once per frame
	void Update () {
		//bool breakable=( this.tag=="Breakable");

		if (movingRight) {
		
		

			transform.position += new Vector3 (speed * Time.deltaTime, 0.0f, 0.0f);

		
		} else {
		
			transform.position +=  new Vector3 (-speed * Time.deltaTime, 0.0f, 0.0f);
		
		}


		float rightEdgeOfFormation = transform.position.x + (0.5f * width);

		float leftEdgeOfFormation = transform.position.x - (0.5f * width);

		if (leftEdgeOfFormation < xmin ) {
			
			movingRight =true;

		} else if ( rightEdgeOfFormation > xmax) {
		
			movingRight= false;
		
		}

		if (AllMemebersDead ()) {
		
			Debug.Log ("Empty Formation");
			//SpawnEnemies ();
		
			SpawnUntilFull ();
		}






	}

	void SpawnUntilFull(){
		Transform freePosition = NextFreePosition ();
	
		if(freePosition){
			//omstamtoate the enemy prefab as a gameobject
			GameObject enemy = Instantiate (enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
		enemy.transform.parent = freePosition;// after creating an enmy ie instantiating it we parent it to that currnet child of this class

			numberofenimes++;
		}

		if (NextFreePosition ()) {
			Invoke ("SpawnUntilFull", spawnDeley);
		
		}

	}

	Transform NextFreePosition(){
		foreach (Transform childPositioninGameObject in transform) {

			if(childPositioninGameObject.childCount==0) {

				return childPositioninGameObject;
			}
		}

		{return null;}



	}

	void SpawnEnemies(){

		foreach( Transform child in this.transform){// loop over every child this object has have
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;// after creating an enmy ie instantiating it we parent it to that currnet child of this class

		}
	}


	bool AllMemebersDead(){
		//transform.childCount
		foreach (Transform childPositioninGameObject in transform) {
		
			if(childPositioninGameObject.childCount>0) {

				return false;
			}
		}
	
		{return true;}


	}

}
