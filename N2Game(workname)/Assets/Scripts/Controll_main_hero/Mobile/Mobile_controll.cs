using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Mobile_controll : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image joystick_BG;
    [SerializeField] private Image use_joystick;

    private Vector2 input_vector;

    private void Start()
    {
        joystick_BG = GetComponent<Image>();
        use_joystick = transform.GetChild(0).GetComponent<Image>();
    }


    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        input_vector = Vector2.zero;
        use_joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystick_BG.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / joystick_BG.rectTransform.sizeDelta.x);
            pos.y = (pos.y / joystick_BG.rectTransform.sizeDelta.y);

            input_vector = new Vector2(pos.x * 2, pos.y * 2); //получения координат позиции
            input_vector = (input_vector.magnitude > 1.0) ? input_vector.normalized : input_vector;

            use_joystick.rectTransform.anchoredPosition = new Vector2(input_vector.x * (joystick_BG.rectTransform.sizeDelta.x / 2), input_vector.y * (joystick_BG.rectTransform.sizeDelta.y / 2));
        }
    }

    public float Horizontal()
    {
        if (input_vector.x != 0) return input_vector.x;
        else return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (input_vector.y != 0) return input_vector.y;
        else return Input.GetAxis("Vertical");
    }
}