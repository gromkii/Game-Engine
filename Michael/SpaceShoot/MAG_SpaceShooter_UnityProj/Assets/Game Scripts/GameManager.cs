/// <summary>
/// Ss_ game manager.
/// This class is a control flow construct of when the game is active an not active, and works by having the player click on the play the minigame 
/// and the enemy spawner does not kick in until the player clicks ploay and then a 5 second wait time begins. 
/// </summary>

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject playButton;
	public GameObject playerShip;

	// references to our Enemies' Spawners. 
	public GameObject enemy1Spawner;  
	public GameObject enemy2Spawner;  
	public GameObject enemy3Spawner;  
	// reference to the Game Over Sprite image.
	public GameObject GameOver; 

	// reference to the Winner Sprite image.
	public GameObject Winner;

	public GameObject InvisibleWinSpawner;

	//References to the the ScoreTextUI.
	public GameObject scoreUIText;

	//this is used to control the game states of gameplay, player loses and game start
	public enum GameManagerState
	{
		Opening,
		Gameplay,
		GameOver,
		Winning
	}

	GameManagerState GMState;

	// Use this for initialization
	void Start () {
		GMState = GameManagerState.Opening;
	}
	
//Function to update the game manager state.
	void UpdateGameManagerState()
	{
		switch(GMState)
		{
		case GameManagerState.Opening:
		
			//Set play button visible (active)
			playButton.SetActive(true);
		
			//Hide Game Over Screen.
			GameOver.SetActive(false);
			break;
		case GameManagerState.Gameplay:
		
			//RESET the Score Values each gameplay has started.
			scoreUIText.GetComponent<ss_GameScore>().Score = 0;

		//Hide the play button in the GamePlay state.
		playButton.SetActive(false);

	

		//Set the Player visible (active) and Initialize the player lives.
			playerShip.GetComponent<ss_PlayerControl>().Init();

			//Starts for all 3 enemy spawners
			enemy1Spawner.GetComponent<ss_Enemy1Spawner>().ScheduledEnemySpawner(); 
			enemy2Spawner.GetComponent<ss_Enemy2Spawner>().ScheduledEnemySpawner(); 
			enemy3Spawner.GetComponent<ss_Enemy3Spawner>().ScheduledEnemySpawner(); 
			InvisibleWinSpawner.GetComponent<ss_InvisibleWinSpawner>().ScheduledWinColliderSpawner();
		
			break;
		case GameManagerState.GameOver:
		
			//Stops all 3 enemy Spawners .
			enemy1Spawner.GetComponent<ss_Enemy1Spawner>().UnscheduledEnemySpawner();
			enemy2Spawner.GetComponent<ss_Enemy2Spawner>().UnscheduledEnemySpawner();
			enemy3Spawner.GetComponent<ss_Enemy3Spawner>().UnscheduledEnemySpawner();
			InvisibleWinSpawner.GetComponent<ss_InvisibleWinSpawner>().UnScheduledWinColliderSpawner();

			//planning to use Boss: in game when player loses his lifes game restarts.
			//BossSpawner.GetComponent <ss_BossSpawner>().ScheduleBossSpawner();

			//Display GameOver Screen.
			GameOver.SetActive(true);

		/*Change Game Manager state to Opening State after any number of seconds to
			Replay the game continously. */
			Invoke("ChangeToOpeningState", 3f);
		
			break;

			//Change Game Manager state to MissionSuiccess
			//when the player Collides into Win2DColliderBody 
			//FOR DAX TO MOD for Game Returning Main Menu
			case GameManagerState.Winning:
		{
			// This will show the Winner Sprite Screen.
			Winner.SetActive(true);

			enemy1Spawner.GetComponent<ss_Enemy1Spawner>().UnscheduledEnemySpawner();
			enemy2Spawner.GetComponent<ss_Enemy2Spawner>().UnscheduledEnemySpawner();
			enemy3Spawner.GetComponent<ss_Enemy3Spawner>().UnscheduledEnemySpawner();
			InvisibleWinSpawner.GetComponent<ss_InvisibleWinSpawner>().UnScheduledWinColliderSpawner();


		}
			break;

			//planning to use Boss in game when Boss enters the battle
			//BossSpawner.GetComponent <ss_BossSpawner>().ScheduleBossSpawner();
		}

	}

	//Function to set the game manager state.
	public void SetGameManagerState(GameManagerState state)
	{
		GMState = state;
		UpdateGameManagerState();
	}
	/*Our play button will call this fucntion whne the user clicks the button.*/
	public void StartGamePlay()
	{
		GMState = GameManagerState.Gameplay;
		UpdateGameManagerState();
	}

	//Function to change game manager state to Opening State.
	public void ChangeToOpeningState()
	{
		SetGameManagerState(GameManagerState.Opening);

	}



}
