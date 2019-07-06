using UnityEngine;

public class Mobile_cameraRotation : MonoBehaviour
{    
    //чувствительность вращения камеры
    private float sensivityCamera = 40;

    //максимальное/минимальное значение поворота камеры по оси X
    [HideInInspector] public float maxRotX = 50;
    [HideInInspector] public float minRotX = -55;

    //максимальное/минимальное значение поворота камеры по оси Y
    [HideInInspector] public float maxRotY = 50;
    [HideInInspector] public float minRotY = -50;

    //включатели ограничений по осям XY
    [HideInInspector] public bool frameRotX;
    [HideInInspector] public bool frameRotY;

    //оси вращения X и Y
    public float _rotationX;
    public float _rotationY;


    //ссылка на скрипт, считывающий координаты нажатия
    private FixedTouchField coord;


    public enum RotationAxes
    {
        rotationX = 1,
        rotationY = 0        
    }
    public RotationAxes rotation;


    private void Start()
    {                
        coord = GameObject.Find("Touch").GetComponent<FixedTouchField>();
    }

    private void FixedUpdate()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        switch (rotation)
        {     
            case RotationAxes.rotationX:
                {
                    frameRotX = true;

                    _rotationX += coord.coordinateX() * sensivityCamera * Time.deltaTime;
                    transform.localEulerAngles = new Vector3(0, _rotationX, 0);
                }

                break;

            case RotationAxes.rotationY:
                {
                    frameRotY = true;

                    _rotationY += coord.coordinateY() * sensivityCamera * Time.deltaTime;
                    transform.localEulerAngles = new Vector3(-_rotationY, 0, 0);                    
                }

                break;
        }
    }
}
