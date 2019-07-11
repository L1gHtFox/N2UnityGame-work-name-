using UnityEngine;


public class Change_gun : MonoBehaviour
{
    //объекты "Gun_..." и их патроны
    public GameObject Gun_null;
    public GameObject Gun_one;
    public GameObject Gun_two;


    //значения оружий
    public int scrollInt = 0; //текущее оружие
    public int maxGuns = 2; //всего оружий экипировано

    private void Start()
    {
        //Gun_null = GameObject.Find("Gun_null");
        //Gun_one = GameObject.Find("Gun_one");
        //Gun_two = GameObject.Find("ProjGun");
    }

    private void Update()
    {
        Change();
    }


    //метод, проверяющий отжатие кнопки (для телефона)
    public void ChangeGun_OnButton()
    {
        scrollInt++;
        if (scrollInt > maxGuns) scrollInt = 1;
    }

    //смена оружия
    public void Change()
    {
        switch (Value_gun())
        {
            case 0:
                Gun_null.SetActive(true);
                Gun_one.SetActive(false);
                Gun_two.SetActive(false);

                break;

            case 1:
                Gun_null.SetActive(false);
                Gun_one.SetActive(true);
                Gun_two.SetActive(false);

                break;

            case 2:
                Gun_null.SetActive(false);
                Gun_one.SetActive(false);
                Gun_two.SetActive(true);

                break;
        }
    }

    //значение текущего оружия
    public int Value_gun()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0) scrollInt++;
        if (Input.GetAxis("Mouse ScrollWheel") < 0) scrollInt--;

        if (scrollInt > maxGuns) scrollInt = 0;
        if (scrollInt < 0) scrollInt = 2;

        if (Input.GetKeyDown("f")) scrollInt = 0;
        if (Input.GetKeyDown("1")) scrollInt = 1;
        if (Input.GetKeyDown("2")) scrollInt = 2;

        return scrollInt;
    }
}