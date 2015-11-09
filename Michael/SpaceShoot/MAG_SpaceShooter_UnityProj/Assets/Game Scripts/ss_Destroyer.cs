/*part 6 
 * Addan animation event after all the explosion frames to call the
 * DerstroyGameObject function.
The exploaion animation will call this function at the end of 
the animation to destroy the GO_Explosion.*/

using UnityEngine;
using System.Collections;

public class ss_Destroyer : MonoBehaviour {

	void DestroyGameObject(){
		Destroy(gameObject);

	}
}
