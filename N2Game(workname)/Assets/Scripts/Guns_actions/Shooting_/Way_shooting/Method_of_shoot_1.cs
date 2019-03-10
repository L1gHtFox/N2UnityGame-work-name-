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
        FirstWayShoot();
    }

    private void FirstWayShoot()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);             
    }
    
    //столкновение снаряда
    private void OnCollisionEnter (Collision other)
    {
        StartCoroutine(projectile_action());
    }

    //последовательность действий при столкновении снаряда
    private IEnumerator projectile_action()
    {
        speed = 0;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}