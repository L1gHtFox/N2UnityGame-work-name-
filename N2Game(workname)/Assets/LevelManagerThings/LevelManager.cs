using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	private static LevelManager instance;

	void Awake () {
		if (!instance) {
			instance = this;
		} else 
		{
			Destroy (this.gameObject);
		}
		LevelManager (this.gameObject);
	}
}