using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fierball : MonoBehaviour {
	public float speed = 10.0f;
	public float damage = 0.1f;

	void Start () {
		
	}

	void Update () {
		transform.Translate (0, 0, speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		ReactiveTarget target = other.GetComponent<ReactiveTarget> ();
			if(target != null){
			target.ReactToHit();
		}
		Destroy (this.gameObject);
	}
}
