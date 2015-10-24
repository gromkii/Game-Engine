using UnityEngine;
using System.Collections;

public class ss_EnemySpawner : MonoBehaviour {

	public GameObject GO_Enemy;  //This is our enemy prefab.

	// this will be used for spawn control an Enemy every 5 seconds.
	float maxSpawnRateinSeconds = 5f; 

	// Use this for initialization
	void Start () {
		//start to spawn the enemy once in 5 seconds and that is it.
		Invoke ("SpawnEnemy", maxSpawnRateinSeconds);

		//Increase spawn  rate every 30 seconds.
		InvokeRepeating("IncreaseSpawnRate", 0f, 30f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*//Part4
This function will create and enemy prefab position on
the top edge of the screen, and randomly between the 
left and right edge of the screen.
	 */

	void SpawnEnemy()
	{
		// This is the bottom-left point of the screen.
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0,0)); 
		// This is the Top-Right point of the screen.
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1)); 

		//Instantiate an enemy.
		GameObject anEnemy = (GameObject)Instantiate (GO_Enemy);
		anEnemy.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);

		//Schedule when to spawn next enemy.
		ScheduleNextEnemySpawn();
	}

	void ScheduleNextEnemySpawn()
	{
		float spawnInNSeconds;

		if (maxSpawnRateinSeconds > 1f)
		{
			//Picks a Number between 1 and MaxSpawnRAteInSeconds.
			spawnInNSeconds = Random.Range (1f, maxSpawnRateinSeconds);
		}
		else spawnInNSeconds = 1f;

		Invoke ("SpawnEnemy", spawnInNSeconds);
	}

	//Function to increase the difficulty of the game.
	void IncreaseSpawnRate()
	{
		if(maxSpawnRateinSeconds > 1f)
			maxSpawnRateinSeconds--;

		if(maxSpawnRateinSeconds == 1f)
			CancelInvoke("IncreaseSpawnRAte");
	}

}
