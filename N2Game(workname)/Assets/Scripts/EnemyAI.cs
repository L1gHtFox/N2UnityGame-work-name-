using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
	public GameObject playerCharecter;
	public float dist;
	NavMeshAgent nav;
	public float radius = 10;

	void Start () {
		nav = GetComponent<NavMeshAgent> ();
	}

	void Update () {
		dist = Vector3.Distance (playerCharecter.transform.position, transform.position);
		if (dist > radius) {
			nav.enabled = false;
			gameObject.GetComponent<Animator> ().SetTrigger ("Idle");
		} 
		if(dist < radius){
			nav.enabled = true;
			nav.SetDestination (playerCharecter.transform.position);
			gameObject.GetComponent<Animator> ().SetTrigger ("Walk");
		}
	}
}
