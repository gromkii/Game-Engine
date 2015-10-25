using UnityEngine;
using System.Collections;
[@RequireComponent(typeof(BoxCollider2D))]

public class pp_PlayerController_2 : MonoBehaviour
{
	public float pp_speed = 150f;
	RaycastHit2D pp_colCheck;
	BoxCollider2D pp_boxCollider;
	
	void Start() {
		pp_boxCollider = GetComponent<BoxCollider2D>();
	}
	
	void Update() {		
		var pp_direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * pp_speed * Time.deltaTime;

		pp_colCheck = Physics2D.BoxCast(transform.position, pp_boxCollider.size, 0, new Vector2(pp_direction.x,0), Mathf.Abs(pp_direction.x));
		if (pp_colCheck.collider == null) {
			transform.Translate(pp_direction.x, 0, 0);
		}

		pp_colCheck = Physics2D.BoxCast(transform.position, pp_boxCollider.size, 0, new Vector2(0, pp_direction.y), Mathf.Abs(pp_direction.y));
		if (pp_colCheck.collider == null) {
			transform.Translate(0, pp_direction.y, 0);
		}
	}
}
