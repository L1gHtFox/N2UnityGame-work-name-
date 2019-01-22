using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Controll Script/FPS Input")]
public class FPSInput : MonoBehaviour
{

    private CharacterController _charController;
    private Vector3 movement;


    int secs = 3;
    public float speed;
    private float walkspeed = 5;
    private float shiftspeed = 12;
    private float szspeed = 8;

    private float jForce = 14;
    private float gravity;

    public float Stamina = 100;
    float MaxStamina = 100;

    bool SafeZone;

    bool bRun;
    bool bWalk;
    bool grounded;
    public bool Idle = false;


    void Start()
    {
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

        if (_charController.isTrigger) SafeZone = !SafeZone;
        if (_charController.isGrounded) gravity = -15f;
        else
        {
            gravity -= 50 * Time.deltaTime;
        }


        // MOVEMENT  //////////////////////////////////////
        if (Stamina < 0) Stamina = 0;
        if (Stamina > 100) Stamina = 100;


        // IDLE  //////////////////////////////////////
        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal") || Input.GetButtonDown("Jump")) Idle = false;
        else if(_charController.isGrounded) Idle = true;

        if (Input.GetButton("SafeZone")) SafeZone = !SafeZone;

        if (Input.GetButtonDown("Walk")) bWalk = !bWalk;
        
        if (Idle == true) Stamina += Time.deltaTime * 12;

        

        //CORE   ////////////////////////////
        if (SafeZone == false)
        {
            if (Stamina >= 10)
            {
                if (Input.GetButtonDown("Jump") && _charController.isGrounded)
                {
                    gravity = jForce;
                    Stamina -= 10;
                    bWalk = false;
                }
            }
            //runnig  ///////////////////
            if (Input.GetButton("Run") && Stamina > 1 && _charController.isGrounded )
            {
                bWalk = false;
                bRun = true;
                
                speed += Time.deltaTime * 10;
                if (speed > shiftspeed) speed = shiftspeed;
                Stamina -= Time.deltaTime * 15;
            }

            else 
            //standart //////////////////////////
                if(bWalk==false && _charController.isGrounded)
                {
                    speed -= Time.deltaTime * 14;
                    if (speed < 8) speed = 8;
                }
            else
            //walking  //////////////////////////
            if (_charController.isGrounded && bWalk == true)
            {
                bWalk = true;
                bRun = false;

                Stamina += Time.deltaTime * 8;
                    speed -= Time.deltaTime * 10;
                    if (speed < walkspeed) speed = walkspeed;
            if(Idle == true && bWalk == true) Stamina += Time.deltaTime * 12;
            }
        }


        else

        if (SafeZone == true)
        {
            // safezone running ////////////////////////////////////////////
            if (Input.GetButton("Run") && _charController.isGrounded) 
            {
                bRun = true;

                speed += Time.deltaTime * 10;
                if (speed > szspeed) speed = szspeed;

            }
            else
            // safezone standart ////////////////////////////
            {
                bRun = false;
                speed -= Time.deltaTime * 17;
                if (speed < walkspeed) speed = walkspeed;
            }

        }
        if (Stamina < 0) Stamina = 0;
        if (Stamina > 100) Stamina = 100;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (SafeZone == false) SafeZone = true;
        else SafeZone = false;
    }

}




