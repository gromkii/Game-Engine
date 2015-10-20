using UnityEngine;
using System.Collections;

public class MU_Player : MonoBehaviour {

	public Rigidbody2D mu_rigid;
	
	public float mu_moveSpeed;
	
	// Use this for initialization
	void Start () {
		mu_rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		MU_PlayerControls();
	
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log (collider);	
	}
	
	//Check the keyboard for player input.
	public void MU_PlayerControls(){
		//Left
		if (Input.GetKey(KeyCode.A)){
			mu_rigid.AddForce(new Vector2(-mu_moveSpeed,0f),ForceMode2D.Force);			
		}
		//Right
		if (Input.GetKey (KeyCode.D)){
			mu_rigid.AddForce(new Vector2(mu_moveSpeed,0f),ForceMode2D.Force);
		}
		//Up
		if (Input.GetKey (KeyCode.W)){
			mu_rigid.AddForce(new Vector2(0f,mu_moveSpeed),ForceMode2D.Force);
		}
		
		//Down
		if (Input.GetKey (KeyCode.S)){
			mu_rigid.AddForce(new Vector2(0f,-mu_moveSpeed),ForceMode2D.Force);
		}
		//Space
		
		Vector3 mu_playerTransform = transform.position;
		mu_playerTransform.y = Mathf.Clamp (mu_playerTransform.y,-2,4);
		transform.position = mu_playerTransform;
	}
}
