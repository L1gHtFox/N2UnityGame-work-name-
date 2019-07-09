using System;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileGun : MonoBehaviour
{
    //ссылка на скрипт
    private EnergyBank Bank;

    //объекты
    private Animator anim;
    private GameObject MainCamera;

    //индекс оружия в инвентаре
    public int indexWeapon = 1;

    //переменные энергии
    public float oneShot;
    
    //переменные снаряда
    private GameObject projectile;
    private GameObject square;

    //текстовые объекты
    public Text mainBankText; //текст макс. кол - во патрон
    public Text currentEnergyText; //текст кол - во патрон в обойме

    //преобразование
    private bool Transform = true;


    private void Start()
    {
        //ссылки на игровые объекты
        MainCamera = GameObject.FindWithTag("MainCamera");        
        anim = GetComponent<Animator>();

        //находим префабы:
        square = Resources.Load("Prefubs/Gun_two/projectile_M0") as GameObject;

        //ссылки на скрипты
        Bank = GameObject.Find("EnergyBank").GetComponent<EnergyBank>();

        //ссылки на текст, показывающий энергию
        mainBankText = GameObject.Find("Main_bank").GetComponent<Text>();
        currentEnergyText = GameObject.Find("Use_energy").GetComponent<Text>();
    }

    private void Update()
    {
        ManagementProjGun();
    }

    private void ManagementProjGun()
    {
        if (Transform)
        {
            Bank.transform(oneShot, indexWeapon);
            Transform = false;
        }


        if (Bank.currentEnergy == 0 && Bank.energyFull != 0)
            reloading();
    }

    public void reloading()
    {
        if (!anim.GetBool("boolReloading") && !anim.GetBool("boolShooting")
            && gameObject.active && Bank.currentEnergy != Bank.energyMagazin)
        {            
            anim.SetBool("boolReloading", true);

            if (!anim.GetBool("boolReloading"))
                Bank.reloading(true);
        }
    }

    public void shooting()
    {
        if (!anim.GetBool("boolReloading") && !anim.GetBool("boolShooting")
            && gameObject.active)
        {
            if (Bank.currentEnergy != 0)
            {
                anim.SetBool("boolShooting", true);
                CreateProj();
                Bank.shooting(true);
            }
            else if (Bank.energyFull != 0)
                reloading();
        }
    }

    private void CreateProj()
    {
        //создаем префаб
        projectile = Instantiate(square);

        //размещаем префаб в точке:
        projectile.transform.position = MainCamera.transform.TransformPoint(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 1.3f);

        //направляем префаб
        projectile.transform.rotation = MainCamera.transform.rotation;        
    }

    private void AnimationControll()
    {
        if (anim.GetBool("boolReloading"))
        {
            anim.SetBool("boolReloading", false);
            Bank.reloading(true);
        }

        anim.SetBool("boolShooting", false);        
    }
}