using UnityEngine;
using System.Collections;

public class ss_EnemyGun : MonoBehaviour {
	public GameObject GO_EnemyAttack; // this is our enemy bullet prefab.
	
	// Use this for initialization
	void Start () {
	
		//fire an enemy bullet after 1 second
		Invoke("FireEnemyBullet", 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Function to fire an enemy bullet.
	void FireEnemyBullet()
	{
		//get a reference to the player's ship.
		GameObject playerShip = GameObject.Find("GO_TestPlayer");

		//If the player is not destroyed.
		if(playerShip != null)
		{
			//instantiate an enemy bullet.
			GameObject bullet = (GameObject)Instantiate(GO_EnemyAttack);

			//set the bullet's initial position.
			bullet.transform.position = transform.position;

			//compute the bullet's direction towards the player's ship.
	Vector2 direction = playerShip.transform.position - bullet.transform.position;
		
			//set the bullet's direction.
			bullet.GetComponent<ss_EnemyBullet>().SetDirection(direction);
		
		}
	}
}
