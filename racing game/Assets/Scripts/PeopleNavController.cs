using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PeopleNavController : MonoBehaviour {

	public Transform target;
	NavMeshAgent agent;
	Vector3 origin;

	// Use this for initialization
	void Start () {
		origin = GetComponent<Transform> ().position;
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination (target.position);
		if (GetComponent<Transform> ().position == target.position) {
			agent.SetDestination (origin);
		}
	}
}
