using UnityEngine;
using System.Collections;

public class pp_toggleConsole: MonoBehaviour {
	private Canvas canvas; // Assign in inspector
	
	void Start() {
		canvas = GetComponent<Canvas> ();
		canvas.enabled = false;
	}
	
	void Update() {
		if (Input.GetButtonDown("Activate")) {
			canvas.enabled = !canvas.enabled;
		}
	}
}
