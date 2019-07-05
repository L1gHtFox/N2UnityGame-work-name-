using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{    
    //чувствительность вращения камеры
    private float sensivityCamera = 40;

    //максимальное/минимальное значение поворота камеры
    private float maxVert = 0.3f;
    private float minVert = -0.3f;

    //оси вращения X и Y
    private float _rotationX;
    private float _rotationY;

    //ссылка на скрипт, считывающий координаты нажатия
    private FixedTouchField coord;

    Transform ransform;

    public enum RotationAxes
    {
        vectorX = 0,
        vectorY = 1
    }
    public RotationAxes vector;


    private void Start()
    {                
        coord = GameObject.Find("Touch").GetComponent<FixedTouchField>();
    }

    private void FixedUpdate()
    {
        cameraRotation();
    }

    private void cameraRotation()
    {
        switch (vector)
        {            
            case RotationAxes.vectorX:
                {
                    transform.Rotate(0, coord.coordinateX() * sensivityCamera * Time.deltaTime, 0);
                }

              break;

            case RotationAxes.vectorY:
                {
                    _rotationY = coord.coordinateY() * sensivityCamera * Time.deltaTime;

                    if (transform.rotation.x <= maxVert && transform.rotation.x >= minVert)
                        transform.Rotate(-_rotationY, 0, 0);
                }

                break;
        }
    }

}
