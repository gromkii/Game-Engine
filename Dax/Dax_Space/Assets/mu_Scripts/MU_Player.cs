using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MU_Player : MonoBehaviour {

	public Rigidbody2D mu_rigid;
	//public Text mu_text;
	
	public float mu_moveSpeed;
	public float mu_boostCount = 0;
	
	public bool mu_hasItem = false;
	
	private Slider mu_boostSlider;
	private Slider mu_goalSlider;
	private MU_Camera mu_camera;
	private bool mu_canBoost = true;
	private Transform mu_goalTransform;
	
	void Start () {
		//Initialize private variables		
		mu_rigid = GetComponent<Rigidbody2D>();
		mu_boostSlider = FindObjectOfType<MU_BoostSlider>().GetComponent<Slider>();
		mu_goalSlider = FindObjectOfType<MU_GoalSlider>().GetComponent<Slider>();
		mu_camera = FindObjectOfType<MU_Camera>();
		mu_goalTransform = FindObjectOfType<MU_Pickup>().transform;
	}
	
	void Update () {
		//Call control and UI functions.
		MU_PlayerControls();
		if (mu_canBoost == true) {
			MU_SpeedBoost();
		}
		MU_DistanceToGoal();
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		float mu_reflectDampening = 5f;
		Debug.Log (collider);
		mu_rigid.velocity = Vector3.Reflect (-mu_rigid.velocity/mu_reflectDampening,collider.transform.forward);
		mu_moveSpeed -= .5f;	
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
		Vector3 mu_playerTransform = transform.position;
		mu_playerTransform.y = Mathf.Clamp (mu_playerTransform.y,-4,4);
		
		//Set gameObject's transform after clamp.
		transform.position = mu_playerTransform;

		//Set the center gravity line at y coordinate 0.
		if (transform.position.y > 0 && Physics2D.gravity.y > 0){
			MU_GravityFlip();
		}
		
		if (transform.position.y < 0 && Physics2D.gravity.y < 0){
			MU_GravityFlip ();
		}
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
				mu_camera.mu_cameraSpeed += .5f;
				mu_moveSpeed += .5f;
				mu_canBoost = false;
				Invoke ("MU_ReturnBoost",3f);
				
			} else {
				Debug.Log ("No boost.");
				mu_camera.mu_cameraSpeed -= .5f;
				mu_moveSpeed -= .5f;
				mu_canBoost = false;
				Invoke ("MU_ReturnBoost",3f);
			}
			
			mu_boostCount = 0;
			mu_boostCheck = 0;
		}
	}
	
	private void MU_GravityFlip(){
		//Inverse the gravity with a new vector2
		Physics2D.gravity = new Vector2(Physics2D.gravity.x,-Physics2D.gravity.y);
	}
	
	private void MU_ReturnBoost(){
		//Cancel invocation and reset canBoost
		CancelInvoke("MU_ReturnBoost");
		mu_canBoost = true;
		Debug.Log ("Can boost.");
	}
	
	public void MU_DistanceToGoal(){
		//Position of Slider is relative to the distance to the pickup object.
		if (mu_hasItem) {
			mu_goalSlider.value = Vector3.Distance(transform.position,mu_goalTransform.position) * Time.deltaTime ;
		}
		
	}
	
	
		
}
