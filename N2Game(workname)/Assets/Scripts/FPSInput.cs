using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Controll Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    CharacterController controller;
    public float speed = 2.5f;
    public float gravity = -1.6f;
    float jForce;
    float jSpeed = 01;
    private CharacterController _charController;

    public float timer = 10;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 dir = new Vector3(deltaX, gravity, deltaZ);
        dir = Vector3.ClampMagnitude(dir, speed);
        if (controller.isGrounded)
        {
            jForce = 0;
            if (Input.GetKeyDown(KeyCode.Space)) ;
        }
        jForce = jSpeed;

        _charController.Move(dir);
    }
}
