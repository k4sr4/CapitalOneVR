using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class platinumcard : MonoBehaviour {

    public bool showDetails = false;

	// Use this for initialization
	void Start () {
		GameObject.Find ("PlatinumText").GetComponent<Text> ().enabled = false;
	}

    void Update()
    {        
        if (showDetails)
        {
            GameObject.Find("PlatinumText").GetComponent<Text>().enabled = true;
        }
        else
        {
            GameObject.Find("PlatinumText").GetComponent<Text>().enabled = false;
        }
    }
}
