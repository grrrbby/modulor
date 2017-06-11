using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
public class GenerateMesh : MonoBehaviour {


	Vector3[] vertices = new Vector3[]{};
	Vector3[] normals = new Vector3[]{};
	Vector2[] uvs = new Vector2[]{};

	// Use this for initialization
	void Start () {
		
		MeshFilter mf = GetComponent<MeshFilter> ();
		if (mf.sharedMesh == null) {
			mf.sharedMesh = new Mesh ();
		}
		Mesh mesh = mf.sharedMesh;

		mesh.Clear ();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
