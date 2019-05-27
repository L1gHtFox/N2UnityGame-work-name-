using UnityEngine;


public class ProjectileGun_choiceMOS : MonoBehaviour
{
    //скрипты методов стрельбы
    private ProjectileGun_MOS_0 MOS_0;
    private ProjectileGun_MOS_1 MOS_1;

    //значения методов стрельбы
    private int _value_Shoot; //значение текущего выбранного метода стрельбы
    public int current_MOS = 0; //текущий выбранный метод
    public int total_MOS = 1; //максимальное кол - во методов    


    private void Start()
    {
        //поиск скриптов с методами стрельбы
        MOS_0 = GetComponent<ProjectileGun_MOS_0>();
        MOS_1 = GetComponent<ProjectileGun_MOS_1>();       
    }    

    private void Update()
    {
        choice_of_MOS(); //MOS - метод стрельбы
    }

    //определение значения текущего метода стрельбы
    public void Choice_of_MOS_OnButton()
    {
        current_MOS += 1;
        if (current_MOS > total_MOS) current_MOS = 0;
    }

    //выбор метода стрельбы
    private void choice_of_MOS()
    {
        switch (value_MOS())
        {
            case 0:
                MOS_0.enabled = true;
                MOS_1.enabled = false;

                break;

            case 1:
                MOS_0.enabled = false;
                MOS_1.enabled = true;

                break;
        }
    }

    //определение значения текущего метода стрельбы
    private int value_MOS()
    {
        if (Input.GetButtonDown("Change")) current_MOS += 1;
        if (current_MOS > total_MOS) current_MOS = 0;

        return current_MOS;
    }
}