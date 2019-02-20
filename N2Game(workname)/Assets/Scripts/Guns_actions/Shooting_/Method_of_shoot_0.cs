using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Method_of_shoot_0 : MonoBehaviour
{
    //скорость полета снаряда
    public float speed = 80;

    private void Update()
    {
        FirstWayShoot();
    }

    private void FirstWayShoot()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);       
    }    

    private void OnCollisionEnter (Collision other)
    {
        Destroy(gameObject);
    }
}