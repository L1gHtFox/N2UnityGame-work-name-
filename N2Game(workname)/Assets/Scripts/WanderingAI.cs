using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour {
	public float speed = 2.5f;
	public float obstacleRange = 1.0f;
	public float gravity = -1.6f;
	private bool _alive;
	private CharacterController _charController;
	[SerializeField] private GameObject FierballPrefab;
	private GameObject _fierball;
	public void SetAlive(bool alive){
		_alive = _alive;
	}

	void Start(){
		_charController = GetComponent<CharacterController>();
		_alive = true;
	}

	void Update () {
		if (_alive) {
			float deltaX = speed;
			float deltaZ = speed;
			Vector3 movement = new Vector3 (deltaX, gravity, deltaZ);
			movement = Vector3.ClampMagnitude (movement, speed);

			movement *= Time.deltaTime;
			movement = transform.TransformDirection (movement);
			_charController.Move (movement); 

			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;

			if (Physics.SphereCast (ray, 0.75f, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				if (hitObject.GetComponent<CharReactive> ()) {
					if (_fierball == null) {
						_fierball = Instantiate (FierballPrefab) as GameObject;
						_fierball.transform.position = transform.TransformPoint (Vector3.forward * 1.5f);
						_fierball.transform.rotation = transform.rotation;
					}
				}
				else if (hit.distance < obstacleRange) {
					float angle = Random.Range (-110, 110);
					transform.Rotate (0, angle, 0);
				}
			}
		} else {
			speed = 0;
		}
	}
}
