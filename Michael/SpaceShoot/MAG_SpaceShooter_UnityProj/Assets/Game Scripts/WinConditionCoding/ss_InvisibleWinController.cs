/// <summary>
/// Ss_ invisible window controller. this Class will control the invisble boxes to exist and 
/// move towards the player by moving all spawns to the Left side of the GameScreen Setting up the Win conditon for the player.  
/// </summary>

using UnityEngine;
using System.Collections;

public class ss_InvisibleWinController : MonoBehaviour {

	float ss_speed; //for the enemy speed.

	public AudioClip[] audioClip; // references the SFX for the Enemy1 GameObject

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
		if(col.tag == "PlayerShipTag")
		{	
			//play the Explosion Sound Effect.
			PlaySound(0);

			//for testing purposes Temp. comment the line below.
			//Destroy(gameObject); //Destroy the Enemies' ship.
		}
	}


	void PlaySound(int clip)
	{
		GetComponent<AudioSource>().clip = audioClip[clip];
		GetComponent<AudioSource>().Play();
		
	}
}
