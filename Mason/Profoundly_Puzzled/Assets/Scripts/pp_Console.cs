using UnityEngine;
using System.Collections;

public class pp_Console : MonoBehaviour {
	public Canvas canvas;

	void Start() {
		canvas = GetComponent<Canvas> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		Instantiate(canvas);
	}

	void OnTriggerExit2D(Collider2D other) {
		canvas.enabled = !canvas.enabled;
	}
}
