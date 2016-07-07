using UnityEngine;
using System.Collections;

public class repeatTexture : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.GetComponent<Renderer>().material.mainTextureScale = new Vector2 (10, 20);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
