using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelthBar : MonoBehaviour {
	[SerializeField]
	private Slider HpSlider;

	public float currentHealth = 100;

	private float maxHealth = 100;
	private float minHealth = 0;

	void Star(){
		
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.E)) {
			PlayerDamage (10);
		}
		if(Input.GetKeyDown(KeyCode.R)){
			PlayerHealing(10);
		}
	}

	public void PlayerDamage (float damage){
		currentHealth -= damage;
		HpSlider.value = currentHealth;
		if (currentHealth < 0) {
			currentHealth = minHealth;
		}
	}

	public void PlayerHealing(float healing){
		
		currentHealth += healing;
		HpSlider.value = currentHealth;
	}
}
