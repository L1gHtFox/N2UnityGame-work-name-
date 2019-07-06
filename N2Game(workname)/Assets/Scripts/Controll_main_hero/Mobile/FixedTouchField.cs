using UnityEngine;
using UnityEngine.EventSystems;

public class FixedTouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Mobile_cameraRotation mob;


    [HideInInspector] public Vector2 TouchDist;
    [HideInInspector] public Vector2 PointerOld;
    [HideInInspector] protected int PointerId;
    [HideInInspector] public bool Pressed;

    //координаты свайпов
    public float vectorX;
    public float vectorY;

    //выход за рамки
    public float extra;

    private void Start()
    {
        mob = GameObject.Find("Head_PC").GetComponent<Mobile_cameraRotation>();
    }


    private void Update()
    {        
        CheckCoorinate();
    }

    private void CheckCoorinate()
    {
        if (Pressed)
        {
            if (PointerId >= 0 && PointerId < Input.touches.Length)
            {
                TouchDist = Input.touches[PointerId].position - PointerOld;
                PointerOld = Input.touches[PointerId].position;
            }
            else
            {
                TouchDist = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - PointerOld;
                PointerOld = Input.mousePosition;
            }
        }
        else
        {
            TouchDist = new Vector2();
        }

        coordinateX();
        coordinateY();
    }

    public float coordinateX()
    {
        vectorX = TouchDist.x;
        if (mob.frameRotX == true)
        {
            if (mob._rotationX > mob.maxRotY)
            {
                extra = mob._rotationX - mob.maxRotY;
                if (extra > 0.000001f)
                    vectorX -= extra;
            }
            else if (mob._rotationX < mob.minRotY)
            {
                extra = mob._rotationX - mob.minRotY;
                if (extra < -0.000001f)
                    vectorX -= extra;
            }
        }        

        return vectorX;
    }

    public float coordinateY()
    {
        vectorY = TouchDist.y;
        if (mob.frameRotY == true)
        {
            if (mob._rotationY > mob.maxRotX)
            {
                extra = mob._rotationY - mob.maxRotX;
                if (extra > 0.000001f)
                    vectorY -= extra;
            }
            else if (mob._rotationY < mob.minRotX)
            {
                extra = mob._rotationY - mob.minRotX;
                if (extra < -0.000001f)
                    vectorY -= extra;
            }
        }        

        return vectorY;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        PointerId = eventData.pointerId;
        PointerOld = eventData.position;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }

}
