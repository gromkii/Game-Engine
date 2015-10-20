using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MU_Player : MonoBehaviour {

	public Rigidbody2D mu_rigid;
	public Text mu_text;
	
	public float mu_moveSpeed;
	public float mu_boostCount = 0;
	
	private Slider mu_boostSlider;
	
	// Use this for initialization
	void Start () {
		mu_rigid = GetComponent<Rigidbody2D>();
		mu_boostSlider = FindObjectOfType<Slider>().GetComponent<Slider>();
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
		
		MU_SpeedBoost();
		
		//Limit the Y movement of the player to certain parameters.
		//Move to separate function later?
		Vector3 mu_playerTransform = transform.position;
		mu_playerTransform.y = Mathf.Clamp (mu_playerTransform.y,-2,4);
		transform.position = mu_playerTransform;
	}
	
	//Spacebar boost mechanic.
	public void MU_SpeedBoost(){
		mu_boostSlider.value = mu_boostCount;
		float mu_boostText = Mathf.Ceil(mu_boostCount);
		if (Input.GetKey (KeyCode.Space)){
			mu_text.text = mu_boostText.ToString ("0.00");
			mu_boostCount += .5f * Time.deltaTime;
			if (Input.GetKeyUp(KeyCode.Space) && (mu_moveSpeed > .25 && mu_moveSpeed <.75)){
				mu_moveSpeed *= 2;
			} else if (Input.GetKeyUp (KeyCode.Space) && (mu_moveSpeed < .25 && mu_moveSpeed >.75)){
				mu_moveSpeed /= 2;
			} else {
				return;
			}
		} else {
			mu_boostCount = 0;
		}
		
		mu_boostCount = 0;
	}
	
	public float MU_BoostValue(){
		return mu_boostCount;
	}
	
}
