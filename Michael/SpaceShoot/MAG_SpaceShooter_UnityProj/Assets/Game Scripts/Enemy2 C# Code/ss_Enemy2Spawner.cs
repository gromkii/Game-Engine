/// <summary>
/// Ss_ enemy spawner.
/// works as a enemy spawner control class by setting up the time spawn of each enemy and the enemy will fly out vertically above the screen shotting the player and the
/// spawning does not start until player clicks the play button and kicks in after a 'n' seconds.
/// </summary>
using UnityEngine;
using System.Collections;

public class ss_Enemy2Spawner : MonoBehaviour {

	public GameObject GO_Enemy2;  //This is our enemy prefab.

	// this will be used for spawn control an Enemy every 'n' seconds.
	float maxSpawnRateinSeconds = 20f; 

	// Use this for initialization
	void Start () {
	

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
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0,0)); //0,0 
		// This is the Top-Right point of the screen.
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1)); //1,1

		//Instantiate an enemy. this is used for spawning directions.
		GameObject anEnemy = (GameObject)Instantiate (GO_Enemy2);

		//this is used for Horizontally spawning directions(from the Right to Left).
		anEnemy.transform.position = new Vector2 (max.x, Random.Range(min.y, max.y)); 

		//This is used for Vertically Directions(From the Top to Bottom).
		//anEnemy.transform.position = new Vector2 (Random.Range(min.x, max.x), max.y)  

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
			CancelInvoke("IncreaseSpawnRate");
	}

	//Function to start enemy spawner.
	public void ScheduledEnemySpawner()
	{
		//reset spawning for all enemy 1.
		maxSpawnRateinSeconds = 20f; 

		//start to spawn the enemy once in 'n' seconds and that is it.
		Invoke ("SpawnEnemy", maxSpawnRateinSeconds);
		
		//Increase spawn  rate every 'n' seconds.
		InvokeRepeating("IncreaseSpawnRate", 0f, 5f);
	}

	//Function to stop enemy spawner.
	public void UnscheduledEnemySpawner()
	{
		CancelInvoke("SpawnEnemy");
		CancelInvoke("IncreaseSpawnRate");
	}
}
