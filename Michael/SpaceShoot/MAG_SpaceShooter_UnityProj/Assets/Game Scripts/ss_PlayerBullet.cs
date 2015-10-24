/*
 * Michael Anthony Gonzalez
 * Houston Community College
 * Fall 2015
 * MonoDevelop - Unity 5.1.2f1(64-bit))
This class will be an Added Component to PlayerBullet GameObject for programming Player's 
Bullete blast attack.
 */

using UnityEngine;
using System.Collections;

public class ss_PlayerBullet : MonoBehaviour {



  float ss_speed;

	// Use this for initialization
	void Start () {
		ss_speed = 8f;
	}
	
	// Update is called once per frame
	void Update () {
	
		//Get the bullet's current position.
		Vector2 position = transform.position;
		//Compute the bullet's new position.
		position = new Vector2 (position.x, position.y + ss_speed * Time.deltaTime);
		//Update the bullet's  position.
		transform.position = position;

		//This is the top-right point of the screen.
		Vector2 max= Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		//If the bullet went outside the screen on the top, then destory the bullet.
		if (transform.position.y > max.y){
			Destroy(gameObject);
		}
	}
}
