using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Move_character : MonoBehaviour
{
    //основные параметры
    public float moveSpeed = 5f; //скорость передвижение
    public float acceleration = 4f; //увелечение скорости передвижения
    public float jForce = 9f; //сила прыжка
    public float gravityForce = 0; //сила гравитации

    //геймплей героя
    private CharacterController ch_character;
    private Vector3 moveVector = Vector3.zero; //обнуляем позицию;

    //переменная для джойстика
    private Mobile_controll mob_c;


    private void Start()
    {        
        ch_character = GetComponent<CharacterController>();
        mob_c = GameObject.FindGameObjectWithTag("Joystick_BG").GetComponent<Mobile_controll>();
    }
    

    private void Update()
    {
        action_character();
        gravity_hero();
    }

    //гравитация, действующая на героя
    private void gravity_hero()
    {
        if (!ch_character.isGrounded) gravityForce -= 50f * Time.deltaTime;
        else gravityForce = -1f;

        Jump(); //добавляем действие "прыжок"
    }

    //метод действий
    private void action_character()
    {        
        //добавляем возможность передвижения
        moveVector.x = mob_c.Horizontal() * moveSpeed;        
        moveVector.z = mob_c.Vertical() * moveSpeed;
        
        acceleration_hero(); //добавляем ускорение героя
        
        moveVector = transform.TransformDirection(moveVector);
        
        //добавляем гравитацию
        moveVector = Vector3.ClampMagnitude(moveVector, moveSpeed);
        moveVector.y = gravityForce;

        //сглаживаем движения героя
        moveVector *= Time.deltaTime;
        ch_character.Move(moveVector);
    }

    //метод ускорения
    private void acceleration_hero()
    {
        if (Input.GetButtonDown("Run")) moveSpeed += acceleration;
        else if (Input.GetButtonUp("Run")) moveSpeed -= acceleration;
    }

    //метод прыжка
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && ch_character.isGrounded) gravityForce = jForce;            
    }   
}