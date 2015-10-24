/*
 * Michael Anthony Gonzalez
 * Houston Community College
 * Fall 2015
 * MonoDevelop - Unity 5.1.2f1(64-bit))
This class will be an Added Component to Player GameObject for programming Player;'s control 
movement with the keyboard.
 */

using UnityEngine;
using System.Collections;

public class ss_PlayerControl : MonoBehaviour {

	public GameObject GO_TestPlayerBullet;//This is our player's bullet prefab.
	public GameObject BulletPosition01;
	public GameObject BulletPosition02;

	public float ss_speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Fire bullets when the 'Spacebar' key is pressed.
		if(Input.GetKeyDown("space"))
		{
			//Instatiate the first bullet
			GameObject bullet01 = (GameObject)Instantiate (GO_TestPlayerBullet);
			//Set the bullet initial position.
			bullet01.transform.position = BulletPosition01.transform.position;

			//Instatiate the second bullet
			GameObject bullet02 = (GameObject)Instantiate (GO_TestPlayerBullet);
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

		//Time of video 5:07
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



}
