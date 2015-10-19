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
		MuPlayerControls();
	
	}
	
	public void MuPlayerControls(){
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
	}
}
