using UnityEngine;
using System.Collections;

public class  EnemyDetector: MonoBehaviour {


	private GameObject target;
	private Camera eye;
	private Unit unit;


	private Collider targetCollider;
	private Plane[] planes;




	void Start () {
		
		target = GameObject.Find("Sphere");

		eye = GetComponentInChildren<Camera>();

		targetCollider = target.GetComponent<Collider>();

		unit = GetComponent<Unit> ();


	}


	public bool EnemyVisible(){
		planes = GeometryUtility.CalculateFrustumPlanes (eye);
		if(GeometryUtility.TestPlanesAABB(planes,targetCollider.bounds)){

			RaycastHit hit;
			Vector3 start = transform.position;
			Vector3 RayDirection = -1 * start + target.transform.position; 
		
			if (Physics.Raycast (start, RayDirection, out hit, 100.0f)) {
				string nm = hit.collider.gameObject.name;
				if (nm == "Sphere") {

					return true;
				}
				return false;
			}
			else
				return false;
		}
		else 
			return false;

	}


}