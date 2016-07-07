using UnityEngine;
using System.Collections;

public class Playsound : MonoBehaviour 

{

	public static int numm = 0;

	public IEnumerator MoveOverSpeed (GameObject objectToMove, Vector3 end, float speed){
		// speed should be 1 unit per second
		while (objectToMove.transform.position != end)
		{
			objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
			yield return new WaitForEndOfFrame ();
		}
	}
	public IEnumerator MoveOverSeconds (GameObject objectToMove, Vector3 end, float seconds)
	{
		float elapsedTime = 0;
		Vector3 startingPos = objectToMove.transform.position;
		while (elapsedTime < seconds)
		{
			objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		objectToMove.transform.position = end;

	}

	public void playSuccess(){
		GetComponent<AudioSource> ().pitch = 1;
		GetComponent<AudioSource>().Play();
	}

	public void playFail(){
		GetComponent<AudioSource> ().pitch = 0.2f;
		GetComponent<AudioSource>().Play();
	}

	public void Clicky (){
		if (this.name == "Button 1") {
			if (numm == 0) {
				numm++;
				playSuccess ();
			} else {
				numm = 0;
				playFail ();
			}
		} else if (this.name == "Button 3") {
			if (numm == 1) {
				numm++;
				playSuccess ();
			} else {
				numm = 0;
				playFail ();
			}
		} else if (this.name == "Button Dot") {
			if (numm == 2) {
				numm++;
				playSuccess ();
			} else {
				numm = 0;
				playFail ();
			}
		} else if (this.name == "Button 2") {
			if (numm == 3) {
				numm++;
				playSuccess ();
			} else {
				numm = 0;
				playFail ();
			}
		} else if (this.name == "Button 4") {
			if (numm == 4) {
				numm++;
				playSuccess ();
			} else {
				numm = 0;
				playFail ();
			}
		}
		else if (this.name == "Button Red") {
			if (numm == 5) {
				openDoor ();
				playSuccess ();
				numm = -1;
			} else {
				numm = 0;
				playFail ();
			}
		} else {
			numm = 0;
			playFail ();
		}

	}

	public void openDoor(){
		GameObject thedoor = GameObject.Find("door");
        thedoor.GetComponent<AudioSource>().Play();
		Vector3 vect = thedoor.transform.position;
		Vector3 vect2 = vect + new Vector3(0,5f,0);
		StartCoroutine (MoveOverSeconds (thedoor, vect2, 5f));
	}



}
