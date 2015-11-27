/*
 * Michael Anthony Gonzalez
 * Houston Community College
 * Fall 2015
 * MonoDevelop - Unity 5.1.2f1(64-bit))
This class will be an Added Component to Enemy GameObject for programming Player;'s control 
movement with the keyboard.
 */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ss_Enemy3Control : MonoBehaviour {

	GameObject GO_ScoreUIText;  //This is our Explosion Prefab.

	public GameObject GO_Explosion; //This is our Explosion Prefab.

	public AudioClip[] audioClip; // references the SFX for the Enemy2 GameObject

	float ss_speed; //for the enemy speed.

	// Use this for initialization
	void Start () {
	
		ss_speed = 3f; // set speed

		//Get the Score Text UI
		GO_ScoreUIText = GameObject.FindGameObjectWithTag ("ScoreTextTag");
	}
	
	// Update is called once per frame
	void Update () {
	
		//Get the enemy current position
		Vector2 position = transform.position;

		//Compute the enemy new postion. ( - ss_speed * Time.deltaTime)
		position = new Vector2 (position.x - ss_speed * Time.deltaTime, position.y);//sommat like dat

		//Update the enemy postion. this will attack player with its body!!
		transform.position = position;

		//This is the bottom-left point of the screen.
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0)); //0,0

		//If the enemy went outside the screen  on the bottom, then destroy the enemy. if(transform.position.y < min.y)

		//If the enemy went outside the screen  on the LEFT side of screen, then destroy the enemy.
		if(transform.position.x < min.x)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//Detect coliision of the  enemyship with an playership, or with an players bullet
		if((col.tag== "PlayerShipTag")||(col.tag == "PlayerBulletTag"))
		{	
			//play the Explosion Sound Effect.
			PlaySound(0);

			PlayExplosion();

			//add 100 Points to the Player's score! 
			GO_ScoreUIText.GetComponent<ss_GameScore>().Score += 100;

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
		Destroy(explosion);
	}
	void PlaySound(int clip)
	{
		GetComponent<AudioSource>().clip = audioClip[clip];
		GetComponent<AudioSource>().Play();
		
	}

}
