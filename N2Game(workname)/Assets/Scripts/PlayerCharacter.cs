using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {
	public float _health;
	public float _N2;
	public bool _HaveN2 = true;
	public Image UIHealth;
	public Image UIN2;

	void OnTriggerEnter(Collider N2transitor){
		if(_HaveN2 == true){
		_HaveN2 =false;
		}else{
			_HaveN2 = true;
		}
	}

	void FixedUpdate () {
		if (_HaveN2 == true && _N2 <= 1f && _N2 >0) {
			_N2 = _N2 - 0.1f * Time.deltaTime;
		} else if(_N2<1f && _N2>=-0.002f) {
			_N2 += 0.1f * Time.deltaTime;
		}
		UIHealth.fillAmount = _health;
		UIN2.fillAmount = _N2;
		if (_N2 <= 0) {
			_health = _health - 0.01f * Time.deltaTime;
		}
	}

	public void Hurt(float damage){
		_health -= damage;
		Debug.Log ("Helth: " +_health);
		if (_health < 0) {
			Debug.Log ("You died");
		}
	}
}
