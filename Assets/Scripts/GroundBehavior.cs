using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroundBehavior : MonoBehaviour {

	GameObject invisiblePath;
	List<GameObject> pathList;

	// Use this for initialization
	void Start () {
		invisiblePath = GameObject.FindGameObjectWithTag ("InvisiblePath");
		pathList = new List<GameObject> ();
		for(int i = 0; i < 5; i++){
			pathList.Add(invisiblePath.transform.GetChild (i).gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	void OnTriggerEnter(Collider collider){
		this.GetComponent<AudioSource> ().Play();

		Debug.Log ("ENTERED RESET TRIGGER");
		GameObject floatingBox;
		MeshRenderer meshRenderer;
		for(int i = 0; i < 5; i++){
			floatingBox = pathList[i].transform.GetChild (0).gameObject;
			meshRenderer = floatingBox.GetComponent<MeshRenderer> ();
			meshRenderer.enabled = false;
		}
		floatingBox = pathList [0].transform.GetChild (0).gameObject;
		meshRenderer = floatingBox.GetComponent<MeshRenderer> ();
		meshRenderer.enabled = true;
	}
}
