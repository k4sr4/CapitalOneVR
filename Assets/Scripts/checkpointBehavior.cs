using UnityEngine;
using System.Collections;

public class checkpointBehavior : MonoBehaviour {

	public GameObject nextPath;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(){
		this.GetComponent<AudioSource> ().Play();

		Debug.Log ("REMOVED OBJ");
		//disable current checkpoint upon entry
		GameObject myFloatingBox = transform.GetChild(0).gameObject;
		MeshRenderer myMeshRenderer = myFloatingBox.GetComponent<MeshRenderer> ();
		myMeshRenderer.enabled = false;

		//turn on next checkpoint
		GameObject floatingBox = nextPath.transform.GetChild (0).gameObject;
		MeshRenderer meshRenderer= floatingBox.GetComponent<MeshRenderer> ();
		meshRenderer.enabled = true;
	}
}
