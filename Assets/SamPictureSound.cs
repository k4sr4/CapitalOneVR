using UnityEngine;
using System.Collections;

public class SamPictureSound : MonoBehaviour {

    public void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
}
