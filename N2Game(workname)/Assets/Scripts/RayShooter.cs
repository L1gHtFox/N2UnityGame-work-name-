using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour {
	private Camera _camera;
	[SerializeField] private GameObject CrystalPrefab;
	private GameObject _crystal;

	void Start () {
		_camera = GetComponent<Camera> ();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void OnGUI(){
		int size = 12;
		float posX = _camera.pixelWidth / 2 - size / 4;
		float posY = _camera.pixelHeight / 2 - size / 4;
		GUI.Label(new Rect(posX,posY, size, size), "*");
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 point = new Vector3 (_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
					if (_crystal == null) {
						_crystal = Instantiate (CrystalPrefab) as GameObject;
						_crystal.transform.position = transform.TransformPoint (Vector3.forward * 1.5f);
						_crystal.transform.rotation = transform.rotation;
					}
				}
		}
}