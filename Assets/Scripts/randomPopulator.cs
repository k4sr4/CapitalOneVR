using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class randomPopulator : MonoBehaviour {

	public GameObject chasePrefab;
	public GameObject capOnePrefab;
	public GameObject citiPrefab;

	int xLowerBound;
	int xUpperBound;
	int zLowerBound; 
	int zUpperBound;
	int yLowerBound;
	int yUpperBound;

	int numOfElements;
	List<GameObject> prefabList;

	private Color[] colors;

	// Use this for initialization
	void Start () {
		xLowerBound = -20;
		xUpperBound = 24;
		zLowerBound = -19; 
		zUpperBound = 19;
		yLowerBound = 0;
		yUpperBound = 3;

		numOfElements = 30;

		prefabList = new List<GameObject>();

		generateElements ();


	}
	
	// Update is called once per frame
	void Update () {
		/*if (Time.frameCount % 2000 == 1) {
			destroyElements ();
			generateElements ();
		}*/

	}

	private void generateElements(){
		for(int i = 0; i < numOfElements; i++){
			int xRange = Random.Range (xLowerBound, xUpperBound);
			int zRange = Random.Range (zLowerBound, zUpperBound);
			int yRange = Random.Range (yLowerBound, yUpperBound);

			float rotationX = Random.Range(0f, 360f) ;
			float rotationY = Random.Range(0f, 360f) ;
			float rotationZ = Random.Range(0f, 360f) ;

			GameObject gameObj = Instantiate(companySelector(), new Vector3(xRange, yRange, zRange), 
				Quaternion.Euler(new Vector3(rotationX, rotationY, rotationZ))) as GameObject;
			prefabList.Add(gameObj);
		}
	}

	private void destroyElements(){
		foreach(GameObject gameObj in prefabList){
			Destroy (gameObj);
		}
	}

	private GameObject companySelector(){
		int selector = Random.Range (1, 3);	
		if(selector == 1){
			return capOnePrefab;
		} else if(selector == 2){
			return chasePrefab;
		} else {
			return citiPrefab;
		}
	}
}
