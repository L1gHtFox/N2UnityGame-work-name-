using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwordDamage : MonoBehaviour
{
    public EnemyAI eai;
    public float t;
    public float AttacTime = 2.5f;
    public float uron = 10f;

    void Start()
    {
        eai = GetComponent<EnemyAI>();
    }

    void Update()
    {
    }

    IEnumerator Damage(Collider playerr)
    {
        yield return new WaitForSeconds(0.12f);
        playerr.gameObject.GetComponent<PlayerUI>().PlayerDamage(uron);
    }

    public void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.GetComponent<PlayerUI>())
        {

            if (Time.time - t > AttacTime)
            {
                StartCoroutine(Damage(other));
                t = Time.time;
            }
        }
    }
}

