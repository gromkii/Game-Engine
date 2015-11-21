using UnityEngine;
using System.Collections;

public class MU_Camera : MonoBehaviour {
	
	
	public Transform mu_playerTransform; //Change to private?
	public float mu_cameraSpeed; //How fast the camera interpolates.
	public float mu_paddingAmmount;
	
	void FixedUpdate () {	
		MU_CameraLerp();
	}
	
	public void MU_CameraLerp(){
		//Interpolates the camera and player object's current position.
		Vector3 mu_pos = transform.position;
		
		mu_pos.x = mu_playerTransform.position.x;
		mu_pos.y = 0f;
		
		transform.position = Vector3.Lerp (transform.position, mu_pos, mu_cameraSpeed * Time.deltaTime);
	}
}
