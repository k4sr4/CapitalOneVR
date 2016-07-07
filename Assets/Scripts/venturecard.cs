using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class venturecard : MonoBehaviour {

    public bool showDetails = false;

    // Use this for initialization
    void Start()
    {
        GameObject.Find("VentureText").GetComponent<Text>().enabled = false;
    }

    void Update()
    {
        if (showDetails)
        {
            GameObject.Find("VentureText").GetComponent<Text>().enabled = true;
        }
        else
        {
            GameObject.Find("VentureText").GetComponent<Text>().enabled = false;
        }
    }
}
