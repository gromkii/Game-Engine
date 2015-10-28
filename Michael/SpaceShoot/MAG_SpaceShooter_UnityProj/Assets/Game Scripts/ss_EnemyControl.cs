/*
 * Michael Anthony Gonzalez
 * Houston Community College
 * Fall 2015
 * MonoDevelop - Unity 5.1.2f1(64-bit))
This class will be an Added Component to Enemy GameObject for programming Player;'s control 
movement with the keyboard.
 */
using UnityEngine;
using System.Collections;

public class ss_EnemyControl : MonoBehaviour {

	public GameObject GO_Explosion; //This is our Explosion Prefab.

	float ss_speed; //for the enemy speed.

	// Use this for initialization
	void Start () {
	
		ss_speed = 2f; // set speed

	}
	
	// Update is called once per frame
	void Update () {
	
		//Get the enemy current position
		Vector2 position = transform.position;

		//Compute the enemy new postion. ( - ss_speed * Time.deltaTime)
		position = new Vector2 (position.x - ss_speed * Time.deltaTime, position.y);//sommat like dat

		//Update the enemy postion.
		transform.position = position;

		//This is the bottom-left point of the screen.
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0)); //0,0

		//If the enemy went outside the screen  on the bottom, then destroy the enemy.
		if(transform.position.y < min.y)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//Detect coliision of the  enemyship with an playership, or with an players bullet
		if((col.tag== "PlayerShipTag")||(col.tag == "PlayerBulletTag"))
		{	PlayExplosion();

			//for testing purposes Temp. comment the line below.
			Destroy(gameObject); //Destroy the Enemies' ship.
		}
	}

	//Function to Instantiate of the Explosion.
	void PlayExplosion()
	{	//Set the position of the Explosion animation.
		GameObject explosion = (GameObject)Instantiate(GO_Explosion);
		
		explosion.transform.position = transform.position;

		//to test the sprite instant destroy after.
		//Destroy(explosion);
	}

}
