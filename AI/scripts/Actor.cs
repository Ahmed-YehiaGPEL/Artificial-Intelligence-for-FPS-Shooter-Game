using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {

	Unit unit;
	EnemyDetector detector;

	bool alarmed;


	void Awake(){

		alarmed = false;
		unit = GetComponent<Unit> ();

		detector = GetComponent<EnemyDetector> ();
		unit.enabled = false;


	}
	void Update(){
		if (detector.EnemyVisible ()) {
			alarmed = true;
			if(!unit.enabled)
			unit.enabled = true;
			transform.LookAt (unit.target);
			print ("Visible");
			//attack enemy 
		}

	
		if (!alarmed) {//stable state -> keep searching
				
			alarmed = detector.EnemyVisible ();

		} 

		else {
			print ("heeere");
			if (!unit.moving) {// i know && does not moving 
							
				if (unit.enabled == false)//if first time 
					unit.enabled = true;
				PathRequestManager.RequestPath (transform.position, unit.target.position, unit.OnPathFound);
			} 		
			}

		
		}
	
	
	}



