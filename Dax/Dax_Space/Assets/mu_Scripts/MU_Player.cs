using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MU_Player : MonoBehaviour {

	public Rigidbody2D mu_rigid;
	public Text mu_text;
	
	public float mu_moveSpeed;
	public float mu_boostCount = 0;
	
	private Slider mu_boostSlider;
	private MU_Camera mu_camera;
	
	// Use this for initialization
	void Start () {
		mu_rigid = GetComponent<Rigidbody2D>();
		mu_boostSlider = FindObjectOfType<Slider>().GetComponent<Slider>();
		mu_camera = FindObjectOfType<MU_Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		MU_PlayerControls();
		MU_SpeedBoost();
	
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log (collider);
		mu_rigid.velocity = Vector3.Reflect (-mu_rigid.velocity/2,collider.transform.forward);	
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
		
		
		
		//Limit the Y movement of the player to certain parameters.
		//Move to separate function later?
		Vector3 mu_playerTransform = transform.position;
		mu_playerTransform.y = Mathf.Clamp (mu_playerTransform.y,-2,4);
		transform.position = mu_playerTransform;
	}
	
	private void MU_SpeedBoost(){
		
		
		float mu_boostCheck = 0;
		float mu_boostTimer = .5f;
		float mu_boostMin = .25f;
		float mu_boostMax = .75f;
	
		if (Input.GetKey (KeyCode.Space)){
			mu_boostCount += mu_boostTimer * Time.deltaTime;
		}
		
		mu_boostCheck = mu_boostCount;
		mu_boostSlider.value = mu_boostCount;
		
		if (Input.GetKeyUp(KeyCode.Space)){
			Debug.Log ("Key released, boost speed " + mu_boostCheck.ToString ("#.##"));
			if (mu_boostCheck > mu_boostMin && mu_boostCheck < mu_boostMax){
				Debug.Log ("Boost success.");
				mu_camera.mu_cameraSpeed += 1;
				mu_moveSpeed += .5f;
				
			} else {
				Debug.Log ("No boost.");
				mu_camera.mu_cameraSpeed -= 1;
				mu_moveSpeed -= .5f;
			}
			
			mu_boostCount = 0;
			mu_boostCheck = 0;
		}
		
	
	}
	
}
