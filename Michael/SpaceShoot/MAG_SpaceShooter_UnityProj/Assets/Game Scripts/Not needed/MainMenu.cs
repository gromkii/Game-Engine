using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	//creating the buttons and testing it out!!
	//this is applied in the Canvas game object or applied to the Buttons!!
	// Creating buttons play and Quit and any other button functions using Application modes

	public string playGameLevel;  //this allows the programmer to input the EXACT name of a Unity Scene 

	public void PlayGame()
	{	// this functon  works by loading the Programmer's input Unity scene to be played
		Application.LoadLevel(playGameLevel);
		}


	// this is used inside the main menu for the Quit button and will execute by ending the game
	public void QuitGame()	  
	{

Application.Quit ();  //terminates the executable program!


}
}