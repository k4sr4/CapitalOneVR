using UnityEngine;
using System.Collections;

public class DragScript : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Drop")
        {
            transform.parent = null;
            GetComponent<Rigidbody>().isKinematic = false;
        }            
    }
}
