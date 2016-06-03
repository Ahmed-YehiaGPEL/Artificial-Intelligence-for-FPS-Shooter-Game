using UnityEngine;
using System.Collections;

public class Eye : MonoBehaviour {


	string parentName;

	void Start () {
		parentName = transform.parent.name;
	}

	void FixedUpdate () {

		Vector3 v = GameObject.Find (parentName).transform.position;
		v.y = 1.551f;
		transform.position = v;


	}
}
