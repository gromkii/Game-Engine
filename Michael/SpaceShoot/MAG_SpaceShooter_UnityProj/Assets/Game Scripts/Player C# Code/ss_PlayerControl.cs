/*
 * Michael Anthony Gonzalez
 * Houston Community College
 * Fall 2015
 * MonoDevelop - Unity 5.1.2f1(64-bit))
This class will be an Added Component to Player GameObject for programming Player;'s control 
movement with the keyboard. this will also add trigger event when player collides with enemy 
fire and enemy ships.
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ss_PlayerControl : MonoBehaviour 
{

	public GameObject GO_GameManager; //Reference to our game manager.

	public GameObject GO_PlayerBullet;//This is our player's bullet prefab.
	public GameObject BulletPosition01;
	public GameObject BulletPosition02;
	public GameObject GO_Explosion; //This is our Explosion Prefab. 

	public AudioClip[] audioClip; // references the SFX for the player GameObject

	//Reference to the lives UI Text
	public Text TextLives;


	const int MaxLives = 5; //control of player's Max Lives during gameplay.
	int lives; // Current player lives.

	public float ss_speed;

	public void Init()
	{
		lives = MaxLives;
		//Update the TextLives UI. 
		TextLives.text = lives.ToString();

		//Resets the player position to the center of the screen.
		//Whenever the player clicks play to start the game,
		transform.position = new Vector2(0,0); 
		//The player Gameobject will spawn at the center of the screen.


		//Set this player game object to active.
		gameObject.SetActive(true);
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {

		//Fire bullets when the 'Spacebar' key is pressed.
		if(Input.GetKeyDown("space"))
		{
			//play the laser Sound Effect.
			PlaySound(0);

			//Instatiate the first bullet
			GameObject bullet01 = (GameObject)Instantiate (GO_PlayerBullet);

			//Set the bullet initial position.
			bullet01.transform.position = BulletPosition01.transform.position;

			//Instatiate the second bullet
			GameObject bullet02 = (GameObject)Instantiate (GO_PlayerBullet);

			//Set the bullet initial position.
			bullet02.transform.position = BulletPosition02.transform.position;

		}

		//the value will be -1, 0 or 1 (for Left, no input, and Right)
		float x = Input.GetAxisRaw("Horizontal");

		//the value will be -1, 0 or 1 (for Down, no input, and Up)
		float y = Input.GetAxisRaw("Vertical");

	//Now based on the input we compute a direction vector, and we normalize it to get a unit vector.
		Vector2 direction = new Vector2 (x,y).normalized;

		//Now we call the function that computes and sets the player's position.
		Move (direction); 
	}

	void Move(Vector2 direction)
	{
		//Find the screen limits to the player's movment (left, right, top and bottom edges of the screen)
		// This is the bottom-left corner of the screen.
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0,0));

		// This is the Top-Right corner of the screen.
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1)); 


		max.x = max.x - 0.225f;  //subtract the player sprite half width.
		min.x = min.x + 0.225f;  //add the player sprite half width.

		max.y = max.y - 0.285f;  //subtract the player sprite half height.
		min.y = min.y + 0.285f;  //add the player sprite half height.

		//Get the player's current position
		Vector2 pos = transform.position;

		//Calculate the new Position
		pos += direction * ss_speed * Time.deltaTime;

		// Make sure the new position is not outside the screen.
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);

		//Update the player's position.
		transform.position = pos;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//Detects all coliision of the  playership with all enemyships, or with an enemies' bullet attacks!!
		if((col.tag== "EnemyShipTag")||(col.tag == "EnemyBulletTag"))
		{	
			//play the Explosion Sound Effect.
			PlaySound(1);

			//Call this function whenever player gets collided with enemy ships or fire.
			PlayExplosion();

			lives--;//Subtract one live each time playership gets killed.
			//Update the TextLives UI. 
			TextLives.text = lives.ToString();

			if(lives == 0)//If our player lives reaches zero.
			{
			//***Change game manager state to game over state.***
		GO_GameManager.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);

			//Hide the player's ship.
			gameObject.SetActive(false);
			}
		}

		//This code below will force the player to exit off screen
		//when colliding into the GO_Win2DColliderBody!
		if(col.tag== "WinConditionTag") 
		   {

			//***Change game manager state to Winning state.***
			GO_GameManager.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.Winning);

			/* This code will be used for a decoy version of the player object.
			//This piece of code control the player's movement to leave off screen
			Vector2 position = gameObject.transform.position;
			position = new Vector2 (position.x + ss_speed * Time.deltaTime , position.y);

			//Update the invisible collider position.
			transform.position = position;

			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0)); //0,0
			
		
			
			//If the enemy went outside the screen  on the LEFT side of screen, then destroy the enemy.
			if(transform.position.y < min.y)
			{
				Destroy(gameObject);
			}*/
		}

	}

	//Function to Instantiate of the Explosion.
	void PlayExplosion()
	{	



		//Set the position of the Explosion animation.
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
