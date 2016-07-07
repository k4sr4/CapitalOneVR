using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

    public IEnumerator MoveOverSpeed(GameObject objectToMove, Vector3 end, float speed)
    {
        // speed should be 1 unit per second
        while (objectToMove.transform.position != end)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
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

    public void openDoor()
    {
        GameObject thedoor = GameObject.Find("door");
        Vector3 vect = thedoor.transform.position;
        Vector3 vect2 = vect + new Vector3(0, 2.5f, 0);
        StartCoroutine(MoveOverSeconds(thedoor, vect2, 5f));
    }
}
