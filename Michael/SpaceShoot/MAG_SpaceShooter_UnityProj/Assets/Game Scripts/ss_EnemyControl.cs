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

	float ss_speed; //for the enemy speed.

	// Use this for initialization
	void Start () {
	
		ss_speed = 2f; // set speed

	}
	
	// Update is called once per frame
	void Update () {
	
		//Get the enemy current position
		Vector2 position = transform.position;

		//Compute the enemy new postion.
		position = new Vector2 (position.x, position.y - ss_speed * Time.deltaTime);

		//Update the enemy postion.
		transform.position = position;

		//This is the bottom-left point of the screen.
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//If the enemy went outside the screen  on the bottom, then destroy the enemy.
		if(transform.position.y < min.y)
		{
			Destroy(gameObject);
		}
	}
}
