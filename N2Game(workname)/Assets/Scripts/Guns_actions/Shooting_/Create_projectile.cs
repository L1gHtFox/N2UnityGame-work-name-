using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Create_projectile : MonoBehaviour
{
    //индикаторы методов
    private GameObject Indic_0;
    private GameObject Indic_1;

    //значения методов стрельбы
    private int _value_Shoot; //значение текущего выбранного метода стрельбы
    public int current_MOS = 0; //текущий выбранный метод
    public int total_MOS = 1; //максимальное кол - во методов    


    private void Start()
    {       
        //поиск индикаторов
        Indic_0 = GameObject.Find("Indicator_0");
        Indic_1 = GameObject.Find("Indicator_1");       
    }


    private void Update()
    {
        choose_MOS();
    }

    //выбор метода стрельбы
    private void choose_MOS()
    {
        switch (value_MOS())
        {
            case 0:
                Indic_1.SetActive(false);
                Indic_0.SetActive(true);

                break;

            case 1:
                Indic_0.SetActive(false);
                Indic_1.SetActive(true);
                break;
        }
    }

    //проверка истины стрельбы
    private void true_of_Shoot()
    {
        /* ЮНИТИ НЕ ХОЧЕТ КОМПИЛИТЬ ГЕЙМ С ЭТИМИ СТРОКАМИ
        while (fullAmmo > 0)        
            switch (_value_Shoot)
            {
                case 0:
                    if (currentAmmo > 0 && Input.GetButtonDown("Fire1"))
                    {
                        _prefabProjectile = Resources.Load("Prefubs/Gun_two/projectile_M0") as GameObject;
                        Shoot();
                    }
                    else if (Input.GetButtonDown("Reloading")) Reloading();
                    break;

                case 1:
                    if (currentAmmo > 0 && Input.GetButton("Fire1"))
                    {
                        _prefabProjectile = Resources.Load("Prefubs/Gun_two/projectile_M1") as GameObject;
                        Shoot();
                    }
                    else if (Input.GetButtonDown("Reloading")) Reloading();
                    break;

                default:

                    Reloading();
                    break;
            }
        */     
    }

    //определение значения текущего метода стрельбы
    private int value_MOS()
    {
        if (Input.GetButtonDown("Change")) current_MOS += 1;
        if (current_MOS > total_MOS) current_MOS = 0;

        return current_MOS;
    }
}