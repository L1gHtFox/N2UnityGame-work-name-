using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Controll Script/FPS Input")]
public class FPSInput : MonoBehaviour {
    public float speed;
    private float tired=6f; // для голода и жажды
    private float jForce=12f;
    private float gravity;
    private Vector3 movement;
    public float Stamina = 100;

    float MaxStamina = 100f;
    bool bRun;

    private CharacterController _charController;

	void Start () {
        _charController = GetComponent<CharacterController>();
        movement = Vector3.zero;
	}

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, gravity, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);

        if (_charController.isGrounded) gravity = -9f;
        else gravity -= 50f * Time.deltaTime;
        if (Stamina > 10)
        {
            if (Input.GetButtonDown("Jump") && _charController.isGrounded)      //прыжок выполнен в виде уменьшения гравитации и возвращении в прежнее значение
            {
                gravity = jForce;                           
                Stamina -= 15;
            }
        }
        if (Input.GetButton("Run") && Stamina>1)
        {

            bRun = true;

                speed += Time.deltaTime * 10;             // для того, чтобы бег казался правдоподобнее(идет плавный разгон)
                if (speed > 15) speed = 15;
                Stamina -= Time.deltaTime * 9;           //трата стамины должна быть больше, чем ее получение, чтобы не было обуза
                if (Stamina < 0) Stamina = 0;

        }
        else
        {
            bRun = false;

            speed -= Time.deltaTime * 17;        // для того, чтобы бег казался правдоподобнее(идет плавная остановка)
            if (speed < 8) speed = 8;
            Stamina += Time.deltaTime * 3;       //трата стамины должна быть больше, чем ее получение, чтобы не было обуза
            if (Stamina > 100) Stamina = 100;
        }
        }

    }
