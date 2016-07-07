using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Raycast : MonoBehaviour {

    RaycastHit hit;

    public float distance = 5f;

    public bool grabbed = false;

    bool noMove = false;
    bool eyesOnKeypad = false;

    public Text quickText, ventureText, platinumText;

    public int correctPics = 0;
    bool canOpen = true;    
	// Update is called once per frame
	void Update () {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (ventureText != null && quickText != null && platinumText != null)
        {
            ventureText.enabled = false;
            quickText.enabled = false;
            platinumText.enabled = false;
        }

        if (Physics.Raycast(transform.position, fwd, out hit, distance))
        {

            if (hit.collider.tag == "Grab")
            {                
                if (Input.GetMouseButtonDown(0) && !grabbed)
                {                    
                    grabbed = true;
                    if (transform.rotation.y > 275f && transform.rotation.y < 90f)
                    {
                        hit.collider.transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z + 1.5f);
                    }
                    else if (transform.rotation.y > 90f && transform.rotation.y < 275f)
                    {
                        hit.collider.transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z - 1.5f);
                    }
                    hit.collider.transform.parent = this.transform;

                    if (hit.collider.gameObject.name == "Samuel")
                    {
                        FindObjectOfType<SamPictureSound>().PlaySound();
                    }
                }
            }
            else if (hit.collider.tag == "Venture")
            {
                ventureText.enabled = true;
            }
            else if (hit.collider.tag == "Platinum")
            {
                platinumText.enabled = true;
            }
            else if (hit.collider.tag == "QuickSilver")
            {
                quickText.enabled = true;
            }
            else if (hit.collider.tag == "Keypad")
            {
                eyesOnKeypad = true;
            }
            
            
        }

        if (correctPics == 3 && canOpen == true)
        {
            canOpen = false;
            GameObject.FindObjectOfType<OpenDoor>().openDoor();
        }

        if (noMove && eyesOnKeypad)
        {
            GameObject.FindObjectOfType<OVRPlayerController>().canMove = false;
        }
	}

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "KeypadGround")
        {
            noMove = true;
        }
        else if (other.tag == "EndLevel")
        {
            Debug.Log("loading next scene");
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            if (currentScene == 4)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(currentScene + 1);
            }
        }
    }
}
