using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelthBar : MonoBehaviour {

	public void Healing(int value){
		
		GetComponent<Slider> ().value += value;

	}
}
