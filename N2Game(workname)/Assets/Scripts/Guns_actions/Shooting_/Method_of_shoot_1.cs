using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Method_of_shoot_1 : MonoBehaviour
{
    //скорость полета снаряда
    public float speed = 25;

    private void Update()
    {        
        SecondWayShoot();
    }

    public void SecondWayShoot()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);             
    }

    private void OnCollisionEnter (Collision other)
    {
        speed = 0;

        Destroy(gameObject);
    }
}