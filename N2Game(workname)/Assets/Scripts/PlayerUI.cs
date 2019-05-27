using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
	public Slider HpSlider;
	public Slider N2Slider;

	public float currentHealth = 100f;

	private float maxHealth = 100f;
	private float minHealth = 0f;
    private bool alive = true;

	public float currentN2 = 100;

	private float minN2 = 0;

	public float time = 1f;


	void Star(){
		StartCoroutine(MinusN2(20));
	}

	void Update(){
        HpSlider.value = currentHealth;
		N2Slider.value = currentN2;

		if (currentN2 <= minN2) {
			PlayerDamage (20);
		}

	}

	public void PlayerDamage (float amount){
		currentHealth -= amount;
		HpSlider.value = currentHealth;
		if (currentHealth <= 0) {
			currentHealth = minHealth;
            alive = false;
            gameObject.SetActive(false);
		}
	}
    public void PlayerDamageFromBullet(float amount, Vector3 hitPoint)
    {
        currentHealth -= amount;
        HpSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            currentHealth = minHealth;
            alive = false;
            gameObject.SetActive(false);
        }
    }

    public void PlayerHealing(float healing){

		currentHealth += healing;
		HpSlider.value = currentHealth;
		if (currentHealth > 0) {
			currentHealth = maxHealth;
		}
	}

	public IEnumerator MinusN2(float n){
		while(currentN2 >= minN2){
			yield return new WaitForSeconds(time);
			currentN2 = currentN2 - n;
			N2Slider.value = currentN2;
		}
		if (currentN2 <= minN2) {
			PlayerDamage (20);
		}
	}
}