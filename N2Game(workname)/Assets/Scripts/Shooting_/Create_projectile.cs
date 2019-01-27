using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_projectile : MonoBehaviour
{
    private GameObject _prefabProjectile;
    private GameObject _camera;
     
    void Start()
    {
        _prefabProjectile = Resources.Load("projectile") as GameObject;
        _camera = GameObject.FindWithTag("MainCamera");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(_prefabProjectile);

            projectile.transform.position = _camera.transform.TransformPoint(Vector3.forward * 1.5f);
            projectile.transform.rotation = _camera.transform.rotation;
        }
    }
}