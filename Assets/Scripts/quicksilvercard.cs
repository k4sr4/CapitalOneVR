using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class quicksilvercard : MonoBehaviour {

    public bool showDetails = false;

    // Use this for initialization
    void Start()
    {
        GameObject.Find("QuickSilverText").GetComponent<Text>().enabled = false;
    }

    void Update()
    {
        if (showDetails)
        {
            GameObject.Find("QuickSilverText").GetComponent<Text>().enabled = true;
        }
        else
        {
            GameObject.Find("QuickSilverText").GetComponent<Text>().enabled = false;
        }
    }
}
