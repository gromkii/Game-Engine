using UnityEngine;
using System.Collections;

public class ss_Enemy1Gun : MonoBehaviour {
	public GameObject GO_Enemy1Attack; // this is our enemy bullet prefab.
	public AudioClip[] audioClip; // references the SFX for the player GameObject

	// Use this for initialization
	void Start () {
	
		//fire an enemy bullet after 1 second
		Invoke("FireEnemyBullet", 1f);
		//Enemy Laser sound
		PlaySound (0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Function to fire an enemy bullet.
	void FireEnemyBullet()
	{
		//get a reference to the player's ship.
		GameObject playerShip = GameObject.Find("GO_Player");

		//If the player is not destroyed.
		if(playerShip != null)
		{
			//instantiate an enemy bullet.
			GameObject bullet = (GameObject)Instantiate(GO_Enemy1Attack);

			//set the bullet's initial position.
			bullet.transform.position = transform.position;

			//compute the bullet's direction towards the player's ship.
	Vector2 direction = playerShip.transform.position - bullet.transform.position;
		
			//set the bullet's direction.
			bullet.GetComponent<ss_Enemy1Bullet>().SetDirection(direction);
		
		}
	}

	void PlaySound(int clip)
	{
		GetComponent<AudioSource>().clip = audioClip[clip];
		GetComponent<AudioSource>().Play();
		
	}

}
