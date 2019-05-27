using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Method_of_shootingProjectileGun_0 : MonoBehaviour
{
    //скорость полета снаряда
    public float speed = 80;

    private void Update()
    {
        NullWayShoot();
    }

    private void NullWayShoot()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    //столкновение снаряда
    private void OnCollisionEnter(Collision other)
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
