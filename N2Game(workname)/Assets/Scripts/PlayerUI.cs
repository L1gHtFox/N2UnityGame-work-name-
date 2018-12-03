using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelthBar : MonoBehaviour {
	[SerializeField]
	private Slider HpSlider;
	private Slider N2Slider;

	public float currentHealth = 100;
	public float currentN2 = 100;

	private float maxHealth = 100;
	private float minHealth = 0;

	private float maxN2 = 100;
	private float minN2 = 0;

	public float time = 1f;

	void Star(){
		StartCoroutine(MinusN2(20));
	}

	void Update(){
		if (currentN2 <= minN2) {
			PlayerDamage (20);
		}
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

	public IEnumerator MinusN2(float n){
		while(currentN2 >= minN2){
			yield return new WaitForSeconds(time);
			currentN2 -= n;
			N2Slider.value = currentN2;
		}
}
