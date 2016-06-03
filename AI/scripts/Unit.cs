using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public Transform target;
	public Vector3 targetOldPos;
	public bool attack;
	float speed = 4;
	public Vector3[] path;
	int targetIndex;
	public bool moving;
	Rigidbody rb;


	void Start() {
		moving = false;
		rb = GetComponent<Rigidbody>();
	}

	public void OnPathFound(Vector3[] newPath, bool pathSuccessful) {
		if (pathSuccessful) {
			path = newPath;

			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}

	public IEnumerator FollowPath() {
		Vector3 currentWaypoint = path[0];
		//print (transform.gameObject.name + " " + currentWaypoint);
		while (true) {
			if (transform.position == currentWaypoint) {
				targetIndex ++;


				if (targetIndex >= path.Length - 1) {
					
					yield break;

				}
				currentWaypoint = path[targetIndex];
			}			
			transform.LookAt (currentWaypoint);

			if (Vector3.Distance (transform.position, target.position) <= 8 && Vector3.Distance (transform.position, target.position) > 2) {
				StopCoroutine ("FollowPath");
				yield break;
			}

		
			transform.position = Vector3.MoveTowards (transform.position, currentWaypoint, speed * Time.deltaTime);
			yield return null;
		}
	}
}
