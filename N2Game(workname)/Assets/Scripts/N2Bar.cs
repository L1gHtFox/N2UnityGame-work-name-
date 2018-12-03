using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class N2Bar : MonoBehaviour {
	private Slider slider;

	public float currentN2 = 100;
	public float time = 1f;

	private float minN2 = 0;

	public float playerHealth;

	void Start () {
		playerHealth = GameObject.FindWithTag ("Player").GetComponent<HelthBar>().currentHealth;
		slider = GetComponent<Slider> ();
		slider.interactable = false;
		StartCoroutine (MinusN2 (20));
	}
		

	public IEnumerator MinusN2(float n){
		while(currentN2 >= minN2){
			yield return new WaitForSeconds(time);
			currentN2 -= n;
			slider.value = currentN2;
		}
		if (currentN2 < minN2) {
			playerHealth -= 10;
		}
	}
}
