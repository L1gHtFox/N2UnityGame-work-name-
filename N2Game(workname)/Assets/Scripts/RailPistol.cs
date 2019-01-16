﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailPistol : MonoBehaviour {

	public float damage = 10f;
	public float range = 100f;

	public float impactForse = 30f;

	public ParticleSystem muzzleFlash;
	public GameObject impactEffect;

	public Camera fpsCam;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Shoot ();
		}
	}

	void Shoot(){
		muzzleFlash.Play();
		RaycastHit hit;

		if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
			Debug.Log (hit.transform.name);

			Target target = hit.transform.GetComponent<Target> ();
			if (target != null) {
				target.TakeDamage (damage);
			}

			if (hit.rigidbody != null) {
				hit.rigidbody.AddForce (-hit.normal * impactForse);
			}

			GameObject impactGO = Instantiate (impactEffect, hit.point, Quaternion.LookRotation (hit.normal));
			Destroy (impactGO, 2f);
		}
	}
}
