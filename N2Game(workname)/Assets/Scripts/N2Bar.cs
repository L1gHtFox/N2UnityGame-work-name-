using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class N2Bar : MonoBehaviour {
	private Slider slider;

	public float currentN2 = 100;
	public float time = 1f;

	private float minN2 = 0;



	void Start () {
		slider = GetComponent<Slider> ();
		slider.interactable = false;
		StartCoroutine (MinusN2 (2));
	}

	public IEnumerator MinusN2(float n){
		while(currentN2 >= minN2){
			yield return new WaitForSeconds(time);
			currentN2 -= n;
			slider.value = currentN2;
		}
	}
}
