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

    GameObject invisFloor;
    Vector3 lastPosition;
    bool eyesOnCapOne = false;

    public int correctPics = 0;

    void Start()
    {
        invisFloor = GameObject.FindGameObjectWithTag("InvisibleFloor");        
        lastPosition = new Vector3(0, 0, 0);
    }
	
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
            else if (hit.collider.tag == "CapOne")
            {
                eyesOnCapOne = true;
                if (invisFloor != null)
                {
                    invisFloor.GetComponent<MeshCollider>().enabled = true;
                    Debug.Log("FLOOR ON");
                }
            }
            
            
        }
        if (isPlayerMoving() && !eyesOnCapOne)
        {
            if (invisFloor != null)
            {
                invisFloor.GetComponent<MeshCollider>().enabled = false;
                Debug.Log("FLOOR OFF");
            }
        }
        eyesOnCapOne = false;

        if (correctPics == 3)
        {
            GameObject.FindObjectOfType<OpenDoor>().openDoor();
        }

        if (noMove && eyesOnKeypad)
        {
            GameObject.FindObjectOfType<OVRPlayerController>().canMove = false;
        }
	}

    bool isPlayerMoving()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }
        return false;
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
