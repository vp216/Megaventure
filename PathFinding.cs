using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PathFinding : MonoBehaviour {

	//public Transform origin;
	//public Transform destination;

	public InputField ofield;
	public InputField dfield;

	//public GameObject cube;
	private UnityEngine.AI.NavMeshAgent myAgent;

	// Use this for initialization
	void Start () {



	}

	/*talk about invisible cube
	 *First, the trail renderer of the navigation cube  is obtained, disabled and cleared before being enabled again; 
	 *this is to clear the path if the navigation route planner was used previously.
	 *
	 *The invisible cubes' position is then set to the origin objects' position. Its NavMeshAgent is then retrieved.
	 *
	 *Finally, the position of the destination object is obtained and passed to the NavMeshAgents' 'SetDestination' function.
	 *This causes the invisible cube to move to the destination position using the most optimal path, 
	 *with the trail renderer drawing the path on screen.
	 */

	public void findPath() {

		TrailRenderer trail = GetComponent<TrailRenderer> ();

		trail.enabled = false;


		gameObject.transform.position = GameObject.FindGameObjectWithTag (ofield.text).transform.position;

		trail.Clear ();
		trail.enabled = true;

		myAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		//myAgent = cube.GetComponent<UnityEngine.AI.NavMeshAgent> ();

		Vector3 pos = GameObject.FindGameObjectWithTag (dfield.text).transform.position;
		myAgent.SetDestination (pos);

		//trail.enabled = false;
	}



	
	// Update is called once per frame
	void Update () {	
		
	}
}
