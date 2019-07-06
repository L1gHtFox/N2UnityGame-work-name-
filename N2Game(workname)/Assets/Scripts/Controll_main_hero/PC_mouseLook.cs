using UnityEngine;

public class PC_mouseLook : MonoBehaviour
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

    public enum RotationAxes
    {
        rotationX = 0,
        rotationY = 1,
        rotationXY = 2
    }
    public RotationAxes rotation;


    private void Start()
    {
        
    }

    private void Update ()
    {
        CameraRotation();
  //      if (axes == RotationAxes.rotationX) {
  //        transform.Rotate(0, Input.GetAxis("Mouse X") * sensivityCamera, 0);
  //      }
  //else if (axes == RotationAxes.MouseY)
  //      {
  //          _rotationX -= Input.GetAxis("Mouse Y") * sensivityCamera;
  //          _rotationX = Mathf.Clamp(_rotationX, minRotX, maxRotX);
  //          float rotationY = transform.localEulerAngles.y;
  //          transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);

        //      }
        //      else
        //      {
        //          _rotationX -= Input.GetAxis("Mouse Y") * sensivityCamera;
        //          _rotationX = Mathf.Clamp(_rotationX, mixRotX, maxRotX);

        //          float delta = Input.GetAxis("Mouse X") * sensivityHor;
        //          float rotationY = transform.localEulerAngles.y + delta;

        //          transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        //      }
    }

    private void CameraRotation()
    {
        switch (rotation)
        {
            case RotationAxes.rotationX:
                {
                    transform.Rotate(0, Input.GetAxis("Mouse X") * sensivityCamera, 0);
                }

                break;

            case RotationAxes.rotationY:
                {
                    _rotationX -= Input.GetAxis("Mouse Y") * sensivityCamera;
                    _rotationX = Mathf.Clamp(_rotationX, minRotX, maxRotX);
                    float rotationY = transform.localEulerAngles.y;
                    transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
                }

                break;

            case RotationAxes.rotationXY:
                {
                    _rotationX -= Input.GetAxis("Mouse Y") * sensivityCamera;
                    _rotationX = Mathf.Clamp(_rotationX, minRotX, maxRotX);

                    float delta = Input.GetAxis("Mouse X") * sensivityCamera;
                    float rotationY = transform.localEulerAngles.y + delta;

                    transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
                }

                break;
        }
    }
}