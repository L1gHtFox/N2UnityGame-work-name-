using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Controll Script/FPS Input")]
public class FPSInput : MonoBehaviour {
    public float speed = 2.5f;
	public float gravity = -1.61f;
    public float jumpForce = 3f;
    public Vector3 movement = Vector3.zero;

	void Start () {

	}

    void Update() {
        CharacterController controller = gameObject.GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            movement = new Vector3(Input.GetAxis("Horizontal")* speed, 0, Input.GetAxis("Vertical")*speed);
            movement = transform.TransformDirection(movement);
            if (Input.GetKeyDown(KeyCode.Space)) ;
            {
                movement.y = jumpForce;
            }
            movement.y -= gravity * Time.deltaTime;
            controller.Move(movement * Time.deltaTime);

        }
    }
}