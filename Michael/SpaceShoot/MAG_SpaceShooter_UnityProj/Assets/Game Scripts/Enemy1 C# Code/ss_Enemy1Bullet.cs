//part 5 enemy fire mechanics
using UnityEngine;
using System.Collections;

public class ss_Enemy1Bullet : MonoBehaviour {

	float ss_speed; //bullet speed for this enemy bullet.
	Vector2 _direction; //the direction of the enemy bullet
	bool isReady; //to know when the bullet direction is set.


	void Awake()
	{
		ss_speed = 15f;
		isReady = false;
	
	}

	// Use this for initialization
	void Start () 
	{


	}

	//Function to set the bullet's direction 
	public void SetDirection(Vector2 direction)
	{

		//This code piece will shoot straight towards the left side of the screen W/O having to shoot directly at player *** CODING for Second Enemy Gameobject and bullets.
		//I used the code that is oppisite of Player's bullet class functions, that instead of shooting the bullet at the right it shoots to the LEFT.
		 _direction = new Vector2 (_direction.x + ss_speed * (-Time.deltaTime), _direction.y );

		//This will allow the bullet to target shoot at playership's position on game screen.
		//set the direction normalized, to get an unit vector.
		// _direction = direction.normalized; 

		isReady = true; //set flag to true.
	}

	// Update is called once per frame
	void Update () {
	
	if(isReady)
		{
			//get the bullet's current position.
			Vector2 position = transform.position;

			//compute the bullet's new position.
			position += _direction * ss_speed * Time.deltaTime;

			//update the bullet's postion.
			transform.position = position;
		

/*Next we nee to remove the bullet from our game
if the bullet goes outside the game screen. */

	//this is the Bottom-Left point of the screen.
	Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));

	//this is the Top_Right point of the screen.
	Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

	//if the bullet goes outside the screen, then  destroy it.
	if ((transform.position.x < min.x)||(transform.position.x > max.x)||
		(transform.position.y < min.y)||(transform.position.y > max.y))
			{
				Destroy(gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//Detect coliision of the enemy bullet with an plsyer's ships.
		if((col.tag== "PlayerShipTag"))
		{
			Destroy(gameObject); //Destroy This Enemy's bullet.
		}
	}
	

}
