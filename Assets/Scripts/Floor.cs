using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {
	
	[Header("The space between each pylon.")][SerializeField][Range(1.1f,10f)]
	float pylonGap = 3;
	[Header("The gap left between each pylon for the floor tile")][Range(1,2f)]
	public float floorHeight = 1.1f;
	[Header("The number of pylons along each axis.")][SerializeField][Range(1,30f)]
	float nPylonsX = 4;
	[SerializeField][Range(1,30f)]
	float  nPylonsY = 3;
	[SerializeField][Range(1,30f)]
	float  nPylonsZ = 5;

	[Header("Click to set to above values")][SerializeField]
	public bool change;

	public GameObject pylon;
	public GameObject floor;

	List<GameObject> pylons = new List<GameObject>();
	List<GameObject> floors = new List<GameObject>();

	void LayPylons(){

		change = false;

		foreach (GameObject py in pylons) {
			DestroyImmediate (py);
		}

		foreach (GameObject fl in floors) {
			DestroyImmediate (fl);
		}
			
		GameObject go;
		Vector3 position = this.transform.position;
		Vector3 scale = new Vector3 (1f, 2f, 1f);
		for (int x = 0; x < nPylonsX; x++) {
			for (int y = 0; y < nPylonsY; y++) {
				for (int z = 0; z < nPylonsZ; z++) {

					position.x = x * pylonGap;
					position.y = y * 4.5f;
					position.y *= floorHeight;
					position.z = z * pylonGap;
					go = Instantiate (pylon, position, Quaternion.identity, this.transform);
					pylons.Add (go);
					position = go.transform.position;
					position.y += 4f;
					scale = new Vector3 (pylonGap, 0.4f, pylonGap);
					go = Instantiate (floor, position, Quaternion.identity, go.transform);
					go.transform.localScale = scale;
				}
			}
		}
	}
	
	void Update(){
		if (change == true) {
			LayPylons ();
		}
	}
}