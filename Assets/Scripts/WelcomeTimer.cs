using UnityEngine;
using System.Collections;

public class WelcomeTimer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.FindObjectOfType<OVRPlayerController>().canMove = false;
        StartCoroutine(Wait());
	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        GameObject.FindObjectOfType<OVRPlayerController>().canMove = true;
        Destroy(this.gameObject);
    }
}
