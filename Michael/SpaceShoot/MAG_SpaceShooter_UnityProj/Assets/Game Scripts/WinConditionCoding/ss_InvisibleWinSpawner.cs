/// <summary>
/// Ss_ invisible window spawner.
/// This clas will control the Spawning mechanics for the invisble win conditions Boxes to set up  the win condition for the Player's Invisible Win conditions.
/// </summary>

using UnityEngine;
using System.Collections;

public class ss_InvisibleWinSpawner : MonoBehaviour {
	
	public GameObject InvisibleWinBody;
	
	// this will be used for spawn control an Enemy every 'n' seconds.
	float maxSpawnRateinSeconds = 31f; 


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	


	}


	public void SpawnWinCodition()
	{
		// This is the bottom-left point of the screen.
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0,0)); //0,0 
		// This is the Top-Right point of the screen.
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1)); //1,1
		
		//Instantiate an InvisibleWinBlock. this is used for spawning directions.
		GameObject AGoal = (GameObject)Instantiate (InvisibleWinBody);
		
		//this is used for Horizontally spawning directions(from the Right to Left).
		AGoal.transform.position = new Vector2 (max.x, Random.Range(min.y, max.y)); 
		
		//This is used for Vertically Directions(From the Top to Bottom).
		//AGoal.transform.position = new Vector2 (Random.Range(min.x, max.x), max.y)  
		
		//Schedule when to spawn next Win Box.
		ScheduleNextWin();
	}

	public void ScheduleNextWin()
	{

		float spawnInNSeconds;
		
		if (maxSpawnRateinSeconds > 1f)
		{
			//Picks a Number between 1 and MaxSpawnRAteInSeconds.
			spawnInNSeconds = Random.Range (1f, maxSpawnRateinSeconds);
		}
		else spawnInNSeconds = 4f;
		
		Invoke ("SpawnWinCodition", spawnInNSeconds);
	}

	void IncreaseSpawnRate()
	{
		if(maxSpawnRateinSeconds > 1f)
			maxSpawnRateinSeconds--;
		
		if(maxSpawnRateinSeconds == 1f)
			CancelInvoke("IncreaseSpawnRate");
	}

	public void ScheduledWinColliderSpawner()
	{
		//reset spawning for all enemy 1.
		maxSpawnRateinSeconds = 31; 
		//start to spawn the enemy once in 'n' seconds and that is it.
		Invoke ("SpawnWinCodition", maxSpawnRateinSeconds);
		
		//Increase spawn  rate every 'n' seconds.
		InvokeRepeating("IncreaseSpawnRate", 0f, 1f);
		
	

	}



	public void UnScheduledWinColliderSpawner()
	{
		CancelInvoke("SpawnWinCodition");
		CancelInvoke("IncreaseSpawnRate");
	}
}
