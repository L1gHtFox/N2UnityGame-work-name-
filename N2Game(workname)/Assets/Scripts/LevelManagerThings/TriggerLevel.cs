using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLevel : MonoBehaviour {
	public GameObject panel;
	public int levelCount;
	public FPSInput fpsi;
	public MouseLook playerLook;
	public MouseLook camLook;
	public RayShooter rayShooter;

	void OnTriggerEnter (Collider col) {
		if (col.tag == "Player") 
		{
			panel.SetActive (true);
		}
		fpsi.enabled = false;
		camLook.enabled = false;
		playerLook.enabled = false;
		rayShooter.enabled = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	void OnTriggerExit (Collider col) 
	{
		if (col.tag == "Player") 
		{
			Back ();
		}
	}

	public void NextLevel()
	{
		SceneManager.LoadScene (levelCount);
	}

	public void Back()
	{
		panel.SetActive (false);
	}
}