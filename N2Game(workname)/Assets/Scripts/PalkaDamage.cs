using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalkaDamage : MonoBehaviour
{
   float pDamage = 10f;
    float speed = 300f;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerUI>())
        {
            other.gameObject.GetComponent<PlayerUI>().PlayerDamage(pDamage);
        }
        if (other.gameObject.GetComponent<EnemyAI>())
        {
            other.gameObject.GetComponent<EnemyAI>().TakeDamageFromMelee(pDamage);
        }
    }

}
