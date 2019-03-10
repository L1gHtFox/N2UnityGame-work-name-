using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autojump : MonoBehaviour
{
    float jumpforce = 12f;
    public EnemyAI eai;
    void Start()
    {
        eai = GetComponent<EnemyAI>();
    }

    void Update(){}

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kub"))
        {
            Debug.Log("Kub tut");
 //           eai.jump();
        }
    }
}
