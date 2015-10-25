using UnityEngine;
using System.Collections;

public class pp_PlayerController : MonoBehaviour {

	public float pp_speed = 200f;
	
	//private Rigidbody2D body2d;

	/*void Awake() {
		body2d = GetComponent<Rigidbody2D>();
	}*/

	void FixedUpdate () {
		float pp_translationX = Input.GetAxis("Horizontal") * pp_speed;
		float pp_translationY = Input.GetAxis("Vertical") * pp_speed;
		pp_translationX *= Time.deltaTime;
		pp_translationY *= Time.deltaTime;
		transform.Translate(pp_translationX, pp_translationY, 0);
	}

	/*void FixedUpdate() {
		if (Input.GetAxis("Horizontal") > 0) {
			body2d.velocity = new Vector2(pp_speed,body2d.velocity.y);
		}
		if (Input.GetAxis("Horizontal") < 0) {
			body2d.velocity = new Vector2(-pp_speed,body2d.velocity.y);
		}
		if (Input.GetAxis("Vertical") > 0) {
			body2d.velocity = new Vector2(body2d.velocity.x,pp_speed);
		}
		if (Input.GetAxis("Vertical") < 0) {
			body2d.velocity = new Vector2(body2d.velocity.x,-pp_speed);
		}
	}*/
}
