using UnityEngine;
using System.Collections;

public class FloatingObjectBehavior : MonoBehaviour {

	int speed;

	// Use this for initialization
	void Start () {
		speed = 30;
	}

	// Update is called once per frame
	void Update () {
		this.transform.Rotate (Vector3.left * Time.deltaTime * speed);
	}


}
