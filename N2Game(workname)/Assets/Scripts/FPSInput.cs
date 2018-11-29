using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Controll Script/FPS Input")]
public class FPSInput : MonoBehaviour {
    private float speed=10f;
    private float jForce=12f;
    private float gravity;
    private Vector3 movement;
    private CharacterController _charController;

	void Start () {
        _charController = GetComponent<CharacterController>();
        movement = Vector3.zero;
	}

	void Update () {
            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaZ = Input.GetAxis("Vertical") * speed;
            Vector3 movement = new Vector3(deltaX, gravity, deltaZ);
            movement = Vector3.ClampMagnitude(movement, speed);
            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
        _charController.Move(movement);
        if (_charController.isGrounded) gravity =-9f;
        else gravity -=50f *Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space) && _charController.isGrounded) gravity = jForce; 
        }

    }
