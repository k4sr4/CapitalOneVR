using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	float speed;
	float upperLimit;
	float lowerLimit;
	bool goingUp;

	// Use this for initialization
	void Start () {
		speed = 2f;
		upperLimit = -0.4f;
		lowerLimit = -5.5f;
		goingUp = false;
	}

	// Update is called once per frame
	void Update () {

		if (this.transform.localPosition.y > upperLimit) {
			goingUp = false;
		} else if(this.transform.localPosition.y < lowerLimit){
			goingUp = true;
		}

		if(goingUp){
			this.transform.Translate (Vector3.up * Time.deltaTime * speed);
		} else{
			this.transform.Translate (Vector3.down * Time.deltaTime * speed);
		}
	}
}