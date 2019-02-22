using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Change_guns : MonoBehaviour
{
    //объекты "Gun_..." и их патроны
    public GameObject Gun_null;
    public GameObject Canvas0;

    public GameObject Gun_one;
    public GameObject Canvas1;

    public GameObject Gun_two;
    public GameObject Canvas2;

    //значения оружий
    public int scrollInt = 0; //текущее оружие
    public int maxGuns = 2; //всего оружий экипировано

    private void Start()
    {
        Gun_null = GameObject.Find("Gun_null");
        Gun_one = GameObject.Find("Gun_one");
        Gun_two = GameObject.Find("Gun_two");

        Canvas0 = GameObject.Find("Canvas_0");
        Canvas1 = GameObject.Find("Canvas_1");
        Canvas2 = GameObject.Find("Canvas_2");
    }

    private void Update()
    {
        Change_gun();
    }

    //смена оружия
    public void Change_gun()
    {       
        switch (Value_gun())
        {
            case 0:
                Gun_null.SetActive(true);
                Canvas0.SetActive(true);

                Gun_one.SetActive(false);
                Canvas1.SetActive(false);

                Gun_two.SetActive(false);
                Canvas2.SetActive(false);
                break;

            case 1:
                Gun_null.SetActive(false);
                Canvas0.SetActive(false);

                Gun_one.SetActive(true); 
                Canvas1.SetActive(true);

                Gun_two.SetActive(false);
                Canvas2.SetActive(false);
                break;

            case 2:
                Gun_null.SetActive(false);
                Canvas0.SetActive(false);

                Gun_one.SetActive(false);
                Canvas1.SetActive(false);

                Gun_two.SetActive(true);
                Canvas2.SetActive(true);
                break;              
        }
    }

    //значение текущего оружия
    public int Value_gun()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0) scrollInt += 1;
        if (Input.GetAxis("Mouse ScrollWheel") < 0) scrollInt -= 1;

        if (scrollInt > maxGuns) scrollInt = 0;
        if (scrollInt < 0) scrollInt = 2;

        if (Input.GetKeyDown("f")) scrollInt = 0;
        if (Input.GetKeyDown("1")) scrollInt = 1;
        if (Input.GetKeyDown("2")) scrollInt = 2;

        return scrollInt;
    }
}
