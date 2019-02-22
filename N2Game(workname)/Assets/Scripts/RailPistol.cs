using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RailPistol : MonoBehaviour {

	public float damage = 10f;
	public float range = 100f;
	public float impactForse = 30f;

	public float allAmmo = 180f;
	public float ammo = 30f;
	public float takeAmmo = 0f;
	public float currentAmmo = 30f;
	public Text ammoInMagazineText; 
	public Text allAmmoText;

	public ParticleSystem muzzleFlash;
	public GameObject impactEffect;

	public Camera fpsCam;

	void Start()
    {
		ammoInMagazineText = GameObject.Find ("AmmoInMagazine_1").GetComponent<Text>();
		allAmmoText = GameObject.Find("Full_Ammo_1").GetComponent<Text>();

		ammoInMagazineText.text = currentAmmo.ToString();
		allAmmoText.text = allAmmo.ToString();
	}

	public void Update ()
    {
		if (Input.GetButtonDown ("Fire1") && currentAmmo > 0) {
			currentAmmo -= 1f;
			ammoInMagazineText.text = currentAmmo.ToString ();
			Shoot ();
		}

		if((Input.GetButtonDown("Fire1") && currentAmmo <= 0) | (Input.GetKeyDown(KeyCode.R))){
			StartCoroutine(Reloading());
		}
	}

	private void Shoot()
    {
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

	IEnumerator Reloading()
    {
	    if (allAmmo != 0)
        {
			ammoInMagazineText.text = "Reloading";
			yield return new WaitForSeconds (3);
			takeAmmo = ammo - currentAmmo;
			allAmmo -= takeAmmo;
			currentAmmo += takeAmmo;
			ammoInMagazineText.text = currentAmmo.ToString ();
			allAmmoText.text = allAmmo.ToString ();
		}
	}
}
