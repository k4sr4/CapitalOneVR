using UnityEngine;
using System.Collections;

public class SnapRich : MonoBehaviour {

	void OnTriggerEnter(Collider other){		
		if(other.tag == "Frame")
        {		
	        if (!other.GetComponent<FrameScript>().isFull)
            {
                transform.parent = null;

                GameObject.FindObjectOfType<Raycast>().grabbed = false;

                transform.position = other.transform.position;
                transform.localEulerAngles = new Vector3(0f, 90f, 0f);

                other.GetComponent<FrameScript>().isFull = true;

                if (this.gameObject.name == other.name)
                {
                    GameObject.FindObjectOfType<Raycast>().correctPics++;
                    GetComponent<Collider>().enabled = false;                    
                }
            }
		}
	}

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Frame")
        {
            other.GetComponent<FrameScript>().isFull = false;
        }
    }
}
