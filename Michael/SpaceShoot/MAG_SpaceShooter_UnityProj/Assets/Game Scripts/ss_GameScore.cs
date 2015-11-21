using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ss_GameScore : MonoBehaviour {
	Text scoreTextUI;

	int score;

	public int Score
	{
		get{
			return this.score;
		}
		set{
			this.score = value;
			UpdateScoreTextUI();
		}
	}



	// Use this for initialization
	void Start () {
		//Get the Text UI component
		scoreTextUI = GetComponent<Text> ();
	}
	
void UpdateScoreTextUI()
	{
		string scoreStr = string.Format("{0}",score);
		scoreTextUI.text = scoreStr;
	}

}
