using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Method_of_shoot_1 : MonoBehaviour
{
    //скорость полета снаряда
    public float speed = 25;
    public float time = 0;

    private void Update()
    {
        time += 1 * Time.deltaTime;

        SecondWayShoot();
    }

    public void SecondWayShoot()
    {
        transform.Translate(Vector3.forward * speed * time);             
    }

    private void OnCollisionEnter (Collision other)
    {
        Destroy(gameObject);
    }
}