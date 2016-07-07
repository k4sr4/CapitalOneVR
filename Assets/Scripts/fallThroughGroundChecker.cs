using UnityEngine;
using System.Collections;

public class fallThroughGroundChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(){
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.transform.position = new Vector3 (-24.73f, .88f, 0f);
	}
}
