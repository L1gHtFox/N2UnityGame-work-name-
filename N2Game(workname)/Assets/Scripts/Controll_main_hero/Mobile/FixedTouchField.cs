using UnityEngine;
using UnityEngine.EventSystems;

public class FixedTouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    public Vector2 TouchDist;

    [HideInInspector]
    public Vector2 PointerOld;

    [HideInInspector]
    protected int PointerId;

    [HideInInspector]
    public bool Pressed;

    //координаты свайпов
    public float vectorX;
    public float vectorY;


    private void Start()
    {

    }


    private void Update()
    {
        coordinateX();
        coordinateY();

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
    }

    public float coordinateX()
    {
        vectorX = TouchDist.x;
        return vectorX;
    }

    public float coordinateY()
    {
        vectorY = TouchDist.y;
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
