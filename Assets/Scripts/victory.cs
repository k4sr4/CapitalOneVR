using UnityEngine;
using System.Collections;

public class victory : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){
		this.GetComponent<AudioSource> ().Play();
	}
}
