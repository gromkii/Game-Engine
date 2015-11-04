using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MU_TextDebug : MonoBehaviour {

	private MU_Player mu_player;
	private Text mu_text;
	
	void Start(){
		mu_text = GetComponent<Text>();
		mu_player = FindObjectOfType<MU_Player>();
	}
	
	void Update(){
		mu_text.text = mu_player.mu_moveSpeed.ToString ("0.00") + "\n" +
						mu_player.mu_boostCount;
	}
}
