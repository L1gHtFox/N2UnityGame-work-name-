using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Controll Script/FPS Input")]
public class FPSInput : MonoBehaviour {
    public float speed = 2.5f;
	public float gravity = -1.61f;

    private CharacterController _charController;

	void Start () {
        _charController = GetComponent<CharacterController>();	
	}

	void Update () {

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, gravity, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement); 
	}
}