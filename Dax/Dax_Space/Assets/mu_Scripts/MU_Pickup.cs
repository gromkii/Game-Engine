using UnityEngine;
using System.Collections;

public class MU_Pickup : MonoBehaviour {
	private MU_Player mu_pickPlayer;

	void Start(){
		mu_pickPlayer = FindObjectOfType<MU_Player>();
	}

	void OnTriggerEnter2D(){
		mu_pickPlayer.mu_hasItem = true;
		Debug.Log ("Item Get");
		Destroy(gameObject);
	}
	
}
		
